using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.Logica
{
    //Esta clase permite que se puedan mantener los datos correctamente en el programa
    internal class Cla_Persistencia
    {
        #region atributos
        static Cls_mensaje Msg = new Cls_mensaje();
        public static Cla_Persona[] PArray_Persona {  get; set; }
        public int Indice_Persona { get; set; }
        #endregion

        #region Inicialización Array
        public Cla_Persistencia() 
        {
            if (PArray_Persona == null)
                PArray_Persona = new Cla_Persona[20];
        }
        #endregion

        #region Metodos
        public void Almacenar_Personas(Cla_Persona[] PMatriz)
        {
            //Se guarda en la matriz de la clase lo que tenga almacenado la matriz de personas en pantalla
            PArray_Persona = PMatriz;
        }
        public Cla_Persona[] Cargar_Personas()
        {
            //Se envía solo que está actualmente almacenado en la matriz de la clase
            return PArray_Persona;
        }

        public void Mostrar_Arreglo()
        {
            if (PArray_Persona[0] != null)
            {
                Msg.mensaje(PArray_Persona[0].Nombre);
            }
        }
        #endregion
    }
}
