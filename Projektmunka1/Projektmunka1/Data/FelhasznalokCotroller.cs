using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows.Media.Media3D;
using Projektmunka1.DatabaseManager;

namespace Projektmunka1.Data
{
    public class FelhasznalokController : BaseDatabaseManager
    {
        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM felhasznalok ORDER BY Nev";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dolgozo egyDolgozo = new Dolgozo();
                    egyDolgozo.Id = int.Parse(reader["Id"].ToString());
                    egyDolgozo.Nev = reader["Nev"].ToString();
                    egyDolgozo.Lakcim = reader["Lakcim"].ToString();
                    egyDolgozo.Fizetes = int.Parse(reader["Fizetes"].ToString());
                    egyDolgozo.Pozicio = reader["Pozicio"].ToString();
                    egyDolgozo.Email = reader["Email"].ToString();
                    list.Add(egyDolgozo);
                }
            }
            catch (Exception ex)
            {
                Dolgozo dolgozo = new Dolgozo();
                dolgozo.Id = -1;
                dolgozo.Nev = ex.Message;
                list.Add(dolgozo);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public string Insert(Record record)
        {
            Dolgozo dolgozo = record as Dolgozo;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"INSERT INTO dolgozok (Nev,Lakcim,Fizetes,Pozicio,Email) VALUES (@Nev,@Lakcim,@Fizetes,@Pozicio,@Email);";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = dolgozo.Nev;
                cmd.Parameters.Add(new MySqlParameter("@Lakcim", MySqlDbType.VarChar)).Value = dolgozo.Lakcim;
                cmd.Parameters.Add(new MySqlParameter("@Fizetes", MySqlDbType.Int32)).Value = dolgozo.Fizetes;
                cmd.Parameters.Add(new MySqlParameter("@Pozicio", MySqlDbType.VarChar)).Value = dolgozo.Pozicio;
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.Int32)).Value = dolgozo.Email;
                try
                {
                    cmd.Connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            cmd.Parameters.Clear();
            return "Sikeres adattárolás.";
        }

        public string Update(Record record)
        {
            Dolgozo dolgozo = record as Dolgozo;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"UPDATE dolgozok SET Nev=@Nev,Lakcim=@Lakcim,Fizetes=@Fizetes,Pozicio=@Pozicio,Email=@Email WHERE Id=@Id;";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                //cmd.Parameters.Add(new MySqlParameter);
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = dolgozo.Nev;
                cmd.Parameters.Add(new MySqlParameter("@Lakcim", MySqlDbType.VarChar)).Value = dolgozo.Lakcim;
                cmd.Parameters.Add(new MySqlParameter("@Fizetes", MySqlDbType.Int32)).Value = dolgozo.Fizetes;
                cmd.Parameters.Add(new MySqlParameter("@Pozicio", MySqlDbType.VarChar)).Value = dolgozo.Pozicio;
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.Int32)).Value = dolgozo.Email;
                cmd.Connection = BaseDatabaseManager.connection;
                try
                {
                    cmd.Connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            cmd.Parameters.Clear();
            return "Sikeres adattárolás.";
        }

        public string Delete(Record record)
        {
            Dolgozo dolgozo = record as Dolgozo;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"DELETE FROM felhasznalok WHERE Id=@Id;";
            //Nev=@Nev,Lakcim=@Lakcim,Fizetes=@Fizetes,Pozicio=@Pozicio,Email=@Email WHERE 
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                //cmd.Parameters.Add(new MySqlParameter);
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = dolgozo.Nev;
                cmd.Parameters.Add(new MySqlParameter("@Lakcim", MySqlDbType.VarChar)).Value = dolgozo.Lakcim;
                cmd.Parameters.Add(new MySqlParameter("@Fizetes", MySqlDbType.Int32)).Value = dolgozo.Fizetes;
                cmd.Parameters.Add(new MySqlParameter("@Pozicio", MySqlDbType.VarChar)).Value = dolgozo.Pozicio;
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.Int32)).Value = dolgozo.Email;
                cmd.Connection = BaseDatabaseManager.connection;
                try
                {
                    cmd.Connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            cmd.Parameters.Clear();
            return "Sikeres törlés.";
        }
    }
}
