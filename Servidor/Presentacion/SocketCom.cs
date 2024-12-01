using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using Servidor.Presentacion;
using Servidor.Logica;
using System.Net.Http.Headers;


namespace Servidor
{
    public partial class SocketCom : Form
    {
        #region Atributos
        static Cla_Persona[] Array_Persona = new Cla_Persona[20];
        Cls_mensaje Obj_Util = new Cls_mensaje();
        static Cla_Persistencia Obj_Persistencia = new Cla_Persistencia();

        private TcpListener tcpListener;
        private Thread listenThread;
        private String lastMessage;
        private int clientesConectados;
        private bool listening;
        #endregion
        public SocketCom()
        {
            InitializeComponent();
        }

        #region Eventos
        private void Principal_Load(object sender, EventArgs e)
        {
            Txt_Mensajes.Text = "Servidor Iniciado. Esperando por clientes...\n";
            tcpListener = new TcpListener(IPAddress.Any, 30000);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listening = true;
            listenThread.Start();
            Array_Persona = Obj_Persistencia.Cargar_Personas();
        }
        #endregion

        #region procedimientos
        private void ListenForClients()
        {
            this.tcpListener.Start();

            try
            {
                while (listening)
                {
                    if (this.tcpListener.Pending())
                    {
                        // Bloquea hasta que un cliente se conecte al servidor
                        TcpClient client = this.tcpListener.AcceptTcpClient();

                        // Crear un hilo para manejar la comunicación con el cliente conectado
                        clientesConectados++;

                        if (InvokeRequired)
                            Invoke(new Action(() => Txt_Clientes.Text = clientesConectados.ToString()));

                        Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                        clientThread.Start(client);
                    }
                    else
                    {
                        Thread.Sleep(100); // Espera un corto período antes de verificar nuevamente
                    }
                }
            }
            catch (SocketException ex)
            {
                // Manejar excepción de socket
                Console.WriteLine("Excepción de socket: " + ex.Message);
            }
            finally
            {
                this.tcpListener.Stop();
            }
        }


        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] message = new byte[4096];
            int bytesRead;
            while (true)
            {
                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                }
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    clientesConectados--;

                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => Txt_Clientes.Text = clientesConectados.ToString()));
                    }
                    break;
                }

                //message has successfully been received
                //encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
                lastMessage = encoder.GetString(message, 0, bytesRead);


                if (InvokeRequired)
                {
                    Obj_Util.mensaje(lastMessage);
                    Invoke(new Action(() => Txt_Mensajes.Text = "\n" + lastMessage));
                    string Opcion = Validar_Peticion(Txt_Mensajes.Text);
                    byte[] buffer = new byte[4096];

                    buffer = encoder.GetBytes(Opcion);
                    Invoke(new Action(() => Txt_Mensajes.Text += "Respuesta: " + Opcion + "\r\n"));
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();
                }
            }
            // tcpClient.Close();
            // clientesConectados--;

            //if (InvokeRequired)
            //{
            //  Invoke(new Action(() => Txt_Clientes.Text = clientesConectados.ToString()));
            //}

        }
        public string Validar_Peticion(string Peticion)
        {
            int Indice_APersona = -1;
            
            for (int i = 1; i < Peticion.Trim().Length; i++)
            {
                System.Console.Write("Posición: {0} Letra {1}", i, Peticion.Substring(i-1, 1));
            }
            try
            {
                if (Peticion != "Hello Server!")
                {
                    int cedula = int.Parse(Peticion.Substring(1, 9));
                    Indice_APersona = Validar_Cedula(cedula);
                    if (Indice_APersona != -1)
                    {
                        if (Array_Persona[Indice_APersona].Estado)
                        {
                            return "1" + Array_Persona[Indice_APersona].Nombre +
                                Array_Persona[Indice_APersona].Num_Mesa +
                                Array_Persona[Indice_APersona].Dsc_Mesa;
                        }
                        else
                        {
                            return "2" + Array_Persona[Indice_APersona].Nombre +
                                "Aparece Fallecido";
                        }
                    }
                    else
                    {
                        return "3Persona no registrada";
                    }
                }
                else
                {
                    return "";
                }

            }
            catch 
            {
                return "4Formato invalido";
            }
        }

        private int Validar_Cedula(int cedula)
        {
            for (int i = 0; i < Array_Persona.GetLength(0); i++)
            {
                if (Array_Persona[i] != null)
                    if (Array_Persona[i].cedula == cedula)
                        return i;
            }
            return -1;
        }
        #endregion

        #region botones
        private void BTN_Salir_Click(object sender, EventArgs e)
        {
            if (clientesConectados == 0)
            {
                listening = false; // Cambiar el flag para detener el hilo de escucha
                tcpListener.Stop();
                this.listenThread.Abort();
                Close();
                MenuInicio menu = new MenuInicio();
                menu.Show();
            }
            else
            {
                Obj_Util.mensaje("No se puede salir del programa, existen clientes conectados");
            }

        }
        #endregion
    }
}
        
