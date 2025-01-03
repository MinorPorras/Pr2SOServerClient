﻿using Servidor.Logica;
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
    public partial class Mantenimiento : Form
    {
        #region Atributos

        public Mantenimiento()
        {
            InitializeComponent();
            cbxEstado.Items.Add("Activo");
            cbxEstado.Items.Add("Inactivo");
            cbxEstado.SelectedIndex = 0;
        }

        Cls_mensaje Msg = new Cls_mensaje();
        static Cla_Persistencia obj_Persistencia = new Cla_Persistencia();
        static Cla_Persona[] Array_Persona = new Cla_Persona[20];
        static Cla_Persona obj_Persona = new Cla_Persona();

        static int Indice_Persona = 0;
        static int Indice_Busqueda = -0;

        #endregion

        #region Botones

        private void BTN_Salir_Click(object sender, EventArgs e)
        {
            obj_Persistencia.Almacenar_Personas(Array_Persona);
            Close();
            MenuInicio menu = new MenuInicio();
            menu.Show();
        }
        private void BTN_Grabar_Click(object sender, EventArgs e)
        {
            if (Validar_Campos())
            {
                if (Msg.Grabar() == 1)//Si se presiona el botón de Si en la alerta
                {
                    if (Grabar_Campos())
                    {
                        Msg.mensaje("Información guardada con exito");
                        Limpiar();
                    }
                }
                else
                {
                    Msg.mensaje("Error al grabar la información");
                }
            }
            else
            {
                Msg.mensaje("Error al grabar la información, revise los datos");
                txtCedula.SelectAll();
            }
        }

        private void BTN_Eliminar_Click(object sender, EventArgs e)
        {
            if (Msg.Eliminar() == 1)
            {
                Borrar();
                Limpiar();
            }
        }

        private void BTN_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Obtener_Indice();
        }
        #endregion

        #region Metodos

        private void Limpiar()
        {
            txtCedula.Clear();
            txtCentro.Clear();
            txtNombre.Clear();
            txtNumMesa.Clear();
        }

        private void cargar_informacion()
        {
            txtCedula.Text = Array_Persona[Indice_Busqueda].cedula.ToString();
            txtNombre.Text = Array_Persona[Indice_Busqueda].Nombre;
            txtNumMesa.Text = Array_Persona[Indice_Busqueda].Num_Mesa.ToString();
            txtCentro.Text = Array_Persona[Indice_Busqueda].Dsc_Mesa;
            cbxEstado.Text = Array_Persona[Indice_Busqueda].Estado == true ? "Activo" : "Inactivo";
        }

        private bool Validar_Campos()
        {
            if (string.IsNullOrEmpty(txtCedula.Text))
            {
                Msg.mensaje("Debe de digitar un número de cedula");
                txtCedula.Select();
                return false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                Msg.mensaje("Debe de digitar un nombre");
                txtNombre.Select();
                return false;
            }

            if (string.IsNullOrEmpty(txtNumMesa.Text))
            {
                Msg.mensaje("Debe de digitar un número de mesa");
                txtNumMesa.Select();
                return false;
            }

            if (string.IsNullOrEmpty(txtCentro.Text))
            {
                Msg.mensaje("Debe de digitar un centro de votación");
                txtCentro.Select();
                return false;
            }

            if (cbxEstado.SelectedIndex == -1)
            {
                Msg.mensaje("Debe de seleccionar un estado");
                cbxEstado.Select();
                return false;
            }

            return true;
        }

        private bool Validar_Cedula()
        {
            if (txtCedula.TextLength < 9)
            {
                Msg.mensaje("Debe de digitar un número de cedula válido [999999999]");
                txtCedula.Focus();
                return false;
            }
            else
            {
                Indice_Busqueda = obj_Persona.Buscar_Persona(Array_Persona, Convert.ToInt32(txtCedula.Text));
                if (Indice_Busqueda != -1) //SI encuentra a una persona con esa cedula
                {
                    cargar_informacion();
                    Msg.mensaje("El número de cédula ya esta ingresado");
                    txtCedula.Focus();
                    Indice_Persona = Indice_Busqueda;
                    //mod = true;
                    BTN_Eliminar.Enabled = true;
                    return false;
                }
                else
                {
                    Obtener_Indice();
                    BTN_Eliminar.Enabled = false;
                    return true;
                }
            }
        }

        private void Obtener_Indice()
        {
            for (int i = 0; i <= Array_Persona.Length; i++)
            {
                if (Array_Persona[i] == null)
                {
                    Indice_Persona = i;
                    return;
                }
            }
        }

        private bool Grabar_Campos()
        {
            try
            {
                Array_Persona[Indice_Persona] = new Cla_Persona();
                Array_Persona[Indice_Persona].cedula = Convert.ToInt32(txtCedula.Text);
                Array_Persona[Indice_Persona].Nombre = txtNombre.Text;

                if (cbxEstado.SelectedIndex == 0)
                    Array_Persona[Indice_Persona].Estado = true;
                else
                    Array_Persona[Indice_Persona].Estado = false;

                Array_Persona[Indice_Persona].Num_Mesa = int.Parse(txtNumMesa.Text);
                Array_Persona[Indice_Persona].Dsc_Mesa = txtCentro.Text;

                Obtener_Indice();
                Indice_Persona++;
                return true;
            }
            catch (Exception ex)
            {
                Msg.mensaje("Error al grabar el registro: " + ex.Message.ToString());
                return false;
            }
        }

        private bool Borrar()
        {
            try
            {
                Array_Persona[Indice_Persona].Estado = false;
                Msg.mensaje("Persona dada de baja correctamente");
                return true;
            }
            catch (Exception ex)
            {
                Msg.mensaje("Error al dar de baja el registro: " + ex.Message.ToString());
                return false;
            }
        }
        #endregion

        #region Eventos

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            txtCedula.Focus();
            BTN_Eliminar.Enabled = false;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//Tecla enter
            {
                Validar_Cedula();
            }
        }

        #endregion

    }
}
