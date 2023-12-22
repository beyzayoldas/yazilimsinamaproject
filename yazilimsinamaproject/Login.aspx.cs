using System;
using System.Data.SqlClient;

namespace yazilimsinamaproject
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = "Data Source=BEYZAYOLDAS;Initial Catalog=UserRegistrationDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Sayfa yüklendiğinde gerekli işlemleri yapabilirsiniz.
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT Email, PassWord, UserType FROM UserRegistration WHERE Email = @Email AND PassWord = @Password", sqlCon);
                sqlCmd.Parameters.AddWithValue("@Email", email);
                sqlCmd.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userType = Convert.ToInt32(reader["UserType"]);

                        if (userType == 1)
                        {
                            // Müşteri kullanıcı tipi, AnasayfaCustomer.aspx'e yönlendir.
                            Response.Redirect("AnasayfaCustomer.aspx");
                        }
                        else if (userType == 0)
                        {
                            // Freelancer kullanıcı tipi, AnasayfaFreelancer.aspx'e yönlendir.
                            Response.Redirect("AnasayfaFreelancer.aspx");
                        }
                    }
                    else
                    {
                        lblErrorMessage.InnerText = "Geçersiz kullanıcı adı veya şifre.";
                    }
                }
            }
        }
    }
}
