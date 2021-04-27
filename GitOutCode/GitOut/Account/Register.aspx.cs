using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using GitOut.Models;
using MySql.Data.MySqlClient;

namespace GitOut.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = UserNameBox.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                string Name = NameBox.Text;
                string UserName = UserNameBox.Text;
                string EmailAddress = Email.Text;
                string Password = ConfirmPassword.Text;


                string connStr = "server=csdatabase.eku.edu;user=stu_csc440;database=csc440_db;port=3306;password=Maroons18;";

                MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

                try

                {

                    Console.WriteLine("Connecting to MySQL...");

                    conn.Open();

                    string sql = "INSERT INTO gitoutuser (Name, userName, emailAdd, password) VALUES (@name, @uname, @eAddress, @pword)";

                    MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@uname", UserName);
                    cmd.Parameters.AddWithValue("@eAddress", EmailAddress);
                    cmd.Parameters.AddWithValue("@pword", Password);

                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)

                {
                    Console.WriteLine(ex.ToString());
                }

                conn.Close();

                Console.WriteLine("Done.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}