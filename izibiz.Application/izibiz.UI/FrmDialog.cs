using izibiz.MODEL.Model;
using izibiz.UI.Languages;
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
    public partial class FrmDialog : Form
    {
        

        public FrmDialog()
        {
            InitializeComponent();
        }

    

        private void FrmShowInvoiceState_Load(object sender, EventArgs e)
        {
           
        }


        private void localizationItemTextWrite()
        {
            this.Text = Localization.frmShowInvoiceStatus;
        }





      


    }
}
