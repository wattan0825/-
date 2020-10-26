namespace GoingToWorkApp
{
    partial class ManagementForm
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
            this.btnEmpRegister = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnEmpDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Turquoise;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(170, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "管理画面";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEmpRegister
            // 
            this.btnEmpRegister.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEmpRegister.Location = new System.Drawing.Point(87, 140);
            this.btnEmpRegister.Name = "btnEmpRegister";
            this.btnEmpRegister.Size = new System.Drawing.Size(232, 101);
            this.btnEmpRegister.TabIndex = 1;
            this.btnEmpRegister.Text = "新規従業員登録";
            this.btnEmpRegister.UseVisualStyleBackColor = true;
            this.btnEmpRegister.Click += new System.EventHandler(this.btnEmpRegister_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(27, 423);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(90, 47);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "メインページへ";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnEmpDelete
            // 
            this.btnEmpDelete.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEmpDelete.Location = new System.Drawing.Point(87, 265);
            this.btnEmpDelete.Name = "btnEmpDelete";
            this.btnEmpDelete.Size = new System.Drawing.Size(232, 104);
            this.btnEmpDelete.TabIndex = 3;
            this.btnEmpDelete.Text = "従業員情報削除";
            this.btnEmpDelete.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(390, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 104);
            this.button1.TabIndex = 4;
            this.button1.Text = "準備中";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(390, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 104);
            this.button2.TabIndex = 5;
            this.button2.Text = "準備中";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 494);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEmpDelete);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnEmpRegister);
            this.Controls.Add(this.label1);
            this.Name = "ManagementForm";
            this.Text = "ManagementForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmpRegister;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnEmpDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}