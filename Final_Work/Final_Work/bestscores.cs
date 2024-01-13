using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Final_Work
{
    public partial class bestscores : Form
    {
        int whatlvl;
        public bestscores()
        {
            InitializeComponent();
        }

        public bestscores(int level)
        {
            InitializeComponent();
            whatlvl = level;
            showbymoves(level);
        }

        private void showbymoves(int lvl)// sort score by moves
        {
            listBox1.Items.Clear();
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-S569GU1\\SQLEXPRESS;database=sokoban_game;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"Select fname,timershow,moves from lvlsdata where lvl={whatlvl} order by moves ASC; "; // sql  - take only the name time and moves
            mySqlConnection.Open();                                     // oreder by moves but only the lvl
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            string strname = "";
            string realtime = "";
            string moves = "";

            while (mySqlDataReader.Read())
            {
                strname = mySqlDataReader[0].ToString();
                realtime = mySqlDataReader[1].ToString();
                moves = mySqlDataReader[2].ToString();
                listBox1.Items.Add(strname + " , " + realtime + " , " + moves);
            }

            mySqlDataReader.Close();
            mySqlConnection.Close();

        }

        private void showbytime(int lvl) {
            listBox1.Items.Clear();
            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-S569GU1\\SQLEXPRESS;database=sokoban_game;Integrated Security=SSPI;");
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"Select fname,timershow,moves from lvlsdata where lvl={whatlvl} order by realtime ASC; "; // sql  - take only the name time and moves
            mySqlConnection.Open();                                     // oreder by moves but only the lvl
            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

            string strname = "";
            string realtime = "";
            string moves = "";

            while (mySqlDataReader.Read())
            {
                strname = mySqlDataReader[0].ToString();
                realtime = mySqlDataReader[1].ToString();
                moves = mySqlDataReader[2].ToString();
                listBox1.Items.Add(strname + " , " + realtime + " , " + moves);
            }

            mySqlDataReader.Close();
            mySqlConnection.Close();
        }// sort by time

        private void bestscores_Load(object sender, EventArgs e)
        {
            lvllbl.Text = whatlvl.ToString();
            // Calculate the new location to center the form on the screen
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;

            // Set the new location
            this.Location = new Point(x, y);

            if (whatlvl == 999) {
                lvllbl.Text = "yours";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            showbytime(whatlvl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showbymoves(whatlvl);
        }
    }
}
