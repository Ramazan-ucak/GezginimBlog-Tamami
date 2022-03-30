<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciMaster.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="GezginimBlog.UyeOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/UyeStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MemberTitle">
        <h4>Kayıt Ol</h4>
    </div>
    <div class="GirisForm Form">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="BasariliEkleme" Visible="false">
            <label>Kayıt  işlemi başarılı</label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BasarisizEkleme" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <label>Ad:</label><br />
            <asp:TextBox ID="tb_ad" runat="server" CssClass="Textbox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Soyad:</label><br />
            <asp:TextBox ID="tb_soyad" runat="server" CssClass="Textbox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Mail:</label><br />
            <asp:TextBox ID="tb_mail" runat="server"  CssClass="Textbox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Şifre:</label><br />
            <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="Textbox"></asp:TextBox>
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_kayit" runat="server" OnClick="lbtn_kayit_Click" CssClass="KayıtOl" >Kayıt Ol</asp:LinkButton>
        </div>
    </div>
</asp:Content>
