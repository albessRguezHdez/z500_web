using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace z500
{
    public partial class z500_Escaneo_Red : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*atkSoapClient servicio = new atkSoapClient();
            lbPagina.Text = servicio.getHTML;*/
        }
    }
}
/*
void printfStruct_SpellMsj(struct spell_msj msj){
	printf("_____________________________________________________\n");
	printf("_____________Orden: %d.\n", msj.orden);
	printf("____Dir.IP.Maestro: %s.\n", inet_ntoa(msj.zIP));
	printf("Dir.IP.Solicitante: %s.\n", inet_ntoa(msj.yIP));
	printf("_____Dir.IP.Zombie: %s.\n", inet_ntoa(msj.xIP));
	printf("_________Host name: %s.\n", msj.xNom);
	printf("__________Dir. MAC: %02x-%02x-%02x-%02x-%02x-%02x.\n", msj.xMAC[0], msj.xMAC[1], msj.xMAC[2], msj.xMAC[3], msj.xMAC[4], msj.xMAC[5]);
	printf("______Datos.Extras: %s.\n", msj.datos);
	printf("___________Comserv: %s.\n", msj.comserv);
	printf("_____________________________________________________\n");
}
*/