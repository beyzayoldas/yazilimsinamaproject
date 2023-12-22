using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    namespace yazilimsinamaproject
    {
        public partial class first : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // Sayfa yüklendiğinde gerekli işlemleri yapabilirsiniz.
            }

            protected void btnCustomer_Click(object sender, EventArgs e)
            {
                // Müşteri butonuna tıklandığında Müşteri kayıt sayfasına yönlendirme
                Response.Redirect("CustomerRegister.aspx");
            }

            protected void btnFreelancer_Click(object sender, EventArgs e)
            {
                // Freelancer butonuna tıklandığında Freelancer kayıt sayfasına yönlendirme
                Response.Redirect("FreelancerRegister.aspx");
            }
        }
    }

