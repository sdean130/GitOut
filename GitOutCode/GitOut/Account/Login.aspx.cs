using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using GitOut.Models;
using MySql.Data.MySqlClient;

namespace GitOut.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true


                // Database will reference these when they are called
                string emailAddress = Email.Text;
                string password = Password.Text;

                // Connection to database and whether or not it will successfully access it
                string connStr = "server=csdatabase.eku.edu;user=stu_csc440;database=csc440_db;port=3306;password=Maroons18;";
                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {

                    Console.WriteLine("Connecting to MySQL...");

                    conn.Open();

                    string sql = "SELECT userName FROM gitoutuser WHERE emailAdd=@eAddress and password=@pWord";

                    MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@eAddress", emailAddress);
                    cmd.Parameters.AddWithValue("@pWord", password);

                    MySqlDataReader myReader = cmd.ExecuteReader();

                    if (myReader.Read())
                    {
                        Email.Text = myReader["userName"].ToString();
                        Password.Text = myReader["password"].ToString();
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
                Console.WriteLine("Done.");

                // Puts the email and password in a varible so that it can check whether or not what was grabbed from the database is correct or not
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}