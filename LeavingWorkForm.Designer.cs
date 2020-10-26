namespace GoingToWorkApp
{
    partial class LeavingWorkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLeavingWork = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.BlueViolet;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(165, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "退勤画面";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(34, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 43);
            this.label2.TabIndex = 2;
            this.label2.Text = "名前：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLeavingWork
            // 
            this.btnLeavingWork.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLeavingWork.Location = new System.Drawing.Point(411, 169);
            this.btnLeavingWork.Name = "btnLeavingWork";
            this.btnLeavingWork.Size = new System.Drawing.Size(104, 51);
            this.btnLeavingWork.TabIndex = 3;
            this.btnLeavingWork.Text = "退勤";
            this.btnLeavingWork.UseVisualStyleBackColor = true;
            this.btnLeavingWork.Click += new System.EventHandler(this.btnLeavingWork_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(12, 245);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 38);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(4, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 43);
            this.label3.TabIndex = 5;
            this.label3.Text = "パスワード：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.Location = new System.Drawing.Point(152, 133);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 34);
            this.txtName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPassword.Location = new System.Drawing.Point(152, 176);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(240, 34);
            this.txtPassword.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClear.Location = new System.Drawing.Point(411, 114);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 49);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // LeavingWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 298);
            this.ControlBox = false;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnLeavingWork);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LeavingWorkForm";
            this.Text = "LeavingWorkForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLeavingWork;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnClear;
    }
}