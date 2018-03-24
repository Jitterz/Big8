using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Big8_MAIN
{
    public partial class FormCommentsBugs : Form
    {
        public FormCommentsBugs()
        {
            InitializeComponent();
        }

        private void SendEmail()
        {
            // make the cursor turn into a wait cursor
            Cursor defaultCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string FromMailAdress = "jitterzbugreports@gmail.com";
            string ToMailAdress = "jitterzbugreports@gmail.com";


            MailMessage Message1 = new MailMessage(FromMailAdress, ToMailAdress);

            Message1.Subject = textBoxTitle.Text;
            Message1.Body = textBoxCommentsBugsBody.Text;
            Message1.Priority = MailPriority.Normal;


            SmtpClient mailSender = new SmtpClient("smtp.gmail.com", 587);      //or 465, 587
            mailSender.EnableSsl = true;
            mailSender.Credentials = new System.Net.NetworkCredential("jitterzbugreports@gmail.com", "p1nkjezuzmail");
            //mailSender.UseDefaultCredentials = true; 

            try
            {
                mailSender.Send(Message1);
            }
            catch (Exception ex)
            {
                Cursor.Current = defaultCursor;
                MessageBox.Show("Error with SMTP: " + ex.Message);              
            }
            Message1.Dispose();
            Cursor.Current = defaultCursor;
            MessageBox.Show("Message Sent!");           
        }

        private void buttonSendJitterz_Click(object sender, EventArgs e)
        {
            SendEmail();
        }
    }
}
