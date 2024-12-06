using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Cliente
{

    public partial class Frm_Cliente : Form
    {
        public Frm_Cliente() => InitializeComponent();

        private void Frm_Cliente_Load(object sender, EventArgs e) { }

        #region Attributes

        TcpClient client = new TcpClient();
        ASCIIEncoding encoder = new ASCIIEncoding();
        NetworkStream stream;
        IPEndPoint endPoint;
        byte[] buffer;
        byte[] message;
        int bytesRead;

        #endregion

        #region Buttons

        private void Btn_Conectar_Click(object sender, EventArgs e)
        {
            Btn_Conectar.Enabled = false;


            if (Txt_Servidor.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese una direcci�n IP para el servidor", "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!client.Connected)
                {
                    try
                    {
                        client = new TcpClient();
                        endPoint = new IPEndPoint(IPAddress.Parse(Txt_Servidor.Text), 30000);
                        client.Connect(endPoint);
                        stream = client.GetStream();
                        buffer = encoder.GetBytes("Hello Server!");
                        stream.Write(buffer, 0, buffer.Length);
                        stream.Flush();

                        message = new byte[4096];
                        bytesRead = stream.Read(message, 0, 4096);

                        MessageBox.Show("Conexi�n Realizada con Exito");

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        client.Close();
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show(Exc.ToString());
                    }
                }
            }
        }

        private void Btn_Desconectar_Click(object sender, EventArgs e)
        {
            Btn_Conectar.Enabled = true;
            if (client.Connected)
                try
                {
                    client.Close();
                    MessageBox.Show("Desconexi�n Realizada con Exito");

                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.ToString());
                }

        }

        private void Bnt_Enviar_Click(object sender, EventArgs e)
        {
            stream = client.GetStream();
            buffer = encoder.GetBytes(Txt_Mensaje.Text.Trim());
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();


            message = new byte[4096];
            bytesRead = stream.Read(message, 0, 4096);

            encoder.GetString(message, 0, bytesRead);
            Txt_Mensaje.Text = encoder.GetString(message, 0, bytesRead).ToString();
        }

        #endregion

    }
}
