using System;
using System.Data;
using System.Data.SqlClient;

namespace yazilimsinamaproject
{
    public partial class AnasayfaCustomer : System.Web.UI.Page
    {
        string connectionString = "Data Source=BEYZAYOLDAS;Initial Catalog=UserRegistrationDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomerProjects();
            }
        }

        protected void btnSaveProject_Click(object sender, EventArgs e)
        {
            // Proje bilgilerini veritabanına kaydetme işlemi
            string projectTitle = txtProjectTitle.Text;
            string projectDescription = txtProjectDescription.Text;
            decimal projectBudget = Convert.ToDecimal(txtProjectBudget.Text);
            DateTime projectDeadline = Convert.ToDateTime(txtProjectDeadline.Text);

            // Bu örnek kod, güvenlik önlemleri alınmadan doğrudan SQL sorgusu oluşturulmuştur.
            // Gerçek projelerde güvenli parametre kullanımını unutmayın.

            int customerUserID = GetLoggedInUserID();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string execute = "INSERT INTO CustomerProjects(ProjectTitle, ProjectDescription, ProjectBudget, ProjectDeadline, CustomerUserID)" +
                                "VALUES (@ProjectTitle, @ProjectDescription, @ProjectBudget, @ProjectDeadline, @CustomerUserID)";

                SqlCommand command = new SqlCommand(execute, sqlCon);

                command.Parameters.AddWithValue("@ProjectTitle", projectTitle);
                command.Parameters.AddWithValue("@ProjectDescription", projectDescription);
                command.Parameters.AddWithValue("@ProjectBudget", projectBudget);
                command.Parameters.AddWithValue("@ProjectDeadline", projectDeadline);
                command.Parameters.AddWithValue("@CustomerUserID", customerUserID);

                command.ExecuteNonQuery();
            }

            // Projeleri tekrar yükle
            BindCustomerProjects();
        }

        private void BindCustomerProjects()
        {
            // Müşteri projelerini GridView'e bağlama işlemi
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT ProjectTitle, ProjectDescription, ProjectBudget, ProjectDeadline FROM CustomerProjects WHERE CustomerUserID = @CustomerUserID";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@CustomerUserID", GetLoggedInUserID());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvCustomerProjects.DataSource = dt;
                gvCustomerProjects.DataBind();
            }
        }

        private int GetLoggedInUserID()
        {
            // Bu fonksiyonun, giriş yapan kullanıcının ID'sini döndürmesi gerekiyor.
            // Siz bu fonksiyonu uygun şekilde güncellemeniz gerekiyor.
            return 1; // Örnek olarak 1 döndürülmüştür, gerçek uygulamada kullanıcı oturumu yönetimi kullanılmalıdır.
        }
    }
}
