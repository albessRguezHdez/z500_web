using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace z500
{
    public partial class z500_Descubrir_Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
/*
unsigned char* atenderSolicitudWeb(unsigned char* mensaje, int tamBuff){
	printf("%s\n",mensaje);
	char *host_name = extraerHostName(mensaje, tamBuff);
	printf("--->%s<---\n",host_name);
	struct hostent *server_hostname = gethostbyname(host_name);
	if(server_hostname == NULL){
		printf("Error en el nombre de Host del socket a Internet.\n");
		return " ";
	}

	int sock_Web;
	if((sock_Web = socket(AF_INET, SOCK_STREAM, 0)) == -1){
		printf("Error al crear la socket al Internet.\n");
		return " ";
	}

	int nPort = 80; // = extraerPuerto(mensaje, tamBuff); // <<-------------------------------------------------------------------------------------

    struct sockaddr_in serverWeb;
    bzero((char *) &serverWeb, sizeof(serverWeb));
    serverWeb.sin_family = AF_INET;
	serverWeb.sin_port = htons(nPort);
   	serverWeb.sin_addr = *((struct in_addr *)(server_hostname->h_addr_list[0]));
	//memset(&(serverWeb.sin_zero), '\0', 8);

	if(connect(sock_Web, (struct sockaddr *)&serverWeb, sizeof(struct sockaddr)) == -1){
		printf("Error al iniciar la conexion al Internet.\n");
		return " ";
   	}else{
   		printf("***** Conexion para %s:%d\n", inet_ntoa(serverWeb.sin_addr), serverWeb.sin_port);
   	}

	if(send(sock_Web, mensaje, tamBuff, 0) == -1){
		printf("Error al enviar el mensaje al Internet.\n");
		return " ";
	}else{
		printf("-----------------------------El mensaje fue enviado al Internet\n");
	}

	unsigned char* respuesta = (char *)malloc(tamBuff);
	int numBytes =  recv(sock_Web, respuesta, tamBuff, 0);
	if(numBytes < 0){
		perror("Error al recibir la respuesta Web");
		return " ";
	}else{
		printf("-----------------------------Mensaje recibido del Internet:\n\n%s\n",respuesta);
	}

	close(sock_Web);
	return respuesta;
}

unsigned char* extraerHostName(unsigned char* mensaje, int tamCad){
	
	unsigned char *hostName = (char *)malloc(1);
	int bandFin = 0;
	int iax = 0;
	while(!bandFin && (iax < tamCad)){
		if((mensaje[iax] == 72) || (mensaje[iax] == 104)){ // 72 - 104; H y h
			iax++;
			if((mensaje[iax] == 79) || (mensaje[iax] == 111)){ // 79 - 111; O y o
				iax++;
				if((mensaje[iax] == 83) || (mensaje[iax] == 115)){ // 83 - 115;  S y s
					iax++;
					if((mensaje[iax] == 84) || (mensaje[iax] == 116)){ // 84 - 116; T y t
						iax++;
						if(mensaje[iax] == 58){ // 58; :
							iax++;
							int iHN = 0;
							int bandX = 0;
							while(!bandFin && (iax < tamCad)){
								if(mensaje[iax] != 32){ // Espacio en Blanco
									char *hNx = (char *)malloc(iHN + 1);
									int iaz;
									for(iaz = 0; iaz < (iHN); iaz++){
										hNx[iaz] = hostName[iaz];
									}
									hNx[iHN] = mensaje[iax];
									hostName = NULL;
									hostName = (char *)malloc(iHN + 1);
									for(iaz = 0; iaz < (iHN+1); iaz++){
										hostName[iaz] = hNx[iaz];
									}
									iHN++;
								}
								iax++;
								if((mensaje[iax] == 10) || (mensaje[iax] == 11) || (mensaje[iax] == 12) || (mensaje[iax] == 13) || (mensaje[iax] == 58)){
									bandFin = 1;
								}
							}
						}
					}
				}
			}
		}
		iax++;
	}
	printf("---%s---\n", hostName);
	return hostName;
}

int extraerPuerto(unsigned char* mensaje, int tamCad){
	
	char *c_port = (char *)malloc(1);
	int tamFinal_cPort = 0;
	int bandFin = 0;
	int iax = 0;
	while(!bandFin && (iax < tamCad)){
		if((mensaje[iax] == 72) || (mensaje[iax] == 104)){ // 72 - 104; H y h
			iax++;			
			if((mensaje[iax] == 79) || (mensaje[iax] == 111)){ // 79 - 111; O y o
				iax++;
				if((mensaje[iax] == 83) || (mensaje[iax] == 115)){ // 83 - 115;  S y s
					iax++;
					if((mensaje[iax] == 84) || (mensaje[iax] == 116)){ // 84 - 116; T y t
						iax++;
						if(mensaje[iax] == 58){ // 58; :
							int bandY = 0;
							while(!bandY && (iax < tamCad)){
								iax++;
								if((mensaje[iax] == 58) || (mensaje[iax] == 10) || (mensaje[iax] == 11) 
								|| (mensaje[iax] == 12) || (mensaje[iax] == 13)){
									bandY = 1;
								}
							}
							if(mensaje[iax] == 58){
								iax++;
								int iHN = 0;
								int bandX = 0;
								while(!bandFin && (iax < tamCad)){
									if(mensaje[iax] != 32){ // Espacio en Blanco
										char *hNx = (char *)malloc(iHN + 1);
										int iaz;
										for(iaz = 0; iaz < (iHN); iaz++){
											hNx[iaz] = c_port[iaz];
										}
										hNx[iHN] = mensaje[iax];
										c_port = NULL;
										c_port = (char *)malloc(iHN + 1);
										for(iaz = 0; iaz < (iHN+1); iaz++){
											c_port[iaz] = hNx[iaz];
										}
										iHN++;
										tamFinal_cPort = iHN;
									}
									iax++;
									if((mensaje[iax] == 10) || (mensaje[iax] == 11)
									|| (mensaje[iax] == 12) || (mensaje[iax] == 13)){
										bandFin = 1;
									}
								}
							}else{
								return 80;
							}
						}
					}
				}
			}
		}
		iax++;
	}
	printf("C...%s...%d...\n",c_port,tamFinal_cPort);
	int portNavg;
	if((c_port != NULL) && (tamFinal_cPort > 0)){
		int portNavg = toInt(c_port);
	}else{
		int portNavg = 80;
	}
	printf("D...%d...%d...\n",portNavg,tamFinal_cPort);
	return portNavg;
}

int toInt(const char *s){
	int sign=1;
	if(*s == '-'){
		sign = -1;
	}
 	
 	s++;
 	int num=0;
 	while(*s){
    	num=((*s)-'0')+num*10;
    	s++;
  	}
 	return num*sign;
}

//=========================================================================================================
//=========================================================================================================
//=========================================================================================================

void *zombieBarreRed(void *mensaje){
	struct spell_msj msj = *(struct spell_msj *) mensaje;
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
		printf("Error al crear el Socket para responder al maestro por Barrer.\n");
	}else{

		//Estructurando respuesta para el maestro
		msj.orden = 17; // <<<-------------------------- Orden o tipo de respuesta para el maestro	
		msj.xIP.s_addr = inet_addr(inet_ntoa(myDirIP));
		int iax;

		char ipObjetivo[12]; // Guardar IP objetivo
		for(iax = 0; iax < 12; iax++){
			ipObjetivo[iax] = 0;
		}
		sprintf(ipObjetivo, "%s", msj.datos);

		if(existeIP(ipObjetivo) == 0){

			// Nombre del Zombie ------------------
			for(iax = 0; iax < tamInfo_Nom; iax++){
				msj.xNom[iax] = 0;
			}
			sprintf(msj.xNom, "%s", getNombre(ipObjetivo));

			// Direccion MAC del Zombie ---------
    		for(iax = 0; iax < tamDirMAC; iax++){
	    		msj.xMAC[iax] = myDirMac[iax];
	    	}
	    	sprintf(msj.xMAC, "%s", "0000000A"); // << -----------------------------------------------------------------
			
			printfStruct_SpellMsj(msj);
			//Respondiendo al maestro
			if (sendto(socket_descriptor, &msj, sizeof(msj), 0, (struct sockaddr *) &address, sizeof(address)) == -1){
				printf("Error al responder al maestro por Barrer.\n"); // Si algo salio mal al enviar el mensaje
			}
		}else{

    		for(iax = 0; iax < tamInfo_Comserv; iax++){
	    		msj.comserv[iax] = 0;
	    	}
	    	sprintf(msj.comserv, "Barrer: No existe");
	    	printfStruct_SpellMsj(msj);
			//Respondiendo al maestro
			if (sendto(socket_descriptor, &msj, sizeof(msj), 0, (struct sockaddr *) &address, sizeof(address)) == -1){
				printf("Error al responder al maestro por descubrir.\n"); // Si algo salio mal al enviar el mensaje
			}
		}
		close(socket_descriptor);
	}	
}

void *zombieDescubreServicios(void *mensaje){
	struct spell_msj msj = *(struct spell_msj *) mensaje;
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
		printf("Error al crear el Socket para responder al maestro por descurbrir.\n");
	}else{

		//Estructurando respuesta para el maestro
		msj.orden = 13; // <<<-------------------------- Orden o tipo de respuesta para el maestro	
		msj.xIP.s_addr = inet_addr(inet_ntoa(myDirIP));
		int iax;

		char ipObjetivo[12]; // Guardar IP objetivo
		for(iax = 0; iax < 12; iax++){
			ipObjetivo[iax] = 0;
		}
		sprintf(ipObjetivo, "%s", msj.datos);

		if(existeIP(ipObjetivo) == 0){

    		for(iax = 0; iax < tamInfo_Comserv; iax++){
	    		msj.comserv[iax] = 0;
	    	}
	    	//sprintf(msj.comserv, "%s", getServicio(ipObjetivo)); // << -----------------------------------------------------------------
	    	sprintf(msj.comserv, "%s,%s,%s,%s,%s,%s,%s", getServicio(80), getServicio(8080), getServicio(22), getServicio(21), getServicio(3389), getServicio(23), getServicio(25)); // << -----------------------------------------------------------------
	    	//sprintf(msj.comserv, "Sin servicios");

	    	printfStruct_SpellMsj(msj);
			//Respondiendo al maestro
			if (sendto(socket_descriptor, &msj, sizeof(msj), 0, (struct sockaddr *) &address, sizeof(address)) == -1){
				printf("Error al responder al maestro por descubrir.\n"); // Si algo salio mal al enviar el mensaje
			}			
		}else{

    		for(iax = 0; iax < tamInfo_Comserv; iax++){
	    		msj.comserv[iax] = 0;
	    	}
	    	sprintf(msj.comserv, "Descubrir: No existe");
	    	printfStruct_SpellMsj(msj);
			//Respondiendo al maestro
			if (sendto(socket_descriptor, &msj, sizeof(msj), 0, (struct sockaddr *) &address, sizeof(address)) == -1){
				printf("Error al responder al maestro por descubrir.\n"); // Si algo salio mal al enviar el mensaje
			}
		}
		close(socket_descriptor);
	}
}
*/