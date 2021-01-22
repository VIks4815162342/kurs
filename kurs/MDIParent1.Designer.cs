namespace kurs
{
	partial class MDIParent1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.услугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мастераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отпускаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остаткиРасходныхМатериаловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оказанныеУслугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранениеВExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отправкаНаПочтуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.периодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.справочникиToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.действияToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.периодToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(724, 30);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(59, 24);
            this.fileMenu.Text = "&Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.exitToolStripMenuItem.Text = "В&ыход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.услугиToolStripMenuItem,
            this.мастераToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.расписаниеToolStripMenuItem,
            this.материалыToolStripMenuItem,
            this.отпускаToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "&Справочники";
            // 
            // услугиToolStripMenuItem
            // 
            this.услугиToolStripMenuItem.Checked = true;
            this.услугиToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
            this.услугиToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.услугиToolStripMenuItem.Text = "Услуги";
            this.услугиToolStripMenuItem.Click += new System.EventHandler(this.услугиToolStripMenuItem_Click);
            // 
            // мастераToolStripMenuItem
            // 
            this.мастераToolStripMenuItem.Name = "мастераToolStripMenuItem";
            this.мастераToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.мастераToolStripMenuItem.Text = "Сотрудники";
            this.мастераToolStripMenuItem.Click += new System.EventHandler(this.мастераToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // расписаниеToolStripMenuItem
            // 
            this.расписаниеToolStripMenuItem.Name = "расписаниеToolStripMenuItem";
            this.расписаниеToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.расписаниеToolStripMenuItem.Text = "Расписание";
            this.расписаниеToolStripMenuItem.Click += new System.EventHandler(this.расписаниеToolStripMenuItem_Click);
            // 
            // материалыToolStripMenuItem
            // 
            this.материалыToolStripMenuItem.Name = "материалыToolStripMenuItem";
            this.материалыToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.материалыToolStripMenuItem.Text = "Материалы";
            this.материалыToolStripMenuItem.Click += new System.EventHandler(this.материалыToolStripMenuItem_Click_1);
            // 
            // отпускаToolStripMenuItem
            // 
            this.отпускаToolStripMenuItem.Name = "отпускаToolStripMenuItem";
            this.отпускаToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.отпускаToolStripMenuItem.Text = "Отпуска";
            this.отпускаToolStripMenuItem.Click += new System.EventHandler(this.отпускаToolStripMenuItem_Click_1);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.остаткиРасходныхМатериаловToolStripMenuItem,
            this.оказанныеУслугиToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчётыToolStripMenuItem.Text = "&Отчёты";
            // 
            // остаткиРасходныхМатериаловToolStripMenuItem
            // 
            this.остаткиРасходныхМатериаловToolStripMenuItem.Name = "остаткиРасходныхМатериаловToolStripMenuItem";
            this.остаткиРасходныхМатериаловToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.остаткиРасходныхМатериаловToolStripMenuItem.Text = "Остатки расходных материалов";
            this.остаткиРасходныхМатериаловToolStripMenuItem.Click += new System.EventHandler(this.остаткиРасходныхМатериаловToolStripMenuItem_Click);
            // 
            // оказанныеУслугиToolStripMenuItem
            // 
            this.оказанныеУслугиToolStripMenuItem.Name = "оказанныеУслугиToolStripMenuItem";
            this.оказанныеУслугиToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.оказанныеУслугиToolStripMenuItem.Text = "Оказанные услуги";
            this.оказанныеУслугиToolStripMenuItem.Click += new System.EventHandler(this.оказанныеУслугиToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменениеToolStripMenuItem,
            this.сохранениеВExcelToolStripMenuItem,
            this.печатьToolStripMenuItem,
            this.отправкаНаПочтуToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.действияToolStripMenuItem.Text = "&Действия";
            // 
            // изменениеToolStripMenuItem
            // 
            this.изменениеToolStripMenuItem.Name = "изменениеToolStripMenuItem";
            this.изменениеToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.изменениеToolStripMenuItem.Text = "Изменение";
            this.изменениеToolStripMenuItem.Click += new System.EventHandler(this.изменениеToolStripMenuItem_Click);
            // 
            // сохранениеВExcelToolStripMenuItem
            // 
            this.сохранениеВExcelToolStripMenuItem.Name = "сохранениеВExcelToolStripMenuItem";
            this.сохранениеВExcelToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.сохранениеВExcelToolStripMenuItem.Text = "Сохранение в Excel";
            this.сохранениеВExcelToolStripMenuItem.Click += new System.EventHandler(this.сохранениеВExcelToolStripMenuItem_Click);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.печатьToolStripMenuItem.Text = "Печать";
            this.печатьToolStripMenuItem.Click += new System.EventHandler(this.печатьToolStripMenuItem_Click);
            // 
            // отправкаНаПочтуToolStripMenuItem
            // 
            this.отправкаНаПочтуToolStripMenuItem.Name = "отправкаНаПочтуToolStripMenuItem";
            this.отправкаНаПочтуToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.отправкаНаПочтуToolStripMenuItem.Text = "Отправка таблицы на почту";
            this.отправкаНаПочтуToolStripMenuItem.Click += new System.EventHandler(this.отправкаНаПочтуToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "&Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // периодToolStripMenuItem
            // 
            this.периодToolStripMenuItem.Name = "периодToolStripMenuItem";
            this.периодToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.периодToolStripMenuItem.Text = "&Период";
            this.периодToolStripMenuItem.Visible = false;
            this.периодToolStripMenuItem.Click += new System.EventHandler(this.периодToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.printToolStripButton,
            this.printPreviewToolStripButton,
            this.toolStripSeparator2,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 30);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(724, 27);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.newToolStripButton.Text = "Создать";
            this.newToolStripButton.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(29, 24);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(29, 24);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.printToolStripButton.Text = "Печать";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printPreviewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripButton.Image")));
            this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            this.printPreviewToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.printPreviewToolStripButton.Text = "Предварительный просмотр";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.helpToolStripButton.Text = "Справка";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 468);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 24, 0);
            this.statusStrip.Size = new System.Drawing.Size(724, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(83, 20);
            this.toolStripStatusLabel.Text = "Состояние";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Turquoise;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 57);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(724, 411);
            this.dataGridView1.TabIndex = 4;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Файлы Excel (*.xlsx; *.xls) | *.xlsx; *xls";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 494);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MDIParent1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Салон красоты";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIParent1_FormClosing);
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripButton printToolStripButton;
		private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStripMenuItem услугиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem мастераToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem расписаниеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem остаткиРасходныхМатериаловToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem оказанныеУслугиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem материалыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранениеВExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отправкаНаПочтуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem периодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отпускаToolStripMenuItem;
    }
}



