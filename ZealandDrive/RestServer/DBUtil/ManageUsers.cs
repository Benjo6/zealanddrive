using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace RestServer.DBUtil
{
    public class ManageUsers
    {
        private const String connString = @"Server=tcp:zealand-drive.database.windows.net,1433;Initial Catalog=ZealandDrive;Persist Security Info=False;User ID=zealand-drive-admin;Password=Secret1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    

        public IList<Users> HentAlle()
        {
            IList<Users> retListe = new List<Users>();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        retListe.Add(ReadNextUsers(reader));
                    }
                }
            }
            return retListe;
        }

        public Users HentEn(int id)
        {
            Users enUsers = new Users();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        enUsers = ReadNextUsers(reader);
                    }
                }
            }
            return enUsers;
        }
        public bool Opret(Users Users)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (id, email, name, lastname, password) VALUES (@id, @email, @name, @lastname, @password)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Users.Id);
                    cmd.Parameters.AddWithValue("@email", Users.Email);
                    cmd.Parameters.AddWithValue("@name", Users.Name);
                    cmd.Parameters.AddWithValue("@lastname", Users.Lastname);
                    cmd.Parameters.AddWithValue("@password", Users.Password);
                  

                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public bool Update(Users Users)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET id = @id, email = @email, name = @name, lastname = @lastname, password = @password WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Users.Id);
                    cmd.Parameters.AddWithValue("@email", Users.Email);
                    cmd.Parameters.AddWithValue("@name", Users.Name);
                    cmd.Parameters.AddWithValue("@lastname", Users.Lastname);
                    cmd.Parameters.AddWithValue("@passowrd", Users.Password);
                   


                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public Users Slet(int id)
        {
            Users Users = HentEn(id);

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE id = @id ", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Users.Id);


                    cmd.ExecuteNonQuery();

                }
            }
            return Users;
        }



        private Users ReadNextUsers(SqlDataReader reader)
        {
            Users Users = new Users();

            Users.Id = reader.GetInt32(0);
            Users.Email = reader.GetString(1);
            Users.Name = reader.GetString(2);
            Users.Lastname = reader.GetString(3);
            Users.Password = reader.GetString(4);
        

            return Users;
        }
    }
}
