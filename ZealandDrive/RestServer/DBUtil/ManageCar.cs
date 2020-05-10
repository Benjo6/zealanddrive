using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace RestServer.DBUtil
{
    public class ManageCar
    {
        private const String connString =
    @" Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZealandDrive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IList<Car> HentAlle()
        {
            IList<Car> retListe = new List<Car>();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Car", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        retListe.Add(ReadNextCar(reader));
                    }
                }
            }
            return retListe;
        }

        public Car HentEn(int id)
        {
            Car enCar = new Car();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Car WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        enCar = ReadNextCar(reader);
                    }
                }
            }
            return enCar;
        }
        public bool Opret(Car Car)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Car (id, color, brand, model, year, seats, fk_userId) VALUES (@id, @color, @brand, @model, @year, @seats, @fk_user)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Car.Id);
                    cmd.Parameters.AddWithValue("@color", Car.Color);
                    cmd.Parameters.AddWithValue("@brand", Car.Brand);
                    cmd.Parameters.AddWithValue("@model", Car.Model);
                    cmd.Parameters.AddWithValue("@year", Car.Year);
                    cmd.Parameters.AddWithValue("@seats", Car.Seats);
                    cmd.Parameters.AddWithValue("@fk_user", 1);

                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public bool Update(Car Car)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("UPDATE Car SET id = @id, color = @color, brand = @brand, model = @model, year = @year, seats = @seats WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Car.Id);
                    cmd.Parameters.AddWithValue("@color", Car.Color);
                    cmd.Parameters.AddWithValue("@brand", Car.Brand);
                    cmd.Parameters.AddWithValue("@model", Car.Model);
                    cmd.Parameters.AddWithValue("@year", Car.Year);
                    cmd.Parameters.AddWithValue("@seats", Car.Seats);


                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public Car Slet(int id)
        {
            Car Car = HentEn(id);

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Car WHERE id = @id ", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Car.Id);


                    cmd.ExecuteNonQuery();

                }
            }
            return Car;
        }



        private Car ReadNextCar(SqlDataReader reader)
        {
            Car Car = new Car();

            Car.Id = reader.GetInt32(0);
            Car.Color = reader.GetString(1);
            Car.Brand = reader.GetString(2);
            Car.Model = reader.GetString(3);
            Car.Year = reader.GetInt32(4);
            Car.Seats = reader.GetInt32(5);
            Car.UserId = reader.GetInt32(6);

            return Car;
        }
    }
}
