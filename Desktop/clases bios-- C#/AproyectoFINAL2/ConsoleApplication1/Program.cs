using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        #region Pido cosas
        static DateTime PidoDateTime(string mensaje)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    Console.WriteLine();

                    // Capturar el año
                    int anio = PidoNumero("Ingrese anio : ", 1900, 2100);
                    

                    // Capturar el mes
                    int mes = PidoNumero("Ingrese mes(1-12): ", 1, 12);

                    // Capturar el día
                    int dia = PidoNumero("Ingrese dia: ", 1, DateTime.DaysInMonth(anio, mes));

                    // Capturar la hora
                    int hora = PidoNumero("Ingrese la hora (0-23): ", 0, 23);

                    // Capturar los minutos
                    int minutos = PidoNumero("Ingrese los minutos (0-59): ", 0, 59);

                    
                    DateTime fechaHora = new DateTime(anio, mes, dia, hora, minutos, 0);

                    if (fechaHora <= DateTime.Now) 
                    {
                        throw new Exception("La fecha no puede ser menor a la fecha actual");
                        
                    }

                    return fechaHora;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();
                }
            }
        }

        static DateTime PidoDateTime2(string mensaje)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    Console.WriteLine();

                    // Capturar el año
                    int anio = PidoNumero("Ingrese anio : ", 1900, 2100);


                    // Capturar el mes
                    int mes = PidoNumero("Ingrese mes(1-12): ", 1, 12);

                    // Capturar el día
                    int dia = PidoNumero("Ingrese dia: ", 1, DateTime.DaysInMonth(anio, mes));



                    DateTime fechaHora = new DateTime(anio, mes, dia);

                    return fechaHora;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();
                }
            }
        }


        static bool PidoBoolean(string mensaje)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(mensaje);
                    string siono = Console.ReadLine().Trim().ToLower(); // Convertimos a minúsculas para no tener en cuenta las mayúsculas

                    if (siono == "si")
                    {
                        return true;
                    }
                    else if (siono == "no")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingrese 'si' o 'no'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }



        static int PidoNumero(string mensaje, int minimo, int maximo)
        {
            int numero;

            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    numero = Convert.ToInt32(Console.ReadLine());

                    if (numero < minimo || numero > maximo)
                    {
                        Console.WriteLine
                            ("Debe ingresar un valor entre " + minimo + " y " + maximo);
                        Console.ReadLine();
                    }
                    else
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();
                }
            }
            return numero;
        }

        
       
        static string PidoPalabra(string mensaje)
        {
            string palabra;

            while (true)
            {
                Console.Write(mensaje);
                palabra = Console.ReadLine().Trim();

                if (palabra == "")
                {
                    Console.WriteLine("Debe ingresar una palabra");
                    Console.WriteLine();
                }
                else
                    break;
            }
            return palabra;
        }
       

        static bool SalirDeLaOpcion()
        {
            Console.Write("Ingrese la letra S si desea salir de la opción en la que se encuentra: ");
            return ("S" == Console.ReadLine().Trim().ToUpper());
        }
        
        #endregion
        #region Menu
        public static void Menu()
        {
            Logica logic = new Logica();

            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\tMenu principal");
                    Console.WriteLine();
                    Console.WriteLine("0 - Salir");
                    Console.WriteLine("1 - Mantenimiento compañias");
                    Console.WriteLine("2 - Mantenimiento Terminal Nacional");
                    Console.WriteLine("3 - Mantenimiento Terminal Internacional");
                    Console.WriteLine("4 - Agregar viaje");
                    Console.WriteLine("5 - Listado todas las compañias");
                    Console.WriteLine("6 - Listado terminales");
                    Console.WriteLine("7 - Listado viajes por fecha");
                    Console.WriteLine("8 - Listado viajes por terminal, mes, año");
                    Console.WriteLine();


                    opcion = PidoNumero("Seleccione una de las opciones: ", 0, 8);
                    switch (opcion)
                    {
                        case 0:
                            Console.WriteLine("Cerrando programa");
                            Console.ReadLine();
                            break;

                        case 1:
                            MantenimientoCompania(logic);
                            Console.ReadLine();
                            break;

                        case 2:
                            MantenimientoTermMnacional(logic);
                            Console.ReadLine();
                            break;

                        case 3:
                            MantenimientoTermMInter(logic);
                            Console.ReadLine();
                            break;

                        case 4:
                            AgregarViaje(logic);
                            Console.ReadLine();
                            break;
                            
                            
                        case 5:
                            ListadoCompanias(logic);
                            Console.ReadLine();
                            break;

                        case 6:
                            ListadoTerminales(logic);
                            Console.ReadLine();
                            break;

                        case 7:
                            ListadoViajesFecha(logic);
                            Console.ReadLine();
                            break;

                        case 8:
                            ListadoTermMA(logic);
                            Console.ReadLine();
                            break;



                    }
                }


                catch (Exception ex)
                {
                    Console.WriteLine("Error inesperado: " + ex.Message);
                    Console.ReadLine();
                }
            }
        }

        #endregion
        #region Mantenimiento Compania
        public static void MantenimientoCompania(Logica aComp)
        {
            // Petición y validación de datos
            while (true)
            {
                try
                {
                    string nombreComp = PidoPalabra("Ingrese el nombre de la compania: ");
                    Compania compania = aComp.BuscarCompania(nombreComp);
                    if (compania == null)
                    {
                        int opcion = PidoNumero("No existe ninguna compania con ese nombre, ingrese 1 si quiere darla de alta o 0 para salir: ", 0, 1);
                        if (opcion == 0) 
                        {
                            Console.WriteLine("Saliendo");
                            Console.ReadLine();
                            break;                        }

                        else if (opcion == 1)
                        {
                            Console.WriteLine("Para dar de de alta la compania ingrese los siguientes datos: ");
                            Console.WriteLine();
                            string direccionComp = PidoPalabra("Ingrese la direccion : ");
                            int telComp = PidoNumero("Ingrese el numero de telefono: ", 089999999, 099999999);

                            Compania compaia = new Compania(nombreComp, direccionComp, telComp);
                            Console.WriteLine("Compania dada de alta con exito");
                            Console.WriteLine("Presione la tecla ENTER para seguir");
                            Compania nuevacompania = new Compania(nombreComp, direccionComp, telComp);
                            aComp.AgregarCompania(nuevacompania);
                            break;
                        }

                    }

                    else
                    {
                        int opcion = PidoNumero("Ingrese 1 para eliminar, 2 para editar, 3 para salir ", 1, 3);
                        if (opcion == 1)
                        {
                            aComp.EliminarCompania(compania);
                            Console.WriteLine("Eliminación con éxito");

                            break;
                        }
                        else if (opcion == 2)
                        {
                            bool modificar;
                            Console.WriteLine("Ingrese la letra T si desea hacer cambios en el numero telefonico o enter para seguir");
                            modificar = ("T" == Console.ReadLine().Trim().ToUpper());
                            if (modificar)
                            {
                                compania.Telefono = PidoNumero("Ingrese el nuevo telefono: ", 089999999, 099999999);
                                Console.WriteLine("Telefono modificado con exito");
                            }

                            Console.WriteLine("Ingrese la letra D si desea cambiar la direccion: ");
                            modificar = ("D" == Console.ReadLine().Trim().ToUpper());
                            if (modificar)
                            {
                                compania.Direccion = PidoPalabra("Ingrese la nueva direccion: ");
                                Console.WriteLine("Direccion modificada con exito");
                            }
                            Console.WriteLine("\nDatos actuales de la compania:");
                            Console.WriteLine("\n" + compania.ToString());
                            Console.ReadLine();
                            break;
                        }
                        else if (opcion == 3)
                        {
                            Console.WriteLine("Saliendo");
                            break;
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }

            }


        }
        #endregion
        #region Mantenimiento TerminalNacional
        public static void MantenimientoTermMnacional(Logica aTermNac)
        {
            // Petición y validación de datos
            while (true)
            {
                try
                {
                    string codigoTerm = PidoPalabra("Ingrese el codigo de la terminal: ");
                    if (codigoTerm.Length != 6) 
                    {
                        throw new Exception("El codigo debe tener 6 letras");
                    }
                    Terminal terminal = aTermNac.BuscarTerminal(codigoTerm);
                   
                    if (terminal == null)
                    {
                        int opcion = PidoNumero("No existe ninguna terminal con ese codigo, ingrese 1 si quiere darla de alta o 0 para salir: ", 0, 1);
                        if (opcion == 0)
                        {
                            Console.WriteLine("Saliendo");
                            Console.ReadLine();
                            break;
                        }

                        else if (opcion == 1)
                        {
                            Console.WriteLine("Para dar de de alta la terminal ingrese los siguientes datos: ");
                            Console.WriteLine();
                            string destinoTerm = PidoPalabra("Ingrese el destino : ");
                            bool taxisTerm = PidoBoolean("Tiene taxi? SI/NO: ");
                            Console.WriteLine("Terminal dada de alta con exito");
                            Console.WriteLine("Presione la tecla ENTER para seguir");
                            TerminalNacional terminalnueva = new TerminalNacional(destinoTerm, codigoTerm, taxisTerm);
                            aTermNac.AgregarTerminal(terminalnueva);
                            break;
                        }
                    }

                        else if (terminal != null)
                        {

                            int opcion = PidoNumero("Se encontro un terminal con ese codigo. Ingrese 1 para eliminar, 2 para editar, 3 para salir ", 1, 3);
                            if(opcion == 1)
                            {
                                aTermNac.EliminarTerminal(terminal);
                                Console.WriteLine("Eliminado con exito");
                                break;

                            }

                            if(opcion == 2)
                            {
                            bool modificar;
                            Console.WriteLine("Ingrese la letra T si desea hacer cambios en el estado de taxis");
                            modificar = ("T" == Console.ReadLine().Trim().ToUpper());
                            if (modificar)
                            {
                                ((TerminalNacional)terminal).Taxis = PidoBoolean("Taxis si o no?");
                                Console.WriteLine("Estado de taxis modificado con exito");
                            }

                            Console.WriteLine("Ingrese la letra D si desea cambiar de destino: ");
                            modificar = ("D" == Console.ReadLine().Trim().ToUpper());
                            if (modificar)
                            {
                                terminal.Destino = PidoPalabra("Ingrese el nuevo destino: ");
                                Console.WriteLine("Destino modificado con exito");
                            }
                            }

                            else if (opcion == 3)
                            {
                                Console.WriteLine("Saliendo");
                                Console.ReadLine();
                            }
                            Console.WriteLine("\nDatos actuales de la terminal:");
                            Console.WriteLine("\n" + terminal.ToString());
                            Console.ReadLine();
                            break;
                        }

                    }

                    catch (Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                    }
        }
    }
            
        
        #endregion
        #region Mantenimiento Terminal Internacional
        public static void MantenimientoTermMInter(Logica aTermInt)
        {
            // Petición y validación de datos
            while (true)
            {
                try
                {
                    string codigoTerm = PidoPalabra("Ingrese el codigo de la terminal: ");
                    if (codigoTerm.Length != 6)
                    {
                        throw new Exception("El codigo debe tener 6 letras");
                    }
                    Terminal terminal = aTermInt.BuscarTerminal(codigoTerm);
                    if (terminal == null)
                    {
                        int opcion = PidoNumero("No existe ninguna terminal con ese codigo, ingrese 1 si quiere darla de alta o 0 para salir: ", 0, 1);
                        if (opcion == 0)
                        {
                            Console.WriteLine("Saliendo");
                            Console.ReadLine();
                            break;
                        }

                        else if (opcion == 1)
                        {
                            Console.WriteLine("Para dar de de alta la terminal ingrese los siguientes datos: ");
                            Console.WriteLine();
                            string destinoTerm = PidoPalabra("Ingrese el destino : ");
                            string paisTerm = PidoPalabra("Ingrese el Pais de destino: ");

                            TerminalInternacional terminalnueva = new TerminalInternacional(destinoTerm, codigoTerm, paisTerm);
                            aTermInt.AgregarTerminal(terminalnueva);
                            Console.WriteLine("Compania dada de alta con exito");
                            Console.WriteLine("Presione la tecla ENTER para seguir");
                            break;
                        }

                    }

                    else
                    {
                        int opcion = PidoNumero("La terminal ya existe .Ingrese 1 para eliminar, 2 para editar, 3 para salir ", 1, 3);
                        if (opcion == 1)
                        {
                            aTermInt.EliminarTerminal(terminal);
                            Console.WriteLine("Eliminación con éxito");

                            break;
                        }

                        else if (opcion == 2)
                        {
                            bool modificar;
                            Console.WriteLine("Ingrese la letra P si desea cambiar el pais de destino o enter para seguir");
                            modificar = ("P" == Console.ReadLine().Trim().ToUpper());
                            if (modificar)
                            {
                                ((TerminalInternacional)terminal).Pais = PidoPalabra("Ingrese el nuevo pais de destino: ");
                                Console.WriteLine("Pais modificado con exito");
                            }

                            Console.WriteLine("Ingrese la letra D si desea cambiar de destino: ");
                            modificar = ("D" == Console.ReadLine().Trim().ToUpper());
                            if (modificar)
                            {
                                terminal.Destino = PidoPalabra("Ingrese el nuevo destino: ");
                                Console.WriteLine("Destino modificado con exito");
                            }
                            Console.WriteLine("\nDatos actuales de la terminal:");
                            Console.WriteLine("\n" + terminal.ToString());
                            Console.ReadLine();
                            break;
                        }

                        else if (opcion == 3)
                        {
                            Console.WriteLine("Saliendo");
                            Console.ReadLine();
                            break;
                        }
                    }
                }


                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }

            }
      }
        #endregion
        #region Agregar Viaje
        public static void AgregarViaje(Logica aViaje) 
        {
            while (true)
            {
                string nombreComp = PidoPalabra("Ingrese el nombre de la compania: ");
                Compania compania = aViaje.BuscarCompania(nombreComp);
                if (compania == null)
                {
                    Console.WriteLine("No hay compania con ese nombre ");
                    break;
                }
               
                
                string terminalDestino = PidoPalabra("Ingrese la terminal de destino: ");
                Terminal terminal = aViaje.BuscarTerminal(terminalDestino);
                if(terminal == null) 
                {
                    Console.WriteLine("No hay terminal con ese destino asociado");
                    break;
                }

                DateTime fechayhoraSalida = PidoDateTime("Ingrese fecha y hora de salida: Formato aaaa, m, d, horas, minutos ");
                Console.WriteLine();
                DateTime fechayhoraLlegada = PidoDateTime("Ingrese fecha y hora llegada : Formato aaaa, m , d horas , minutos");

                while (fechayhoraSalida > fechayhoraLlegada)
                {
                    Console.WriteLine("La fecha de llegada no puede ser anterior a la de salida.");
                    fechayhoraLlegada = PidoDateTime("Ingrese nuevamente fecha y hora llegada : Formato aaaa, m , d horas , minutos");
                }

                while (fechayhoraSalida <= fechayhoraLlegada)
                {
                    Console.WriteLine();
                    int precioPasaje = PidoNumero("Ingrese el valor del pasaje: ", 1, 15000);
                    int cantidadPasajeros = PidoNumero("Ingrese cantidad de pasajeros :", 1, 50);
                    int andenNumero = PidoNumero("Ingrese el numero de anden: ", 1, 35);

                    Viajes viaje = new Viajes(fechayhoraSalida, fechayhoraLlegada, precioPasaje, andenNumero, cantidadPasajeros, compania, terminal);

                    aViaje.AgregarViaje(viaje);
                    Console.WriteLine("Viaje agregado con exito");
                    break;
                }

                
    
                break;
               
                }
            }
        
        #endregion
        #region Listado Companias
        public static void ListadoCompanias(Logica logic)
        {
            Console.WriteLine("Listado de companias");
            Console.WriteLine();
            List<Compania> listaCompanias = logic.Listado();
            foreach (var variable in listaCompanias)
            {
                Console.WriteLine(variable.ToString());
                Console.WriteLine();

            }
        }

        #endregion
        #region Listado Terminales
        public static void ListadoTerminales(Logica logic) 
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("Listado de terminales");
                    int elijo = PidoNumero("Seleccione 1 para ver el listado de Terminales Nacionales, 2 para el listado de Terminales Internacionales, 3 para salir: ", 1, 3);


                    if (elijo == 1)
                    {
                        Console.WriteLine("Listado de Terminales Nacionales");
                        List<TerminalNacional> listaTerminalNacional = logic.ListaNacional();
                        if (listaTerminalNacional.Count == 0)
                        {
                            Console.WriteLine("No hay resultados - Lo sentimos");
                            break;
                        }
                        foreach (var variable in listaTerminalNacional)
                        {
                            int contadorviajes = logic.ContarViajes(variable);
                            Console.WriteLine(variable.ToString());
                            Console.WriteLine("Viajes asociados:" + contadorviajes);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Aprete la tecla enter para seguir");
                        break;
                    }

                    else if (elijo == 2)
                    {
                        Console.WriteLine("Listado de Terminales Internacionales");
                        List<TerminalInternacional> listaTerminalInter = logic.ListaInternacional();
                        if (listaTerminalInter.Count == 0)
                        {
                            Console.WriteLine("No hay resultados - Lo sentimos");
                            break;
                        }
                        foreach (var variable in listaTerminalInter)
                        {
                            int contadorviajes = logic.ContarViajes(variable);
                            Console.WriteLine(variable.ToString());
                            Console.WriteLine("Viajes asociados:" + contadorviajes);
                            Console.WriteLine();

                        }
                        Console.WriteLine("Aprete la tecla enter para seguir");
                        break;
                    }

                    else if (elijo == 3)
                    {
                        Console.WriteLine("Saliendo");
                        break;
                    }
                }



                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }
        #endregion
        #region Listado Viaje por fecha
        public static void ListadoViajesFecha(Logica logic) 
        {
            while (true) 
            {
                try
                {
                    Console.WriteLine("Listado de viajes dentro de un rango de fechas");
                    DateTime fechaInicio = PidoDateTime2("Ingrese la fecha de inicio del rango (Formato aaaa, m, d, horas, minutos): ");
                    DateTime fechaFin = PidoDateTime2("Ingrese la fecha de fin del rango (Formato aaaa, m, d, horas, minutos): ");
                    while (fechaInicio > fechaFin)
                    {
                        Console.WriteLine("La fecha de fin no puede ser anterior a la de inicio");
                        fechaFin = PidoDateTime2("Ingrese fecha y hora llegada nuevamente: Formato aaaa, m , d horas , minutos");
                    }

                    List<Viajes> coleccion = logic.ListarPorfecha(fechaInicio, fechaFin);
                    if (coleccion.Count == 0) 
                    {
                        Console.WriteLine("No hay viajes dentro del rango de fechas especificado.");
                        break;
                    }

                    foreach (var variable in coleccion) 
                    {
                        Console.WriteLine();
                        Console.WriteLine("Datos del viaje");
                        Console.WriteLine(variable.ToString());
                        Console.WriteLine();
                        
                    }
                    Console.WriteLine("Presione la tecla enter para seguir: ");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        #endregion
        #region Listado Terminal Mes anio
        public static void ListadoTermMA(Logica logic) 
        {
            while (true) 
            {
                try
                {
                    Console.WriteLine("Listado en base a la Terminal, mes y anio");
                    string codigoTerm = PidoPalabra("Ingrese el codigo de la terminal: ");
                    if(codigoTerm.Trim().Length != 6)
                    {
                        throw new Exception("El codigo debe tener 6 letras");
                    }
                    Terminal terminal = logic.BuscarTerminal(codigoTerm);
                    if (terminal == null) 
                    {
                        Console.WriteLine("No existe terminal con ese codigo");
                        Console.WriteLine("Saliendo");
                        Console.ReadLine();
                        break;
                    }

                    int mes = PidoNumero("Ingrese el número del mes (1 al 12): ", 1, 12);
                    int anio = PidoNumero("Ingrese el año: ",1900,2100);
                    List<Viajes> coleccion = logic.ListadoViajesTerminalMesAño(terminal, mes, anio);
                    if (coleccion.Count == 0)
                    {
                        Console.WriteLine("No hay viajes encontrados con el parametro de busca que seleccionaste");
                        break;
                    }
                    foreach (var variable in coleccion)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Datos del viaje");
                        Console.WriteLine(variable.ToString());
                        Console.WriteLine();
                        
                    }

                    Console.WriteLine("Presione la tecla ENTER para continuar");
                    break;


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    if (SalirDeLaOpcion()) 
                    break;
                }
            }
        }
        #endregion 
    }
}