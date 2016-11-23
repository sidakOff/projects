using System;
using System.Windows.Forms;
using TelelinkUpload;

namespace UploadProgramm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ActiveControl = orderNumberTextBox;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            OrderPresenter.DoIt(orderNumberTextBox.Text);
        }

        private void orderNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                OrderPresenter.DoIt(orderNumberTextBox.Text);
            }
        }
    }
}
