using izibiz.CONTROLLER.Model;
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
    public partial class FrmWriteMail : Form
    {


     
       public List<SendMailModel> sendMailModelList;


        public FrmWriteMail(List<SendMailModel> sendMailModelList)
        {
            InitializeComponent();
            this.sendMailModelList = sendMailModelList;
        }


        private void FrmSelectMail_Load(object sender, EventArgs e)
        {
            localizationTextWrite();

            //datagrid tablosuna ıd degerlerını yazıyoruz ve  maıl default olarak bır deger yazıyoruz
            foreach(var model in sendMailModelList)
            {
                gridSendMail.Rows.Add(model.id, "mail@mail.com");
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
            //datagırddekı maıl degerlerını model liste aktarıyoruz
            int cnt = 0;
            foreach (var model in sendMailModelList)
            {
                model.mail=gridSendMail.Rows[cnt].Cells["clmsendMail"].Value.ToString();
                cnt++;
            }

            this.DialogResult = DialogResult.OK;
        }





    }
}
