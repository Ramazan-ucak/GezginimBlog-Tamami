<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciMaster.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="GezginimBlog.UyeGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/UyeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MemberTitle">
        <h4>Üye Giriş </h4>
    </div>
    <div class="GirisForm Form">
        <div class="row" style="float:left; padding-top:10px;" >
            <img src="Genel/Images/lock.png" class="PanelImage" />
        </div>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="KullaniciYok" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row" style="text-align:center" >
            <label>Mail</label><br />
            <asp:TextBox ID="tb_mail" runat="server" CssClass="Textbox"></asp:TextBox>
        </div> 
        <div class="row" style="text-align:center">
            <label>Şifre</label><br />
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="Textbox" TextMode="Password"></asp:TextBox>
        </div>
        <div class="row" style="text-align:center">
            <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap" OnClick="lbtn_giris_Click" CssClass="UyeButton"></asp:LinkButton>
        </div>
    </div>




</asp:Content>
