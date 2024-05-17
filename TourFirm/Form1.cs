using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// ГЛАВНАЯ ГЛАВНАЯ ФОРМА

namespace TourFirm
{
    public partial class Form1 : Form
    {


        private NpgsqlConnection con;
        private string conString =
         "Host=127.0.0.1;Username=postgres;Password=password;Database=TourFirm";
        public Form1()
        {
            InitializeComponent();
            con = new NpgsqlConnection(conString);
            con.Open();
            loadTourist();
            loadTouristInfo();
            loadSeason();
            loadTour();
            loadVoucher();
            loadPayment();
            tbReq1.Text = "SELECT * FROM tours ORDER BY tour_id";

        }

        private void loadTourist()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tourists", con);
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void loadTouristInfo()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tourist_info", con);
            adap.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void loadSeason()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM seasons", con);
            adap.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void loadTour()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tours", con);
            adap.Fill(dt);
            dataGridView4.DataSource = dt;
        }

        private void loadVoucher()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM trips", con);
            adap.Fill(dt);
            dataGridView5.DataSource = dt;
        }

        private void loadPayment()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM payments", con);
            adap.Fill(dt);
            dataGridView6.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
 
            string tourQuery = @"
    SELECT ti.tour_name AS Name, COUNT(*) AS TourCount
    FROM seasons s
    JOIN tours ti ON s.tour_id = ti.tour_id
    GROUP BY ti.tour_name ORDER BY TourCount DESC;
";

            NpgsqlCommand tourCommand = new NpgsqlCommand(tourQuery, con);
            NpgsqlDataReader tourReader = tourCommand.ExecuteReader();

            Series tourSeries = chart1.Series.Add("Tours");
            tourSeries.ChartType = SeriesChartType.Pie;
            tourSeries.Label = "#PERCENT{P2}";
            tourSeries.LegendText = "#VALX (#PERCENT{P2})";

            while (tourReader.Read())
            {
                tourSeries.Points.AddXY(tourReader["Name"].ToString(), tourReader["TourCount"]);
            }

            chart1.Legends[0].Enabled = true;

            tourReader.Close();

  
            string spendingQuery = @"
    SELECT tu.firstname || ' ' || tu.lastname AS FullName, SUM(p.amount) AS TotalSpent
    FROM payments p
    JOIN trips v ON p.trip_id = v.trip_id
    JOIN tourists tu ON v.tourist_id = tu.id
    GROUP BY FullName ORDER BY TotalSpent DESC;
