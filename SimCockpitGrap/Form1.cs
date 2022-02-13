using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace SimCockpitGrap
{
    public partial class Form1 : Form
    {
        char[] led = { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1' };

        public Form1()
        {
            InitializeComponent();
        }

        #region pierdoly

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void SendButton_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream("C:/Users/Dell/Documents/SimCockpit/Debug/data.txt", FileMode.Create, FileAccess.Write);

            StreamWriter sw = new StreamWriter(file);

            led[0] = (LeftFuel.Text.ToCharArray())[0];
            led[1] = (RightFuel.Text.ToCharArray())[0];
            led[2] = (Amps.Text.ToCharArray())[0];
            led[3] = (FuelPress.Text.ToCharArray())[0];
            led[4] = (OilPress.Text.ToCharArray())[0];
            led[5] = (OatTemp.Text.ToCharArray())[0];
            led[6] = (Tit.Text.ToCharArray())[0];
            led[7] = (OilTemp.Text.ToCharArray())[0];
            led[8] = (CHT.Text.ToCharArray())[0];

            sw.Write('o');

            sw.Write(led, 0, 13);

            sw.Close();

            file.Close();

            Directory.SetCurrentDirectory("C:/Users/Dell/Documents/SimCockpit/Debug");

            Process sim = new Process();
            sim.StartInfo.UseShellExecute = false;
            sim.StartInfo.FileName = "SimCockpit.exe";
            //sim.EnableRaisingEvents = true;

            sim.Start();

        }
    }
}
