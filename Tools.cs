using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Cross_Alpha
{
    class Tools
    {
        private MySqlConnection connection;

        private void InitConnection()
        {
            this.connection = new MySqlConnection("SERVER=127.0.0.1;DATABASE=cross;UID=root;PASSWORD=");
        }
        public Tools()
        {
            this.InitConnection();
        }



        public ArrayList Read_Name(string name)
        {
            ArrayList Name_List = new ArrayList();
            try
            {
                this.connection.Open();
                MySqlCommand get_Name = this.connection.CreateCommand();
                get_Name.CommandText = "SELECT Name FROM Student WHERE Name LIKE '" + name + "%' ORDER BY Name ASC";
                MySqlDataReader Lire = get_Name.ExecuteReader();
                while (Lire.Read())
                    Name_List.Add(Lire.GetString("Name"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return Name_List;
        }

        public ArrayList Read_Firstname(string name)
        {
            ArrayList Firstname_List = new ArrayList();
            try
            {
                this.connection.Open();
                MySqlCommand get_Firstname = this.connection.CreateCommand();
                get_Firstname.CommandText = "SELECT Firstname FROM Student WHERE Name LIKE '" + name + "%' ORDER BY Name ASC";
                MySqlDataReader Lire = get_Firstname.ExecuteReader();
                while (Lire.Read())
                    Firstname_List.Add(Lire.GetString("Firstname"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return Firstname_List;
        }


        public string[] Read_Data(String name, String firstname)
        {
            string[] Data = new string[1];
            try
            {
                this.connection.Open();
                MySqlCommand lire_D = this.connection.CreateCommand();
                lire_D.CommandText = "SELECT * FROM Student WHERE Name=@name AND Firstname=@firstname";
                lire_D.Parameters.AddWithValue("@name", name);
                lire_D.Parameters.AddWithValue("@firstname", firstname);
                MySqlDataReader Lire = lire_D.ExecuteReader();
                while (Lire.Read())
                {
                    Data[0] = Lire.GetString("Class");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return Data;
        }


    }
}
