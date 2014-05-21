﻿using System;
using System.Linq;
using System.Windows.Forms;
using FrbaCommerce.Home;
using Logic;
using Session;

namespace FrbaCommerce.Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void DoLogin(string userName, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new Exception("El usuario no puede ser vacío.");

                if (string.IsNullOrEmpty(password))
                    throw new Exception("La contraseña no puede ser vacía.");

                var user = new UsuarioLogic().Login(userName, password);

                if (user.RolesActivos != null)
                {
                    SessionManager.CurrentUser = user;
                    while (SessionManager.CurrentUser.PassTemporal)
                    {
                        MessageBox.Show("Posee una contraseña temporal. Debera cambiarla a continuacion.", "Atención");

                        var resetPassword = new FrmResetPassword();
                        resetPassword.ShowDialog();
                    }
                    
                    Hide();

                    if (user.RolesActivos.Count > 1)
                    {
                        var chooseRol = new FrmChooseRol();
                        chooseRol.ShowDialog();
                    }
                    else
                    {
                        SessionManager.CurrentRol = user.RolesActivos.First();

                        var home = new FrmHome();
                        home.ShowDialog();
                    }

                    Close();
                }
                else
                    throw new Exception("El usuario no cuenta con roles que se encuentren activos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
            }
        }

        private void LblEntrar_Click(object sender, EventArgs e)
        {
            DoLogin(TxtUsuario.Text, TxtContrasena.Text);
        }
    }
}