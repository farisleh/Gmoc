using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Gmoc
{
    public partial class Form1 : Form
    {
        private string dataIn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            comboBox1.SelectedIndex = 0;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                textBox2.ForeColor = Color.Green;
                textBox2.Text = "Successfully Connected!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            textBox2.Clear();
            try
            {
                serialPort1.Close();
                textBox2.Text = "Disconnected!!";
                textBox2.ForeColor = Color.DarkRed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$00SET,W,IP,01,gtech.dyndns-ip.com!8GTEC8*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                    serialPort1.WriteLine("$00SET,W,IP,02,9000!8GTEC8*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                }       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataIn = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            textBox2.AppendText(dataIn.Replace("#", "#" + Environment.NewLine));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$00SET,W,IP,01,!8GTEC8*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                    serialPort1.WriteLine("$00SET,W,IP,02,!8GTEC8*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$00EOB!8GTEC8*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$00RTF!8GTEC8*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$00SET,R,IP,00,!8GTEC8*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$00SET,W,AC,02,300!XYZ321*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$00SET,W,RP,01,60!XYZ321*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine("$00SET,W,RP,02,300!XYZ321*CS#" + Environment.NewLine);
                    serialPort1.WriteLine("" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
