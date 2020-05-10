using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace RestServer.DBUtil
{
    public class ManagePassenger
    {
        private const String connString =
        @" Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZealandDrive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IList<Passenger> HentAlle()
        {
            IList<Passenger> retListe = new List<Passenger>();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Passenger", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        retListe.Add(ReadNextPassenger(reader));
                    }
                }
            }
            return retListe;
        }

        public Passenger HentEn(int id)
        {
            Passenger enPassenger = new Passenger();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Passenger WHERE fk_userId = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        enPassenger = ReadNextPassenger(reader);
                    }
                }
            }
            return enPassenger;
        }
        public bool Opret(Passenger Passenger)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Passenger (fk_userId, fk_routeId, status) VALUES (@userId, @routeId, @status )", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", Passenger.UserId);
                    cmd.Parameters.AddWithValue("@routeId", Passenger.RouteId);
                    cmd.Parameters.AddWithValue("@status", Passenger.Status);
                  

                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public bool Update(Passenger Passenger)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("UPDATE Passenger SET fk_userId = @userId, fk_routeId = @routeId, status = @status  WHERE fk_userId = @userId", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", Passenger.UserId);
                    cmd.Parameters.AddWithValue("@routeId", Passenger.RouteId);
                    cmd.Parameters.AddWithValue("@status", Passenger.Status);
                


                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public Passenger Slet(int id)
        {
            Passenger Passenger = HentEn(id);

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Passenger WHERE fk_userId = @userId ", conn))
                {
                    cmd.Parameters.AddWithValue("@userId", Passenger.UserId);


                    cmd.ExecuteNonQuery();

                }
            }
            return Passenger;
        }



        private Passenger ReadNextPassenger(SqlDataReader reader)
        {
            Passenger Passenger = new Passenger();

            Passenger.UserId = reader.GetInt32(0);
            Passenger.RouteId = reader.GetInt32(1);
            Passenger.Status = reader.GetString(2);
        

            return Passenger;
        }
    }
}