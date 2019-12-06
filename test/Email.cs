using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using BusinessAccessLayer;
using BusinessEntityLayer;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using MetroFramework.Forms;

namespace test
{
    public partial class Recovery : MetroFramework.Forms.MetroForm
    {
        public Informations info = new Informations();
        public Operations opr = new Operations();
        public DataTable dt = new DataTable();

        public Recovery()
        {
            InitializeComponent();

            metroTextBox1.ForeColor = Color.LightGray;
            metroTextBox1.Text = "someone@example.com";
            this.metroTextBox1.Leave += new System.EventHandler(this.metroTextBox1_Leave);
            this.metroTextBox1.Enter += new System.EventHandler(this.metroTextBox1_Enter);
        }

        private void metroTextBox1_Leave(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "")
            {
                metroTextBox1.Text = "someone@example.com";
                metroTextBox1.ForeColor = Color.LightGray;
            }
        }
        private void metroTextBox1_Enter(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "someone@example.com")
            {
                metroTextBox1.Text = "";
                metroTextBox1.ForeColor = Color.Black;
            }
        }

        public static bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                Regex rx = new Regex(
            @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
                return rx.IsMatch(emailaddress);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void Email_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
         ReturnEmail();    
        }
        private void ReturnEmail()
        {
            info.email = metroTextBox1.Text;
            bool emailflag = IsValidEmailAddress(metroTextBox1.Text);
            dt = opr.email(info);
            if (emailflag == true)
            {
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("no null");
                    foreach (DataRow row in dt.Rows)
                    {
                        string uname = row["username"].ToString();
                        string pwd = row["password"].ToString();
                        MessageBox.Show("Check your inbox !");

                        string first_line = $"Your username is : {uname}";
                        string second_line = $"Your password is : {pwd}";
                                                
                        MailMessage mail = new MailMessage("project.email.address0@gmail.com", metroTextBox1.Text);
                        mail.Subject = "USER DATA RECOVERY";
                        mail.Body = $"{first_line}\n{second_line}";

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        smtpClient.EnableSsl = true;
                        //smtpClient.UseDefaultCredentials = true;
                        smtpClient.Credentials = new System.Net.NetworkCredential()
                        {
                            UserName = "project.email.address0@gmail.com",
                            Password = "ikxiklfsjhhvlyfn"
                        };

                        smtpClient.EnableSsl = true;
                        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                System.Security.Cryptography.X509Certificates.X509Chain chain,
                                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                        {
                            return true;
                        };

                        smtpClient.Send(mail);
                        Close();
                    }
                }
                else MessageBox.Show("There is no account with this email address !");
            }
            else MessageBox.Show("Please insert a valid email address");
        }

        

        private void metroTile2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton_Submit_Click(object sender, EventArgs e)
        {
            ReturnEmail();
        }

        private void metroButton_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            metroTextBox1.TabStop = false;
        }
    }
}
