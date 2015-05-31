<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="web_z500.aspx.cs" Inherits="z500._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.8.0.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 style="text-align:center">
        Sistema de desarrollo en web: z500
    </h2>
    <div>
    
    </div>
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Button ID="Button1"
                    runat="server" Text="Escaneo de red" />
            </td>
            <td>
                Utilizar
            </td>
            <td>
                Dirección IP
            </td>
            <td>
                Nombre de la PC
            </td>
            <td>
                Estado
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2"
                    runat="server" Text="SSH" />
            </td>
            <td>
                &nbsp;
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3"
                    runat="server" Text="Descubriendo servicios" />
            </td>
            <td>
                &nbsp;
                <asp:CheckBox ID="CheckBox2" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button4"
                    runat="server" Text="Activar proxy" />
            </td>
            <td>
                &nbsp;
                <asp:CheckBox ID="CheckBox3" runat="server" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <p>
        Ver documentación del sistema: <a href="https://docs.google.com/document/d/17O4MmyR9GZM6SlyGRokkdHvPxFb5wVUttA9Q0rPZeRE/edit?usp=drive_web"
            title="Documentación de z500">Documentación z500</a>.
    </p>
</asp:Content>
