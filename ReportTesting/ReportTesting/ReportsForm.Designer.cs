namespace ReportTesting
{
    partial class ReportsForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            this.AccountDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётОбОстаткахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.accountReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.usdLabelVal = new System.Windows.Forms.Label();
            this.usdLabel = new System.Windows.Forms.Label();
            this.eurLabelVal = new System.Windows.Forms.Label();
            this.eurLabel = new System.Windows.Forms.Label();
            this.getCourseDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AccountDataSet = new ReportTesting.AccountDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.AccountDataTableBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.reportsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reportsTabControl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.loadDataButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 961);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.отчётыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчётОбОстаткахToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // отчётОбОстаткахToolStripMenuItem
            // 
            this.отчётОбОстаткахToolStripMenuItem.Name = "отчётОбОстаткахToolStripMenuItem";
            this.отчётОбОстаткахToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.отчётОбОстаткахToolStripMenuItem.Text = "Отчёт об остатках";
            // 
            // reportsTabControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.reportsTabControl, 2);
            this.reportsTabControl.Controls.Add(this.tabPage1);
            this.reportsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportsTabControl.Location = new System.Drawing.Point(3, 63);
            this.reportsTabControl.Name = "reportsTabControl";
            this.reportsTabControl.SelectedIndex = 0;
            this.reportsTabControl.Size = new System.Drawing.Size(978, 895);
            this.reportsTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.accountReportViewer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(970, 869);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Отчёт об остатках";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // accountReportViewer
            // 
            this.accountReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "AccountDT";
            reportDataSource1.Value = this.AccountDataTableBindingSource;
            this.accountReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.accountReportViewer.LocalReport.ReportEmbeddedResource = "ReportTesting.Report2.rdlc";
            this.accountReportViewer.Location = new System.Drawing.Point(3, 3);
            this.accountReportViewer.Name = "accountReportViewer";
            this.accountReportViewer.Size = new System.Drawing.Size(964, 863);
            this.accountReportViewer.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.beginDateTimePicker, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.endDateTimePicker, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(495, 33);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(477, 24);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начало периода";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Конец периода";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.Location = new System.Drawing.Point(122, 3);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.Size = new System.Drawing.Size(113, 20);
            this.beginDateTimePicker.TabIndex = 2;
            this.beginDateTimePicker.Value = new System.DateTime(2017, 2, 8, 0, 0, 0, 0);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(360, 3);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(114, 20);
            this.endDateTimePicker.TabIndex = 3;
            // 
            // loadDataButton
            // 
            this.loadDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadDataButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadDataButton.Location = new System.Drawing.Point(495, 3);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(486, 24);
            this.loadDataButton.TabIndex = 3;
            this.loadDataButton.Text = "Загрузить данные";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.usdLabelVal, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.usdLabel, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.eurLabelVal, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.eurLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.getCourseDateTimePicker, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(486, 24);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // usdLabelVal
            // 
            this.usdLabelVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usdLabelVal.AutoSize = true;
            this.usdLabelVal.Location = new System.Drawing.Point(403, 0);
            this.usdLabelVal.Name = "usdLabelVal";
            this.usdLabelVal.Size = new System.Drawing.Size(80, 24);
            this.usdLabelVal.TabIndex = 3;
            this.usdLabelVal.Text = "бакс";
            this.usdLabelVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usdLabel
            // 
            this.usdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usdLabel.AutoSize = true;
            this.usdLabel.Location = new System.Drawing.Point(323, 0);
            this.usdLabel.Name = "usdLabel";
            this.usdLabel.Size = new System.Drawing.Size(74, 24);
            this.usdLabel.TabIndex = 1;
            this.usdLabel.Text = "Доллар";
            this.usdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eurLabelVal
            // 
            this.eurLabelVal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eurLabelVal.AutoSize = true;
            this.eurLabelVal.Location = new System.Drawing.Point(243, 0);
            this.eurLabelVal.Name = "eurLabelVal";
            this.eurLabelVal.Size = new System.Drawing.Size(74, 24);
            this.eurLabelVal.TabIndex = 2;
            this.eurLabelVal.Text = "евро";
            this.eurLabelVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eurLabel
            // 
            this.eurLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eurLabel.AutoSize = true;
            this.eurLabel.Location = new System.Drawing.Point(163, 0);
            this.eurLabel.Name = "eurLabel";
            this.eurLabel.Size = new System.Drawing.Size(74, 24);
            this.eurLabel.TabIndex = 0;
            this.eurLabel.Text = "Евро";
            this.eurLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // getCourseDateTimePicker
            // 
            this.getCourseDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getCourseDateTimePicker.Location = new System.Drawing.Point(3, 3);
            this.getCourseDateTimePicker.Name = "getCourseDateTimePicker";
            this.getCourseDateTimePicker.Size = new System.Drawing.Size(154, 20);
            this.getCourseDateTimePicker.TabIndex = 4;
            // 
            // AccountDataSet
            // 
            this.AccountDataSet.DataSetName = "AccountDataSet";
            this.AccountDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчётность";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccountDataTableBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.reportsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl reportsTabControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётОбОстаткахToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker beginDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Button loadDataButton;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer accountReportViewer;
        private System.Windows.Forms.BindingSource AccountDataTableBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label eurLabel;
        private System.Windows.Forms.Label usdLabel;
        private System.Windows.Forms.Label eurLabelVal;
        private System.Windows.Forms.Label usdLabelVal;
        private System.Windows.Forms.DateTimePicker getCourseDateTimePicker;
        private AccountDataSet AccountDataSet;
    }
}

