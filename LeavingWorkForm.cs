using GoingToWorkApp.DbManagers;
using GoingToWorkApp.Logs;
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

namespace GoingToWorkApp
{
    public partial class LeavingWorkForm : Form
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        private Log log = null;

        public LeavingWorkForm()
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
        }

        //退勤ボタンイベント
        private void btnLeavingWork_Click(object sender, EventArgs e)
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

                //現在勤務中か検索
                var workNowEmp = dbConn.IsNowGoingToWork(name, pass);

                if (!workNowEmp)
                {
                    log.Warn();

                    MessageBox.Show("この従業員は現在出勤していません");

                    this.txtName.Text = string.Empty;
                    this.txtPassword.Text = string.Empty;

                    return;
                }

                //退勤処理
                dbConn.WorkEndInsert(name, pass);

                MessageBox.Show("退勤しました。\nお疲れ様でした。");

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
