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
    public partial class AdminCheck : Form
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        private Log log = null;

        public AdminCheck()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.txtPassword.PasswordChar = '●';

            log = new Log();
            log.Info();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            log.Info();

            this.Owner.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            log.Info();

            this.txtName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
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

            var name = this.txtName.Text;
            var pass = Convert.ToInt32(this.txtPassword.Text);
            var dbConn = new DBConnection();

            try
            {
                log.Info();

                //従業員登録チェック
                var emp = dbConn.SelectEmp(name, pass);

                //従業員の登録が確認できなかったら処理を抜ける
                if (emp.Count().Equals(0))
                {
                    log.Warn();

                    MessageBox.Show("この従業員は登録されていないか、パスワードが違います。");
                    return;
                }

                //権限チェック
                using (var db = new GoingToWorkAppContext())
                {
                    var adminCheck = db.Emp.Where(x => x.EmpName.Equals(name))
                                            .Where(x => x.EmpPassword.Equals(pass))
                                             .Where(x => x.Authority == true).ToList();

                    //アカウントが管理者の権限を持っていなかった場合、処理を抜ける
                    if (adminCheck.Count.Equals(0))
                    {
                        log.Warn();

                        MessageBox.Show("このアカウントは管理者の権限を持っていません。");
                        return;
                    }

                    MessageBox.Show("権限を確認しました。");

                    //権限確認後、管理画面へ
                    var management = new ManagementForm();
                    management.Show();
                    this.Close();
                }
            }
            catch (Exception)
            {
                log.Error();
                throw;
            }

        }
    }
}
