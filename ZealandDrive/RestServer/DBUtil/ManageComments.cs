using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace RestServer.DBUtil
{
    public class ManageComments
    {
        private const String connString =
   @" Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZealandDrive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IList<Comments> HentAlle()
        {
            IList<Comments> retListe = new List<Comments>();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Comments", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        retListe.Add(ReadNextComments(reader));
                    }
                }
            }
            return retListe;
        }

        public Comments HentEn(int id)
        {
            Comments enComments = new Comments();

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Comments WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        enComments = ReadNextComments(reader);
                    }
                }
            }
            return enComments;
        }
        public bool Opret(Comments Comments)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Comments (id, comment, fk_userId, fk_routeId) VALUES (@id, @comment, @userId, @routeId )", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Comments.UserId);
                    cmd.Parameters.AddWithValue("@comment", Comments.Text);

                    cmd.Parameters.AddWithValue("@userId", Comments.UserId);
                    cmd.Parameters.AddWithValue("@routeId", Comments.RouteId);



                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public bool Update(Comments Comments)
        {
            bool ok = false;


            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("UPDATE Comments SET comment = @comment, fk_userId = @userId, fk_routeId = @routeId WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Comments.Id);
                    cmd.Parameters.AddWithValue("@comment", Comments.Text);
                    cmd.Parameters.AddWithValue("@userId", Comments.UserId);
                    cmd.Parameters.AddWithValue("@routeId", Comments.RouteId);




                    int rows = cmd.ExecuteNonQuery();

                    ok = rows == 1;
                }
            }
            return ok;
        }

        public Comments Slet(int id)
        {
            Comments Comments = HentEn(id);

            // forbindelse til database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                // sql kald
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Comments WHERE id = @id ", conn))
                {
                    cmd.Parameters.AddWithValue("@id", Comments.UserId);


                    cmd.ExecuteNonQuery();

                }
            }
            return Comments;
        }



        private Comments ReadNextComments(SqlDataReader reader)
        {
            Comments Comments = new Comments();

            Comments.Id = reader.GetInt32(0); 
            Comments.Text = reader.GetString(1);
            Comments.UserId = reader.GetInt32(2);
            Comments.RouteId = reader.GetInt32(3);



            return Comments;
        }
    }
}