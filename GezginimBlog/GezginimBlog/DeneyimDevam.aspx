<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciMaster.Master" AutoEventWireup="true" CodeBehind="DeneyimDevam.aspx.cs" Inherits="GezginimBlog.DeneyimDevam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Deneyim2">
        <div class="Title">
           <h2>
               <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal>
           </h2>
        </div>
        <div class="Image">
            <asp:Image ID="img_resim" runat="server" />
        </div>
        <div class="information">
            Şehir:
            <asp:Literal ID="ltrl_sehir" runat="server"></asp:Literal> ||
            Yazar:
            <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
        </div><br /><br />
        <div class="summary">
            <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
        </div>
    </div>
    <div style="min-height:500px;">
        <div class="Comment" style="margin-top:50px;" >
            <div class="CommentTitle">
                <h2>Yorumlar</h2>
            </div>
            <asp:Panel ID="pnl_GirisVar" runat="server" Visible="false">
                <br />
                <h3>Yorum Yaz</h3>
                <asp:TextBox ID="tb_yorum" TextMode="MultiLine" runat="server" CssClass="area"></asp:TextBox>
                <br />
                <asp:LinkButton ID="lbtn_yorumyap" runat="server"  Text="Yorum Yap" OnClick="lbtn_yorumyap_Click"  CssClass="YorumButton"></asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="pnl_GirisYok" runat="server" CssClass="girisLink" Style="20px 0;">
                <h2>Yorum yapabilmek için lütfen <a href="UyeGiris.aspx">giriş yapınız..</a></h2>
            </asp:Panel>
            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="YorumItem">
                        <label><%# Eval("Uye") %></label> ||  <label><%# Eval("Tarih") %></label>
                        <br />
                        <p><%# Eval("Icerik") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
