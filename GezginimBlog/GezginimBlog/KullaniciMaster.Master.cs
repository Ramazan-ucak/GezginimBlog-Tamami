using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
namespace GezginimBlog
{
    public partial class KullaniciMaster : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_sehirler.DataSource = dm.SehirListele();
            rp_sehirler.DataBind();
            if (Session["uye"] != null)
            {
                Uye u = (Uye)Session["uye"];
                pnl_GirisVar.Visible = true;
                lbl_Uye.Text = u.Isim;
                pnl_GirisYok.Visible = false;

            }
            else
            {
                pnl_GirisVar.Visible = false;
                pnl_GirisYok.Visible = true;
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}