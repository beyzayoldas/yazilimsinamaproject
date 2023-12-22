using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace yazilimsinamaproject
{
    public partial class AnasayfaFreelancer : System.Web.UI.Page
    {
        string connectionString = "Data Source=BEYZAYOLDAS;Initial Catalog=UserRegistrationDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAvailableProjects();
            }
        }

        protected void btnSearchProject_Click(object sender, EventArgs e)
        {
            // Proje arama işlemi
            string searchKeyword = txtSearchProject.Text;

            // Bu örnek kod, güvenlik önlemleri alınmadan doğrudan SQL sorgusu oluşturulmuştur.
            // Gerçek projelerde güvenli parametre kullanımını unutmayın.

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT ProjectID, ProjectTitle, ProjectDescription, ProjectBudget, ProjectDeadline FROM CustomerProjects WHERE ProjectTitle LIKE @SearchKeyword";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAvailableProjects.DataSource = dt;
                gvAvailableProjects.DataBind();
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            // Proje başvuru işlemi
            Button btnApply = (Button)sender;
            int projectID = Convert.ToInt32(btnApply.CommandArgument);

            // Bu kısımda, seçilen projeye başvuru işlemini gerçekleştirin.
            // Örneğin, FreelancerID ve ProjectID'yi FreelancerApplications tablosuna ekleyebilirsiniz.
            // Bu örnek kod, güvenlik önlemleri alınmadan doğrudan SQL sorgusu oluşturulmuştur.
            // Gerçek projelerde güvenli parametre kullanımını unutmayın.

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string execute = "INSERT INTO FreelancerApplications(FreelancerID, ProjectID) VALUES (@FreelancerID, @ProjectID)";
                SqlCommand command = new SqlCommand(execute, sqlCon);

                command.Parameters.AddWithValue("@FreelancerID", GetLoggedInUserID()); // Bu fonksiyonun sizin kullanıcı ID'nizi alacak şekilde düzenlenmesi gerekiyor.
                command.Parameters.AddWithValue("@ProjectID", projectID);

                command.ExecuteNonQuery();
            }
        }

        private void BindAvailableProjects()
        {
            // Başvurabileceğiniz projeleri GridView'e bağlama işlemi
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT ProjectID, ProjectTitle, ProjectDescription, ProjectBudget, ProjectDeadline FROM CustomerProjects";
                SqlCommand cmd = new SqlCommand(query, sqlCon);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvAvailableProjects.DataSource = dt;
                gvAvailableProjects.DataBind();
            }
        }

        private int GetLoggedInUserID()
        {
            // Bu fonksiyonun, giriş yapan kullanıcının ID'sini döndürmesi gerekiyor.
            // Siz bu fonksiyonu uygun şekilde güncellemeniz gerekiyor.
            return 2; // Örnek olarak 2 döndürülmüştür, gerçek uygulamada kullanıcı oturumu yönetimi kullanılmalıdır.
        }
    }
}
