using GoingToWorkApp.Logs;
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
    public partial class ManagementForm : Form
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        private Log log = null;

        public ManagementForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            log = new Log();

            this.button1.Enabled = false;
            this.button2.Enabled = false;
        }

        
        private void btnEmpRegister_Click(object sender, EventArgs e)
        {
            var empRegister = new EmpRegister();
            empRegister.Owner = this;
            empRegister.Show();
            this.Hide();
        }

        //メインページへボタン
        private void btnReturn_Click(object sender, EventArgs e)
        {
            log.Info();

            var result = MessageBox.Show("メインページへ戻ります。\nよろしいですか？",
                                          "確認画面",
                                           MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Information);

            if (result.Equals(DialogResult.No))
                return;

            var mainPage = new MainPageForm();
            mainPage.Show();
            this.Close();
        }
    }
}
