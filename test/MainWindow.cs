using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using BusinessAccessLayer;
using BusinessEntityLayer;


namespace test
{
    struct QUESTIONS
    {
        public string enunt;
        public string raspuns1;
        public string raspuns2;
        public string raspuns3;
        public string raspuns4;
        public string raspuns_corect;
    };

    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        public Informations info = new Informations();
        public Operations opr = new Operations();
        public DataTable dt = new DataTable();
        public int _question_type;
        public int _id_materie;
        public string nume_materie;
        public string enunt_materie;

        public string _id, _username,_name, _subject, _grade, _date;

        QUESTIONS[] v = new QUESTIONS[10];


        public MainWindow()
        {
            InitializeComponent();

            if (LogInWindow.get_login_type() == "teacher") groupBox_student.Hide();
            else groupBox_teacher.Hide();

            // *** STUDENT ***

            metroLabel_username_student.Text = LogInWindow.get_entered_username();
            groupBox_username.Hide();
            groupBox_test.Hide();
            panel_tests.Hide();
                   
            metroTextBox_oldpassword.ForeColor = Color.LightGray;            
            metroTextBox_oldpassword.Text = "Old password";
            this.metroTextBox_oldpassword.Leave += new System.EventHandler(this.metroTextBox_oldpassword_Leave);
            this.metroTextBox_oldpassword.Enter += new System.EventHandler(this.metroTextBox_oldpassword_Enter);

            metroTextBox_newpassword.ForeColor = Color.LightGray;
            metroTextBox_newpassword.Text = "New password";
            this.metroTextBox_newpassword.Leave += new System.EventHandler(this.metroTextBox_newpassword_Leave);
            this.metroTextBox_newpassword.Enter += new System.EventHandler(this.metroTextBox_newpassword_Enter);

            metroTextBox_retypepassword.ForeColor = Color.LightGray;
            metroTextBox_retypepassword.Text = "Re-type password";
            this.metroTextBox_retypepassword.Leave += new System.EventHandler(this.metroTextBox_retypepassword_Leave);
            this.metroTextBox_retypepassword.Enter += new System.EventHandler(this.metroTextBox_retypepassword_Enter);

            // *** TAECHER ***

            metroLabel_username_teacher.Text = LogInWindow.get_entered_username();
            groupBox_4answer_qustion.Hide();
            groupBox_tests_teacher.Hide();
            groupBox_question_type.Hide();
            groupBox_true_false.Hide();
            groupBox_delete_question.Hide();
            groupBox_teacher_results.Hide();
            groupBox_teacher_options.Hide();
        }

