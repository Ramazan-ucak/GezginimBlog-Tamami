<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticim/Yonetici.Master" AutoEventWireup="true" CodeBehind="SehirEkle.aspx.cs" Inherits="GezginimBlog.Yoneticim.SehirEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/KategoriDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="KategoriContainer">
        <div class="SehirBaslik">
            <h3>Şehir Ekle</h3>
        </div>
        <div class="KategoriContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="BasariliEkleme" Visible="false">
                <label>Şehir Ekleme İşlemi Gerçekleştirildi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BasarisizEkleme" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row">
                <h4>Şehir Adını Giriniz :</h4><br />
                <asp:TextBox ID="tb_sehir" runat="server" placeholder="Tatil şehri giriniz" CssClass="FormInput"></asp:TextBox>
            </div> 
            <div class="row">
                <asp:LinkButton ID="lbtn_ekleme" runat="server" OnClick="lbtn_ekleme_Click" CssClass="EkleButton">Şehir Ekle</asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
