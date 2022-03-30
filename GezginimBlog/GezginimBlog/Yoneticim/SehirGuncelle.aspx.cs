using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace GezginimBlog.Yoneticim
{
    public partial class SehirGuncelle : System.Web.UI.Page
    {  
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["sid"]);
                    Sehir s = dm.SehirGetir(id);
                    tb_ID.Text = s.ID.ToString();
                    tb_sehir.Text = s.Isim;
                }
                else
                {
                    Response.Redirect("SehirListele.aspx");
                }
            }
        }

        protected void lbtn_ekleme_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["sid"]);
            Sehir s = dm.SehirGetir(id);
            s.Isim = tb_sehir.Text;

            if (dm.SehirGuncelle(s))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Güncelleme İşleminde Bir Hata Oluştu";
            }
        }
    }
}