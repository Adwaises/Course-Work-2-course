namespace Project
{
    partial class Diagram
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
            this.PBDiagr = new System.Windows.Forms.PictureBox();
            this.RBReceipt = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.PBLegend = new System.Windows.Forms.PictureBox();
            this.RBCountOrders = new System.Windows.Forms.RadioButton();
            this.GBReport = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.PBDiagr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBLegend)).BeginInit();
            this.GBReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // PBDiagr
            // 
            this.PBDiagr.Location = new System.Drawing.Point(74, 12);
            this.PBDiagr.Name = "PBDiagr";
            this.PBDiagr.Size = new System.Drawing.Size(750, 500);
            this.PBDiagr.TabIndex = 0;
            this.PBDiagr.TabStop = false;
            // 
            // RBReceipt
            // 
            this.RBReceipt.AutoSize = true;
            this.RBReceipt.Location = new System.Drawing.Point(18, 19);
            this.RBReceipt.Name = "RBReceipt";
            this.RBReceipt.Size = new System.Drawing.Size(68, 17);
            this.RBReceipt.TabIndex = 1;
            this.RBReceipt.TabStop = true;
            this.RBReceipt.Text = "Выручка";
            this.RBReceipt.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Построить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PBLegend
            // 
            this.PBLegend.Location = new System.Drawing.Point(28, 175);
            this.PBLegend.Name = "PBLegend";
            this.PBLegend.Size = new System.Drawing.Size(40, 150);
            this.PBLegend.TabIndex = 3;
            this.PBLegend.TabStop = false;
            // 
            // RBCountOrders
            // 
            this.RBCountOrders.AutoSize = true;
            this.RBCountOrders.Location = new System.Drawing.Point(18, 42);
            this.RBCountOrders.Name = "RBCountOrders";
            this.RBCountOrders.Size = new System.Drawing.Size(129, 17);
            this.RBCountOrders.TabIndex = 4;
            this.RBCountOrders.TabStop = true;
            this.RBCountOrders.Text = "Количество заказов";
            this.RBCountOrders.UseVisualStyleBackColor = true;
            // 
            // GBReport
            // 
            this.GBReport.Controls.Add(this.RBReceipt);
            this.GBReport.Controls.Add(this.RBCountOrders);
            this.GBReport.Controls.Add(this.button1);
            this.GBReport.Location = new System.Drawing.Point(639, 342);
            this.GBReport.Name = "GBReport";
            this.GBReport.Size = new System.Drawing.Size(159, 121);
            this.GBReport.TabIndex = 5;
            this.GBReport.TabStop = false;
            this.GBReport.Text = "Отчет";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(639, 469);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(159, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // Diagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 534);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.GBReport);
            this.Controls.Add(this.PBLegend);
            this.Controls.Add(this.PBDiagr);
            this.Name = "Diagram";
            this.Text = "Diagram";
            this.Load += new System.EventHandler(this.Diagram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBDiagr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBLegend)).EndInit();
            this.GBReport.ResumeLayout(false);
            this.GBReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBDiagr;
        private System.Windows.Forms.RadioButton RBReceipt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox PBLegend;
        private System.Windows.Forms.RadioButton RBCountOrders;
        private System.Windows.Forms.GroupBox GBReport;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}