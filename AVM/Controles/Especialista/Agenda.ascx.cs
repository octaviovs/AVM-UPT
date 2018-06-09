﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Core.Model;
using Core.Presenter;
using Core.View;
using System.Data;

namespace AVM.Controles.Especialista
{
    public partial class Agenda : System.Web.UI.UserControl,IConsulta
    {

     
        WConsulta vistaConsulta;
        CEspecialista objLoggerinf;
        CAlumno ObjTmAlumno;// objeto donde se guardan los datos de la tabla 

        public GridViewRow FilaSeleccionada
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            objLoggerinf = (CEspecialista)Session["UsuarioLogeadoEspecialista"];
            if (objLoggerinf != null && objLoggerinf.Rol == 2)
            {
                vistaConsulta = new WConsulta(this);
                ObjTmAlumno = new CAlumno();
                vistaConsulta.ListarMedicoAgenda(8, objLoggerinf);
            }
            else
            {
         
            }
        }


        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = "";
            FilaSeleccionada = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            if (e.CommandName == "Cancelar")
            {
                codigo = (((Label)FilaSeleccionada.FindControl("LabelId")).Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script> $('#ModalEliminar').modal('show');</script>", false);
                TextBoxPkReservacion.Text = codigo;
            }
            if (e.CommandName == "Realizar")
            {
                string id = (((Label)FilaSeleccionada.FindControl("LabelId")).Text);// id de la reservacion
                string matri = (((Label)FilaSeleccionada.FindControl("LabelMatri")).Text);// id del alumno
                string TipoUsuario = (((Label)FilaSeleccionada.FindControl("labelTipo")).Text);// id del alumno


                vistaConsulta.Datosalumno(11, matri);

                ObjTmAlumno.pk_Reservacion = id;// de la reservacion
                ObjTmAlumno.tipo_usuario = TipoUsuario; //agregamos el tipo de usuario

                Session.Add("DatosCitaAlumno", ObjTmAlumno); // se guardar los datos del alumno temporalmente
                Response.Redirect("NuevaConsulta.aspx", true);// no direcciona a la pagina default de la master
            }

            FilaSeleccionada.Dispose();
        }

        #region IConsulta
        public CConsulta DatosPasienteConsulta
        {
            get
            {
                CConsulta Datos = new CConsulta();

                return Datos;
            }
        }
        public CConsulta NewConsulta
        {
            get
            {
                return null;
            }
        }
        int IConsulta.EliminarConsulta
        {
            get
            {
                return 0;

            }
        }
        public DataSet ListadoConsulta
        {
            set
            {
                if (value != null)
                {
                    GridViewCitasPasiente.DataSource = value;
                    GridViewCitasPasiente.DataBind();
                    if (GridViewCitasPasiente.Rows.Count <= 0)
                    {
                        GridViewCitasPasiente.Visible = true;
                    }
                }

            }
        }
        public DataSet Odontograma
        {
            set
            {

            }
        }
        public List<CConsulta> LlenarComboEspecialidad
        {
            get
            {
                return null;

            }

            set
            {
               
            }
        }
        public List<CConsulta> LlenarComboEspecialista
        {
            get
            {
                return null;

            }

            set
            {
              
            }
        }
        public List<CConsulta> LlenarComboHora
        {
            get
            {
                return null;            }

            set
            {
              
            }
        }
        public DataSet HistorialCitas // se usa para obtener los datos del alumno seleccionado
        {
            set
            {
                if (value != null)
                {
                    ObjTmAlumno.alu_E1 = Convert.ToInt16(value.Tables[0].Rows[0][1].ToString());
                    ObjTmAlumno.alu_E2 = Convert.ToInt16(value.Tables[0].Rows[0][2].ToString());
                    ObjTmAlumno.alu_E3 = Convert.ToInt16(value.Tables[0].Rows[0][3].ToString());
                    ObjTmAlumno.alu_NumControl = value.Tables[0].Rows[0][5].ToString();
                    ObjTmAlumno.alu_Nombre = value.Tables[0].Rows[0][6].ToString();
                    ObjTmAlumno.alu_ApePaterno = value.Tables[0].Rows[0][7].ToString();
                    ObjTmAlumno.alu_ApeMaterno = value.Tables[0].Rows[0][8].ToString();
                    ObjTmAlumno.alu_Sexo = value.Tables[0].Rows[0][9].ToString();
                    ObjTmAlumno.alu_FechaNacimiento = value.Tables[0].Rows[0][11].ToString();
                }
            }
        }

        public List<CConsulta> LlenarEnfermedad
        {
            get
            {
                return null;
            }

            set
            {
              
            }
        }

        public void Mensaje(string Mensaje, int tipo)
        {

        }
        #endregion

        protected void ButtonEliminarCita_Click(object sender, EventArgs e)
        {
            int x =Convert.ToInt32(TextBoxPkReservacion.Text);
            vistaConsulta.EliminarConsulta(6, x);
            Response.Redirect(Request.RawUrl);
        }
    }
}