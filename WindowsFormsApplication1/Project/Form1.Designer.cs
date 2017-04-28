namespace Project
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отправитьНаПочтуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графическийОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оформитьСохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализПрибылиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продукцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.самаяПокупаемаяФурнитурасемСетиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетToolStripMenuItem,
            this.заказToolStripMenuItem,
            this.анализПрибылиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(748, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDFToolStripMenuItem,
            this.графическийОтчетToolStripMenuItem});
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетToolStripMenuItem.Text = "Отчеты";
            // 
            // pDFToolStripMenuItem
            // 
            this.pDFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.отправитьНаПочтуToolStripMenuItem});
            this.pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.pDFToolStripMenuItem.Text = "PDF";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click_1);
            // 
            // отправитьНаПочтуToolStripMenuItem
            // 
            this.отправитьНаПочтуToolStripMenuItem.Name = "отправитьНаПочтуToolStripMenuItem";
            this.отправитьНаПочтуToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.отправитьНаПочтуToolStripMenuItem.Text = "Отправить на почту";
            this.отправитьНаПочтуToolStripMenuItem.Click += new System.EventHandler(this.отправитьНаПочтуToolStripMenuItem_Click);
            // 
            // графическийОтчетToolStripMenuItem
            // 
            this.графическийОтчетToolStripMenuItem.Name = "графическийОтчетToolStripMenuItem";
            this.графическийОтчетToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.графическийОтчетToolStripMenuItem.Text = "Графический отчет";
            this.графическийОтчетToolStripMenuItem.Click += new System.EventHandler(this.графическийОтчетToolStripMenuItem_Click);
            // 
            // заказToolStripMenuItem
            // 
            this.заказToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.оформитьСохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.заказToolStripMenuItem.Name = "заказToolStripMenuItem";
            this.заказToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.заказToolStripMenuItem.Text = "Заказ";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // оформитьСохранитьToolStripMenuItem
            // 
            this.оформитьСохранитьToolStripMenuItem.Name = "оформитьСохранитьToolStripMenuItem";
            this.оформитьСохранитьToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.оформитьСохранитьToolStripMenuItem.Text = "Оформить (Сохранить)";
            this.оформитьСохранитьToolStripMenuItem.Click += new System.EventHandler(this.оформитьСохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // анализПрибылиToolStripMenuItem
            // 
            this.анализПрибылиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.продукцииToolStripMenuItem,
            this.самаяПокупаемаяФурнитурасемСетиToolStripMenuItem});
            this.анализПрибылиToolStripMenuItem.Name = "анализПрибылиToolStripMenuItem";
            this.анализПрибылиToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.анализПрибылиToolStripMenuItem.Text = "Знания";
            // 
            // продукцииToolStripMenuItem
            // 
            this.продукцииToolStripMenuItem.Name = "продукцииToolStripMenuItem";
            this.продукцииToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.продукцииToolStripMenuItem.Text = "Анализ прибыли (Продукции)";
            this.продукцииToolStripMenuItem.Click += new System.EventHandler(this.продукцииToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(642, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Вставка в бд";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // самаяПокупаемаяФурнитурасемСетиToolStripMenuItem
            // 
            this.самаяПокупаемаяФурнитурасемСетиToolStripMenuItem.Name = "самаяПокупаемаяФурнитурасемСетиToolStripMenuItem";
            this.самаяПокупаемаяФурнитурасемСетиToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            this.самаяПокупаемаяФурнитурасемСетиToolStripMenuItem.Text = "Самая покупаемая фурнитура (сем. сети)";
            this.самаяПокупаемаяФурнитурасемСетиToolStripMenuItem.Click += new System.EventHandler(this.самаяПокупаемаяФурнитурасемСетиToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Дизайн кухни";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графическийОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отправитьНаПочтуToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem заказToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оформитьСохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анализПрибылиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продукцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem самаяПокупаемаяФурнитурасемСетиToolStripMenuItem;
    }
}

