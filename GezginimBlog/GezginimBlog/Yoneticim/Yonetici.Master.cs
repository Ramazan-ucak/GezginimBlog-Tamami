using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GezginimBlog.Yoneticim
{
    public partial class Yonetici : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null)
            {
                DataAccessLayer.Yonetici yn = (DataAccessLayer.Yonetici)Session["yonetici"];
                lbl_kullanici.Text = yn.Isim + " " + yn.Soyad;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("Giris.aspx");
        }
    }
}