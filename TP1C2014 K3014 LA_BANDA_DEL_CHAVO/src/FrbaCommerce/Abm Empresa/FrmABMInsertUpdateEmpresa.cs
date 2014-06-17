﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Persistance;
using Session;
using Persistance.Entities;
using FrbaCommerce.Home;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class FrmABMInsertUpdateEmpresa : Form
    {
        public bool insertMode { get; set; }
        public SqlTransaction currentTransaction { get; set; }
        private bool _abmEmpresa;
        private Empresa CurrentEmpresa { get; set; }
        public bool CompleteAction = false;
        private Usuario currentUser;

        public FrmABMInsertUpdateEmpresa()
        {
            InitializeComponent();
            _abmEmpresa = false;
        }

        public FrmABMInsertUpdateEmpresa(Empresa empresa)
        {
            InitializeComponent();
            _abmEmpresa = false;

            insertMode = empresa == null;

            if (!insertMode)
                CurrentEmpresa = empresa;
        }

        public FrmABMInsertUpdateEmpresa(SqlTransaction transaction, Boolean abmEmpresa, Usuario user)
        {
            InitializeComponent();
            insertMode = transaction != null;
            _abmEmpresa = abmEmpresa;
            currentUser = user;
            this.currentTransaction = transaction;
        }

        private void TxtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmABMInsertUpdateEmpresa_Load(object sender, EventArgs e)
        {
            this.Text = (insertMode) ? string.Format("{0} - {1}", "FrbaCommerce", "Nueva empresa") : string.Format("{0} - {1}", "FrbaCommerce", "Modificar empresa");
            DtpFechaCreacion.Enabled = false;
            
            if (!insertMode)
            {
                TxtRazonSocial.Enabled = false;
                TxtCuit.Enabled = false;
                DtpFechaCreacion.Enabled = true;
                TxtRazonSocial.Text = CurrentEmpresa.RazonSocial;
                TxtMail.Text = CurrentEmpresa.Mail;
                TxtTelefono.Text = CurrentEmpresa.Telefono;
                TxtCodigoPostal.Text = CurrentEmpresa.CodigoPostal;
                TxtCuit.Text = CurrentEmpresa.CUIT;
                TxtCiudad.Text = CurrentEmpresa.Ciudad;
                TxtNombreContacto.Text = CurrentEmpresa.NombreContacto;
                TxtDireccion.Text = CurrentEmpresa.Direccion;
                DtpFechaCreacion.Value = CurrentEmpresa.FechaCreacion;
            }
        }

        private void LblCancelar_Click(object sender, EventArgs e)
        {
            var dialogAnswer = MessageBox.Show("Esta seguro que quiere cancelar la operacion?", "Atencion", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialogAnswer)
            {
                Close();
            }
        }

        private void LblGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validations

                var exceptionMessage = string.Empty;

                if (string.IsNullOrEmpty(TxtRazonSocial.Text))
                    exceptionMessage += "La razón social de la empresa no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtMail.Text))
                    exceptionMessage += "El mail de la empresa no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtTelefono.Text))
                    exceptionMessage += "El telefono de la empresa no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtDireccion.Text))
                    exceptionMessage += "La dirección de la empresa no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtCodigoPostal.Text))
                    exceptionMessage += "El código postal de la empresa no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtCiudad.Text))
                    exceptionMessage += "La ciudad de la empresa no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtCuit.Text))
                    exceptionMessage += "El CUIT de la empresa no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtNombreContacto.Text))
                    exceptionMessage += "El nombre de contacto de la empresa no puede ser vacío.\n";

                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);



                #endregion

                if (insertMode)
                {
                    if (EmpresaPersistance.GetByBusinessName(TxtRazonSocial.Text, this.currentTransaction) != null)
                        throw new Exception("Ya existe una empresa con la razón social ingresada.");

                    if (EmpresaPersistance.GetByCUIT(TxtCuit.Text, this.currentTransaction) != null)
                        throw new Exception("Ya existe una empresa con el CUIT ingresado.");

                    #region Insert the new company

                    var company = new Empresa();
                    company.IdUsuario = currentUser.ID;
                    company.RazonSocial = TxtRazonSocial.Text;
                    company.Mail = TxtMail.Text;
                    company.Telefono = TxtTelefono.Text;
                    company.Direccion = TxtDireccion.Text;
                    company.CodigoPostal = TxtCodigoPostal.Text;
                    company.Ciudad = TxtCiudad.Text;
                    company.CUIT = TxtCuit.Text;
                    company.NombreContacto = TxtNombreContacto.Text;
                    company.FechaCreacion = DtpFechaCreacion.Value;

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar la nueva empresa?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        EmpresaPersistance.InsertCompany(company, this.currentTransaction);
                        this.currentTransaction.Commit();
                        this.Hide();
                        if (!_abmEmpresa)
                        {
                            var frmHome = new FrmHome();
                            frmHome.ShowDialog();
                        }
                    }

                    #endregion
                }
                else
                {
                    var company = new Empresa();
                    company.IdUsuario = CurrentEmpresa.IdUsuario;
                    company.RazonSocial = TxtRazonSocial.Text;
                    company.Mail = TxtMail.Text;
                    company.Telefono = TxtTelefono.Text;
                    company.Direccion = TxtDireccion.Text;
                    company.CodigoPostal = TxtCodigoPostal.Text;
                    company.Ciudad = TxtCiudad.Text;
                    company.CUIT = TxtCuit.Text;
                    company.NombreContacto = TxtNombreContacto.Text;
                    company.FechaCreacion = DtpFechaCreacion.Value;

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere modificar la empresa?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        EmpresaPersistance.UpdateCompany(company);
                        CompleteAction = true;
                        this.Hide();
                    }   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }
    }
}
