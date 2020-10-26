using GoingToWorkApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoingToWorkApp.DbManagers;
using GoingToWorkApp.Logs;

namespace GoingToWorkApp
{
    public partial class GoingToWorkForm : Form
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        private Log log = null;

        public GoingToWorkForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.txtPassword.PasswordChar = '●';

            log = new Log();
        }

        //戻るボタンイベント
        private void btnReturn_Click(object sender, EventArgs e)
        {
            log.Info();

            this.Owner.Show();
            this.Close();
        }

        //クリアボタンイベント
        private void btnClear_Click(object sender, EventArgs e)
        {
            log.Info();

            this.txtName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtName.Focus();
        }

        //出勤ボタンイベント
        private void btnGoingToWork_Click(object sender, EventArgs e)
        {
            log.Info();

            #region 入力チェック

            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                log.Warn();

                MessageBox.Show("名前を入力して下さい",
                                 "入力確認",
                                  MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation);
                this.txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                log.Warn();

                MessageBox.Show("パスワードを入力して下さい",
                                 "入力確認",
                                  MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation);
                this.txtPassword.Focus();
                return;
            }

            if (!Regex.IsMatch(txtPassword.Text, @"^[0-9]+$"))
            {
                log.Warn();

                MessageBox.Show("パスワードは半角数字を入力して下さい",
                                "入力確認",
                                 MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);

                this.txtPassword.Text = string.Empty;
                this.txtPassword.Focus();
                return;
            }

            #endregion


            var name = this.txtName.Text;
            var pass = Convert.ToInt32(this.txtPassword.Text);
            var dbConn = new DBConnection();

            try
            {
                log.Info();

                //入力された従業員が検索可能か確認
                var selectEmp = dbConn.SelectEmp(name, pass);
                if (selectEmp.Count().Equals(0))
                {
                    log.Warn();

                    MessageBox.Show("この従業員は登録されていないか、パスワードが違います。"
                                     , "確認画面"
                                      , MessageBoxButtons.OK
                                       , MessageBoxIcon.Error);

                    return;
                }

                //入力された従業員が現在勤務中かをチェック
                var goingToWorkCheck = dbConn.IsNowGoingToWork(name, pass);

                if (goingToWorkCheck)
                {
                    log.Warn();

                    MessageBox.Show("この従業員は、現在出勤中です。");

                    this.txtName.Text = string.Empty;
                    this.txtPassword.Text = string.Empty;

                    return;
                }
                else
                {
                    //従業員チェック後、出勤処理
                    dbConn.WorkStartInsert(name, pass);
                    MessageBox.Show("出勤しました。");
                }

                this.txtName.Text = string.Empty;
                this.txtPassword.Text = string.Empty;

            }
            catch (Exception)
            {
                log.Error();
                throw;
            }

        }
    }
}
