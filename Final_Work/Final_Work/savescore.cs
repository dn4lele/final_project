using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Work
{
    public partial class savescore : Form
    {
        public savescore()
        {
            InitializeComponent();
        }

        string fname;
        string muchtime;
        int muchrealtime;
        int muchmoves;
        int lvl;

        public savescore(int moves , string time , int level , int actualtime)
        {
            InitializeComponent();

            movelbl.Text = moves.ToString();
            timelbl.Text = time.ToString();

            muchtime = time;
            muchmoves = moves;
            muchrealtime = actualtime;
            lvl = level;

        }


        private void savescore_Load(object sender, EventArgs e)
        {
            // Calculate the new location to center the form on the screen
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;

            // Set the new location
            this.Location = new Point(x, y);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            fname = nametxt.Text.ToString();

            //write in the sql
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-S569GU1\\SQLEXPRESS;database=sokoban_game;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            mySqlCommand.CommandText = $"insert into lvlsdata values('{fname}','{muchtime}', {muchrealtime},{muchmoves} , {lvl}); ";
            mySqlCommand.ExecuteNonQuery();
            MessageBox.Show("your scored saved");
            mySqlConnection.Close();


            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
