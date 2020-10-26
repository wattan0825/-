namespace GoingToWorkApp
{
    partial class MainPageForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGoingToWork = new System.Windows.Forms.Button();
            this.btnLeavingWork = new System.Windows.Forms.Button();
            this.btnStartBreak = new System.Windows.Forms.Button();
            this.lblNowTime = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.NowTime = new System.Windows.Forms.Timer(this.components);
            this.btnEndBreak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(278, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "メインページ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGoingToWork
            // 
            this.btnGoingToWork.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnGoingToWork.Location = new System.Drawing.Point(36, 149);
            this.btnGoingToWork.Name = "btnGoingToWork";
            this.btnGoingToWork.Size = new System.Drawing.Size(174, 288);
            this.btnGoingToWork.TabIndex = 1;
            this.btnGoingToWork.Text = "出勤";
            this.btnGoingToWork.UseVisualStyleBackColor = true;
            this.btnGoingToWork.Click += new System.EventHandler(this.btnGoingToWork_Click);
            // 
            // btnLeavingWork
            // 
            this.btnLeavingWork.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLeavingWork.Location = new System.Drawing.Point(243, 149);
            this.btnLeavingWork.Name = "btnLeavingWork";
            this.btnLeavingWork.Size = new System.Drawing.Size(174, 288);
            this.btnLeavingWork.TabIndex = 2;
            this.btnLeavingWork.Text = "退勤";
            this.btnLeavingWork.UseVisualStyleBackColor = true;
            this.btnLeavingWork.Click += new System.EventHandler(this.btnLeavingWork_Click);
            // 
            // btnStartBreak
            // 
            this.btnStartBreak.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnStartBreak.Location = new System.Drawing.Point(451, 149);
            this.btnStartBreak.Name = "btnStartBreak";
            this.btnStartBreak.Size = new System.Drawing.Size(174, 288);
            this.btnStartBreak.TabIndex = 3;
            this.btnStartBreak.Text = "休憩開始";
            this.btnStartBreak.UseVisualStyleBackColor = true;
            this.btnStartBreak.Click += new System.EventHandler(this.btnStartBreak_Click);
            // 
            // lblNowTime
            // 
            this.lblNowTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNowTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNowTime.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNowTime.Location = new System.Drawing.Point(29, 21);
            this.lblNowTime.Name = "lblNowTime";
            this.lblNowTime.Size = new System.Drawing.Size(183, 57);
            this.lblNowTime.TabIndex = 7;
            this.lblNowTime.Text = "00:00:00";
            this.lblNowTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(611, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 54);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "アプリ終了";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(730, 493);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(118, 54);
            this.btnAdmin.TabIndex = 6;
            this.btnAdmin.Text = "管理者用ページ";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // NowTime
            // 
            this.NowTime.Tick += new System.EventHandler(this.NowTime_Tick);
            // 
            // btnEndBreak
            // 
            this.btnEndBreak.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEndBreak.Location = new System.Drawing.Point(655, 149);
            this.btnEndBreak.Name = "btnEndBreak";
            this.btnEndBreak.Size = new System.Drawing.Size(174, 288);
            this.btnEndBreak.TabIndex = 4;
            this.btnEndBreak.Text = "休憩終了";
            this.btnEndBreak.UseVisualStyleBackColor = true;
            this.btnEndBreak.Click += new System.EventHandler(this.btnEndBreak_Click);
            // 
            // MainPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 572);
            this.ControlBox = false;
            this.Controls.Add(this.btnEndBreak);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNowTime);
            this.Controls.Add(this.btnStartBreak);
            this.Controls.Add(this.btnLeavingWork);
            this.Controls.Add(this.btnGoingToWork);
            this.Controls.Add(this.label1);
            this.Name = "MainPageForm";
            this.Text = "MainPageForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGoingToWork;
        private System.Windows.Forms.Button btnLeavingWork;
        private System.Windows.Forms.Button btnStartBreak;
        private System.Windows.Forms.Label lblNowTime;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Timer NowTime;
        private System.Windows.Forms.Button btnEndBreak;
    }
}

