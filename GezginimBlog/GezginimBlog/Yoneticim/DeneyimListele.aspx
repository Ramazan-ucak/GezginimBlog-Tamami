<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticim/Yonetici.Master" AutoEventWireup="true" CodeBehind="DeneyimListele.aspx.cs" Inherits="GezginimBlog.Yoneticim.DeneyimListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/KategoriDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="KategoriContainer">
        <div class="SehirBaslik">
            <h3>Deneyimler</h3>
        </div>
        <div class="KategoriContent Contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BasarisizEkleme" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="lv_deneyimler" runat="server" OnItemCommand="lv_deneyimler_ItemCommand">
                <LayoutTemplate>
                    <table class="ListTable" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>Resim</th>
                            <th>ID</th>
                            <th>Başlık</th>
                            <th>Şehir</th>
                            <th>Yazar</th>
                            <th>Ekleme Tarihi</th>
                            <th>Görüntülenme Sayısı</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                         <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><img src='../DeneyimResimler/<%# Eval("GeziResim") %>' width="150"</td>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Baslik") %></td>
                        <td><%# Eval("Sehir") %></td>
                        <td><%# Eval("Yazar") %></td>
                        <td><%# Eval("EklemeTarih") %></td>
                        <td><%# Eval("GoruntulemeSayisi") %></td>
                        <td><%# Eval("Durum") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durum" runat="server" CommandName="durum" CommandArgument='<%# Eval("ID") %>' CssClass="TableButton status">Durum</asp:LinkButton>
                            <a href='DeneyimGuncelle.aspx?ddid=<%# Eval("ID") %>' class="TableButton Update">Güncelle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="TableButton Delete">Sil</asp:LinkButton>
                        </td>
                        
                    </tr>
                </ItemTemplate>
            </asp:ListView> 
        </div>
    </div>
</asp:Content>
