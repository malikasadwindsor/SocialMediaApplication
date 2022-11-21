using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocialMediaApplication
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmiy_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(mainconn);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select email from [dbo].[Users] where email =@email", sqlConnection);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (txtPassword.Text != txtCnPassword.Text)
                {
                    Label1.Text = "Password is not same!";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    cmd = new SqlCommand("Update [dbo].[Users] Set password='" + txtPassword.Text + "' where email = '" + txtEmail.Text + "'", sqlConnection);
                    
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                   
                }
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                Label1.Text = "Email is wrong or not registered!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}
