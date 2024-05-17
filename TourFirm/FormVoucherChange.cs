using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TourFirm
{
    public partial class FormVoucherChange : Form
    {
        private NpgsqlConnection con;
        private string conString =
            "Host = 127.0.0.1; Username = postgres; Password = password; Database = TourFirm";
        public FormVoucherChange()
        {
            InitializeComponent();
            con = new NpgsqlConnection(conString);
            con.Open();
            loadVoucher();

            string sql1 = "SELECT id FROM tourists";
            NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, con);
            NpgsqlDataReader reader1 = cmd1.ExecuteReader();
            comboBoxTourist.Items.Clear();
            while (reader1.Read())
            {
                comboBoxTourist.Items.Add(reader1.GetValue(0));
            }
            reader1.Close();

            string sql2 = "SELECT s_id FROM seasons";
            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, con);
            NpgsqlDataReader reader2 = cmd2.ExecuteReader();
            comboBoxSeason.Items.Clear();
            while (reader2.Read())
            {
                comboBoxSeason.Items.Add(reader2.GetValue(0));
            }
            reader2.Close();

        }
        private void loadVoucher()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM trips", con);
            adap.Fill(dt);
            dataGridViewVoucher.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        

        private void dataGridViewVoucher_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
            int t_index = comboBoxTourist.FindString(dataGridViewVoucher.CurrentRow.Cells[1].Value.ToString());
            comboBoxTourist.SelectedIndex = t_index;
            int s_index = comboBoxSeason.FindString(dataGridViewVoucher.CurrentRow.Cells[2].Value.ToString());
            comboBoxSeason.SelectedIndex = s_index;
            //comboBoxSeason.SelectedItem = s_id;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE trips SET tourist_id = @tourist_id, season_id = @season_id  WHERE trip_id = @trip_id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            
            cmd.Parameters.AddWithValue("tourist_id", int.Parse(comboBoxTourist.SelectedItem.ToString()));
            cmd.Parameters.AddWithValue("season_id", int.Parse(comboBoxSeason.SelectedItem.ToString()));
            int id = int.Parse(dataGridViewVoucher.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("trip_id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            loadVoucher();
        }

        private void comboBoxSeason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
