using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izibiz.UI
{
    public partial class FrmReconcilation : Form
    {
        public FrmReconcilation()
        {
            InitializeComponent();
        }

        private void İtemNewReconcilation_Click(object sender, EventArgs e)
        {
            FrmCreateReconcilation frmCreate = new FrmCreateReconcilation();
            frmCreate.Show();
            this.Hide();


        }





    }
}
