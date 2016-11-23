namespace UploadProgramm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.doItButton = new System.Windows.Forms.Button();
            this.orderNumberTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // doItButton
            // 
            this.doItButton.BackColor = System.Drawing.SystemColors.Window;
            this.doItButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.doItButton.Location = new System.Drawing.Point(12, 38);
            this.doItButton.Name = "doItButton";
            this.doItButton.Size = new System.Drawing.Size(261, 44);
            this.doItButton.TabIndex = 0;
            this.doItButton.Text = "Получить инфу по заявке";
            this.doItButton.UseVisualStyleBackColor = false;
            this.doItButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // orderNumberTextBox
            // 
            this.orderNumberTextBox.Location = new System.Drawing.Point(12, 12);
            this.orderNumberTextBox.Name = "orderNumberTextBox";
            this.orderNumberTextBox.Size = new System.Drawing.Size(261, 20);
            this.orderNumberTextBox.TabIndex = 1;
            this.orderNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.orderNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.orderNumberTextBox_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(285, 95);
            this.Controls.Add(this.orderNumberTextBox);
            this.Controls.Add(this.doItButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выгрузка платежек";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doItButton;
        private System.Windows.Forms.TextBox orderNumberTextBox;
    }
}

