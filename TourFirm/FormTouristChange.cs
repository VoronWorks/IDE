using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ФОРМА ДЛЯ КНОПКИ ИЗМЕНИТЬ ТУРИСТА + ИНФОРМАЦИЯ С ГЛАВНОЙ ФОРМЫ

namespace TourFirm
{
    public partial class FormTouristChange : Form
    {
        private NpgsqlConnection con;
        private string conString =
            "Host = 127.0.0.1; Username = postgres; Password = password; Database = TourFirm";

        //private int id;
        public FormTouristChange()
        {
            InitializeComponent();
            con = new NpgsqlConnection(conString);
            con.Open();
            loadTourist();
        }

        private void loadTourist()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT tourists.id, tourists.lastname, tourists.firstname, tourists.patronym, tourist_info.passport_sid, tourist_info.city, tourist_info.country, tourist_info.phone, tourist_info.indexs FROM tourists INNER JOIN tourist_info ON tourists.id = tourist_info.t_id", con);
            adap.Fill(dt);
            dataGridViewTourist.DataSource = dt;
        }

        private void dataGridViewTourist_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //int selRowNum = dataGridViewTourist.CurrentCell.RowIndex;
            //string lastname = dataGridViewTourist.Rows[selRowNum].ToString();
            //tbLastfirstname.Text = lastname;




            //DataGridViewRow r = dataGridViewTourist.SelectedRows();

            //string orderId = dataGridViewTourist.SelectedCells[0].OwningRow.Cells[0].Value.ToString();

            //var cellindexs = dataGridViewTourist.SelectedCells[0].RowIndex;
            //var cellcollection = dataGridViewTourist.Rows[cellindexs].Cells[0];

            //var orderId = dataGridViewTourist.Value.ToString();
            tbLastname.Text = dataGridViewTourist.SelectedCells[1].Value.ToString();
            tbName.Text = dataGridViewTourist.CurrentRow.Cells[2].Value.ToString();
            tbSurname.Text = dataGridViewTourist.CurrentRow.Cells[3].Value.ToString();
            tbPass.Text = dataGridViewTourist.CurrentRow.Cells[4].Value.ToString();
            tbCity.Text = dataGridViewTourist.CurrentRow.Cells[5].Value.ToString();
            tbCountry.Text = dataGridViewTourist.CurrentRow.Cells[6].Value.ToString();
            tbPhoneNumber.Text = dataGridViewTourist.CurrentRow.Cells[7].Value.ToString();
            tbIndex.Text = dataGridViewTourist.CurrentRow.Cells[8].Value.ToString();
            //id = (int)dataGridViewTourist.CurrentRow.Cells[0].Value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //string sql = "INSERT INTO tourists(lastname, firstname, patronym) VALUES(@lastname, @firstname, @patronym)";
            string sql = "UPDATE tourists SET lastname = @lastname , firstname = @firstname, patronym = @patronym  WHERE id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("lastname", this.tbLastname.Text);
            cmd.Parameters.AddWithValue("firstname", this.tbName.Text);
            cmd.Parameters.AddWithValue("patronym", this.tbSurname.Text);
            int id = int.Parse(dataGridViewTourist.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            string sql2 = "UPDATE tourist_info SET t_id = @t_id, passport_sid = @passport_sid, city = @city, country = @country, phone = @phone, indexs = @indexs WHERE t_id = @t_id";
            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, con);
            cmd2.Parameters.AddWithValue("t_id", id);
            cmd2.Parameters.AddWithValue("passport_sid", this.tbPass.Text);
            cmd2.Parameters.AddWithValue("city", this.tbCity.Text);
            cmd2.Parameters.AddWithValue("country", this.tbCountry.Text);
            cmd2.Parameters.AddWithValue("phone", this.tbPhoneNumber.Text);
            cmd2.Parameters.AddWithValue("indexs", this.tbIndex.Text);
            //int id = int.Parse(dataGridViewTourist.CurrentRow.Cells[0].Value.ToString());
            cmd2.Parameters.AddWithValue("t_id", id);
            cmd2.Prepare();

            cmd2.ExecuteNonQuery();

            this.tbLastname.Text = "";
            this.tbName.Text = "";
            this.tbSurname.Text = "";
            this.tbPass.Text = "";
            this.tbCity.Text = "";
            this.tbCountry.Text = "";
            this.tbPhoneNumber.Text = "";
            this.tbIndex.Text = "";

            loadTourist();
        }
    }
}
