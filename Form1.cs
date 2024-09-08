using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstoTech_Colorimeter_1._0
{
    public partial class Form1 : Form
    {
        SerialPort arduino = new SerialPort();
        string pathHome = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        //private string kata1 = "";
        //private bool buka = false;
        string comPort, dataArduino, min, jam, hari, bulan, tahun, tanggal, pegawai, nama;
        int noR, noG, noB;
        int modeSensing = 0;
        bool modePrinter = false;
        DataTable dataWarna = new DataTable();
        DataTable dataTest = new DataTable();
        public Form1()
        {
            InitializeComponent();
            BuatTabel();
            arduino.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            RefreshArduino();
            panelWarna.BackColor = Color.FromArgb(255, 0, 0);
            panel4.Enabled = false;
            panel5.Enabled = false;
            panel6.Enabled = false;
            ResetSensing();

            dataWarna.Columns.Add("id", typeof(int));
            dataWarna.Columns.Add("Nama", typeof(string));
            dataWarna.Columns.Add("Red", typeof(string));
            dataWarna.Columns.Add("Green", typeof(string));
            dataWarna.Columns.Add("Blue", typeof(string));
            dataWarna.Columns.Add("Warna", typeof(string));
            dataWarna.Columns.Add("Note", typeof(string));
            dataWarna.Columns.Add("Menit", typeof(string));
            dataWarna.Columns.Add("Jam", typeof(string));
            dataWarna.Columns.Add("Hari", typeof(string));
            dataWarna.Columns.Add("Bulan", typeof(string));
            dataWarna.Columns.Add("Tahun", typeof(string));
            dataWarna.Columns.Add("Tanggal", typeof(string));
            dataWarna.Columns.Add("Pegawai", typeof(string));

            dataTest.Columns.Add("No", typeof(int));
            dataTest.Columns.Add("Red", typeof(string));
            dataTest.Columns.Add("Green", typeof(string));
            dataTest.Columns.Add("Blue", typeof(string));
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ambildatabase();
            //Datagrid Rute
            dgHistory.DataSource = dataWarna;
            dgHistory.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[13].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgHistory.Columns[0].Width = 30;
            dgHistory.Columns[1].Width = 120;
            dgHistory.Columns[2].Width = 60;
            dgHistory.Columns[3].Width = 60;
            dgHistory.Columns[4].Width = 60;
            dgHistory.Columns[5].Width = 140;
            dgHistory.Columns[6].Width = 300;
            dgHistory.Columns[7].Visible = false;
            dgHistory.Columns[8].Visible = false;
            dgHistory.Columns[9].Visible = false;
            dgHistory.Columns[10].Visible = false;
            dgHistory.Columns[11].Visible = false;
            dgHistory.Columns[12].Width = 135;
            dgHistory.Columns[13].Width = 100;

            dgTest.DataSource = dataTest;
            dgTest.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgTest.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgTest.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgTest.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgTest.Columns[0].Width = 30;
            dgTest.Columns[1].Width = 80;
            dgTest.Columns[2].Width = 80;
            dgTest.Columns[3].Width = 80;

            cekSerial();
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (arduino.IsOpen == true)
            {
                try
                {
                    dataArduino = arduino.ReadLine(); //baca data dari serial arduino
                    txInput.Invoke(new Action(() => txInput.Text = dataArduino.ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca data : " + ex.Message);
                }
            }
        }

        private void tbRefresh_Click(object sender, EventArgs e)
        {
            RefreshArduino();
        }

        
        private void cbArduino_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort = Convert.ToString(cbArduino.SelectedItem);
            try
            {
                arduino.PortName = comPort;
                arduino.BaudRate = 9600;
                arduino.Open();
                arduino.Write("0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka port : " + ex.Message);
            }
        }
        private void tbBase_Click(object sender, EventArgs e)
        {
            nama = "Base";
            modeSensing = 1;
            try
            {
                arduino.Write("1"); //kirim perintah sensing Base
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail Sending : " + ex.Message);
            }
        }
        private void tbPertamax_Click(object sender, EventArgs e)
        {
            nama = "Pertamax";
            modeSensing = 2;
            try
            {
                arduino.Write("2"); //kirim perintah sensing Base
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail Sending : " + ex.Message);
            }
        }

        private void tbPremium_Click(object sender, EventArgs e)
        {
            nama = "Premium";
            modeSensing = 2;
            try
            {
                arduino.Write("3"); //kirim perintah sensing Base
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail Sending : " + ex.Message);
            }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            simpanRute();
        }

        private void tbTurbo_Click(object sender, EventArgs e)
        {
            nama = "Pertamax Turbo";
            modeSensing = 2;
            try
            {
                arduino.Write("4"); //kirim perintah sensing Base
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail Sending : " + ex.Message);
            }
        }

        private void tbPertalite_Click(object sender, EventArgs e)
        {
            nama = "Pertalite";
            modeSensing = 2;
            try
            {
                arduino.Write("5"); //kirim perintah sensing Base
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail Sending : " + ex.Message);
            }
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            if(dataTest.Rows.Count == 0) { return; }
            string kataCopy = "Red\tGreen\tBlue";
            for(int i = 0; i< dataTest.Rows.Count; i++)
            {
                kataCopy += "\r";
                double no = double.Parse(dataTest.Rows[i][1].ToString());
                kataCopy += no.ToString() + "\t";
                no = double.Parse(dataTest.Rows[i][2].ToString());
                kataCopy += no.ToString() + "\t";
                no = double.Parse(dataTest.Rows[i][3].ToString());
                kataCopy += no.ToString() + "\t";
            }
            kataCopy += "\r" + txTR.Text + "\t" + txTG.Text + "\t" + txTB.Text;
            Clipboard.SetText(kataCopy);
            //System.Diagnostics.Process.Start(pathHome + @"\Data.xlsx");
        }

        private void tbTest_Click(object sender, EventArgs e)
        {
            nama = "Test";
            modeSensing = 3;
            try
            {
                arduino.Write("6"); //kirim perintah sensing Base
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail Sending : " + ex.Message);
            }
        }
        private void tbPrint_Click(object sender, EventArgs e)
        {
            panel5.Enabled = false;
            modePrinter = true;
            if (modeSensing == 1)
            {
                try
                {
                    arduino.Write("7"); //kirim perintah sensing Base
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail Sending : " + ex.Message);
                }
            }
            else if (modeSensing == 2)
            {
                try
                {
                    arduino.Write("8"); //kirim perintah sensing Base
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail Sending : " + ex.Message);
                }
            }
            else if (modeSensing == 3)
            {
                try
                {
                    arduino.Write("9"); //kirim perintah sensing Base
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail Sending : " + ex.Message);
                }
            }
        }
        private void tbAdd_Click(object sender, EventArgs e)
        {
            int no = dataWarna.Rows.Count+1;
            dataWarna.Rows.Add(new object[] { no, nama, txR.Text, txG.Text, txB.Text, txWarna.Text, txNote.Text, min, jam, hari, bulan, tahun, tanggal, pegawai });
            dgHistory.DataSource = dataWarna;
        }
        private void tbDelete_Click(object sender, EventArgs e)
        {
            if(dataWarna.Rows.Count == 0) { return; }
            dataWarna.Rows[dataWarna.Rows.Count - 1].Delete();
            dataWarna.AcceptChanges();
        }

        private void txInput_TextChanged(object sender, EventArgs e)
        {
            string str = txInput.Text;
            string[] arStr = str.Split('-');
            double nilai;
            if (arStr[0] == "Red")
            {
                txR.Text = arStr[1];
                nilai = Math.Round(double.Parse(txR.Text) / 255 * 100);
                pbRed.Value = int.Parse(nilai.ToString());
                noR = int.Parse(Math.Round(double.Parse(txR.Text)).ToString());
            }
            else if (arStr[0] == "Green")
            {
                txG.Text = arStr[1];
                nilai = Math.Round(double.Parse(txG.Text) / 255 * 100);
                pbGreen.Value = int.Parse(nilai.ToString());
                noG = int.Parse(Math.Round(double.Parse(txG.Text)).ToString());
            }
            else if (arStr[0] == "Blue")
            {
                txB.Text = arStr[1];
                nilai = Math.Round(double.Parse(txB.Text) / 255 * 100);
                pbBlue.Value = int.Parse(nilai.ToString());
                noB = int.Parse(Math.Round(double.Parse(txB.Text)).ToString());
                panelWarna.BackColor = Color.FromArgb(noR, noG, noB);
            }
            else if (arStr[0] == "Warna")
            {
                txWarna.Text = arStr[1];
            }
            else if (arStr[0] == "Note")
            {
                txNote.Text = arStr[1];
            }
            else if (arStr[0] == "Sensing")
            {
                txNama.Text = arStr[1];
                txStatus2.Text = "Sensing";
                txStatus2.BackColor = Color.LawnGreen;
                panel2.BackColor = Color.LawnGreen;
                panel5.Enabled = false;
                ResetSensing();
            }
            else if (arStr[0] == "Selesai")
            {
                panel5.Enabled = true;
                panel6.Enabled = true;
                tbSave.Enabled = true;
                tbPrint.Enabled = true;
                tbAdd.Enabled = true;
                txStatus2.Text = "Ready";
                txStatus2.BackColor = System.Drawing.SystemColors.Control;
                panel2.BackColor = System.Drawing.SystemColors.Control;
                if(modeSensing == 3 && modePrinter == false)
                {
                    int no = dataTest.Rows.Count;
                    dataTest.Rows.Add(new object[] { no, txR.Text, txG.Text, txB.Text });
                    dgTest.DataSource = dataTest;
                    hitungTest();
                }
                modePrinter = false;
            }
            else if (arStr[0] == "Printing")
            {
                txStatus2.Text = "Printing";
                txStatus2.BackColor = Color.CornflowerBlue;
                panel2.BackColor = Color.CornflowerBlue;
            }
            else if (arStr[0] == "Tanggal")
            {
                min = arStr[1];
                jam = arStr[2];
                hari = arStr[3];
                bulan = arStr[4];
                tahun = arStr[5];
                pegawai = arStr[6];
                tanggal = jam + ":" + min + " - " + hari + " " + bulan + " " + tahun;
            }
            else if (arStr[0] == "Ready")
            {
                txStatus.Text = "Device Connected";
                txStatus.BackColor = Color.Lime;
                txStatus2.Text = "Ready";
                txStatus2.BackColor = System.Drawing.SystemColors.Control;
                panel2.BackColor = System.Drawing.SystemColors.Control;
                panel4.Enabled = true;
                panel5.Enabled = true;
                panel6.Enabled = true;
            }
            else
            {
                txStatus.Text = "Device Connected";
                txStatus.BackColor = Color.Lime;
                txStatus2.Text = "Ready";
                txStatus2.BackColor = System.Drawing.SystemColors.Control;
                panel2.BackColor = System.Drawing.SystemColors.Control;
                panel4.Enabled = true;
                panel5.Enabled = true;
                panel6.Enabled = true;
            }

        }

        private void hitungTest()
        {
            double nR = 0;
            double nG = 0;
            double nB = 0;
            for(int i = 0; i < dataTest.Rows.Count; i++){
                nR += double.Parse(dataTest.Rows[i][1].ToString());
                nG += double.Parse(dataTest.Rows[i][2].ToString());
                nB += double.Parse(dataTest.Rows[i][3].ToString());
            }
            nR /= dataTest.Rows.Count;
            nG /= dataTest.Rows.Count;
            nB /= dataTest.Rows.Count;
            txTR.Text = nR.ToString();
            txTG.Text = nG.ToString();
            txTB.Text = nB.ToString();
        }

        private void RefreshArduino()
        {
            string[] portList = SerialPort.GetPortNames();
            cbArduino.Items.Clear();
            foreach (string s in portList) cbArduino.Items.Add(s);

        }
        private void ResetSensing()
        {
            txR.Text = "";
            txG.Text = "";
            txB.Text = "";
            txWarna.Text = "";
            txNote.Text = "";
            pbRed.Value = 0;
            pbGreen.Value = 0;
            pbBlue.Value = 0;
            tbPrint.Enabled = false;
            tbAdd.Enabled = false;
            panelWarna.BackColor = Color.FromArgb(0, 0, 0);
        }
        private void BuatTabel()
        {
            string cs = @"URI=file:" + pathHome + @"\DataProses.db";
            if (System.IO.File.Exists(pathHome + @"\DataProses.db") == false)
            {
                var con = new SQLiteConnection(cs);
                con.Open();

                var cmd = new SQLiteCommand(con);

                cmd.CommandText = "DROP TABLE IF EXISTS Proses";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE Proses(id INT,
                    Nama TEXT, Red TEXT, Green TEXT, Blue TEXT, Warna TEXT, Note TEXT, Menit TEXT, Jam TEXT, Hari TEXT, Bulan TEXT, Tahun TEXT, Tanggal TEXT, Pegawai TEXT)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DROP TABLE IF EXISTS Serial";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE Serial(No TEXT)";
                cmd.ExecuteNonQuery();

            }
        }

        private void ambildatabase()
        {
            //Ambil Data Base
            string cs = @"URI=file:" + pathHome + @"\DataProses.db";
            var con = new SQLiteConnection(cs);
            con.Open();
            //Ambil Data Recent
            string stm = "SELECT * FROM Proses";
            var cmd = new SQLiteCommand(stm, con);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            dataWarna.Load(rdr);
            dgHistory.DataSource = dataWarna;
            if(dataWarna.Rows.Count > 0)
            {
                tbDelete.Enabled = true;
            }
        }
        private void simpanRute()
        {
            if (dataWarna.Rows.Count == 0) { return; };
            string cs = @"URI=file:" + pathHome + @"\DataProses.db";
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);
            cmd = new SQLiteCommand(con);
            cmd.CommandText = @"DELETE FROM Proses";
            cmd.ExecuteNonQuery();
            MessageBox.Show(dataWarna.Rows.Count.ToString());
            for (int i = 0; i < dataWarna.Rows.Count; i++)
            {
                cmd.CommandText = "INSERT INTO Proses(id, Nama, Red, Green, Blue, Warna, Note, Menit, Jam, Hari, Bulan, Tahun, Tanggal, Pegawai) " +
                    "VALUES(@A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9, @A10, @A11, @A12, @A13, @A14)";
                cmd.Parameters.AddWithValue("@A1", dataWarna.Rows[i][0]);
                cmd.Parameters.AddWithValue("@A2", dataWarna.Rows[i][1]);
                cmd.Parameters.AddWithValue("@A3", dataWarna.Rows[i][2]);
                cmd.Parameters.AddWithValue("@A4", dataWarna.Rows[i][3]);
                cmd.Parameters.AddWithValue("@A5", dataWarna.Rows[i][4]);
                cmd.Parameters.AddWithValue("@A6", dataWarna.Rows[i][5]);
                cmd.Parameters.AddWithValue("@A7", dataWarna.Rows[i][6]);
                cmd.Parameters.AddWithValue("@A8", dataWarna.Rows[i][7]);
                cmd.Parameters.AddWithValue("@A9", dataWarna.Rows[i][8]);
                cmd.Parameters.AddWithValue("@A10", dataWarna.Rows[i][9]);
                cmd.Parameters.AddWithValue("@A11", dataWarna.Rows[i][10]);
                cmd.Parameters.AddWithValue("@A12", dataWarna.Rows[i][11]);
                cmd.Parameters.AddWithValue("@A13", dataWarna.Rows[i][12]);
                cmd.Parameters.AddWithValue("@A14", dataWarna.Rows[i][13]);
                cmd.ExecuteNonQuery();
            }
        }
        private void cekSerial()
        {
            string cs = @"URI=file:" + pathHome + @"\DataProses.db";
            var con = new SQLiteConnection(cs);
            con.Open();
            //Ambil Data Recent
            string stm = "SELECT * FROM Serial";
            var cmd = new SQLiteCommand(stm, con);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            if(dt.Rows.Count == 0)
            {
                Aktivasi formA = new Aktivasi();
                formA.ShowDialog();
                reCekSerial();
            }
            else
            {
                string txSerial = dt.Rows[0][0].ToString();
                long macAddL = long.Parse(AmbilMacAddress());
                string nilai = HitungSerial(macAddL);
                if (nilai != txSerial)
                {
                    Aktivasi formA = new Aktivasi();
                    formA.ShowDialog();
                    reCekSerial();
                }
            }
            
        }
        private void reCekSerial()
        {
            string cs = @"URI=file:" + pathHome + @"\DataProses.db";
            var con = new SQLiteConnection(cs);
            con.Open();
            //Ambil Data Recent
            string stm = "SELECT * FROM Serial";
            var cmd = new SQLiteCommand(stm, con);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            if (dt.Rows.Count == 0)
            {
                Application.Exit();
            }
            else
            {
                string txSerial = dt.Rows[0][0].ToString();
                long macAddL = long.Parse(AmbilMacAddress());
                string nilai = HitungSerial(macAddL);
                if (nilai != txSerial)
                {
                    Application.Exit();
                }
            }
        }
        public static string AmbilMacAddress()
        {
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Select * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMOS.Get();
            String strMacAdd = string.Empty;
            foreach(ManagementObject objMO in objMOC)
            {
                object tempMacAddObj = objMO["MacAddress"];
                if(tempMacAddObj == null)
                {
                    continue;
                }
                if(strMacAdd == String.Empty)
                {
                    strMacAdd = tempMacAddObj.ToString();
                }
                objMO.Dispose();
            }
            strMacAdd = strMacAdd.Replace(":", "");
            String macAdd = (Int64.Parse(strMacAdd, System.Globalization.NumberStyles.HexNumber)).ToString();
            return macAdd;
        }
        private string HitungSerial(long no)
        {
            long nilai = ((no + 244577) * 45 / 77 * (no * 7 + 85733807878));
            string kata = nilai.ToString();
            return kata;
        }
    }
}
