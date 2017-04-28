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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pBControl = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.AutoScroll = true;
            this.openGLControl.AutoSize = true;
            this.openGLControl.BackColor = System.Drawing.Color.CadetBlue;
            this.openGLControl.DrawFPS = true;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGLControl.Location = new System.Drawing.Point(0, 27);
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
            this.button1.Location = new System.Drawing.Point(753, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить прямоугольник";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(800, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.видToolStripMenuItem,
            this.режимToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
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
            this.размерыКомнатыToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.размерыКомнатыToolStripMenuItem.Text = "Размеры комнаты";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pBControl
            // 
            this.pBControl.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pBControl.Location = new System.Drawing.Point(721, 435);
            this.pBControl.Name = "pBControl";
            this.pBControl.Size = new System.Drawing.Size(214, 196);
            this.pBControl.TabIndex = 3;
            this.pBControl.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(741, 250);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(947, 639);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pBControl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBControl)).EndInit();
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
        private System.Windows.Forms.PictureBox pBControl;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem режимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem просмотрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видСлеваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видСверхуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видСбокуToolStripMenuItem;
    }
}

