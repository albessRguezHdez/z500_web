using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace z500
{
    public partial class z500_Activar_Proxy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
/*
void *iniciarmeComoProxy(void *mensaje){
	struct spell_msj msj = *(struct spell_msj *) mensaje;
	if(!proxyActivado){
	//-------------------------------------------------------------
	//-------------------------------------------------------------
		int sock_Proxy;
		if((sock_Proxy = socket(AF_INET, SOCK_STREAM, 0)) == -1){
			printf("Error al crear la socket al Servidor_Proxy.\n");
			resultadoDeProxy(msj, "Error al iniciar");
		}else{
			char host_name[NI_MAXHOST]; //"localhost";//"74.208.234.113";//"74.208.234.113";
			sprintf(host_name, "%s", msj.datos);
			struct hostent *server_hostname = gethostbyname(host_name);

    		struct sockaddr_in serverWeb;
    		bzero((char *) &serverWeb, sizeof(serverWeb));
    		serverWeb.sin_family = AF_INET;
			serverWeb.sin_port = htons(Puerto_Proxy);
   			serverWeb.sin_addr = *((struct in_addr *)(server_hostname->h_addr_list[0]));

			if(connect(sock_Proxy, (struct sockaddr *)&serverWeb, sizeof(struct sockaddr)) == -1){
				printf("Error al iniciar la conexion al Servidor_Proxy.\n");
				resultadoDeProxy(msj, "Error al iniciar");
			}else{
				printf("--------------------------- Servidor_Proxy encontrado ---------------------------\n");
				unsigned char* mensajeServ = (char *)malloc(tamBuffer);
				int nRSP =  recv(sock_Proxy, mensajeServ, tamBuffer, 0);
				if (strstr(mensajeServ,"Desocupado")!=NULL) {
					printf("--------------------------- Servidor_Proxy: Desocupado.\n");
					proxyActivado = 1;
					resultadoDeProxy(msj, "Iniciado");
					while(proxyActivado){
						unsigned char* mensajeProxy = (char *)malloc(tamBuffer);
						int n1 =  recv(sock_Proxy, mensajeProxy, tamBuffer, 0);
						//printf(" ----------------- Mensaje recibido del Servidor_Proxy:\n%s\n",mensajeProxy);
						printf(" ----------------- Mensaje recibido del Servidor_Proxy:\n");
						unsigned char* respuesta_WEB = atenderSolicitudWeb(mensajeProxy, tamBuffer);
						int n2 = send(sock_Proxy, respuesta_WEB, tamBuffer, 0);
						printf(" ----------------- Mensaje fue enviado al Servidor_Proxy...\n");
					}
					close(sock_Proxy);
					resultadoDeProxy(msj, "Cerrado");
				}else{
					printf("--------------------------- Servidor_Proxy: Ocupado.\n");
					close(sock_Proxy);
					resultadoDeProxy(msj, "Error al iniciar");
				}
			}
   		}
   	//-------------------------------------------------------------
	//-------------------------------------------------------------
	}else{
		resultadoDeProxy(msj, "Error al iniciar");
	}
}

void *cerrarProxy(void *mensaje){
	struct spell_msj msj = *(struct spell_msj *) mensaje;
	// *************************************************************************************************
	// *************************************************************************************************
	// *************************************************************************************************
	int sock_ProxyClose;
	if((sock_ProxyClose = socket(AF_INET, SOCK_STREAM, 0)) == -1){
			printf("Error al crear la socket al Servidor_ProxyClose.\n");
			resultadoDeProxy(msj, "Error al iniciar");
	}else{
		char host_name[NI_MAXHOST]; //"localhost";//"74.208.234.113";//"74.208.234.113";
		sprintf(host_name, "%s", msj.datos);
		struct hostent *server_hostname = gethostbyname(host_name);

    	struct sockaddr_in serverWeb;
    	bzero((char *) &serverWeb, sizeof(serverWeb));
    	serverWeb.sin_family = AF_INET;
		serverWeb.sin_port = htons(Puerto_ProxyClose);
   		serverWeb.sin_addr = *((struct in_addr *)(server_hostname->h_addr_list[0]));

		if(connect(sock_ProxyClose, (struct sockaddr *)&serverWeb, sizeof(struct sockaddr)) == -1){
			printf("Error al iniciar la conexion al Servidor_Proxy.\n");
			resultadoDeProxy(msj, "Error al iniciar");	
		}else{
			printf("--------------------------- Servidor_ProxyClose encontrado ---------------------------\n");
			unsigned char mensajeServ[tamBuffer];
			bzero(mensajeServ,tamBuffer); // Poner en 0 el mensaje para recibir mensaje
			sprintf(mensajeServ, "Cerrar");
			printf("------------------------------------------------------.\n");
			send(sock_ProxyClose, mensajeServ, tamBuffer, 0);
			printf("------------------------------------------------------.\n");
			close(sock_ProxyClose);
			printf("--------------------------- %s.\n", mensajeServ);
			resultadoDeProxy(msj, "Cerrado");
			proxyActivado = 0;
   		}
   	}
	// *************************************************************************************************
	// *************************************************************************************************
	// *************************************************************************************************
}

void resultadoDeProxy(struct spell_msj msj, char *resultado){
	int socket_descriptor;
	int on = 1;
	//Inicia la estructura de direcciones de socket para los protocolos
	struct sockaddr_in address;
	memset(&(address.sin_zero), '\0', 8);
	address.sin_family = AF_INET;	
	address.sin_addr.s_addr = inet_addr(inet_ntoa(msj.zIP)); //struct hostent *server_hostname = gethostbyname(inet_ntoa(msj.zIP)); //address.sin_addr = *((struct in_addr *)(server_hostname->h_addr_list[0]));
	address.sin_port = htons(PORT_Listen); // Puerto por donde escucha el maestro, (Entrada para el maestro)
		
	//Crear socket UDP
	socket_descriptor = socket(AF_INET, SOCK_DGRAM, 0);
    if (setsockopt(socket_descriptor, SOL_SOCKET, SO_BROADCAST, &on, sizeof(on)) < 0){
		printf("Error al crear el Socket para responder al maestro.\n");
	}else{
		
		//Estructurando respuesta para el maestro
		msj.orden = 45; // <<<-------------------------- Orden o tipo de respuesta para el maestro
		msj.xIP.s_addr = inet_addr(inet_ntoa(myDirIP));
		int iax;
	    // Estado del Zombie
	    for(iax = 0; iax < tamInfo_Comserv; iax++){
	    	msj.comserv[iax] = 0;
	    }		
		sprintf(msj.comserv, "%s", resultado);

		//Respondiendo al maestro
		if (sendto(socket_descriptor, &msj, sizeof(msj), 0, (struct sockaddr *) &address, sizeof(address)) == -1){
			printf("Error al responder al maestro.\n"); // Si algo salio mal al enviar el mensaje
		}
		close(socket_descriptor);
	}
}
*/