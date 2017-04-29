namespace WorkPlace
{
    partial class FormLoad
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
            this.CBorder = new System.Windows.Forms.ComboBox();
            this.BLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CBorder
            // 
            this.CBorder.FormattingEnabled = true;
            this.CBorder.Location = new System.Drawing.Point(12, 35);
            this.CBorder.Name = "CBorder";
            this.CBorder.Size = new System.Drawing.Size(260, 21);
            this.CBorder.TabIndex = 0;
            // 
            // BLoad
            // 
            this.BLoad.Location = new System.Drawing.Point(100, 92);
            this.BLoad.Name = "BLoad";
            this.BLoad.Size = new System.Drawing.Size(75, 23);
            this.BLoad.TabIndex = 1;
            this.BLoad.Text = "Загрузить";
            this.BLoad.UseVisualStyleBackColor = true;
            this.BLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите заказ";
            // 
            // FormLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BLoad);
            this.Controls.Add(this.CBorder);
            this.Name = "FormLoad";
            this.Text = "FormLoad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBorder;
        private System.Windows.Forms.Button BLoad;
        private System.Windows.Forms.Label label1;
    }
}