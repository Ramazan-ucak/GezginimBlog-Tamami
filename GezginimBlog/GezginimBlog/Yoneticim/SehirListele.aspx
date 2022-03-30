<%@ Page Title="" Language="C#" MasterPageFile="~/Yoneticim/Yonetici.Master" AutoEventWireup="true" CodeBehind="SehirListele.aspx.cs" Inherits="GezginimBlog.Yoneticim.SehirListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/KategoriDesign.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="KategoriContainer">
        <div class="SehirBaslik">
            <h3>Şehirler</h3>
        </div>
        <div class="KategoriContent Contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="BasarisizEkleme" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="lv_sehirler" runat="server" OnItemCommand="lv_sehirler_ItemCommand">
                <LayoutTemplate>
                    <table class="ListTable" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Seçenekler</th>
                            <th>Konum</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td>
                            <a href='SehirGuncelle.aspx?sid=<%# Eval("ID") %>' class="TableButton Update">Güncelle</a>
                            <asp:LinkButton ID="lbtn_Sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="TableButton Delete">Sil</asp:LinkButton>
                        </td>
                        <td>Henüz Yapılmadı</td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>

        </div>
    </div>
</asp:Content>
