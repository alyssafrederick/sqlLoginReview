using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sql_login_review
{
    public partial class welcomeForm : Form
    {
        DataTable derp;

        public welcomeForm(DataTable users)
        {
            derp = users;
            InitializeComponent();
        }

        public welcomeForm()
        {
            InitializeComponent();
        }

        private void welcomeForm_Load(object sender, EventArgs e)
        {
            nameLabel.Text = string.Format("{0}", derp.Rows[0]["firstname"]);
        }
    }
}
