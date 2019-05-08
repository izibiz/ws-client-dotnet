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
    public partial class FrmSelectMail : Form
    {


        public string[] mailArr;
        string[] idArr;


        public FrmSelectMail(string[] idArr)
        {
            InitializeComponent();
            this.idArr = new string[idArr.Length];
            mailArr = new string[idArr.Length];
            this.idArr = idArr;
        }


        private void FrmSelectMail_Load(object sender, EventArgs e)
        {
            localizationTextWrite();


            for (int cntId=0;cntId<idArr.Length;cntId++)
            {
                gridSendMail.Rows.Add(idArr[cntId], "mail@mail.com");
            }
 

        }


        private void localizationTextWrite()
        {
         /*   this.Text =;
            gridSendMail.Columns["clmArchiveID"].HeaderText =;
            gridSendMail.Columns["clmsendMail"].HeaderText =;
            btnOk.Text =;
            lblText.Text =;*/
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
          
            for (int cnt=0;cnt<gridSendMail.RowCount;cnt++)
            {
                mailArr[cnt]=gridSendMail.Rows[cnt].Cells["clmsendMail"].Value.ToString();
            }

            this.DialogResult = DialogResult.OK;
        }





    }
}
