using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.Logica
{
    public class Cla_Persona
    {
        #region Atributos

        public int cedula { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public int Num_Mesa { get; set; }
        public string Dsc_Mesa { get; set; }

        #endregion

        #region Procedimientos

        public Cla_Persona(int PCedula, string PNombre, bool PEstado, int PNum_Mesa, string PDsc_Mesa)
        {
            cedula = PCedula;
            Nombre = PNombre;
            Estado = PEstado;
            Num_Mesa = PNum_Mesa;
            Dsc_Mesa = PDsc_Mesa;
        }

        public Cla_Persona() { }

        public int Buscar_Persona(Cla_Persona[] PArray_Persona, int ced)
        {
            for (int i = 0; i < PArray_Persona.Length; i++)
            {
                if (PArray_Persona[i] != null)
                {
                    if (PArray_Persona[i].cedula == ced)
                    {
                        return i;
                    }
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }

        public int Obtener_Indice(Cla_Persona[] PArray_Persona, int cedula)
        {
            for (int i = 0; i < PArray_Persona.Length; i++)
            {
                if (PArray_Persona[i] == null)
                {
                    if (PArray_Persona[i].cedula == cedula)
                    {
                        return i;
                    }
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }

        #endregion
    }
}
