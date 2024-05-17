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
    public partial class FormTourAdd : Form
    {
        private NpgsqlConnection con;
        private string conString =
            "Host = 127.0.0.1; Username = postgres; Password = password; Database = TourFirm";
        public FormTourAdd()
        {
            InitializeComponent();
            con = new NpgsqlConnection(conString);
            con.Open();
            loadTour();
        }

        private void loadTour()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tours", con);
            adap.Fill(dt);
            dataGridViewTour.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            string sql = "INSERT INTO tours(tour_name, price, information) VALUES(@tour_name, @price, @information)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("tour_name", this.tbName.Text);
            cmd.Parameters.AddWithValue("price", Decimal.Parse(this.tbPrice.Text));
            cmd.Parameters.AddWithValue("information", this.tbInfo.Text); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            loadTour();

            this.tbName.Text = "";
            this.tbPrice.Text = "";
            this.tbInfo.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbInfo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
