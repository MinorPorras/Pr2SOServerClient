using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor.Logica
{
    public class Cls_mensaje
    {
        #region Methods

        public int Salir()
        {
            return Alerta("¿Desea cerrar la aplicación?", "Cerrar");
        }

        public int Grabar()
        {
            return Alerta("¿Desea grabar este registro?", "Grabar");
        }

        public int Eliminar()
        {
            return Alerta("¿Desea Eliminar este registro?", "Eliminar");
        }

        private int Alerta(string pregunta, String titulo)
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

        #endregion
    }
}
