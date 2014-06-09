using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class FrmABMInsertUpdateEmpresa : Form
    {
        public FrmABMInsertUpdateEmpresa()
        {
            InitializeComponent();
        }

        public FrmABMInsertUpdateEmpresa(SqlTransaction transaction)
        {
            InitializeComponent();
        }

        private void TxtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmABMInsertUpdateEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
