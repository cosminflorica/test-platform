using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using BusinessAccessLayer;
using BusinessEntityLayer;
using System.Text.RegularExpressions;
using MetroFramework.Forms;
namespace test
{
    public partial class LogInWindow : MetroFramework.Forms.MetroForm
    {
        public Informations info = new Informations();
        public Operations opr = new Operations();
        public DataTable dt = new DataTable();
        string logType;
        static string _username;
        static string _username_id;
        static string _login_type;
        static string _teacher_username;
        
        public LogInWindow()
        {
            InitializeComponent();
            groupBox_register.Hide();

            textBox_usernam.ForeColor = Color.Gray;
            textBox_usernam.Text = "Username";
            this.textBox_usernam.Leave += new System.EventHandler(this.textBox_usernam_Leave);
            this.textBox_usernam.Enter += new System.EventHandler(this.textBox_usernam_Enter);

            textBox_passwor.ForeColor = Color.Gray;
            textBox_passwor.Text = "Password";
            this.textBox_passwor.Leave += new System.EventHandler(this.textBox_passwor_Leave);
            this.textBox_passwor.Enter += new System.EventHandler(this.textBox_passwor_Enter);

            textBox_username2.ForeColor = Color.Gray;
            textBox_username2.Text = "Username";
            this.textBox_username2.Leave += new System.EventHandler(this.textBox_username2_Leave);
            this.textBox_username2.Enter += new System.EventHandler(this.textBox_username2_Enter);

            textBox_password2.ForeColor = Color.Gray;
            textBox_password2.Text = "Password";
            this.textBox_password2.Leave += new System.EventHandler(this.textBox_password2_Leave);
            this.textBox_password2.Enter += new System.EventHandler(this.textBox_password2_Enter);

            textBox_email2.ForeColor = Color.Gray;
            textBox_email2.Text = "Email";
            this.textBox_email2.Leave += new System.EventHandler(this.textBox_email2_Leave);
            this.textBox_email2.Enter += new System.EventHandler(this.textBox_email2_Enter);

            textBox_passwordconfirm.ForeColor = Color.Gray;
            textBox_passwordconfirm.Text = "Re-type Password";
            this.textBox_passwordconfirm.Leave += new System.EventHandler(this.textBox_passwordconfirm_Leave);
            this.textBox_passwordconfirm.Enter += new System.EventHandler(this.textBox_passwordconfirm_Enter);

            textBox_name.ForeColor = Color.Gray;
            textBox_name.Text = "Full name";
            this.textBox_name.Leave += new System.EventHandler(this.textBox_name_Leave);
            this.textBox_name.Enter += new System.EventHandler(this.textBox_name_Enter);


        }

        //Watermark LoginWindow TextBoxes
        private void textBox_usernam_Leave(object sender, EventArgs e)
        {
            if (textBox_usernam.Text == "")
            {
                textBox_usernam.Text = "Username";
                textBox_usernam.ForeColor = Color.Gray;
            }
        }
        private void textBox_usernam_Enter(object sender, EventArgs e)
        {
            if (textBox_usernam.Text == "Username")
            {
                textBox_usernam.Text = "";
                textBox_usernam.ForeColor = Color.Black;
            }
        }
        private void textBox_passwor_Leave(object sender, EventArgs e)
        {
            if (textBox_passwor.Text == "")
            {
                textBox_passwor.PasswordChar = '\0' ;
                textBox_passwor.Text = "Password";
                textBox_passwor.ForeColor = Color.Gray;
            }
        }
        private void textBox_passwor_Enter(object sender, EventArgs e)
        {
            if (textBox_passwor.Text != "")
            {
                textBox_passwor.Text = "";
                textBox_passwor.ForeColor = Color.Black;
                textBox_passwor.PasswordChar = '*';        
            }
        }
        private void textBox_username2_Leave(object sender, EventArgs e)
        {
            if (textBox_username2.Text == "")
            {
                textBox_username2.Text = "Username";
                textBox_username2.ForeColor = Color.Gray;
            }
        }
        private void textBox_username2_Enter(object sender, EventArgs e)
        {
            if (textBox_username2.Text == "Username")
            {
                textBox_username2.Text = "";
                textBox_username2.ForeColor = Color.Black;
            }
        }
        private void textBox_password2_Leave(object sender, EventArgs e)
        {
            if (textBox_password2.Text == "")
            {
                textBox_password2.PasswordChar = '\0';
                textBox_password2.Text = "Password";
                textBox_password2.ForeColor = Color.Gray;
            }
        }
        private void textBox_password2_Enter(object sender, EventArgs e)
        {
            if (textBox_password2.Text != "")
            {
                textBox_password2.Text = "";
                textBox_password2.ForeColor = Color.Black;
                textBox_password2.PasswordChar = '*';
            }
        }
        private void textBox_email2_Leave(object sender, EventArgs e)
        {
            if (textBox_email2.Text == "")
            {
                textBox_email2.Text = "Email";
                textBox_email2.ForeColor = Color.Gray;
            }
        }
        private void textBox_email2_Enter(object sender, EventArgs e)
        {
            if (textBox_email2.Text == "Email")
            {
                textBox_email2.Text = "";
                textBox_email2.ForeColor = Color.Black;
            }
        }
        private void textBox_passwordconfirm_Leave(object sender, EventArgs e)
        {
            if (textBox_passwordconfirm.Text == "")
            {
                textBox_passwordconfirm.PasswordChar = '\0';
                textBox_passwordconfirm.Text = "Re-type Password";
                textBox_passwordconfirm.ForeColor = Color.Gray;
            }
        }
        private void textBox_passwordconfirm_Enter(object sender, EventArgs e)
        {
            if (textBox_passwordconfirm.Text != "")
            {
                textBox_passwordconfirm.Text = "";
                textBox_passwordconfirm.ForeColor = Color.Black;
                textBox_passwordconfirm.PasswordChar = '*';
            }
        }
        private void textBox_name_Leave(object sender, EventArgs e)
        {
            if (textBox_name.Text == "")
            {
                textBox_name.Text = "Full name";
                textBox_name.ForeColor = Color.Gray;
            }
        }
        private void textBox_name_Enter(object sender, EventArgs e)
        {
            if (textBox_name.Text == "Full name")
            {
                textBox_name.Text = "";
                textBox_name.ForeColor = Color.Black;
            }
        }
        //
    