        // ************* STUDENT *****************
        public string get_teacher_materie()
        {
            info.id_user = LogInWindow.get_entered_username_id();
           // MessageBox.Show(info.id_user.ToString());

            dt = opr.get_username_materie(info);
            foreach (DataRow row in dt.Rows)
            {
                nume_materie = row["materie"].ToString();
            }
            return nume_materie;
        }
        public int get_materie_id()
        {

            info.id_user  =LogInWindow.get_entered_username_id();
            dt = opr.get_username_materie(info);
            foreach (DataRow row in dt.Rows)
            {
                nume_materie =row["materie"].ToString() ;
            }
            info.materie = nume_materie;
            _subject = nume_materie;
            dt = opr.get_id_materie(info);
            foreach (DataRow row in dt.Rows)
            {
               
                _id_materie = Convert.ToInt32(row["id_materie"]);
            }
            return _id_materie;        
        }
        private void metroTextBox_oldpassword_Leave(object sender, EventArgs e)
        {
            if (metroTextBox_oldpassword.Text == "")
            {
                metroTextBox_oldpassword.PasswordChar = '\0';
                metroTextBox_oldpassword.Text = "Old password";
                metroTextBox_oldpassword.ForeColor = Color.LightGray;
            }
        }
        private void metroTextBox_oldpassword_Enter(object sender, EventArgs e)
        {
            if (metroTextBox_oldpassword.Text != "")
            {
                metroTextBox_oldpassword.Text = "";
                metroTextBox_oldpassword.ForeColor = Color.Black;
                metroTextBox_oldpassword.PasswordChar = '*';
            }
        }
        private void metroTextBox_newpassword_Leave(object sender, EventArgs e)
        {
            if (metroTextBox_newpassword.Text == "")
            {
                metroTextBox_newpassword.PasswordChar = '\0';
                metroTextBox_newpassword.Text = "New password";
                metroTextBox_newpassword.ForeColor = Color.LightGray;
            }
        }
        private void metroTextBox_newpassword_Enter(object sender, EventArgs e)
        {
            if (metroTextBox_newpassword.Text != "")
            {
                metroTextBox_newpassword.Text = "";
                metroTextBox_newpassword.ForeColor = Color.Black;
                metroTextBox_newpassword.PasswordChar = '*';
            }
        }
        private void metroTextBox_retypepassword_Leave(object sender, EventArgs e)
        {
            if (metroTextBox_retypepassword.Text == "")
            {
                metroTextBox_retypepassword.PasswordChar = '\0';
                metroTextBox_retypepassword.Text = "Re-type password";
                metroTextBox_retypepassword.ForeColor = Color.LightGray;
            }
        }
        private void metroTextBox_retypepassword_Enter(object sender, EventArgs e)
        {
            if (metroTextBox_retypepassword.Text != "")
            {
                metroTextBox_retypepassword.Text = "";
                metroTextBox_retypepassword.ForeColor = Color.Black;
                metroTextBox_retypepassword.PasswordChar = '*';
            }
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            groupBox_test.Hide();
            groupBox_options.Hide();
            panel_tests.Hide();
            groupBox_results.Hide();
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Application.Exit();
            Environment.Exit(1);
        }
        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void groupBox_student_Enter(object sender, EventArgs e)
        {

        }
        private void metroTile4_Click(object sender, EventArgs e)
        {
            groupBox_test.Hide();
            panel_tests.Hide();
            groupBox_results.Hide();
            groupBox_options.Show();
        }
        private void metroTile3_Click(object sender, EventArgs e)
        {

        }
        private void metroLabel_username_Click(object sender, EventArgs e)
        {
           
        }
        private void groupBox_options_Enter(object sender, EventArgs e)
        {

        }
        private void metroTile_changepassword_Click(object sender, EventArgs e)
        {
           // groupBox_password.Show();
            groupBox_username.Hide();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void metroTextBox_oldpassword_Click(object sender, EventArgs e)
        {

        }
        private void metroButton_changepasswordsave_Click(object sender, EventArgs e)
        {
            info.username = LogInWindow.get_entered_username();
            info.password = metroTextBox_oldpassword.Text;

            dt = opr.check_oldpassword(info);
            if (dt.Rows.Count > 0)
            {
                dt.Clear();
                if (metroTextBox_newpassword.Text == metroTextBox_retypepassword.Text)
                {
                    info.password = metroTextBox_newpassword.Text;
                    int x = opr.update_password(info);

                    MessageBox.Show("Password changed!");
                }
                else MessageBox.Show("Please re-type your password correctly");

            }
            else MessageBox.Show("Old password is wrong");

           // groupBox_password.Hide();
        }
        private void metroButton_changeusernamesave_Click(object sender, EventArgs e)
        {
            info.username = LogInWindow.get_entered_username();
            //info.password = metroTextBox_oldpassword.Text;

            //dt = opr.update_username(info);
            if (LogInWindow.get_entered_username()==metroTextBox_oldusername.Text)
            {
                //dt.Clear();
                if (metroTextBox_newusername.Text == metroTextBox_retypeusername.Text)
                {
                    info.password = metroTextBox_oldusername.Text;
                    info.username = metroTextBox_newusername.Text;
                    int x = opr.update_username(info);
                    //if (x > 0) MessageBox.Show("ok");
                    MessageBox.Show("Username changed!");
                }
                else MessageBox.Show("Please re-type your username correctly");

            }
            else MessageBox.Show("Old username is wrong");
           // groupBox_username.Hide();
        }
        private void metroTile_changeusername_Click(object sender, EventArgs e)
        {
            groupBox_username.Show();
           // groupBox_password.Hide();
            
        }
        private void groupBox_username_Enter(object sender, EventArgs e)
        {

        }
        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            groupBox_options.Hide();
            groupBox_results.Hide();
            groupBox_test.Show();

            fill_combo();
        }
        private void fill_combo()
        {
            //throw new NotImplementedException();
            metroComboBox1.Items.Clear();
            dt = opr.get_materie();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string materie = row["nume_materie"].ToString();
                    metroComboBox1.Items.Add(materie);
                }
            }
        }
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void metroButton1_Click(object sender, EventArgs e)   //take test clicked
        {
            

            string materie;
            //panel_tests.Show();

            materie = metroComboBox1.SelectedItem.ToString();
            switch (MessageBox.Show("Let's do it !\nAre you ready?", "", MessageBoxButtons.YesNo))
            { case DialogResult.Yes:
                    {
                        //label5.Hide();
                        //metroComboBox1.Hide();
                        //metroButton1.Hide();
                        //panel_tests.Show();
                        //groupBox_test.Hide();
                        _load_test_panel(materie);
                        
                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
            }           
        }
        private void _load_test_panel(string materie)
        {
            // throw new NotImplementedException();
            
            info.materie = materie;
            dt = opr._load_panel(info);
            
            if (dt.Rows.Count > 0)
            {
                string intrebare1=null;
                string raspuns1=null;
                string raspuns2=null;
                string raspuns3 = null  ;
                string raspuns4=null;
                string raspuns_corect=null;
                int i = 0;
               
                foreach (DataRow row in dt.Rows)
                {
                    intrebare1 = row["enunt"].ToString();
                    raspuns1 = row["raspuns1"].ToString();
                    raspuns2 = row["raspuns2"].ToString();
                    raspuns3 = row["raspuns3"].ToString();
                    raspuns4 = row["raspuns4"].ToString();
                    raspuns_corect = row["raspuns_corect"].ToString();
                    v[i].enunt = intrebare1;
                    v[i].raspuns1 = raspuns1;
                    v[i].raspuns2 = raspuns2;
                    v[i].raspuns3 = raspuns3;
                    v[i].raspuns4 = raspuns4;
                    v[i].raspuns_corect = raspuns_corect;
                    i++;
                }
                if (i < 10)
                {
                    MessageBox.Show("Not enought questions");
                    
                }
                else
                {
                    label5.Hide();
                    metroComboBox1.Hide();
                    metroButton1.Hide();
                    panel_tests.Show();
                    groupBox_test.Hide();
                    metroTile_options_student.Enabled = false;
                    metroTile_results_student.Enabled = false;

                    label_question1.Text = v[0].enunt;
                    label_question2.Text = v[1].enunt;
                    label_question3.Text = v[2].enunt;
                    label_question4.Text = v[3].enunt;
                    label_question5.Text = v[4].enunt;
                    label_question6.Text = v[5].enunt;
                    label_question7.Text = v[6].enunt;
                    label_question8.Text = v[7].enunt;
                    label_question9.Text = v[8].enunt;
                    label_question10.Text = v[9].enunt;

                    if (v[0].raspuns1=="-1")
                    {
                        radioButton_ans1q1.Hide();
                        radioButton_ans2q1.Text = "TRUE";
                        radioButton_ans3q1.Hide();
                        radioButton_ans4q1.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q1.Text=v[0].raspuns1;
                        radioButton_ans2q1.Text = v[0].raspuns2;
                        radioButton_ans3q1.Text =v[0].raspuns3;
                        radioButton_ans4q1.Text = v[0].raspuns4;
                    }

                    if (v[1].raspuns1 == "-1")
                    {
                        radioButton_ans1q2.Hide();
                        radioButton_ans2q2.Text = "TRUE";
                        radioButton_ans3q2.Hide();
                        radioButton_ans4q2.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q2.Text = v[1].raspuns1;
                        radioButton_ans2q2.Text = v[1].raspuns2;
                        radioButton_ans3q2.Text = v[1].raspuns3;
                        radioButton_ans4q2.Text = v[1].raspuns4;
                    }

                    if (v[2].raspuns1 == "-1")
                    {
                        radioButton_ans1q3.Hide();
                        radioButton_ans2q3.Text = "TRUE";
                        radioButton_ans3q3.Hide();
                        radioButton_ans4q3.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q3.Text = v[2].raspuns1;
                        radioButton_ans2q3.Text = v[2].raspuns2;
                        radioButton_ans3q3.Text = v[2].raspuns3;
                        radioButton_ans4q3.Text = v[2].raspuns4;
                    }

                    if (v[3].raspuns1 == "-1")
                    {
                        radioButton_ans1q4.Hide();
                        radioButton_ans2q4.Text = "TRUE";
                        radioButton_ans3q4.Hide();
                        radioButton_ans4q4.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q4.Text = v[3].raspuns1;
                        radioButton_ans2q4.Text = v[3].raspuns2;
                        radioButton_ans3q4.Text = v[3].raspuns3;
                        radioButton_ans4q4.Text = v[3].raspuns4;
                    }

                    if (v[4].raspuns1 == "-1")
                    {
                        radioButton_ans1q5.Hide();
                        radioButton_ans2q5.Text = "TRUE";
                        radioButton_ans3q5.Hide();
                        radioButton_ans4q5.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q5.Text = v[4].raspuns1;
                        radioButton_ans2q5.Text = v[4].raspuns2;
                        radioButton_ans3q5.Text = v[4].raspuns3;
                        radioButton_ans4q5.Text = v[4].raspuns4;
                    }
                    if (v[5].raspuns1 == "-1")
                    {
                        radioButton_ans1q6.Hide();
                        radioButton_ans2q6.Text = "TRUE";
                        radioButton_ans3q6.Hide();
                        radioButton_ans4q6.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q6.Text = v[5].raspuns1;
                        radioButton_ans2q6.Text = v[5].raspuns2;
                        radioButton_ans3q6.Text = v[5].raspuns3;
                        radioButton_ans4q6.Text = v[5].raspuns4;
                    }

                    if (v[6].raspuns1 == "-1")
                    {
                        radioButton_ans1q7.Hide();
                        radioButton_ans2q7.Text = "TRUE";
                        radioButton_ans3q7.Hide();
                        radioButton_ans4q7.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q7.Text = v[6].raspuns1;
                        radioButton_ans2q7.Text = v[6].raspuns2;
                        radioButton_ans3q7.Text = v[6].raspuns3;
                        radioButton_ans4q7.Text = v[6].raspuns4;
                    }


                    if (v[7].raspuns1 == "-1")
                    {
                        radioButton_ans1q8.Hide();
                        radioButton_ans2q8.Text = "TRUE";
                        radioButton_ans3q8.Hide();
                        radioButton_ans4q8.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q8.Text = v[7].raspuns1;
                        radioButton_ans2q8.Text = v[7].raspuns2;
                        radioButton_ans3q8.Text = v[7].raspuns3;
                        radioButton_ans4q8.Text = v[7].raspuns4;
                    }

                    if (v[8].raspuns1 == "-1")
                    {
                        radioButton_ans1q9.Hide();
                        radioButton_ans2q9.Text = "TRUE";
                        radioButton_ans3q9.Hide();
                        radioButton_ans4q9.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q9.Text = v[8].raspuns1;
                        radioButton_ans2q9.Text = v[8].raspuns2;
                        radioButton_ans3q9.Text = v[8].raspuns3;
                        radioButton_ans4q9.Text = v[8].raspuns4;
                    }

                    if (v[9].raspuns1 == "-1")
                    {
                        radioButton_ans1q10.Hide();
                        radioButton_ans2q10.Text = "TRUE";
                        radioButton_ans3q10.Hide();
                        radioButton_ans4q10.Text = "FALSE";
                    }
                    else
                    {
                        radioButton_ans1q10.Text = v[9].raspuns1;
                        radioButton_ans2q10.Text = v[9].raspuns2;
                        radioButton_ans3q10.Text = v[9].raspuns3;
                        radioButton_ans4q10.Text = v[9].raspuns4;
                    }

                }
            }
            else MessageBox.Show("Not enought questions on this category");


        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void groupBox_question1_Enter(object sender, EventArgs e)
        {
           
        }
        private void groupBox_question2_Enter(object sender, EventArgs e)
        {

        }
        private void panel_tests_Paint(object sender, PaintEventArgs e)
        {

        }
        private void metroButton_submit_test_Click(object sender, EventArgs e)
        {
            int _checkflag = 0;
            int _gradee = 0;

            if (radioButton_ans1q1.Checked == true)
            {
                if (radioButton_ans1q1.Text == v[0].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q1.Checked == true)
            {
                if (radioButton_ans2q1.Text == v[0].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q1.Checked == true)
            {
                if (radioButton_ans3q1.Text == v[0].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q1.Checked == true)
            {
                if (radioButton_ans4q1.Text == v[0].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;

            if (radioButton_ans1q2.Checked == true)
            {
                if (radioButton_ans1q2.Text == v[1].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q2.Checked == true)
            {
                if (radioButton_ans2q2.Text == v[1].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q2.Checked == true)
            {
                if (radioButton_ans3q2.Text == v[1].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q2.Checked == true)
            {
                if (radioButton_ans4q2.Text == v[1].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;

            if (radioButton_ans1q3.Checked == true)
            {
                if (radioButton_ans1q3.Text == v[2].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q3.Checked == true)
            {
                if (radioButton_ans2q3.Text == v[2].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q3.Checked == true)
            {
                if (radioButton_ans3q3.Text == v[2].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q3.Checked == true)
            {
                if (radioButton_ans4q3.Text == v[2].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;

            if (radioButton_ans1q4.Checked == true)
            {
                if (radioButton_ans1q4.Text == v[3].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q4.Checked == true)
            {
                if (radioButton_ans2q4.Text == v[3].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q4.Checked == true)
            {
                if (radioButton_ans3q4.Text == v[3].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q4.Checked == true)
            {
                if (radioButton_ans4q4.Text == v[3].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;

            if (radioButton_ans1q5.Checked == true)
            {
                if (radioButton_ans1q5.Text == v[4].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q5.Checked == true)
            {
                if (radioButton_ans2q5.Text == v[4].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q5.Checked == true)
            {
                if (radioButton_ans3q5.Text == v[4].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q5.Checked == true)
            {
                if (radioButton_ans4q5.Text == v[4].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;

            if (radioButton_ans1q6.Checked == true)
            {
                if (radioButton_ans1q6.Text == v[5].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q6.Checked == true)
            {
                if (radioButton_ans2q6.Text == v[5].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q6.Checked == true)
            {
                if (radioButton_ans3q6.Text == v[5].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q6.Checked == true)
            {
                if (radioButton_ans4q6.Text == v[5].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;


            if (radioButton_ans1q7.Checked == true)
            {
                if (radioButton_ans1q7.Text == v[6].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q7.Checked == true)
            {
                if (radioButton_ans2q7.Text == v[6].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q7.Checked == true)
            {
                if (radioButton_ans3q7.Text == v[6].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q7.Checked == true)
            {
                if (radioButton_ans4q7.Text == v[6].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;


            if (radioButton_ans1q8.Checked == true)
            {
                if (radioButton_ans1q8.Text == v[7].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q8.Checked == true)
            {
                if (radioButton_ans2q8.Text == v[7].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q8.Checked == true)
            {
                if (radioButton_ans3q8.Text == v[7].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q8.Checked == true)
            {
                if (radioButton_ans4q8.Text == v[7].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;

            if (radioButton_ans1q9.Checked == true)
            {
                if (radioButton_ans1q9.Text == v[8].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q9.Checked == true)
            {
                if (radioButton_ans2q9.Text == v[8].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q9.Checked == true)
            {
                if (radioButton_ans3q9.Text == v[8].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q9.Checked == true)
            {
                if (radioButton_ans4q9.Text == v[8].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;


            if (radioButton_ans1q10.Checked == true)
            {
                if (radioButton_ans1q10.Text == v[9].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans2q10.Checked == true)
            {
                if (radioButton_ans2q10.Text == v[9].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans3q10.Checked == true)
            {
                if (radioButton_ans3q10.Text == v[9].raspuns_corect) _gradee++;
            }
            else if (radioButton_ans4q10.Checked == true)
            {
                if (radioButton_ans4q10.Text == v[9].raspuns_corect) _gradee++;
            }
            else _checkflag = 1;


            

            if (_checkflag == 1) { MessageBox.Show("Please answer all questions"); }
            else
            {
                string message = string.Format("Congratulations!\n You got {0} out of 10", _gradee.ToString());
                MessageBox.Show(message);
                //insert grade;
                info.username = LogInWindow.get_entered_username();
                info.id_user = LogInWindow.get_entered_username_id();
                info.materie = metroComboBox1.SelectedItem.ToString();
                info.grade = _gradee ;
                info.data = DateTime.Today;


                dt = opr.id_log(info);
                foreach (DataRow row in dt.Rows)
                {
                    string id1 = row["id_log"].ToString();
                    info.id_log = Convert.ToInt32(id1) + 1;
                    //if (Convert.ToInt32(id1) < ) info.id_log = 1;
                    //else info.id_log = Int32.Parse(id1) + 1;
                }
                //info.id_log = 1;
                // MessageBox.Show(info.username);
                // MessageBox.Show(info.id_user.ToString());
                // MessageBox.Show(info.id_log.ToString());
                // MessageBox.Show(info.data.ToString());
                // MessageBox.Show(info.grade.ToString());

                int x = opr._insert_grade(info);
                if(x>0)
                {
                    panel_tests.Hide();
                    metroTile_options_student.Enabled = true;
                    metroTile_results_student.Enabled = true;
                    groupBox_test.Show();
                    label5.Show();
                    metroComboBox1.Show();
                    metroButton1.Show();
                }

            }

        }
        private void metroTile_results_Click(object sender, EventArgs e)
        {

            groupBox_test.Hide();
            groupBox_options.Hide();
            groupBox_results.Show();
            metroButton_showresults.Enabled = true;
           // dataGridView_results.I
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void metroButton_showresults_Click(object sender, EventArgs e)
        {
            info.id_user = LogInWindow.get_entered_username_id();
            dt = opr.fill_datagrid(info);
            foreach (DataRow row in dt.Rows)
            {
                string materie = row["materie"].ToString();
                string grade = row["nota_test"].ToString();
                string date = row["data_test"].ToString();
                this.dataGridView_results.Rows.Add(materie, grade, date);
                metroButton_showresults.Enabled = false;
            }

                //this.dataGridView_results.Rows.Add("aaa", "fff", "ddd");

       }
        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        //************************  TEACHER ********************

        private void metroTile_options_teacher_Click(object sender, EventArgs e)
        {
            groupBox_teacher_options.Show();
            groupBox_teacher_results.Hide();
            groupBox_tests_teacher.Hide();
        }
        private void metroTile_test_teacher_Click(object sender, EventArgs e)
        {
            groupBox_teacher_options.Hide();
            groupBox_teacher_results.Hide();
            groupBox_tests_teacher.Show();
        }
        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }
        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }
        private void metroTile3_Click_1(object sender, EventArgs e)
        {
            groupBox_4answer_qustion.Show();
            groupBox_question_type.Hide();
            _question_type = 1;
        }
        private void metroTile4_Click_1(object sender, EventArgs e)
        {
            groupBox_true_false.Show();
            groupBox_question_type.Hide();
            _question_type = 2;
        }
        private void metroTile1_Click_2(object sender, EventArgs e)
        {
            int _flag = 0;
            if (string.IsNullOrWhiteSpace(metroTextBox_question_sentence.Text)) _flag = 1;
            if (string.IsNullOrWhiteSpace(metroTextBox_asnwer1.Text)) _flag = 1;
            if (string.IsNullOrWhiteSpace(metroTextBox_answer2.Text)) _flag = 1;
            if (string.IsNullOrWhiteSpace(metroTextBox_answer3.Text)) _flag = 1;
            if (string.IsNullOrWhiteSpace(metroTextBox_answer4.Text)) _flag = 1;
            if (string.IsNullOrWhiteSpace(metroTextBox_right_answer.Text)) _flag = 1;
            if (_flag == 1) MessageBox.Show("Please complete all required fields!");
            else
            {
                info.sentence = metroTextBox_question_sentence.Text;
                info.answer1 = metroTextBox_asnwer1.Text;
                info.answer2 = metroTextBox_answer2.Text;
                info.answer3 = metroTextBox_answer3.Text;
                info.answer4 = metroTextBox_answer4.Text;
                info.right_answer = metroTextBox_right_answer.Text;
                info.question_type = _question_type;


                info.username = LogInWindow.get_entered_username();
                info.id_materie = get_materie_id();
                //MessageBox.Show(TeacherType.get_teacher_materie());
               // MessageBox.Show(info.id_materie.ToString());

                int x = opr.insert_question(info);
                if (x > 0) MessageBox.Show("Question added!");
               // int x = get_materie_id();
            }
        }
        private void metroTile_add_question_Click(object sender, EventArgs e)
        {
            groupBox_question_type.Show();
            groupBox_delete_question.Hide();
        }
        private void metroTile2_Click(object sender, EventArgs e)
        {
            int _flag = 0;
            if (string.IsNullOrWhiteSpace(metroTextBox_sentencetruefalse.Text)) _flag = 1;
            if (metroRadioButton_false.Checked == false && metroRadioButton_true.Checked == false) _flag = 1;
            if (metroRadioButton_true.Checked== true)
            {
                info.right_answer = "TRUE";
            }        
            if(metroRadioButton_false.Checked== true)
            {
                info.right_answer = "FALSE";
            }
            if (_flag == 0)
            {
                info.sentence = metroTextBox_sentencetruefalse.Text;
                info.answer1 = "-1";
                info.answer2 = "-1";
                info.answer3 = "-1";
                info.answer4 = "-1";

                info.question_type = _question_type;
                info.username = LogInWindow.get_entered_username();
                info.id_materie = get_materie_id();

                int x = opr.insert_question(info);
                if (x > 0) MessageBox.Show("Question added!");
            }
            else MessageBox.Show("Please complete all required fields!");
        }
        private void metroTile6_Click(object sender, EventArgs e)
        {
            groupBox_true_false.Hide();
        }
        private void metroTile1_Click_3(object sender, EventArgs e)
        {
            groupBox_4answer_qustion.Hide();
        }
        private void fill_delete_combo()
        {
            metroComboBox_delete_question.Items.Clear();
            info.id_materie = get_materie_id();
            dt = opr.select_question_by_materie_id(info);
            foreach (DataRow row in dt.Rows)
            {
               enunt_materie=(row["enunt"].ToString());
                metroComboBox_delete_question.Items.Add(enunt_materie);
            }
        }
        private void fill_results_combo()
        {
            metroComboBox_teacher_results.Items.Clear();
            metroComboBox_teacher_results.Items.Add("* All students *");
            //info.type = "student";
            //dt = opr.get_all_students_list(info);
            //foreach (DataRow row in dt.Rows)
            //{
            //    enunt_materie = (row["name"].ToString());
            //    metroComboBox_teacher_results.Items.Add(enunt_materie);
            //}
        }
        private void dataGridView_teacher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void metroTile_logoff_student_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInWindow Cs = new LogInWindow();
            Cs.Show();
        }
        private void metroButton_changepasswordsave1_Click(object sender, EventArgs e)
        {
            info.username = LogInWindow.get_entered_username();
            info.password = metroTextBox_oldpassword1.Text;

            dt = opr.check_oldpassword(info);
            if (dt.Rows.Count > 0)
            {
                dt.Clear();
                if (metroTextBox_newpassword1.Text == metroTextBox_retypepassword1.Text)
                {
                    info.password = metroTextBox_newpassword1.Text;
                    int x = opr.update_password(info);

                    MessageBox.Show("Password changed!");
                }
                else MessageBox.Show("Please re-type your password correctly");

            }
            else MessageBox.Show("Old password is wrong");
        }
        private void metroTile_changepassword1_Click(object sender, EventArgs e)
        {
            groupBox_password1.Show();
            groupBox_username1.Hide();
        }
        private void metroTile_changeusername1_Click(object sender, EventArgs e)
        {
            groupBox_password1.Hide();
            groupBox_username1.Show();
        }
        private void metroButton_changeusernamesave1_Click(object sender, EventArgs e)
        {
            info.username = LogInWindow.get_entered_username();
          
            if (LogInWindow.get_entered_username() == metroTextBox_oldusername1.Text)
            { 
                if (metroTextBox_newusername1.Text == metroTextBox_retypeusername1.Text)
                {
                    info.password = metroTextBox_oldusername1.Text;
                    info.username = metroTextBox_newusername1.Text;
                    int x = opr.update_username(info);
                    MessageBox.Show("Username changed!");
                }
                else MessageBox.Show("Please re-type your username correctly");

            }
            else MessageBox.Show("Old username is wrong");
            // groupBox_username.Hide();
        }
        private void metroTile_logoff_teacher_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInWindow Cs = new LogInWindow();
            Cs.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroTile_results_student.Enabled = true;
            metroTile_options_student.Enabled = true;
            panel_tests.Hide();
            groupBox_test.Show();
            label5.Show();
            metroComboBox1.Show();
            metroButton1.Show();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            groupBox_question_type.Hide();
            groupBox_true_false.Hide();
            groupBox_4answer_qustion.Hide();
            if (metroComboBox_delete_question.SelectedIndex<0) MessageBox.Show("You must select a question to delete!");
            else
            {
                enunt_materie = metroComboBox_delete_question.SelectedItem.ToString();
               //MessageBox.Show(enunt_materie);
                info.materie = enunt_materie;
                switch (MessageBox.Show("Are you sure?", " ", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        {
                            int x = opr.delete_question(info);
                            MessageBox.Show("Question deleted");
                            groupBox_delete_question.Hide();
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                }
            }
        }
        private void metroTile_delete_question_Click(object sender, EventArgs e)
        {
            groupBox_4answer_qustion.Hide();
            groupBox_question_type.Hide();
            groupBox_true_false.Hide();
            groupBox_delete_question.Show();
            groupBox_true_false.Hide();
            fill_delete_combo();
        }
        private void metroTile5_Click(object sender, EventArgs e)
        {
            groupBox_delete_question.Hide();
        }
        private void metroTile_results_teacher_Click(object sender, EventArgs e)
        {
            groupBox_tests_teacher.Hide();
            groupBox_teacher_options.Hide();
            groupBox_teacher_results.Show();
            fill_results_combo();
        }
        private void metroTile_teacher_result_show_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(get_teacher_materie());
            if (metroComboBox_teacher_results.SelectedIndex < 0)
                MessageBox.Show("You must select something to show!");
            else
            {
               if(metroComboBox_teacher_results.SelectedIndex==0)
                { 
                    info.materie = get_teacher_materie();
                    dt = opr.select_all_log_table(info);
                    foreach (DataRow row in dt.Rows)
                    {
                        _id = row["id_user"].ToString();
                        _subject = row["materie"].ToString();
                        _grade = row["nota_test"].ToString();
                        _date = row["data_test"].ToString();
                        DataTable dt2 = new DataTable();
                        info.id = Convert.ToInt32(row["id_user"]);
                        int a = get_materie_id();
                        dt2 = opr.get_username_with_id(info);

                        foreach (DataRow row2 in dt2.Rows)
                        {

                            _username = row2["username"].ToString();
                            _name = row2["name"].ToString();
                            this.dataGridView_teacher.Rows.Add(_id, _username, _name, _subject,_grade, _date);
                        }

                        //this.dataGridView_teachers.Rows.Add();
                    }                    
                }
                else
                {
                    
                }
            }
        }
    }
}
