namespace ChangeRoot
{
    partial class ChangeRootForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.routeDataGridView = new System.Windows.Forms.DataGridView();
            this.RouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.routeDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.userComboBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 321);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // routeDataGridView
            // 
            this.routeDataGridView.AllowUserToAddRows = false;
            this.routeDataGridView.AllowUserToDeleteRows = false;
            this.routeDataGridView.AutoGenerateColumns = false;
            this.routeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RouteName});
            this.tableLayoutPanel1.SetColumnSpan(this.routeDataGridView, 4);
            this.routeDataGridView.DataSource = this.routeBindingSource;
            this.routeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeDataGridView.Location = new System.Drawing.Point(3, 27);
            this.routeDataGridView.Name = "routeDataGridView";
            this.routeDataGridView.ReadOnly = true;
            this.routeDataGridView.Size = new System.Drawing.Size(485, 270);
            this.routeDataGridView.TabIndex = 0;
            // 
            // RouteName
            // 
            this.RouteName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RouteName.DataPropertyName = "RouteName";
            this.RouteName.HeaderText = "Маршрут";
            this.RouteName.Name = "RouteName";
            this.RouteName.ReadOnly = true;
            // 
            // userComboBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.userComboBox, 3);
            this.userComboBox.DataSource = this.userBindingSource;
            this.userComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(125, 3);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(363, 21);
            this.userComboBox.TabIndex = 4;
            this.userComboBox.SelectedIndexChanged += new System.EventHandler(this.userComboBox_SelectedIndexChanged);
            // 
            // ChangeRootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 321);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChangeRootForm";
            this.Text = "Права пользователей";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView routeDataGridView;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource routeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteName;
    }
}

