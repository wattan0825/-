using GoingToWorkApp.DbManagers;
using GoingToWorkApp.Logs;
using GoingToWorkApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoingToWorkApp
{
    public partial class EmpRegister : Form
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        private Log log = null;

        public EmpRegister()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            log = new Log();
        }

        /// <summary>
        /// クリアボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            log.Info();

            this.txtName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtBirth.Text = string.Empty;
            this.txtName.Focus();
        }

        /// <summary>
        /// 前画面へ戻る
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            log.Info();

            this.Owner.Show();
            this.Close();
        }

        /// <summary>
        ///登録処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            log.Info();

            var name = this.txtName.Text;
            var pass = Convert.ToInt32(this.txtPassword.Text);
            var birth = Convert.ToDateTime(this.txtBirth.Text);
            var authority = this.checkAdmin.Checked;
            var dbConn = new DBConnection();

            try
            {
                log.Info();
                //従業員登録処理
                var addEmpResult = dbConn.AddEmp(name, pass, birth, authority);

                string message = addEmpResult ? "登録しました。" : "この従業員は既に登録済みです。";

                MessageBox.Show(message,
                                 "確認画面",
                                  MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                this.txtName.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
                this.txtBirth.Text = string.Empty;
                this.checkAdmin.Checked = false;
            }
            catch (Exception)
            {
                log.Error();
                throw;
            }
        }

       
    }
}
