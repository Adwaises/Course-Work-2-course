namespace WorkPlace
{
    partial class FormSave
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
            this.button1 = new System.Windows.Forms.Button();
            this.CBCustomer = new System.Windows.Forms.ComboBox();
            this.RBSelect = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBNew = new System.Windows.Forms.RadioButton();
            this.TBFamil = new System.Windows.Forms.TextBox();
            this.TBName = new System.Windows.Forms.TextBox();
            this.TBOtch = new System.Windows.Forms.TextBox();
            this.TBTel = new System.Windows.Forms.TextBox();
            this.TBmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Оформить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CBCustomer
            // 
            this.CBCustomer.FormattingEnabled = true;
            this.CBCustomer.Location = new System.Drawing.Point(128, 15);
            this.CBCustomer.Name = "CBCustomer";
            this.CBCustomer.Size = new System.Drawing.Size(221, 21);
            this.CBCustomer.TabIndex = 1;
            // 
            // RBSelect
            // 
            this.RBSelect.AutoSize = true;
            this.RBSelect.Checked = true;
            this.RBSelect.Location = new System.Drawing.Point(6, 19);
            this.RBSelect.Name = "RBSelect";
            this.RBSelect.Size = new System.Drawing.Size(69, 17);
            this.RBSelect.TabIndex = 2;
            this.RBSelect.TabStop = true;
            this.RBSelect.Text = "Выбрать";
            this.RBSelect.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBNew);
            this.groupBox1.Controls.Add(this.RBSelect);
            this.groupBox1.Controls.Add(this.CBCustomer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Закачик";
            // 
            // RBNew
            // 
            this.RBNew.AutoSize = true;
            this.RBNew.Location = new System.Drawing.Point(6, 42);
            this.RBNew.Name = "RBNew";
            this.RBNew.Size = new System.Drawing.Size(59, 17);
            this.RBNew.TabIndex = 3;
            this.RBNew.Text = "Новый";
            this.RBNew.UseVisualStyleBackColor = true;
            // 
            // TBFamil
            // 
            this.TBFamil.Location = new System.Drawing.Point(206, 101);
            this.TBFamil.Name = "TBFamil";
            this.TBFamil.Size = new System.Drawing.Size(100, 20);
            this.TBFamil.TabIndex = 4;
            // 
            // TBName
            // 
            this.TBName.Location = new System.Drawing.Point(206, 127);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(100, 20);
            this.TBName.TabIndex = 5;
            // 
            // TBOtch
            // 
            this.TBOtch.Location = new System.Drawing.Point(206, 153);
            this.TBOtch.Name = "TBOtch";
            this.TBOtch.Size = new System.Drawing.Size(100, 20);
            this.TBOtch.TabIndex = 6;
            // 
            // TBTel
            // 
            this.TBTel.Location = new System.Drawing.Point(206, 179);
            this.TBTel.Name = "TBTel";
            this.TBTel.Size = new System.Drawing.Size(100, 20);
            this.TBTel.TabIndex = 7;
            // 
            // TBmail
            // 
            this.TBmail.Location = new System.Drawing.Point(206, 205);
            this.TBmail.Name = "TBmail";
            this.TBmail.Size = new System.Drawing.Size(100, 20);
            this.TBmail.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Номер тел.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Эл. почта";
            // 
            // FormSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 336);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBmail);
            this.Controls.Add(this.TBTel);
            this.Controls.Add(this.TBOtch);
            this.Controls.Add(this.TBName);
            this.Controls.Add(this.TBFamil);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "FormSave";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSave_FormClosed);
            this.Load += new System.EventHandler(this.FormSave_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CBCustomer;
        private System.Windows.Forms.RadioButton RBSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBNew;
        private System.Windows.Forms.TextBox TBFamil;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.TextBox TBOtch;
        private System.Windows.Forms.TextBox TBTel;
        private System.Windows.Forms.TextBox TBmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}