using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstoTech_Colorimeter_1._0
{
    public partial class Aktivasi : Form
    {
        string pathHome = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        public Aktivasi()
        {
            InitializeComponent();
        }

        private void Aktivasi_Load(object sender, EventArgs e)
        {
            txSerial.Text = AmbilMacAddress();
        }
        
        public static string AmbilMacAddress()
        {
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Select * FROM Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMOS.Get();
            String strMacAdd = string.Empty;
            foreach (ManagementObject objMO in objMOC)
            {
                object tempMacAddObj = objMO["MacAddress"];
                if (tempMacAddObj == null)
                {
                    continue;
                }
                if (strMacAdd == String.Empty)
                {
                    strMacAdd = tempMacAddObj.ToString();
                }
                objMO.Dispose();
            }
            strMacAdd = strMacAdd.Replace(":", "");
            String macAdd = (Int64.Parse(strMacAdd, System.Globalization.NumberStyles.HexNumber)).ToString();
            return macAdd;
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txSerial.Text);
        }

        private void tbAktivasi_Click(object sender, EventArgs e)
        {
            string nilai = HitungSerial(long.Parse(txSerial.Text));
            txKata.Visible = true;
            if (txActivation.Text == nilai)
            {
                txKata.Text = "Product Activated";
                txKata.ForeColor = Color.Green;
                saveSerial(nilai);
            }
            else
            {
                txKata.Text = "Product not activation";
                txKata.ForeColor = Color.Red;
                txActivation.Text = "";
            }
        }
        private string HitungSerial(long no)
        {
            long nilai = ((no + 244577) * 45 / 77 * (no * 7 + 85733807878));
            string kata = nilai.ToString();
            return kata;
        }
        private void saveSerial(string kata)
        {
            string cs = @"URI=file:" + pathHome + @"\DataProses.db";
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);
            cmd = new SQLiteCommand(con);
            cmd.CommandText = @"DELETE FROM Serial";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Serial(No) " +
                    "VALUES(@A1)";
            cmd.Parameters.AddWithValue("@A1", kata);
            cmd.ExecuteNonQuery();
        }
    }
}
