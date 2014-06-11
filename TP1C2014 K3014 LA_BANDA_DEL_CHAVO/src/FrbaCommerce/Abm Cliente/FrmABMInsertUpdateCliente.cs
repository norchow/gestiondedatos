﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Persistance;
using System.Data.SqlClient;
using Persistance.Entities;
using Session;
using FrbaCommerce.Home;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class FrmABMInsertUpdateCliente : Form
    {
        public bool insertMode { get; set; }
        public SqlTransaction currentTransaction { get; set; }

        public FrmABMInsertUpdateCliente()
        {
            InitializeComponent();
        }

        public FrmABMInsertUpdateCliente(SqlTransaction transaction)
        {
            InitializeComponent();
            insertMode = transaction != null;

            this.currentTransaction = transaction;
        }

        private void FrmABMInsertUpdateCliente_Load(object sender, EventArgs e)
        {
            this.Text = (insertMode) ? string.Format("{0} - {1}", "FrbaCommerce", "Nuevo cliente") : string.Format("{0} - {1}", "FrbaCommerce", "Modificar cliente");

            CboTipoDocumento.DataSource = TipoDocumentoPersistance.GetAll(this.currentTransaction);
            CboTipoDocumento.ValueMember = "ID";
            CboTipoDocumento.DisplayMember = "Descripcion";
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

                if (string.IsNullOrEmpty(TxtNombre.Text))
                    exceptionMessage += "El nombre del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtApellido.Text))
                    exceptionMessage += "El apellido del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtDocumento.Text))
                    exceptionMessage += "El documento del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtMail.Text))
                    exceptionMessage += "El mail del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtTelefono.Text))
                    exceptionMessage += "El telefono del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtDireccion.Text))
                    exceptionMessage += "La dirección del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtCodigoPostal.Text))
                    exceptionMessage += "El código postal del cliente no puede ser vacío.\n";

                if (string.IsNullOrEmpty(TxtCuil.Text))
                    exceptionMessage += "El CUIL del cliente no puede ser vacío.\n";

                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                if (ClientePersistance.GetByPhone(TxtTelefono.Text, this.currentTransaction) != null)
                    throw new Exception("Ya existe un cliente con el telefono ingresado.");

                if (ClientePersistance.GetByDocument((int)CboTipoDocumento.SelectedValue, Int32.Parse(TxtDocumento.Text), this.currentTransaction) != null)
                    throw new Exception("Ya existe un cliente con el documento ingresado.");

                #endregion

                if (insertMode)
                {
                    #region Insert the new client
                    
                    var client = new Cliente();
                    client.IdUsuario = SessionManager.CurrentUser.ID;
                    client.Nombre = TxtNombre.Text;
                    client.Apellido = TxtApellido.Text;
                    client.TipoDocumento = (int)CboTipoDocumento.SelectedValue;
                    client.NroDocumento = Int32.Parse(TxtDocumento.Text);
                    client.Mail = TxtMail.Text;
                    client.Telefono = TxtTelefono.Text;
                    client.Direccion = TxtDireccion.Text;
                    client.CodigoPostal = TxtCodigoPostal.Text;
                    client.FechaNacimiento = DtpFechaNacimiento.Value;
                    client.CUIL = TxtCuil.Text;

                    var dialogAnswer = MessageBox.Show("Esta seguro que quiere insertar el nuevo cliente?", "Atencion", MessageBoxButtons.YesNo);
                    if (dialogAnswer == DialogResult.Yes)
                    {
                        ClientePersistance.InsertClient(client, this.currentTransaction);
                        this.currentTransaction.Commit();
                        this.Hide();
                        var frmHome = new FrmHome();
                        frmHome.ShowDialog();
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }
    }
}