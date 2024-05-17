using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ФОРМА ДЛЯ КНОПКИ ДОБАВИТЬ ТУРИСТА + ИНФОО С ГЛАВНОЙ ФОРМЫ

namespace TourFirm
{
    public partial class FormTouristAdd : Form
    {

        private NpgsqlConnection con;
        private string conString =
            "Host=127.0.0.1;Username=postgres;Password=password;Database=TourFirm";
        public FormTouristAdd()
        {
            InitializeComponent();
            con = new NpgsqlConnection(conString);
            con.Open();
            loadTourist();
        }

        private void loadTourist()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tourists", con);
            adap.Fill(dt);
            dataGridViewTourist.DataSource = dt;
        }

        private void FormTourist_Load(object sender, EventArgs e)
        {

        }

        private void tblastname_Click(object sender, EventArgs e)
        {
            tbLastname.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tourists(lastname, firstname, patronym) VALUES(@lastname, @firstname, @patronym)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("lastname", this.tbLastname.Text);
            cmd.Parameters.AddWithValue("firstname", this.tbName.Text);
            cmd.Parameters.AddWithValue("patronym", this.tbSurname.Text);
            cmd.Prepare();  

            cmd.ExecuteNonQuery();


            string sql2 = "SELECT * FROM tourists";

            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, con);
            NpgsqlDataReader reader = cmd2.ExecuteReader();
            int id = 0;
            while (reader.Read())
            {
                id = Convert.ToInt32(reader.GetValue(0));
            }
            reader.Close();
            string id1 = id.ToString();
            string sql3 = "INSERT INTO tourist_info(t_id, passport_sid, city, country, phone, indexs) VALUES(@t_id, @passport_sid, @city, @country, @phone, @indexs)";
            NpgsqlCommand cmd3 = new NpgsqlCommand(sql3, con);

            //Добавим параметр в коллекцию специального типа
            //cmd3.Parameters.Add(new NpgsqlParameter("t_id", NpgsqlDbType.Integer));
            //Добавим значение в параметр в команда
            //cmd3.Parameters[0].Value = id;
            //CAST(@t_id AS integer)
            cmd3.Parameters.AddWithValue("t_id", id);
            cmd3.Parameters.AddWithValue("passport_sid", this.tbPass.Text);
            cmd3.Parameters.AddWithValue("city", this.tbCity.Text);
            cmd3.Parameters.AddWithValue("country", this.tbCountry.Text);
            cmd3.Parameters.AddWithValue("phone", this.tbPhoneNumber.Text);
            cmd3.Parameters.AddWithValue("indexs", this.tbIndex.Text);
            cmd3.Prepare();

            cmd3.ExecuteNonQuery();

            this.tbLastname.Text = "";
            this.tbName.Text = "";
            this.tbSurname.Text = "";
            this.tbPass.Text = "";
            this.tbCity.Text = "";
            this.tbCountry.Text = "";
            this.tbPhoneNumber.Text = "";
            this.tbIndex.Text = "";
            //this.label9.Text = id.ToString();

            loadTourist();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
