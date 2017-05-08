using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MVCMariaDBDemo.Models
{
    public class MySqlContext
    {

        public string constr { get; set; }

        public MySqlContext()
        {
            constr = ConfigurationManager.ConnectionStrings["MariaDBstr"].ConnectionString;
        }

        public List<Opera> GetOperas()
        {
            List<Opera> operas = new List<Opera>();

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM Opera";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            operas.Add(new Opera
                            {
                                OperaID = Convert.ToInt32(sdr["OperaID"]),
                                Title = sdr["Title"].ToString(),
                                Year = Convert.ToInt32(sdr["Year"]),
                                Composer = sdr["Composer"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return operas;
        }

        public Opera SelectOperaItem(string id)
        {
            Opera op = new Opera();

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM Opera Where OperaID=@OperaID";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@OperaID", id);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {

                            op.OperaID = Convert.ToInt32(sdr["OperaID"]);
                            op.Title = sdr["Title"].ToString();
                            op.Year = Convert.ToInt32(sdr["Year"]);
                            op.Composer = sdr["Composer"].ToString();

                        }
                    }
                    con.Close();
                }
            }
            return op;
        }

        public void InsertOperas(Opera op)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "INSERT INTO Opera VALUES(@OperaID, @Title,@Year,@Composer)";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@OperaID", op.OperaID);
                    cmd.Parameters.AddWithValue("@Title", op.Title);
                    cmd.Parameters.AddWithValue("@Year", op.Year);
                    cmd.Parameters.AddWithValue("@Composer", op.Composer);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public void UpdateOpera(Opera op)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "UPDATE Opera SET Title=@Title,Year=@Year,Composer=@Composer Where OperaID=@OperaID";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@OperaID", op.OperaID);
                    cmd.Parameters.AddWithValue("@Title", op.Title);
                    cmd.Parameters.AddWithValue("@Year", op.Year);
                    cmd.Parameters.AddWithValue("@Composer", op.Composer);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public void DeleteOpera(string id)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "DELETE FROM Opera Where OperaID=@OperaID";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@OperaID", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }


    }
}