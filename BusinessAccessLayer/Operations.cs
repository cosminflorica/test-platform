using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessEntityLayer;
using System.Data;
using System.Data.SqlClient;


namespace BusinessAccessLayer
{
    public class Operations
    {
        public Dbconnection db = new Dbconnection();
        public Informations info = new Informations();

       
        public DataTable login(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * FROM Users_Table Where username='"+info.username+"' and password='"+info.password+"' and type='"+info.type+"'";
            return db.ExeReader(command);
        }
        public DataTable email(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select username,password  FROM Users_Table Where email='" + info.email + "'";
            
            return db.ExeReader(command);
           
        }    
        public DataTable id_user(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT id_user FROM Users_Table WHERE id_user = (SELECT max(id_user) FROM Users_Table)";
            return db.ExeReader(command);
        }
        public DataTable check_oldpassword(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Users_Table WHERE username = '"+info.username+"' and password='"+info.password+"'";
            return db.ExeReader(command);
        }
        public DataTable get_username_materie(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT materie FROM Teacher_Materie_Table WHERE id_teacher= '"+ info.id_user+"'";
            return db.ExeReader(command);
        }   
        public DataTable get_id_materie(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT id_materie FROM Materie_Table WHERE nume_materie='"+info.materie+"'";
            return db.ExeReader(command);
        }
        public DataTable get_materie()
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT nume_materie FROM Materie_Table WHERE id_materie>0";
            return db.ExeReader(command);
        }
        public DataTable _load_panel(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT TOP 10 enunt,raspuns1,raspuns2,raspuns3,raspuns4,raspuns_corect FROM Intrebari_Table JOIN Materie_Table on Intrebari_Table.id_materie = Materie_Table.id_materie where nume_materie = '"+info.materie+"' ORDER by newid()";
            return db.ExeReader(command);
        }        
        public DataTable get_username_id(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT id_user FROM Users_Table where username = '"+info.username+"'";
            return db.ExeReader(command);
        }
        public DataTable id_log(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT id_log FROM Log_Table WHERE id_log = (SELECT max(id_log) FROM Log_Table)";
            return db.ExeReader(command);
        }
        public DataTable fill_datagrid(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT materie,nota_test,data_test from Log_Table WHERE id_user = '"+info.id_user+"' ";
            return db.ExeReader(command);
        }      
        public DataTable select_question_by_materie_id(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT enunt from Intrebari_Table WHERE id_materie = '" + info.id_materie + "' ";
            return db.ExeReader(command);
        }       
        public DataTable get_all_students_list(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * from Users_Table WHERE type = '"+info.type+"'";
            return db.ExeReader(command);
        }
        public DataTable select_all_log_table(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * from Log_Table WHERE materie='"+info.materie+"'";
            return db.ExeReader(command);
        }
        public DataTable get_username_with_id(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT name,username from Users_Table WHERE id_user='" + info.id + "'";
            return db.ExeReader(command);
        }


        public int insert_LogData(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO Users_Table VALUES ('" + info.id + "','" + info.name + "','" + info.username + "','" + info.password + "','" + info.email + "','" + info.type + "')";
            return db.ExeNonQuery(command);
        }
        public int delete_question(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM Intrebari_Table WHERE enunt = '" + info.materie + "'";
            return db.ExeNonQuery(command);
        }
        public int insert_question(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO Intrebari_Table VALUES ('" + info.id_materie + "', '" + info.question_type + "', '" + info.sentence + "','" + info.answer1 + "','" + info.answer2 + "','" + info.answer3 + "','" + info.answer4 + "','" + info.right_answer + "')";
            return db.ExeNonQuery(command);
        }
        public int _insert_grade(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO Log_Table VALUES ('" + info.id_log + "', '" + info.id_user + "', '" + info.materie + "', '" + info.grade + "', '" + info.data + "')";
            return db.ExeNonQuery(command);
        }
        public int update_username(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE Users_Table SET username='" + info.username + "' WHERE username='" + info.password + "'";
            return db.ExeNonQuery(command);
        }
        public int update_password(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE Users_Table SET password='" + info.password + "' WHERE username='" + info.username + "'";
            return db.ExeNonQuery(command);
        }
        public int insert_teacher(Informations info)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO Teacher_Materie_Table VALUES ('" + info.id + "','" + info.materie + "')";
            return db.ExeNonQuery(command);
        }
    }
}
