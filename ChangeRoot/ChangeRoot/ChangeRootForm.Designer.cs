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
            this.routesGridView = new System.Windows.Forms.DataGridView();
            this.RouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rightsGridView = new System.Windows.Forms.DataGridView();
            this.rightsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.routesGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.userComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightsGridView, 2, 1);
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
            // routesGridView
            // 
            this.routesGridView.AllowUserToAddRows = false;
            this.routesGridView.AllowUserToDeleteRows = false;
            this.routesGridView.AutoGenerateColumns = false;
            this.routesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RouteName});
            this.tableLayoutPanel1.SetColumnSpan(this.routesGridView, 2);
            this.routesGridView.DataSource = this.routeBindingSource;
            this.routesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routesGridView.Location = new System.Drawing.Point(3, 27);
            this.routesGridView.Name = "routesGridView";
            this.routesGridView.ReadOnly = true;
            this.routesGridView.Size = new System.Drawing.Size(238, 270);
            this.routesGridView.TabIndex = 0;
            this.routesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.routesGridView_CellClick);
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
            // rightsGridView
            // 
            this.rightsGridView.AutoGenerateColumns = false;
            this.rightsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.rightsGridView, 2);
            this.rightsGridView.DataSource = this.rightsBindingSource;
            this.rightsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightsGridView.Location = new System.Drawing.Point(247, 27);
            this.rightsGridView.Name = "rightsGridView";
            this.rightsGridView.Size = new System.Drawing.Size(241, 270);
            this.rightsGridView.TabIndex = 5;
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
            ((System.ComponentModel.ISupportInitialize)(this.routesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView routesGridView;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource routeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteName;
        private System.Windows.Forms.DataGridView rightsGridView;
        private System.Windows.Forms.BindingSource rightsBindingSource;
    }
}

