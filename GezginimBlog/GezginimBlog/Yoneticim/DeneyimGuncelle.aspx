<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticim/Yonetici.Master" AutoEventWireup="true" CodeBehind="DeneyimGuncelle.aspx.cs" Inherits="GezginimBlog.Yoneticim.DeneyimGuncelle" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/KategoriDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="KategoriContainer">
       <div class="SehirBaslik">
           <h3>Deneyim Güncelle</h3>
       </div>
       <div class="KategoriContent">
             <asp:Panel ID="pnl_basarili" runat="server" CssClass="BasariliEkleme" Visible="false">
                <label>Deneyim Ekleme İşlemi Gerçekleştirildi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BasarisizEkleme" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
           <div style="width:500px; float:left">
               <div class="row">
                   <h4>Deneyim Başlık</h4><br />
                   <asp:TextBox ID="tb_isim" runat="server" CssClass="FormInput"></asp:TextBox>
               </div>
               <div class="row">
                   <h4>Şehir</h4><br />
                   <asp:DropDownList ID="ddl_sehirler" runat="server" CssClass="FormInput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
               </div>
               <div class="row">
                   <h4>Kapak Resim</h4><br />
                   <asp:Image ID="img_resim" runat="server" Width="500" /><br />
                   Resim Seç:
                   <asp:FileUpload ID="fu_resim" runat="server" />
               </div>
               <div class="row">
                   <h4>Deneyimini Paylaş</h4>
                   <asp:CheckBox ID="cb_paylas" runat="server" />
               </div>
           </div>
           <div style="width:500; float:left; padding-left:140px;" >
               <div class="row">
                   <h4>ÖnYazı</h4>
                   <asp:TextBox ID="tb_onyazi" runat="server" CssClass="FormInput" TextMode="MultiLine"></asp:TextBox>
               </div>
               <div class="row">
                   <h4>İçerik</h4><br />
                   <asp:TextBox ID="tb_icerik" runat="server" CssClass="FormInput" TextMode="MultiLine"></asp:TextBox>
               </div>
           </div>
           <div class="row" style="clear:both; text-align:center" >
               <asp:LinkButton ID="lbtn_guncelle" runat="server" OnClick="lbtn_guncelle_Click" CssClass="EkleButton">Deneyim Güncelle</asp:LinkButton>
           </div>
       </div>
   </div>


</asp:Content>
