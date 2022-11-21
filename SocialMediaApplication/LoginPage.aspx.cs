using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace SocialMediaApplication
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Session.Clear();
            Session.RemoveAll();
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(mainconn);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select email,password from [dbo].[Users] where email =@email and password=@password", sqlConnection);

            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["loginUser"] = txtEmail.Text;//stores email id
                Response.Redirect("LandingPage2.aspx");
            }
            else
            {
                Label1.Text = "Email or Password is incorrect !";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
           
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void Unnamed6_Click(object sender, EventArgs e)
        {
            string clientid = "308410945363-taa0snfelolsvc5l16mf4bgak8t8m6v5.apps.googleusercontent.com";
            //your client secret  
            string clientsecret = "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";
            //your redirection url  
            string redirection_url = "https://localhost:44323/LandingPage2.aspx";
            string url = "https://accounts.google.com/o/oauth2/v2/auth?scope=profile&include_granted_scopes=true&redirect_uri=" + redirection_url + "&response_type=code&client_id=" + clientid + "";
            Response.Redirect(url);
        }
    }
}