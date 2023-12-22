using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace yazilimsinamaproject
{
    public partial class FreelancerRegister : Page
    {
        string connectionString = "Data Source=BEYZAYOLDAS;Initial Catalog=UserRegistrationDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Sayfa yüklendiğinde gerekli işlemleri yapabilirsiniz.
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string execute = "INSERT INTO UserRegistration(FirstName, LastName, Email, PassWord, Country, UserType)" +
                                "VALUES (@FirstName, @LastName, @Email, @PassWord, @Country, @UserType)";

                SqlCommand command = new SqlCommand(execute, sqlCon);


                //SqlCommand sqlCmd = new SqlCommand("UserAddOrEdit", sqlCon);
                //sqlCmd.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                command.Parameters.AddWithValue("@PassWord", txtPassword.Text.Trim()); // Güvenlik önlemleri alınmamış şifre
                command.Parameters.AddWithValue("@Country", txtCountry.Text.Trim());
                command.Parameters.AddWithValue("@UserType", 0);

                command.ExecuteNonQuery();
            }

            // Kullanıcıyı giriş sayfasına yönlendirin veya başka bir işlem yapın.
            Response.Redirect("Login.aspx");
        }
    }
}
