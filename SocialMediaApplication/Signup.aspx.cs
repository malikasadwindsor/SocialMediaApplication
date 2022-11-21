using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace SocialMediaApplication
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                if (profilePic.PostedFile != null)
                {
                    string strpath = Path.GetExtension(profilePic.PostedFile.FileName);
                    if (strpath != ".JPG" && strpath != ".JPEG" && strpath != ".PNG" && strpath != "GIF")
                    {
                        Label1.Text = "Only image with Gif, Jpeg, Jpg, and Png type is allowed!";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        Label1.Text = "Profile Image is saved";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }

                    string fileimg = Path.GetFileName(profilePic.PostedFile.FileName);
                    profilePic.SaveAs(Server.MapPath("~/UserImages/") + fileimg);
                        
                    string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(mainconn);
                    string sqlQuery = "insert into [dbo].[Users] (firstName,lastName,email,password,dateOfBirth,profileImage) values (@firstName,@lastName,@email,@password,@dateOfBirth,@profileImage)";
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    sqlCommand.Parameters.AddWithValue("@lastName", txtLastName.Text);
                    sqlCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                    sqlCommand.Parameters.AddWithValue("@password", txtPassword.Text);
                    sqlCommand.Parameters.AddWithValue("@dateOfBirth", txtDateOfBirth.Text);
                    sqlCommand.Parameters.AddWithValue("@profileImage","C:/Users/mali_/source/repos/SocialMediaApplication/SocialMediaApplication/UserImages/"+fileimg);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    Label1.Text = "Registration has been done!";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    Label1.Text = "Record Not Saved";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex) { }


        }
    }
}