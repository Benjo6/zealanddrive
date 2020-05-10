using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace RestServer.DBUtil
{
    public class ManageRoute
    {
        private const String connString =
    @" Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZealandDrive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IList<Route> HentAlle()
        {
            IList<Route> retListe = new List<Route>();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Route", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        retListe.Add(ReadNextRoute(reader));
                    }
                }
            }
            return retListe;
        }

        public Route HentEn(int id)
        {
            Route enRoute = new Route();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Route WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        enRoute = ReadNextRoute(reader);
                    }
                }
            }
            return enRoute;
        }
        public bool Opret(Route Route)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Route (id, routestart, routeend, starttime, fk_carId ) VALUES (@id, @routestart, @routeend, @starttime, @fk_carId )", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Route.Id);
                    cmd.Parameters.AddWithValue("@routestart", Route.RouteStart);
                    cmd.Parameters.AddWithValue("@routeend", Route.RouteEnd);
                    cmd.Parameters.AddWithValue("@starttime", Route.StartTime);
                    cmd.Parameters.AddWithValue("@fk_carId", Route.CarId);
                  

                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public bool Update(Route Route)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("UPDATE Route SET id = @id, routestart = @routestart, routeend = @routeend, starttime = @starttime, fk_carId = @fk_carId, WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Route.Id);
                    cmd.Parameters.AddWithValue("@routestart", Route.RouteStart);
                    cmd.Parameters.AddWithValue("@routeend", Route.RouteEnd);
                    cmd.Parameters.AddWithValue("@starttime", Route.StartTime);
                    cmd.Parameters.AddWithValue("@fk_carId", Route.CarId);
                  

                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public Route Slet(int id)
        {
            Route Route = HentEn(id);

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Route WHERE id = @id ", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Route.Id);


                    cmd.ExecuteNonQuery();

                }
            }
            return Route;
        }



        private Route ReadNextRoute(SqlDataReader reader)
        {
            Route Route = new Route();

            Route.Id = reader.GetInt32(0);
            Route.RouteStart = reader.GetString(1);
            Route.RouteEnd = reader.GetString(2);
            Route.StartTime = reader.GetDateTime(3);
            Route.CarId = reader.GetInt32(4);
         

            return Route;
        }
    }
}
