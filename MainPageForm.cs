using GoingToWorkApp.Logs;
using System;
using System.Windows.Forms;

namespace GoingToWorkApp
{
    public partial class MainPageForm : Form
    {
        /// <summary>
        /// ログ出力用変数
        /// </summary>
        private Log log = null;

        public MainPageForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.NowTime.Interval = 500;
            this.NowTime.Enabled = true;
            //this.btnAdmin.Enabled = false;
            
            log = new Log();
        }
    
        //現在時刻取得
        private void NowTime_Tick(object sender, EventArgs e)
        {
            log.Info();

            var time = DateTime.Now;
            this.lblNowTime.Text = string.Format("{0:00}:{1:00}:{2:00}"
                                                 , time.Hour
                                                  , time.Minute
                                                   , time.Second);
        }

        //アプリ終了ボタンイベント
        private void btnClose_Click(object sender, EventArgs e)
        {
            log.Info();

            var resulr = MessageBox.Show("アプリを終了します。\nよろしいですか？",
                                            "アプリ終了",
                                             MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (resulr.Equals(DialogResult.No))
                return;
            
            this.Close();
        }

        //出勤ボタンイベント
        private void btnGoingToWork_Click(object sender, EventArgs e)
        {
            log.Info();

            var goinToWork = new GoingToWorkForm();
            goinToWork.Owner = this;
            goinToWork.Show();
            this.Hide();
        }

        //退勤ボタンイベント
        private void btnLeavingWork_Click(object sender, EventArgs e)
        {
            log.Info();
            
            var leavingWork = new LeavingWorkForm();
            leavingWork.Owner = this;
            leavingWork.Show();
            this.Hide();
        }

        //休憩開始イベント
        private void btnStartBreak_Click(object sender, EventArgs e)
        {
            log.Info();

            var startBreak = new StartBreak();
            startBreak.Owner = this;
            startBreak.Show();
            this.Hide();
        }

        //休憩終了イベント
        private void btnEndBreak_Click(object sender, EventArgs e)
        {
            log.Info();

            var endBreak = new EndBreak();
            endBreak.Owner = this;
            endBreak.Show();
            this.Hide();
        }

        //管理者画面へ
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            log.Info();

            var adminCheck = new AdminCheck();
            adminCheck.Owner = this;
            adminCheck.Show();
            this.Hide();
        }
    }
    
}
