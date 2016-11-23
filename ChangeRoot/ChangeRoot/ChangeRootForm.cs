using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChangeRoot.Properties;

namespace ChangeRoot
{
    public partial class ChangeRootForm : Form
    {
        private int userId;
        private RootPresenter presenter;

        public ChangeRootForm()
        {
            InitializeComponent();
            presenter = new RootPresenter();
            var users = presenter.LoadData();
            userBindingSource.DataSource = users;
            userComboBox.DataSource = userBindingSource.DataSource;
            userComboBox.DisplayMember = "Name";
            userComboBox.ValueMember = "UserId";
        }

        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            User x = (User) userComboBox.SelectedItem;
            userId = x.UserId;
            routeBindingSource.DataSource = presenter.GetUserRoutes(userId);
        }
    }
}