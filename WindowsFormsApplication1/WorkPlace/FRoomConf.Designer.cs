namespace WorkPlace
{
    partial class FRoomConf
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
            this.tBLength = new System.Windows.Forms.TextBox();
            this.tBWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tBHeigth = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tBLength
            // 
            this.tBLength.Location = new System.Drawing.Point(39, 42);
            this.tBLength.Name = "tBLength";
            this.tBLength.Size = new System.Drawing.Size(100, 20);
            this.tBLength.TabIndex = 0;
            // 
            // tBWidth
            // 
            this.tBWidth.Location = new System.Drawing.Point(39, 78);
            this.tBWidth.Name = "tBWidth";
            this.tBWidth.Size = new System.Drawing.Size(100, 20);
            this.tBWidth.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Длина в метрах";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ширина в метрах";
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(215, 175);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(91, 22);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancle
            // 
            this.butCancle.Location = new System.Drawing.Point(118, 175);
            this.butCancle.Name = "butCancle";
            this.butCancle.Size = new System.Drawing.Size(91, 22);
            this.butCancle.TabIndex = 5;
            this.butCancle.Text = "Cancle";
            this.butCancle.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Высота в метрах";
            // 
            // tBHeigth
            // 
            this.tBHeigth.Location = new System.Drawing.Point(39, 114);
            this.tBHeigth.Name = "tBHeigth";
            this.tBHeigth.Size = new System.Drawing.Size(100, 20);
            this.tBHeigth.TabIndex = 6;
            // 
            // FRoomConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBHeigth);
            this.Controls.Add(this.butCancle);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBWidth);
            this.Controls.Add(this.tBLength);
            this.Name = "FRoomConf";
            this.Text = "Настройка параметров комнаты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBLength;
        private System.Windows.Forms.TextBox tBWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBHeigth;
    }
}