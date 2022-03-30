<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GezginimBlog.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_deneyimler" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="Deneyim">
                <div class="Title">
                    <h3><%# Eval("Baslik") %></h3>
                </div>
                <div class="Image">
                    <img src='DeneyimResimler/<%# Eval("GeziResim") %>' />
                </div>
                <div class="information">
                    Şehir: <%# Eval("Sehir") %> || Yazar: <%# Eval("Yazar") %> 
                   
                </div>
                <div class="covering">
                    <%# Eval("Onyazi") %>
                </div>
                 <div class="ButtonDevam">
                    <a href="DeneyimDevam.aspx?did= <%# Eval("ID") %>">Tümünü gör</a>
                </div>
               
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
