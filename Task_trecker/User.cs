using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_trecker
{
    public class User
    {
        public string user_login { get; set; }
        public string user_password { get; set; }
        public string user_email { get; set; }
       
        public bool user_entry { get; set; }

        DataBase database = new DataBase();

        public User(string user_login, string user_password, string user_email)
        {
            this.user_login = user_login;
            this.user_password = user_password;
            this.user_email = user_email;
            this.user_entry = false;
        }
        public User(string user_login, string user_password)
        {
            this.user_login = user_login;
            this.user_password = user_password;
            this.user_email = "0";
            this.user_entry = false;
        }

        public void Sign_in()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query_string =
            $"select user_id , user_login ,user_email, user_password from users where user_login = '{user_login}' and user_password = '{user_password}'";
            SqlCommand command = new SqlCommand(query_string, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                user_entry = true;
            }
            else
            {
                Console.WriteLine("No such account!");
                
            }
        }

        public void Sign_up()
        {
            database.openConnection();


            if (!existingUser())
            {
                string query_string =
            $"insert into users(user_login , user_email,user_password)  values('{user_login}', '{user_email}', '{user_password}')";

                SqlCommand command = new SqlCommand(query_string, database.getConnection());



                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("success");
                }
                else
                {
                    Console.WriteLine("error!");
                }
                database.closeConnection();

                
                Sign_in();
            }
            else
            {
                Console.WriteLine("acc already exist!");
            }
        }

        public Boolean existingUser()
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query_string =
           $"select user_id , user_login , user_email, user_password from users where user_login = '{user_login}'";
            SqlCommand command = new SqlCommand(query_string, database.getConnection());


            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public async void GetEmail()
        {
            database.openConnection();
            SqlDataReader adapter = null;

            string query_string =
           $"select user_id , user_login , user_email , user_password from users where user_login = '{user_login}' and user_password = '{user_password}'";
            SqlCommand command = new SqlCommand(query_string, database.getConnection());

            adapter = await command.ExecuteReaderAsync();
            adapter.Read();
            user_email = Convert.ToString(adapter["user_email"]);

            database.closeConnection();
        }
    }
}
