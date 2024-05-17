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
    public partial class FormPaymentAdd : Form
    {
        private NpgsqlConnection con;
        private string conString =
            "Host = 127.0.0.1; Username = postgres; Password = password; Database = TourFirm";
        public FormPaymentAdd()
        {
            InitializeComponent();
            con = new NpgsqlConnection(conString);
            con.Open();
            loadPayment();

            string sql = "SELECT trip_id FROM trips";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            comboBoxVoucher.Items.Clear();
            while (reader.Read())
            {
                comboBoxVoucher.Items.Add(int.Parse(reader.GetValue(0).ToString()));
            }
            reader.Close();
        }

        private void loadPayment()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM payments", con);
            adap.Fill(dt);
            dataGridViewPayment.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            string sql1 = "INSERT INTO payments(trip_id, payment_date, amount) VALUES(@trip_id, @payment_date, @amount)";
            NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, con);
            cmd1.Parameters.AddWithValue("trip_id", int.Parse(this.comboBoxVoucher.SelectedItem.ToString()));
            cmd1.Parameters.AddWithValue("payment_date", this.datePayment.Value);
            cmd1.Parameters.AddWithValue("amount", Decimal.Parse(this.tbDeposit.Text));


            cmd1.Prepare();

            cmd1.ExecuteNonQuery();
            loadPayment();

            this.comboBoxVoucher.Text = "";
            this.datePayment.Text = "";
            this.tbDeposit.Text = "";
        }
    }
}
