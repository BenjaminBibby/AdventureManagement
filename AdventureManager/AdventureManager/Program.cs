using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace AdventureManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //SQLiteConnection.CreateFile("AdventureManager.db");

            SQLiteConnection dbConn = new SQLiteConnection("Data Source=AdventureManager.db;Version=3");
            dbConn.Open();
            String sql = "create table Fælde(ID Integer, skade int)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            //SQLiteConnection dbConn = new SQLiteConnection("Data Source=mind.db;Version=3");
            //dbConn.Open();
            //String sql = "insert into Bruger (name, alder) values ('Carsten', 43)";
            //SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            //command.ExecuteNonQuery();
        }
    }
}
