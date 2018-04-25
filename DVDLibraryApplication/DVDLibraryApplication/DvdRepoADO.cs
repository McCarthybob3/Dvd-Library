using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DVDLibraryApplication.Models;
using System.Configuration;
using System.Data;
using Dapper;

namespace DVDLibraryApplication
{
    public class DvdRepoADO : IDvdRepository
    {
        public void Add(dvd dvd)
        {
   

            using (SqlConnection conn = new SqlConnection())
            {
                dvd dvds = new dvd();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("CreateNewDvd", conn);
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                cmd.Parameters.AddWithValue("@Title", dvd.title);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.director);
                cmd.Parameters.AddWithValue("@Rating", dvd.rating);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.realeaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.notes);
                cmd.Parameters.AddWithValue("@DirectorID", SqlDbType.Int);
                cmd.Parameters.AddWithValue("@RatingID", SqlDbType.Int);
                cmd.Parameters.AddWithValue("@DvdID", SqlDbType.Int);

             
                cmd.ExecuteNonQuery();


            }



        }

        public void Delete(int dvdid)
        {

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("DeleteDvd", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@DvdId", dvdid);


                conn.Open();

                cmd.ExecuteNonQuery();



            }
        }

        public void Edit(dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
               
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand("UpdateDvd", conn);
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
             

                cmd.Parameters.AddWithValue("@Title", dvd.title);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.director);
                cmd.Parameters.AddWithValue("@Rating", dvd.rating);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.realeaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.notes);
                cmd.Parameters.AddWithValue("@DirectorID", SqlDbType.Int);
                cmd.Parameters.AddWithValue("@RatingID", SqlDbType.Int);
                cmd.Parameters.AddWithValue("@DvdID", dvd.dvdId);

                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {

                        dvd.dvdId = (int)rdr["dvdId"];
                        dvd.title = rdr["title"].ToString();
                        dvd.realeaseYear = (string)rdr["releaseYear"];

                        dvd.director = rdr["Name"].ToString();
                        dvd.rating = rdr["Rating"].ToString();
                        if (rdr["Notes"] != DBNull.Value)
                        {
                            dvd.notes = rdr["Notes"].ToString();
                        }

                    }
                }


            }
        }

        public dvd Get(int dvdid)
        {
            dvd dvds = new dvd();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RetreiveDvdByID";
                cmd.Parameters.AddWithValue("@DvdID", dvdid);
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        dvd currentRow = new dvd();
                        currentRow.dvdId = (int)rdr["dvdId"];
                        currentRow.title = rdr["title"].ToString();
                        currentRow.realeaseYear = (string)rdr["releaseYear"];

                        currentRow.director = rdr["Name"].ToString();
                        currentRow.rating = rdr["Rating"].ToString();
                        if (rdr["Notes"] != DBNull.Value)
                        {
                            currentRow.notes = rdr["Notes"].ToString();
                        }
                        dvds =currentRow;
                    }
                }
            }
            return dvds;
        }

    

        public List<dvd> GetAll()
        {
            List<dvd> dvds = new List<dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetreivingAllDvds";
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        dvd currentRow = new dvd();
                        currentRow.dvdId = (int)rdr["dvdId"];
                        currentRow.title = rdr["title"].ToString();
                        currentRow.realeaseYear = (string)rdr["releaseYear"];
                       
                        currentRow.director = rdr["Name"].ToString();
                        currentRow.rating = rdr["Rating"].ToString();
                        if (rdr["notes"] != DBNull.Value)
                        {
                            currentRow.notes = rdr["notes"].ToString();
                        }
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<dvd> GetDirector(string dvdDirector)
        {
            List<dvd> dvds = new List<dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RetreiveDvdByDirectorName";
                cmd.Parameters.AddWithValue("@DirectorName", dvdDirector);
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        dvd currentRow = new dvd();
                        currentRow.dvdId = (int)rdr["dvdId"];
                        currentRow.title = rdr["title"].ToString();
                        currentRow.realeaseYear = (string)rdr["releaseYear"];

                        currentRow.director = rdr["Name"].ToString();
                        currentRow.rating = rdr["Rating"].ToString();
                        if (rdr["Notes"] != DBNull.Value)
                        {
                            currentRow.notes = rdr["Notes"].ToString();
                        }
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<dvd> GetName(string dvdTitle)
        {
            List<dvd> dvds = new List<dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RetreiveDvdByTitle";
                cmd.Parameters.AddWithValue("@DvdTitle", dvdTitle);
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        dvd currentRow = new dvd();
                        currentRow.dvdId = (int)rdr["dvdId"];
                        currentRow.title = rdr["title"].ToString();
                        currentRow.realeaseYear = (string)rdr["releaseYear"];

                        currentRow.director = rdr["Name"].ToString();
                        currentRow.rating = rdr["Rating"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<dvd> GetRating(string dvdRating)
        {
            List<dvd> dvds = new List<dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RetreiveDvdByRating";
                cmd.Parameters.AddWithValue("@Rating", dvdRating);
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        dvd currentRow = new dvd();
                        currentRow.dvdId = (int)rdr["dvdId"];
                        currentRow.title = rdr["title"].ToString();
                        currentRow.realeaseYear = (string)rdr["releaseYear"];

                        currentRow.director = rdr["Name"].ToString();
                        currentRow.rating = rdr["Rating"].ToString();
                       
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<dvd> GetYear(string dvdYear)
        {
            List<dvd> dvds = new List<dvd>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "RetreiveDvdByReleaseYear";
                cmd.Parameters.AddWithValue("@ReleaseYear", dvdYear);
                conn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        dvd currentRow = new dvd();
                        currentRow.dvdId = (int)rdr["dvdId"];
                        currentRow.title = rdr["title"].ToString();
                        currentRow.realeaseYear = (string)rdr["releaseYear"];

                        currentRow.director = rdr["Name"].ToString();
                        currentRow.rating = rdr["Rating"].ToString();
                        
                        
                        
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }
    }
}