        public static string get_entered_username()
        {

            return _username;
        }
        public static string get_login_type()
        {
            return _login_type;
        }
        public static string get_teacher_username()
        {
            return _teacher_username;
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
        public static int get_entered_username_id()
        { 
            return Convert.ToInt32(_username_id);
        }
        private void set_username_id()
        {
            info.name = get_entered_username();
            dt = opr.get_username_id(info);
            foreach (DataRow row in dt.Rows)
            {
                _username_id = row["id_user"].ToString();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!radioButton_student.Checked && !radioButton_teacher.Checked)
            {
                MessageBox.Show("Choose between Student and Teacher","", MessageBoxButtons.OK, MessageBoxIcon.Error);             
            }
            else if (radioButton_student.Checked)
            {
                info.type = "student";
            }
            else if (radioButton_teacher.Checked)
            {
                info.type = "teacher";
            }

            info.username = textBox_usernam.Text;
            info.password = textBox_passwor.Text;
            if (textBox_usernam.Text != "Username" && textBox_passwor.Text != "Password")
            {
                dt = opr.login(info);

                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Login successfully");
                    if (info.type == "student")
                    {
                        this.Hide();
                        var Window = new MainWindow();
                        Window.Closed += (s, args) => this.Close();
                        this.Show();
                    }
                    else
                    {

                    }
                }
                else MessageBox.Show("Invalid username or password !\nFeel free to use available recovery methods.");
            }
            else if (!(textBox_usernam.Text != "Username" && textBox_passwor.Text != "Password"))
                MessageBox.Show("Please provide your username and password !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }      
        private void label3_Click(object sender, EventArgs e)
        {
            Recovery f = new Recovery();
            f.ShowDialog();
        }
        private void button_register_Click(object sender, EventArgs e)
        {
            if (!radioButton_student.Checked && !radioButton_teacher.Checked)
            {
                MessageBox.Show("Choose between Student and Teacher", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (radioButton_student.Checked)
            {
                groupBox_register.Show();
            }
            else
            { 
                groupBox_register.Show();
            }
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            groupBox_register.Hide();
            groupBox_passwor.Show();
        }
        private void button_register2_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text != "Full name" && textBox_passwordconfirm.Text != "Re-type Password" && textBox_username2.Text != "Username" && textBox_email2.Text != "Email" && textBox_password2.Text != "Password")
            {
                string id1;
                bool emailflag = IsValidEmailAddress(textBox_email2.Text);
                dt = opr.id_user(info);
                foreach (DataRow row in dt.Rows)
                {
                    id1 = row["id_user"].ToString();
                    int id = Int32.Parse(id1) + 1;
                    if (radioButton_student.Checked == true)
                    {
                        logType = "student";
                        info.id = id;
                        info.type = logType;
                        info.name = textBox_name.Text;
                        info.username = textBox_username2.Text;
                        info.password = textBox_password2.Text;
                        info.email = textBox_email2.Text;
                    }
                    else if (radioButton_teacher.Checked == true)
                    {
                        logType = "teacher";
                        info.id = id;
                        info.type = logType;
                        info.name = textBox_name.Text;
                        info.username = textBox_username2.Text;
                        info.password = textBox_password2.Text;
                        info.email = textBox_email2.Text;
                    }
                    else
                    {
                        if (!radioButton_student.Checked && !radioButton_teacher.Checked)
                            MessageBox.Show("Choose between Student and Teacher", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string passwd_Confirm = textBox_passwordconfirm.Text;
                    if (emailflag == true)
                    {
                        if (passwd_Confirm == info.password)
                        {
                            int x = opr.insert_LogData(info);
                            if (x > 0)
                            {
                                id++;
                                MessageBox.Show("Insert successfuly");
                            }
                        }
                        else MessageBox.Show("Please confim your password correctly");
                    }
                    else MessageBox.Show("Please insert a valid email address");
                }
            }
            else if (!(textBox_name.Text != "Full name" && textBox_passwordconfirm.Text != "Re-type Password" && textBox_username2.Text != "Username" && textBox_email2.Text != "Email" && textBox_password2.Text != "Password"))
                MessageBox.Show("please insert all data");
        }
        private void label_forgot_username_Click(object sender, EventArgs e)
        {
            Recovery f = new Recovery();
            f.ShowDialog();
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (!radioButton_student.Checked && !radioButton_teacher.Checked)
            {
                MessageBox.Show("Choose between Student and Teacher", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (radioButton_student.Checked)
            {
                info.type = "student";
            }
            else if (radioButton_teacher.Checked)
            {
                info.type = "teacher";
            }

            info.username = textBox_usernam.Text;
            info.password = textBox_passwor.Text;
            if (textBox_usernam.Text != "Username" && textBox_passwor.Text != "Password")
            {
                dt = opr.login(info);

                if (dt.Rows.Count > 0)
                {
                    _login_type = info.type;
                    MessageBox.Show("Login successfully");
                    if (info.type == "student")
                    {
                        _username = textBox_usernam.Text;
                        MainWindow Window = new MainWindow();
                        Window.Show();
                        Window.Activate();
                        set_username_id();
                        this.Hide();
                    }
                    else if (info.type=="teacher")
                    {
                        _username = textBox_usernam.Text;
                        MainWindow Window = new MainWindow();
                        Window.Show();
                        Window.Activate();
                        set_username_id();
                        this.Hide();
                    }
                }
                else MessageBox.Show("Invalid username or password !\nFeel free to use available recovery methods.");
            }
            else if (!(textBox_usernam.Text != "Username" && textBox_passwor.Text != "Password"))
                MessageBox.Show("Please provide your username and password !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void metroButton_register_Click(object sender, EventArgs e)
        {
            if (!radioButton_student.Checked && !radioButton_teacher.Checked)
            {
                MessageBox.Show("Choose between Student and Teacher", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (radioButton_student.Checked)
            {
                groupBox_register.Show();
            }
            else
            {
                groupBox_register.Show();
            }
        }
        private void metroButton_back2_Click(object sender, EventArgs e)
        {
            groupBox_register.Hide();
            groupBox_passwor.Show();
        }
        private void metroButton_register2_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text != "Full name" && textBox_passwordconfirm.Text != "Re-type Password" && textBox_username2.Text != "Username" && textBox_email2.Text != "Email" && textBox_password2.Text != "Password")
            {
                string id1;
                bool emailflag = IsValidEmailAddress(textBox_email2.Text);
                dt = opr.id_user(info);
                foreach (DataRow row in dt.Rows)
                {
                    id1 = row["id_user"].ToString();
                    int id = Int32.Parse(id1) + 1;
                    if (radioButton_student.Checked == true)
                    {
                        logType = "student";

                        info.id = id;
                        info.type = logType;
                        info.name = textBox_name.Text;
                        info.username = textBox_username2.Text;
                        info.password = textBox_password2.Text;
                        info.email = textBox_email2.Text;

                    }
                    else if (radioButton_teacher.Checked == true)
                    {
                        logType = "teacher";
                        info.id = id;
                        info.type = logType;
                        info.name = textBox_name.Text;
                        info.username = textBox_username2.Text;
                        info.password = textBox_password2.Text;
                        info.email = textBox_email2.Text;

                    }
                    else
                    {
                        if (!radioButton_student.Checked && !radioButton_teacher.Checked)
                            MessageBox.Show("Choose between Student and Teacher", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    int ok = 0;
                    string passwd_Confirm = textBox_passwordconfirm.Text;
                    if (emailflag == true)
                    {
                        if (passwd_Confirm == info.password)
                        {
                            int x = opr.insert_LogData(info);
                            if (x > 0)
                            {
                                _teacher_username = info.username;
                                id++;
                                ok = 1;
                                MessageBox.Show("Insert successfuly");
                            }
                        }
                        else MessageBox.Show("Please confim your password correctly");
                    }
                    else MessageBox.Show("Please insert a valid email address");
                    if(ok==1)
                    {
                        MessageBox.Show(_teacher_username);
                        TeacherType Window = new TeacherType();
                        Window.Show();
                    }
                }
            }
            else if (!(textBox_name.Text != "Full name" && textBox_passwordconfirm.Text != "Re-type Password" && textBox_username2.Text != "Username" && textBox_email2.Text != "Email" && textBox_password2.Text != "Password"))
                MessageBox.Show("please insert all data");
        }
    }
}
