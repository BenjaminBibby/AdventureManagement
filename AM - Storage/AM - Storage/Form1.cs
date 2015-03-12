using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AM___Storage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SQLiteConnection.CreateFile("AdventureManager.db");

            SQLiteConnection dbConn = new SQLiteConnection("Data Source=AdventureManager.db;Version=3");
            dbConn.Open();
            String sql = "create table if not exists Storage(ID Integer primary key, player_id int, current_space_used int, maxsimum_space)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            sql = "create table if not exists Items(ID Integer primary key, weight int, quality string, is_in_storage bool, type string)";
            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
