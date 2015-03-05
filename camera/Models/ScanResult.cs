using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace camera.Models
{
    public class ScanResult
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        //public byte[] Photo { get; set; }

        //private bool connection_open;
        //private MySqlConnection connection;

        public ScanResult(int id, string email)
        {
            UserID = id;
            Email = email;
        }

        //public ScanResult(int arg_id)
        //{
        //    Get_Connection();
        //    UserID = arg_id;
        //    try
        //    {


        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.Connection = connection;
        //        cmd.CommandText = string.Format("select * from users where id = '{0}'", UserID);
                
        //        MySqlDataReader reader = cmd.ExecuteReader();

        //        try
        //        {
        //            reader.Read();

        //            if (reader.IsDBNull(0) == false)
        //                Email = reader.GetString(0);
        //            else
        //                Email = null;
        //            //if (reader.IsDBNull(3) == false)
        //            //{
        //            //    Photo = new byte[reader.GetInt32(4)];
        //            //    reader.GetBytes(3, 0, Photo, 0, reader.GetInt32(4));
        //            //}
        //            //else
        //            //{
        //            //    Photo = null;
        //            //}
        //            reader.Close();

        //        }
        //        catch (MySqlException e)
        //        {
        //            string MessageString = "Read error occurred  / entry not found loading the Column details: "
        //                + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
        //            //MessageBox.Show(MessageString, "SQL Read Error");
        //            reader.Close();
        //            Email = MessageString;
        //        }
        //    }
        //    catch (MySqlException e)
        //    {
        //        string MessageString = "The following error occurred loading the Column details: "
        //            + e.ErrorCode + " - " + e.Message;
        //        Email = MessageString;
        //    }




        //    connection.Close();


        //}

        //private void Get_Connection()
        //{
        //    connection_open = false;

        //    connection = new MySqlConnection();
        //    //connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
        //    connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        //    //            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
        //    if (Open_Local_Connection())
        //    {
        //        connection_open = true;
        //    }
        //    else
        //    {
        //        //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
        //        //					 Application::Exit();
        //    }

        //}

        //private bool Open_Local_Connection()
        //{
        //    try
        //    {
        //        connection.Open();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}
    }
}