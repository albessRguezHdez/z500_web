<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="web_z500.aspx.cs" Inherits="z500._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" >
        $(document).ready(function () {
            $.getJSON("datos.json", function (data) {
                for (u in data.ipes.ipe) {
                    $("#ipess").append("<option value=" + data.ipes.ipe[u].ip +
                        ">" + data.ipes.ipe[u].dir_MAC + data.ipes.ipe[u].estado + "</option>");
                }
            })

            $("#ipess").change(function () {
                var stra = "";
                var stre = "";
                $("#ipess option:selected").each(function () {
                    stra = $(this).val();
                    stre = $(this).val();
                })
                $("#txtvalor").text("Ha seleccionado la ip: " + stra);
                $("#txtvalue").text("Ha seleccionad la MAC: " + str);
            })

            $("#ipess1").change(function () {
                var str = "";
                $("#ipess1 option:selected").each(function () {
                    str = $(this).val();
                })
                $("#txtvalor1").text("Ha seleccionado la ip: " + str);
            })

            $("#ipess2").change(function () {
                var str = "";
                $("#ipess2 option:selected").each(function () {
                    str = $(this).val();
                })
                $("#txtvalor2").text("Ha seleccionado la ip: " + str);
            })

            $("#ipess3").change(function () {
                var str = "";
                $("#ipess3 option:selected").each(function () {
                    str = $(this).val();
                })
                $("#txtvalor3").text("Ha seleccionado la ip: " + str);
            })
        });
</script> 
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
  <h2 style="text-align:center">
        Sistema de desarrollo en web: z500
    </h2>
  <br/>
  
   <table style="width: 100">
        <tr>
            <td></td>
            <td>Lista de IP´s</td>
            <td><h3>Dirección IP</h3></td>
            <td><h3>Dirección MAC</h3></td>
            <td><h3>Estado</h3></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Escaneo de red" />
            </td>
            
            <td>
                <select id="ipess">
                    <option value="0">[--Seleccione una ip--]</option>
                </select> 
            </td>
            <td>
                <span id="txtvalor" style="color: #008000; font-weight: bolder"></span>
                <span id="txtvalue" style="color: #008000; font-weight: bolder"></span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="SSH" />
            </td>
            
            <td>
                <select id="ipess1">
                    <option value="0">[--Seleccione una ip--]</option>
                </select>
            </td>
            <td> 
                <span id="txtvalor1" style="color: #008000; font-weight: bolder"></span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Descubriendo servicios" />
            </td>
            
            <td>
                <select id="ipess2">
                    <option value="0">[--Seleccione una ip--]</option>
                </select>
            </td>
            <td> 
                <span id="txtvalor2" style="color: #008000; font-weight: bolder"></span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button4" runat="server" Text="Activar proxy" />
            </td>
            <td>
                <select id="ipess3">
                    <option value="0">[--Seleccione una ip--]</option>
                </select>
            </td>
            <td> 
                <span id="txtvalor3" style="color: #008000; font-weight: bolder"></span>
            </td>
        </tr>
   </table>
</asp:Content>