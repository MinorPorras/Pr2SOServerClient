using Servidor.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor.Presentacion
{
    public partial class MenuInicio : Form
    {
        public MenuInicio() => InitializeComponent();

        #region Atributos

        Cls_mensaje obj_util = new Cls_mensaje();
        static Cla_Persona Obj_Persona;
        static Cla_Persona[] array_Persona;

        #endregion

        #region Botones

        private void BTN_SocketCom_Click(object sender, EventArgs e)
        {
            Hide();
            var socket = new SocketCom();
            socket.Show();
        }

        private void BTN_Mantenimiento_Click(object sender, EventArgs e)
        {
            Hide();
            var mantenimiento = new Mantenimiento();
            mantenimiento.Show();
        }
        #endregion

        #region Eventos

        private void MenuInicio_Load(object sender, EventArgs e)
        {

        }

        private void MenuInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                if (obj_util.Salir() == 1)
                {
                    Dispose();
                }
            }
            else if (e.KeyChar == 49)
            {
                BTN_Mantenimiento.PerformClick();
            }
            else if (e.KeyChar == 50)
            {
                BTN_SocketCom.PerformClick();
            }
        }

        #endregion
    }
}
