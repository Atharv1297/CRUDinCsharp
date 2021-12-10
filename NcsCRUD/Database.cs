using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Npgsql;
using System.IO;
using System.Data;
using System.Data.SqlClient;



namespace NcsCRUD
{
    class Database
    {
        //database connection
        NpgsqlConnection Con;
        string Cs = "Host=localhost;Username=postgres;Password=password;Database=postgres";
        public Boolean ConnectDatabase()
        {


            Con = new NpgsqlConnection(Cs);

            try
            {
                Con.Open();//open connection
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //select query
        NpgsqlCommand cmd;
        NpgsqlDataReader dr;
        public Boolean SelectQuery(String query, string password)
        {
            try
            {
                ConnectDatabase();
                cmd = new NpgsqlCommand(query)
                {
                    Connection = Con,
                    CommandText = query
                };


                dr = cmd.ExecuteReader();
                Console.WriteLine(dr);
                while (dr.Read())
                {
                    Console.WriteLine("Login Successfully");
                    Console.Write("{0}\t{1} \n", dr[0], dr[1]);

                    dr.Close();
                    return true;
                }
                return false;
                //else
                //{
                //    Console.WriteLine("Plz Create Your Account");
                //    dr.Close();
                //    return false;
                //}

            }
            catch (Exception ex)
            {

                Console.WriteLine("String");
                return false;
            }
        }

        //close database connection
        public Boolean CloseDatabase()
        {
            try
            {
                Con.Close();
                Console.WriteLine("Connection closed");
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        //insert query
        public Boolean Ins_Up_Dro_Cre_Query(String query)
        {
            if (ConnectDatabase())
            {
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query);
                    cmd.Connection = Con;
                    cmd.CommandText = query;

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {

                    CloseDatabase();
                    return false;
                }
            }
            else { return false; }

        }

    }
}
