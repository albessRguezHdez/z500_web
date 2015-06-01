<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="z500_SSH.aspx.cs" Inherits="z500.z500_SSH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<script language="C#" runat="server">

       void Page_Load(Object sender, EventArgs e) {
           Message.Text = "SSH";
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
    <div class="loginDisplay">
        <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
            <AnonymousTemplate>
                [ <a href="~/Account/Login.aspx" ID="HeadLoginStatus" runat="server">Iniciar sesión</a> ]
            </AnonymousTemplate>
            <LoggedInTemplate>
                Pantalla de bienvenida <span class="bold"><asp:LoginName ID="HeadLoginName" runat="server" /></span>!
                [ <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Cerrar sesión" LogoutPageUrl="~/"/> ]
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
