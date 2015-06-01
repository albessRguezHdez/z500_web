<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="web_z500.aspx.cs" Inherits="z500._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" >
        $(document).ready(function () {
            $.getJSON("datos.json", function (data) {
                for (u in data.ipes.ipe) {
                    $("#ipess").append("<option value=" + data.ipes.ipe[u].Id +
                        ">" + data.ipes.ipe[u].ip + "</option>");
                }
            })

            $("#ipess").change(function () {
                var str = "";
                $("#ipess option:selected").each(function () {
                    str = $(this).val();
                })
                $("#txtvalor").text("Ha seleccionado la ip: " + str);
            })
        });
</script> 
</asp:Content>
<!--
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
-->
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
  <h1>Lista de IP´s, MAC y estado del zombie</h1> 
  <br/>
  <select id="usuarios">
      <option value="0">[--Seleccione una ip--]</option>
   </select> 
   <span id="txtvalor" style="color: #008000; font-weight: bolder"></span>
</asp:Content>