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
    public partial class TeacherType : MetroFramework.Forms.MetroForm
    {
        public Informations info = new Informations();
        public Operations opr = new Operations();
        public DataTable dt = new DataTable();
        static int _flag;
        static string _teacher_materie;

        public TeacherType()
        {
            InitializeComponent();
            fill_combo();
           


        }
        public static string get_teacher_materie()
        {
            return _teacher_materie;
        }
        public static int get_flag()
        {
            return _flag;
        }
        private void TeacherType_Load(object sender, EventArgs e)
        {

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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string answer = metroComboBox1.SelectedItem.ToString();
            info.username = LogInWindow.get_teacher_username();
            dt = opr.get_username_id(info);
            foreach (DataRow row in dt.Rows)
            {
                info.id = Convert.ToInt32(row["id_user"]);
                MessageBox.Show(info.id.ToString());
                // MessageBox.Show(_username_id.ToString());
            }
            MessageBox.Show(info.id.ToString());
            _teacher_materie = answer;
            MessageBox.Show(info.id.ToString());
            info.materie = answer;
            //info.id = 1;
            int x = opr.insert_teacher(info);
            if (x > 0) _flag = 1;
        }
        //public void insert_register_teacher(Informations inf)
        //{
        //    if (_flag == 1)
        //    {
        //        int x = opr.insert_LogData(inf);
        //        if (x > 0)
        //        {
        //            id++;
        //            MessageBox.Show("Insert successfuly");
        //        }
        //    }
        //}
    }
}
