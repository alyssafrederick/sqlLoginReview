using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sql_login_review
{
    public partial class newUserForm : Form
    {
        public newUserForm()
        {
            InitializeComponent();
        }

        private void allGoodButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("server=GMRDLT1; database=alyssaReview; user=sa; password=GreatMinds110");
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            command.CommandText = String.Format("INSERT Account VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", username.Text, password.Text, firstName.Text, lastName.Text, birthday.Text);

            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(result);

            Close();
        }
    }
}
