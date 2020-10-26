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
    public partial class StartBreak : Form
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        private Log log = null;

        public StartBreak()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.txtPassword.PasswordChar = '●';

            log = new Log();
        }

        //戻るボタン
        private void btnReturn_Click(object sender, EventArgs e)
        {
            log.Info();

            this.Owner.Show();
            this.Close();
        }

        //クリアボタン
        private void btnClear_Click(object sender, EventArgs e)
        {
            log.Info();

            this.txtName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }


        //休憩開始ボタン
        private void btnStartBreak_Click(object sender, EventArgs e)
        {
            log.Info();

            if (String.IsNullOrEmpty(this.txtName.Text))
            {
                log.Warn();

                MessageBox.Show("名前を入力して下さい");
                this.txtName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(this.txtPassword.Text))
            {
                log.Warn();

                MessageBox.Show("パスワードを入力して下さい");
                this.txtPassword.Focus();
                return;
            }

            if (!int.TryParse(this.txtPassword.Text, out int intTypePass))
            {
                log.Warn();

                MessageBox.Show("パスワードは半角数字のみ入力できます。");
                this.txtPassword.Text = string.Empty;
                return;
            }

            var name = this.txtName.Text;
            var pass = Convert.ToInt32(this.txtPassword.Text);

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

                //従業員の出勤確認
                var workNowEmp = dbConn.IsNowGoingToWork(name, pass);

                if (!workNowEmp)
                {
                    log.Warn();

                    MessageBox.Show("この従業員は出勤していません");

                    this.txtName.Text = string.Empty;
                    this.txtPassword.Text = string.Empty;

                    return;
                }

                //休憩開始時間を記録
                dbConn.BreakStartInsert(name, pass);

                MessageBox.Show("休憩開始しました。");

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
