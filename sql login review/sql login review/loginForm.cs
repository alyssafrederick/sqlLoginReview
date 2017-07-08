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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("server=GMRDLT1; database=alyssaReview; user=sa; password=GreatMinds110");
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;

            #region C# looking for data
            /*
            //c# looking for data
            command.CommandText = "SELECT * FROM Account";

            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(result);
            bool valid = false;
            string firstname = "";
            foreach (DataRow row in result.Rows)
            {
                if (row["username"].ToString() == username.Text && row["password"].ToString() == password.Text)
                {
                    firstname = row["firstname"].ToString();
                    valid = true;
                }
            }

            if (valid)
            {
                MessageBox.Show(String.Format("Welcome {0}", firstname));
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            */
            #endregion 

            command.CommandText = String.Format("SELECT * FROM Account WHERE username = '{0}' AND password = '{1}'", username.Text, password.Text);

            DataTable result = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(result);

            if (result.Rows.Count > 0)
            {
                welcomeForm welcomeForm = new welcomeForm(result);
                welcomeForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            newUserForm newUserForm = new newUserForm();
            newUserForm.Show();
        }

    }
}
