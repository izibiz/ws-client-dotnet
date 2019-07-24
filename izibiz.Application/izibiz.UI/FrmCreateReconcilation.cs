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
    public partial class FrmCreateReconcilation : Form
    {
        public FrmCreateReconcilation()
        {
            InitializeComponent();
        }

        private void FrmCreateReconcilation_Load(object sender, EventArgs e)
        {

        }


        private void pnlVisibleBaBsOrCurrentShow()
        {
            if(cmbReconcilationSenario.SelectedItem.ToString() == "BA/BS Mutabakat")
            {
                pnlBaBsDocPiece.Visible = true;
                pnlCurrentPiece.Visible = false;
                btnCreate.Enabled = true;
            }
           else
            {
                pnlCurrentPiece.Visible = true;
                pnlBaBsDocPiece.Visible = false;
                btnCreate.Enabled = true;
            }
        }

        private void CmbReconcilationSenario_SelectedValueChanged(object sender, EventArgs e)
        {
            pnlVisibleBaBsOrCurrentShow();
        }
    }
}