";

            NpgsqlCommand spendingCommand = new NpgsqlCommand(spendingQuery, con);
            NpgsqlDataReader spendingReader = spendingCommand.ExecuteReader();

            Series spendingSeries = chart2.Series.Add("TotalSpent");
            spendingSeries.ChartType = SeriesChartType.Column;

            // Add points with individual colors
            int colorIndex = 0;
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Cyan, Color.Magenta };
            while (spendingReader.Read())
            {
                int pointIndex = spendingSeries.Points.AddXY(spendingReader["FullName"].ToString(), spendingReader["TotalSpent"]);
                spendingSeries.Points[pointIndex].Color = colors[colorIndex % colors.Length];
                colorIndex++;
            }

            spendingReader.Close();

        }

        private void btnAddTourist_Click(object sender, EventArgs e)
        {
            FormTouristAdd t = new FormTouristAdd();
            t.ShowDialog();
            loadTourist();
            loadTouristInfo();
        }

        private void btnDeleteTourist_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM tourists WHERE id=(@id)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("id", id) ;
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            string sql2 = $"DELETE FROM tourist_info WHERE t_id=(@id)";
            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, con);
            //int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd2.Parameters.AddWithValue("id", id);
            cmd2.Prepare();

            cmd2.ExecuteNonQuery();
            loadTourist();
            loadTouristInfo();
        }

        private void btnChangeTourist_Click(object sender, EventArgs e)
        {
            FormTouristChange t = new FormTouristChange();
            t.ShowDialog();
            loadTourist();
            loadTouristInfo();
        }

        private void btnChangeTouristInfo_Click(object sender, EventArgs e)
        {

        }

       
        private void btnDeleteSeason_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM seasons WHERE s_id=(@id)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            int id = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            loadSeason();
        }

        private void btnAddSeason_Click(object sender, EventArgs e)
        {
            FormSeasonAdd t = new FormSeasonAdd();
            t.ShowDialog();
            loadSeason();
        }

        private void btnChangeSeason_Click(object sender, EventArgs e)
        {
            FormSeasonChange t = new FormSeasonChange();
            t.ShowDialog(); 
            loadSeason();
        }

        private void btnDeleteTour_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM tours WHERE tour_id=(@id)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            int id = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            loadTour();
        }

        private void btnAddTour_Click(object sender, EventArgs e)
        {
            FormTourAdd t = new FormTourAdd();
            t.ShowDialog();
            loadTour();
        }

        private void btnChangeTour_Click(object sender, EventArgs e)
        {
            FormTourChange t = new FormTourChange();
            t.ShowDialog();
            loadTour();
        }

        private void btnDeleteVoucher_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM trips WHERE trip_id=(@id)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            int id = int.Parse(dataGridView5.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            loadVoucher();
        }

        private void btnAddVoucher_Click(object sender, EventArgs e)
        {
            FormVoucherAdd t = new FormVoucherAdd();
            t.ShowDialog();
            loadVoucher();
        }

        private void btnChangeVoucher_Click(object sender, EventArgs e)
        {
            FormVoucherChange t = new FormVoucherChange();
            t.ShowDialog();
            loadVoucher();
        }

        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM payments WHERE payment_id=(@id)";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            int id = int.Parse(dataGridView6.CurrentRow.Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            loadPayment();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            FormPaymentAdd t = new FormPaymentAdd();
            t.ShowDialog();
            loadPayment();
        }

        private void btnChangePayment_Click(object sender, EventArgs e)
        {
            FormPaymentChange t = new FormPaymentChange();
            t.ShowDialog();
            loadPayment();
        }

        private void btnReq1_Click(object sender, EventArgs e)
        {
            dataGridViewReq.Refresh();
            string sql = tbReq1.Text;
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter(sql, con);
            try
            {
                adap.Fill(dt);
                dataGridViewReq.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то не так","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnReq2_Click(object sender, EventArgs e)
        {
            dataGridViewReq.Refresh();
            string sql = tbReq2.Text;
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter(sql, con);
            try
            {
                adap.Fill(dt);
                dataGridViewReq.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то не так", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportUsingXmlDocument()
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "XML Files(*.xml*)|*.xml*";
            d.ShowDialog();
            if (d.FileName != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement rootElement = xmlDoc.CreateElement("Results");
                xmlDoc.AppendChild(rootElement);

                foreach (DataGridViewRow row in dataGridViewReq.Rows)
                {
                    if (row.IsNewRow) continue; 

                    XmlElement rowElement = xmlDoc.CreateElement("Row");
                    rootElement.AppendChild(rowElement);

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        XmlElement cellElement = xmlDoc.CreateElement(dataGridViewReq.Columns[i].Name);
                        cellElement.InnerText = row.Cells[i].Value?.ToString() ?? "";
                        rowElement.AppendChild(cellElement);
                    }
                }

                xmlDoc.Save(d.FileName);
            }
        }

        private void LoadXmlIntoDataGridView6WithXmlDocument()
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "XML Files(*.xml*)|*.xml*";
            d.ShowDialog();
            if (d.FileName != null)
            {
                DataTable dataTable = new DataTable();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(d.FileName); 

            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("/Results/Row"); 

                if (xmlNodeList.Count > 0)
                {

                    foreach (XmlNode node in xmlNodeList[0].ChildNodes)
                    {
                        dataTable.Columns.Add(node.Name);
                    }

                    foreach (XmlNode node in xmlNodeList)
                    {
                        DataRow dataRow = dataTable.NewRow();

                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            dataRow[childNode.Name] = childNode.InnerText;
                        }

                        dataTable.Rows.Add(dataRow);
                    }

                    dataGridViewReq.DataSource = dataTable;
                }
            }
        }
        private void btnExportXmlWriter_Click(object sender, EventArgs e)
        {
           

            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "XML Files(*.xml*)|*.xml*";
            d.ShowDialog();
            if (d.FileName != null)
            {
                XmlWriter xmlWriter = XmlWriter.Create(d.FileName);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Parent");

                List<string> listNames = new List<string>();
                for (int i = 0; i < dataGridViewReq.Columns.Count; i++)
                {
                    listNames.Add(dataGridViewReq.Columns[i].HeaderText);
                }


                for (int i = 0; i < dataGridViewReq.Rows.Count - 1; i++)
                {
                    xmlWriter.WriteStartElement("child");
                    xmlWriter.WriteAttributeString("id", dataGridViewReq.Rows[i].Cells[0].Value.ToString());
                    for (int j = 1; j < dataGridViewReq.Rows[i].Cells.Count; j++)
                    {
                        //xmlWriter.WriteStartElement(listNames[j]);
                        xmlWriter.WriteStartElement(dataGridViewReq.Columns[j].HeaderText);
                        xmlWriter.WriteString(dataGridViewReq.Rows[i].Cells[j].Value.ToString());
                        xmlWriter.WriteEndElement();
                    }
                    xmlWriter.WriteEndElement();


                }
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
        }

        private void btnImportXmlReader_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "XML Files(*.xml*)|*.xml*";
            d.ShowDialog();
            if (d.FileName != null)
            {
                DataTable dt = new DataTable();
                XmlReader xmlReader = XmlReader.Create(d.FileName);
                DataColumn columnPID = new DataColumn("payment_id", typeof(Int32));
                DataColumn columnVID = new DataColumn("trip_id", typeof(Int32));
                DataColumn columnPDate = new DataColumn("pay_date", typeof(DateTime));
                DataColumn columnDeposit = new DataColumn("deposit", typeof(Decimal));
                dt.Columns.Add(columnPID);
                dt.Columns.Add(columnVID);
                dt.Columns.Add(columnPDate);
                dt.Columns.Add(columnDeposit);
                //dt = null;
                DataRow dr = null;

                xmlReader.MoveToContent();
                while (xmlReader.Read())
                {

                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "child")
                    {
                        dr = dt.NewRow();
                     
                        dr = dt.NewRow();
                        Int32 pid = 0;
                        Int32 vid = 0;
                        Decimal depos = 0;
                        DateTime date = DateTime.Now;
                        XmlReader r1 = xmlReader.ReadSubtree();
                        while (r1.Read())
                        {

                            if (r1.NodeType == XmlNodeType.Element)
                            {
                                
                                if (r1.Name == "payment_id") pid = int.Parse(r1.ReadElementContentAsString());
                                if (r1.Name == "trip_id") vid = Convert.ToInt32(r1.ReadElementContentAsString());
                                if (r1.Name == "pay_date") date = DateTime.Parse(r1.ReadElementContentAsString());
                                if (r1.Name == "deposit") depos = Convert.ToDecimal(r1.ReadElementContentAsString());
                            }
                        }
                        dr["payment_id"] = pid;
                        dr["trip_id"] = vid;
                        dr["pay_date"] = date;
                        dr["deposit"] = depos;
                        dt.Rows.Add(dr);

                    }


                }

                dataGridViewReq.DataSource = dt;
            }
        }

        private void btnExportXmlDocument_Click(object sender, EventArgs e)
        {
            ExportUsingXmlDocument();
        }

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            // Ensure there is at least one row in the DataGridView
            if (dataGridView1.RowCount > 0)
            {
                // Access the last row
                var lastRowIndex = dataGridView1.RowCount - 1;
                var lastRow = dataGridView1.Rows[lastRowIndex-1];

              
                var touristIdValue = lastRow.Cells[0].Value;

                
                if (int.TryParse(touristIdValue?.ToString(), out int touristId))
                {
               
                    using (var cmd = new NpgsqlCommand($"SELECT * from trips", con))
                    {
                        cmd.ExecuteNonQuery();
                        
                    }

               
                    loadVoucher();
                    tabControl1.SelectedIndex = 4;
                }
                else
                {
                
                    MessageBox.Show("Invalid Tourist ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                
                MessageBox.Show("No tourists available to create a trips for.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImportXmlDocument_Click(object sender, EventArgs e)
        {
            LoadXmlIntoDataGridView6WithXmlDocument();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            string tourQuery = @"
    SELECT ti.tour_name AS Name, COUNT(*) AS TourCount
    FROM seasons s
    JOIN tours ti ON s.tour_id = ti.tour_id
    GROUP BY ti.tour_name ORDER BY TourCount DESC;
";

            NpgsqlCommand tourCommand = new NpgsqlCommand(tourQuery, con);
            NpgsqlDataReader tourReader = tourCommand.ExecuteReader();

            Series tourSeries = chart1.Series.Add("Tours");
            tourSeries.ChartType = SeriesChartType.Pie;
            tourSeries.Label = "#PERCENT{P2}";
            tourSeries.LegendText = "#VALX (#PERCENT{P2})";

            while (tourReader.Read())
            {
                tourSeries.Points.AddXY(tourReader["Name"].ToString(), tourReader["TourCount"]);
            }

            chart1.Legends[0].Enabled = true;

            tourReader.Close();

  
            string spendingQuery = @"
    SELECT tu.firstname || ' ' || tu.lastname AS FullName, SUM(p.amount) AS TotalSpent
    FROM payments p
    JOIN trips v ON p.trip_id = v.trip_id
    JOIN tourists tu ON v.tourist_id = tu.id
    GROUP BY FullName ORDER BY TotalSpent DESC;
";

            NpgsqlCommand spendingCommand = new NpgsqlCommand(spendingQuery, con);
            NpgsqlDataReader spendingReader = spendingCommand.ExecuteReader();

            Series spendingSeries = chart2.Series.Add("TotalSpent");
            spendingSeries.ChartType = SeriesChartType.Column;

            // Add points with individual colors
            int colorIndex = 0;
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Orange, Color.Purple, Color.Cyan, Color.Magenta };
            while (spendingReader.Read())
            {
                int pointIndex = spendingSeries.Points.AddXY(spendingReader["FullName"].ToString(), spendingReader["TotalSpent"]);
                spendingSeries.Points[pointIndex].Color = colors[colorIndex % colors.Length];
                colorIndex++;
            }

            spendingReader.Close();

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
