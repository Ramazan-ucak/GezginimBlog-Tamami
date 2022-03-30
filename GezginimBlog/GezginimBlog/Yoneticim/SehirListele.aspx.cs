using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace GezginimBlog.Yoneticim
{
    public partial class SehirListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_sehirler.DataSource = dm.SehirListele();
            lv_sehirler.DataBind();
        }

        protected void lv_sehirler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (!dm.SehirSil(id))
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Şehir Silinirken Hata Oluştu";
                }
            }
            lv_sehirler.DataSource = dm.SehirListele();
            lv_sehirler.DataBind();
        }
    }
}