using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektmunka1.DatabaseManager
{
    public class BaseDatabaseManager
    {
        protected BaseDatabaseManager() { }

        public static MySqlConnection connection
        {
            get
            {
                MySqlConnection connection = new MySqlConnection();
                string connctionString = "SERVER=192.168.50.103;" + "DATABASE=Dolgozo;" + "UID=root;" + "PASSWORD=;" + "SSL MODE=none;";
                connection.ConnectionString = connctionString;
                return connection;
            }
        }
    }
}
