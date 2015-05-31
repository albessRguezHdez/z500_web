<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="z500_Activar_Proxy.aspx.cs" Inherits="z500.z500_Activar_Proxy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<script language="C#" runat="server">

       void Page_Load(Object sender, EventArgs e) {
           Message.Text = "ACTIVAR PROXY";
       }

</script>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2 style="text-align:center">
        Sistema de desarrollo en web: z500
    </h2>
    <div>
         <asp:label id="Message" font-size="12" runat="server"/>
    </div>
    
    <div class="register">
        
    </div>
</asp:Content>