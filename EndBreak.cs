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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoingToWorkApp
{
    public partial class EndBreak : Form
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        private Log log = null;

        public EndBreak()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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

        //休憩終了ボタンイベント
        private void btnEndBreak_Click(object sender, EventArgs e)
        {
            log.Info();

            //入力チェック
            if (this.txtName.Text.Equals(string.Empty))
            {
                log.Warn();

                MessageBox.Show("名前が空欄です。");
                return;
            }

            if (this.txtPassword.Text.Equals(string.Empty))
            {
                log.Warn();

                MessageBox.Show("パスワードが空欄です。");
                return;
            }

            if (!int.TryParse(this.txtPassword.Text, out int pass))
            {
                log.Warn();

                MessageBox.Show("パスワードは半角数字のみ入力できます。");
                return;
            }

            var name = this.txtName.Text;
                pass = Convert.ToInt32(this.txtPassword.Text);

            var dbConn = new DBConnection();

            try
            {
                log.Info();

                //従業員の登録確認
                var emp = dbConn.SelectEmp(name, pass);

                if (emp.Count().Equals(0))
                {
                    log.Warn();

                    MessageBox.Show("この従業員は登録されていないか、パスワードが違います。");
                    return;
                }

                //従業員が出勤中か確認
                var workNowEmp = dbConn.IsNowGoingToWork(name, pass);

                if (!workNowEmp)
                {
                    log.Warn();

                    MessageBox.Show("この従業員は出勤していません。");

                    this.txtName.Text = string.Empty;
                    this.txtPassword.Text = string.Empty;

                    return;
                }

                //休憩終了時間の記録
                dbConn.BreakEndInsert(name, pass);

                MessageBox.Show("休憩を終了しました。");

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
