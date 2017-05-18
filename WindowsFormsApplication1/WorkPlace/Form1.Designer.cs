using SharpGL;

namespace WorkPlace
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
            this.components = new System.ComponentModel.Container();
            this.openGLControl = new SharpGL.OpenGLControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерыКомнатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прежнееПоложениеКамерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видСлеваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видСверхуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видСбокуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.режимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отправитьНаПочтуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графическиеОтчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оформитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.просмотрыременноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьОбоиплиткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анализПрибылиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.самаяПокупаемаяФурнитураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.структураТоваровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.логическиеВыводыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bOboiR = new System.Windows.Forms.Button();
            this.bOboiAdd = new System.Windows.Forms.Button();
            this.bOboiL = new System.Windows.Forms.Button();
            this.pbOboi = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bPlitkaR = new System.Windows.Forms.Button();
            this.bPlitkaAdd = new System.Windows.Forms.Button();
            this.bPlitkaL = new System.Windows.Forms.Button();
            this.pbPlitka = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bFurnitR = new System.Windows.Forms.Button();
            this.bFurnitL = new System.Windows.Forms.Button();
            this.pbFurnit = new System.Windows.Forms.PictureBox();
            this.bFurnitAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOboi)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlitka)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFurnit)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.AutoScroll = true;
            this.openGLControl.AutoSize = true;
            this.openGLControl.BackColor = System.Drawing.Color.CadetBlue;
            this.openGLControl.DrawFPS = true;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGLControl.Location = new System.Drawing.Point(12, 27);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(703, 604);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseClick);
            this.openGLControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDoubleClick);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1120, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить прямоугольник";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(890, 578);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Очистить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.видToolStripMenuItem,
            this.режимToolStripMenuItem,
            this.отчетToolStripMenuItem,
            this.заказToolStripMenuItem,
            this.бДToolStripMenuItem,
            this.информацияToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1263, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размерыКомнатыToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // размерыКомнатыToolStripMenuItem
            // 
            this.размерыКомнатыToolStripMenuItem.Name = "размерыКомнатыToolStripMenuItem";
            this.размерыКомнатыToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.размерыКомнатыToolStripMenuItem.Text = "Размеры помещения";
            this.размерыКомнатыToolStripMenuItem.Click += new System.EventHandler(this.размерыКомнатыToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прежнееПоложениеКамерыToolStripMenuItem,
            this.видСлеваToolStripMenuItem,
            this.видСверхуToolStripMenuItem,
            this.видСбокуToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // прежнееПоложениеКамерыToolStripMenuItem
            // 
            this.прежнееПоложениеКамерыToolStripMenuItem.Name = "прежнееПоложениеКамерыToolStripMenuItem";
            this.прежнееПоложениеКамерыToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.прежнееПоложениеКамерыToolStripMenuItem.Text = "Начальное положение";
            this.прежнееПоложениеКамерыToolStripMenuItem.Click += new System.EventHandler(this.НачальноеПоложениеToolStripMenuItem_Click);
            // 
            // видСлеваToolStripMenuItem
            // 
            this.видСлеваToolStripMenuItem.Name = "видСлеваToolStripMenuItem";
            this.видСлеваToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.видСлеваToolStripMenuItem.Text = "Вид спереди";
            this.видСлеваToolStripMenuItem.Click += new System.EventHandler(this.видСпередиToolStripMenuItem_Click);
            // 
            // видСверхуToolStripMenuItem
            // 
            this.видСверхуToolStripMenuItem.Name = "видСверхуToolStripMenuItem";
            this.видСверхуToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.видСверхуToolStripMenuItem.Text = "Вид сверху";
            this.видСверхуToolStripMenuItem.Click += new System.EventHandler(this.видСверхуToolStripMenuItem_Click);
            // 
            // видСбокуToolStripMenuItem
            // 
            this.видСбокуToolStripMenuItem.Name = "видСбокуToolStripMenuItem";
            this.видСбокуToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.видСбокуToolStripMenuItem.Text = "Вид сбоку";
            this.видСбокуToolStripMenuItem.Click += new System.EventHandler(this.видСбокуToolStripMenuItem_Click);
            // 
            // режимToolStripMenuItem
            // 
            this.режимToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрToolStripMenuItem,
            this.редактированиеToolStripMenuItem});
            this.режимToolStripMenuItem.Name = "режимToolStripMenuItem";
            this.режимToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.режимToolStripMenuItem.Text = "Режим";
            // 
            // просмотрToolStripMenuItem
            // 
            this.просмотрToolStripMenuItem.Name = "просмотрToolStripMenuItem";
            this.просмотрToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.просмотрToolStripMenuItem.Text = "Просмотр";
            this.просмотрToolStripMenuItem.Click += new System.EventHandler(this.просмотрToolStripMenuItem_Click);
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.редактированиеToolStripMenuItem.Text = "Редактирование";
            this.редактированиеToolStripMenuItem.Click += new System.EventHandler(this.редактированиеToolStripMenuItem_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDFToolStripMenuItem,
            this.графическиеОтчетыToolStripMenuItem});
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
            this.pDFToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.pDFToolStripMenuItem.Text = "Бланк заказа";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // отправитьНаПочтуToolStripMenuItem
            // 
            this.отправитьНаПочтуToolStripMenuItem.Name = "отправитьНаПочтуToolStripMenuItem";
            this.отправитьНаПочтуToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.отправитьНаПочтуToolStripMenuItem.Text = "Отправить на почту";
            this.отправитьНаПочтуToolStripMenuItem.Click += new System.EventHandler(this.отправитьНаПочтуToolStripMenuItem_Click);
            // 
            // графическиеОтчетыToolStripMenuItem
            // 
            this.графическиеОтчетыToolStripMenuItem.Name = "графическиеОтчетыToolStripMenuItem";
            this.графическиеОтчетыToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.графическиеОтчетыToolStripMenuItem.Text = "Графические отчеты";
            this.графическиеОтчетыToolStripMenuItem.Click += new System.EventHandler(this.графическиеОтчетыToolStripMenuItem_Click);
            // 
            // заказToolStripMenuItem
            // 
            this.заказToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.оформитьToolStripMenuItem});
            this.заказToolStripMenuItem.Name = "заказToolStripMenuItem";
            this.заказToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.заказToolStripMenuItem.Text = "Заказ";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // оформитьToolStripMenuItem
            // 
            this.оформитьToolStripMenuItem.Name = "оформитьToolStripMenuItem";
            this.оформитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.оформитьToolStripMenuItem.Text = "Оформить";
            this.оформитьToolStripMenuItem.Click += new System.EventHandler(this.оформитьToolStripMenuItem_Click);
            // 
            // бДToolStripMenuItem
            // 
            this.бДToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрыременноToolStripMenuItem,
            this.добавитьОбоиплиткуToolStripMenuItem});
            this.бДToolStripMenuItem.Name = "бДToolStripMenuItem";
            this.бДToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.бДToolStripMenuItem.Text = "Шаблоны";
            // 
            // просмотрыременноToolStripMenuItem
            // 
            this.просмотрыременноToolStripMenuItem.Name = "просмотрыременноToolStripMenuItem";
            this.просмотрыременноToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.просмотрыременноToolStripMenuItem.Text = "Добавить фурнитуру";
            this.просмотрыременноToolStripMenuItem.Click += new System.EventHandler(this.просмотрыременноToolStripMenuItem_Click);
            // 
            // добавитьОбоиплиткуToolStripMenuItem
            // 
            this.добавитьОбоиплиткуToolStripMenuItem.Name = "добавитьОбоиплиткуToolStripMenuItem";
            this.добавитьОбоиплиткуToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.добавитьОбоиплиткуToolStripMenuItem.Text = "Добавить обои/плитку";
            this.добавитьОбоиплиткуToolStripMenuItem.Click += new System.EventHandler(this.добавитьОбоиплиткуToolStripMenuItem_Click);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.анализПрибылиToolStripMenuItem,
            this.самаяПокупаемаяФурнитураToolStripMenuItem,
            this.структураТоваровToolStripMenuItem,
            this.логическиеВыводыToolStripMenuItem});
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.информацияToolStripMenuItem.Text = "Информация";
            // 
            // анализПрибылиToolStripMenuItem
            // 
            this.анализПрибылиToolStripMenuItem.Name = "анализПрибылиToolStripMenuItem";
            this.анализПрибылиToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.анализПрибылиToolStripMenuItem.Text = "Анализ прибыли";
            this.анализПрибылиToolStripMenuItem.Click += new System.EventHandler(this.анализПрибылиToolStripMenuItem_Click);
            // 
            // самаяПокупаемаяФурнитураToolStripMenuItem
            // 
            this.самаяПокупаемаяФурнитураToolStripMenuItem.Name = "самаяПокупаемаяФурнитураToolStripMenuItem";
            this.самаяПокупаемаяФурнитураToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.самаяПокупаемаяФурнитураToolStripMenuItem.Text = "Самая покупаемая фурнитура";
            this.самаяПокупаемаяФурнитураToolStripMenuItem.Click += new System.EventHandler(this.самаяПокупаемаяФурнитураToolStripMenuItem_Click);
            // 
            // структураТоваровToolStripMenuItem
            // 
            this.структураТоваровToolStripMenuItem.Name = "структураТоваровToolStripMenuItem";
            this.структураТоваровToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.структураТоваровToolStripMenuItem.Text = "Структура товаров";
            this.структураТоваровToolStripMenuItem.Click += new System.EventHandler(this.структураТоваровToolStripMenuItem_Click);
            // 
            // логическиеВыводыToolStripMenuItem
            // 
            this.логическиеВыводыToolStripMenuItem.Name = "логическиеВыводыToolStripMenuItem";
            this.логическиеВыводыToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.логическиеВыводыToolStripMenuItem.Text = "Логические выводы";
            this.логическиеВыводыToolStripMenuItem.Click += new System.EventHandler(this.логическиеВыводыToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(25, 20);
            this.toolStripMenuItem1.Text = "1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "1";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(1094, 299);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bOboiR);
            this.groupBox1.Controls.Add(this.bOboiAdd);
            this.groupBox1.Controls.Add(this.bOboiL);
            this.groupBox1.Controls.Add(this.pbOboi);
            this.groupBox1.Location = new System.Drawing.Point(730, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 169);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обои";
            // 
            // bOboiR
            // 
            this.bOboiR.Location = new System.Drawing.Point(158, 121);
            this.bOboiR.Name = "bOboiR";
            this.bOboiR.Size = new System.Drawing.Size(40, 23);
            this.bOboiR.TabIndex = 10;
            this.bOboiR.Text = ">";
            this.bOboiR.UseVisualStyleBackColor = true;
            this.bOboiR.Click += new System.EventHandler(this.bOboiR_Click);
            // 
            // bOboiAdd
            // 
            this.bOboiAdd.Location = new System.Drawing.Point(77, 121);
            this.bOboiAdd.Name = "bOboiAdd";
            this.bOboiAdd.Size = new System.Drawing.Size(75, 23);
            this.bOboiAdd.TabIndex = 1;
            this.bOboiAdd.Text = "Выбрать";
            this.bOboiAdd.UseVisualStyleBackColor = true;
            this.bOboiAdd.Click += new System.EventHandler(this.bOboiAdd_Click);
            // 
            // bOboiL
            // 
            this.bOboiL.Location = new System.Drawing.Point(31, 121);
            this.bOboiL.Name = "bOboiL";
            this.bOboiL.Size = new System.Drawing.Size(40, 23);
            this.bOboiL.TabIndex = 9;
            this.bOboiL.Text = "<";
            this.bOboiL.UseVisualStyleBackColor = true;
            this.bOboiL.Click += new System.EventHandler(this.bOboiL_Click);
            // 
            // pbOboi
            // 
            this.pbOboi.Location = new System.Drawing.Point(65, 19);
            this.pbOboi.Name = "pbOboi";
            this.pbOboi.Size = new System.Drawing.Size(96, 96);
            this.pbOboi.TabIndex = 8;
            this.pbOboi.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bPlitkaR);
            this.groupBox2.Controls.Add(this.bPlitkaAdd);
            this.groupBox2.Controls.Add(this.bPlitkaL);
            this.groupBox2.Controls.Add(this.pbPlitka);
            this.groupBox2.Location = new System.Drawing.Point(730, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 160);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Плитка";
            // 
            // bPlitkaR
            // 
            this.bPlitkaR.Location = new System.Drawing.Point(160, 121);
            this.bPlitkaR.Name = "bPlitkaR";
            this.bPlitkaR.Size = new System.Drawing.Size(40, 23);
            this.bPlitkaR.TabIndex = 7;
            this.bPlitkaR.Text = ">";
            this.bPlitkaR.UseVisualStyleBackColor = true;
            this.bPlitkaR.Click += new System.EventHandler(this.bPlitkaR_Click);
            // 
            // bPlitkaAdd
            // 
            this.bPlitkaAdd.Location = new System.Drawing.Point(77, 121);
            this.bPlitkaAdd.Name = "bPlitkaAdd";
            this.bPlitkaAdd.Size = new System.Drawing.Size(75, 23);
            this.bPlitkaAdd.TabIndex = 1;
            this.bPlitkaAdd.Text = "Выбрать";
            this.bPlitkaAdd.UseVisualStyleBackColor = true;
            // 
            // bPlitkaL
            // 
            this.bPlitkaL.Location = new System.Drawing.Point(31, 121);
            this.bPlitkaL.Name = "bPlitkaL";
            this.bPlitkaL.Size = new System.Drawing.Size(40, 23);
            this.bPlitkaL.TabIndex = 6;
            this.bPlitkaL.Text = "<";
            this.bPlitkaL.UseVisualStyleBackColor = true;
            this.bPlitkaL.Click += new System.EventHandler(this.bPlitkaL_Click);
            // 
            // pbPlitka
            // 
            this.pbPlitka.Location = new System.Drawing.Point(65, 19);
            this.pbPlitka.Name = "pbPlitka";
            this.pbPlitka.Size = new System.Drawing.Size(96, 96);
            this.pbPlitka.TabIndex = 5;
            this.pbPlitka.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bFurnitR);
            this.groupBox3.Controls.Add(this.bFurnitL);
            this.groupBox3.Controls.Add(this.pbFurnit);
            this.groupBox3.Controls.Add(this.bFurnitAdd);
            this.groupBox3.Location = new System.Drawing.Point(730, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 189);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фурнитура";
            // 
            // bFurnitR
            // 
            this.bFurnitR.Location = new System.Drawing.Point(160, 153);
            this.bFurnitR.Name = "bFurnitR";
            this.bFurnitR.Size = new System.Drawing.Size(40, 23);
            this.bFurnitR.TabIndex = 4;
            this.bFurnitR.Text = ">";
            this.bFurnitR.UseVisualStyleBackColor = true;
            this.bFurnitR.Click += new System.EventHandler(this.button7_Click);
            // 
            // bFurnitL
            // 
            this.bFurnitL.Location = new System.Drawing.Point(31, 153);
            this.bFurnitL.Name = "bFurnitL";
            this.bFurnitL.Size = new System.Drawing.Size(40, 23);
            this.bFurnitL.TabIndex = 3;
            this.bFurnitL.Text = "<";
            this.bFurnitL.UseVisualStyleBackColor = true;
            this.bFurnitL.Click += new System.EventHandler(this.button6_Click);
            // 
            // pbFurnit
            // 
            this.pbFurnit.Location = new System.Drawing.Point(46, 19);
            this.pbFurnit.Name = "pbFurnit";
            this.pbFurnit.Size = new System.Drawing.Size(128, 128);
            this.pbFurnit.TabIndex = 2;
            this.pbFurnit.TabStop = false;
            // 
            // bFurnitAdd
            // 
            this.bFurnitAdd.Location = new System.Drawing.Point(77, 153);
            this.bFurnitAdd.Name = "bFurnitAdd";
            this.bFurnitAdd.Size = new System.Drawing.Size(75, 23);
            this.bFurnitAdd.TabIndex = 1;
            this.bFurnitAdd.Text = "Добавить";
            this.bFurnitAdd.UseVisualStyleBackColor = true;
            this.bFurnitAdd.Click += new System.EventHandler(this.bFurnitAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(725, 605);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1263, 639);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Кухня";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOboi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlitka)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFurnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //    private SceneControl sceneControl;
        private OpenGLControl openGLControl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерыКомнатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прежнееПоложениеКамерыToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem режимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видСлеваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видСверхуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видСбокуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отправитьНаПочтуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графическиеОтчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оформитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрыременноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анализПрибылиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem самаяПокупаемаяФурнитураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem структураТоваровToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem логическиеВыводыToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bOboiAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bPlitkaAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bFurnitAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bFurnitR;
        private System.Windows.Forms.Button bFurnitL;
        private System.Windows.Forms.PictureBox pbFurnit;
        private System.Windows.Forms.Button bPlitkaR;
        private System.Windows.Forms.Button bPlitkaL;
        private System.Windows.Forms.PictureBox pbPlitka;
        private System.Windows.Forms.Button bOboiR;
        private System.Windows.Forms.Button bOboiL;
        private System.Windows.Forms.PictureBox pbOboi;
        private System.Windows.Forms.ToolStripMenuItem добавитьОбоиплиткуToolStripMenuItem;
    }
}

