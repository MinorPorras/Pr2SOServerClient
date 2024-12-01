using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor.Logica
{
    internal class Cls_mensaje
    {
        public int Salir()
        {
            return alerta("¿Desea cerrar la aplicación?", "Cerrar");
        }

        public int Grabar()
        {
            return alerta("¿Desea grabar este registro?", "Grabar");
        }

        public int Eliminar()
        {
            return alerta("¿Desea Eliminar este registro?", "Eliminar");
        }
        private int alerta(string pregunta, String titulo)
        {
            DialogResult result = MessageBox.Show(pregunta, titulo, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    return 1;
                case DialogResult.No:
                    return 0;
                case DialogResult.Cancel:
                    return -1;

            }
            return 0;
        }

        public void mensaje(string texto) 
        { 
            MessageBox.Show(texto, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
