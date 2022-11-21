using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SocialMediaApplication
{
    public partial class LandingPage2 : System.Web.UI.Page
    {
        //your client id  
        string clientid = "308410945363-taa0snfelolsvc5l16mf4bgak8t8m6v5.apps.googleusercontent.com";
        //your client secret  
        string clientsecret = "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";
        //your redirection url  
        string redirection_url = "https://localhost:44323/LandingPage2.aspx";
        string url = "https://accounts.google.com/o/oauth2/token";

        public class Tokenclass
        {
            public string access_token
            {
                get;
                set;
            }
            public string token_type
            {
                get;
                set;
            }
            public int expires_in
            {
                get;
                set;
            }
            public string refresh_token
            {
                get;
                set;
            }
        }
        public class Userclass
        {
            public string id
            {
                get;
                set;
            }
            public string name
            {
                get;
                set;
            }
            public string given_name
            {
                get;
                set;
            }
            public string family_name
            {
                get;
                set;
            }
            public string link
            {
                get;
                set;
            }
            public string picture
            {
                get;
                set;
            }
            public string gender
            {
                get;
                set;
            }
            public string locale
            {
                get;
                set;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["code"] != null)
                {
                    GetToken(Request.QueryString["code"].ToString());
                }


            }


            if (Session["loginUser"]!= null)
            {
                string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(mainconn);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select firstName,lastName,email,dateOfBirth,profileImage from [dbo].[Users] where email ='"+Session["loginUser"] +"'", sqlConnection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    lblEmail.Text = sqlDataReader["email"].ToString();
                    lblFirstName.Text = sqlDataReader["firstName"].ToString();
                    lblLastName.Text = sqlDataReader["lastName"].ToString();
                    lblDob.Text = sqlDataReader["dateOfBirth"].ToString();
                    string imgname = sqlDataReader["profileImage"].ToString();
                    imgprofile.ImageUrl = imgname;
                    

                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }

        }

        public void GetToken(string code)
        {
            string poststring = "grant_type=authorization_code&code=" + code + "&client_id=" + clientid + "&client_secret=" + clientsecret + "&redirect_uri=" + redirection_url + "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            UTF8Encoding utfenc = new UTF8Encoding();
            byte[] bytes = utfenc.GetBytes(poststring);
            Stream outputstream = null;
            try
            {
                request.ContentLength = bytes.Length;
                outputstream = request.GetRequestStream();
                outputstream.Write(bytes, 0, bytes.Length);
            }
            catch { }
            var response = (HttpWebResponse)request.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            string responseFromServer = streamReader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Tokenclass obj = js.Deserialize<Tokenclass>(responseFromServer);
            GetuserProfile(obj.access_token);
        }
        public void GetuserProfile(string accesstoken)
        {
            string url = "https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token=" + accesstoken + "";
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Userclass userinfo = js.Deserialize<Userclass>(responseFromServer);
            imgprofile.ImageUrl = userinfo.picture;
            lblFirstName.Text = userinfo.name;
            lblLastName.Text = userinfo.family_name;
            lblEmail.Text = userinfo.link; 
                    
        }




        protected void updateProfile_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(mainconn);
            SqlCommand cmd = new SqlCommand("Update [dbo].[Users] Set email='" + txtEmail.Text + "', password='" + txtPassword.Text + "',firstName='" + txtFirstName.Text + "',lastName='" + txtLastName.Text + "',dateOfBirth='" + txtDOB.Text + "'  Where email= '" + Session["loginUser"] +"'",sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Profile Updated Successfully!");
            sqlConnection.Close();
        }
    }
}