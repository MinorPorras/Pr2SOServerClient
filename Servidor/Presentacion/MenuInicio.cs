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
        #region atributos
        Cls_mensaje obj_util = new Cls_mensaje();
        static Cla_Persona Obj_Persona;
        static Cla_Persona[] array_Persona;
        #endregion

        public MenuInicio()
        {
            InitializeComponent();
        }

        #region botones
        private void BTN_SocketCom_Click(object sender, EventArgs e)
        {
            this.Hide();
            SocketCom socket = new SocketCom();
            socket.Show();
        }

        private void BTN_Mantenimiento_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimiento mantenimiento = new Mantenimiento();
            mantenimiento.Show();
        }
        #endregion

        #region eventos
        private void MenuInicio_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void MenuInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                if(obj_util.Salir() == 1)
                {
                    Dispose();
                }
            }
            else if (e.KeyChar == 49){
                BTN_Mantenimiento.PerformClick();
            }
            else if (e.KeyChar == 50)
            {
                BTN_SocketCom.PerformClick();
            }
        }
    }
}
