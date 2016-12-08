using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace heilsCarController
{
    public partial class Form1 : Form
    {

        public SerialPort sPort = new SerialPort();

        public float speedx;
        public float speedy;
        public float speedz;

        public string receiveData = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sPort.PortName = "com4";
            sPort.BaudRate = 115200;
            sPort.Open();
            this.speedx = 11.3f;
            this.speedy = 111.98f;
            this.speedz = 67.8f;
            SendStringData(sPort);
            ReceiveData();
            sendBox.Text = "(" + ((float)this.speedx).ToString() + "," + ((float)this.speedy).ToString() + "," + ((float)this.speedz).ToString() + ")";

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            

        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            //sPort.Write(sendBox.Text);
            //string sendMessage = null;
            byte[] hexhead = { 0x0D, 0x0A };
            byte[] hextail = { 0x0A, 0x0D };
//           string message = ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString() + ((float)123.90).ToString();
            byte[] speedxBuff = BitConverter.GetBytes(this.speedx);
            byte[] speedyBuff = BitConverter.GetBytes(this.speedy);
            byte[] speedzBuff = BitConverter.GetBytes(this.speedz);

            //byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(sendMessage);
            // byte[] sendData = Encoding.Unicode.GetBytes(sendMessage);
            sPort.Write(hexhead, 0, 2);
            sPort.Write(speedxBuff, 0, 4);
            sPort.Write(speedyBuff, 0, 4);
            sPort.Write(speedzBuff, 0, 4);
            sPort.Write(hextail, 0, 2);

        }

        private void receiveBtn_Click(object sender, EventArgs e)
        {
            receiveBox.Text = this.receiveData;
        }

        private void SendStringData(SerialPort serialPort)
        {
            serialPort.Write(sendBox.Text);
        }  

        private void SynReceiveData()
        {
            int[] a = { 0, 0, 0, 0, 0 };
            while(true)
            {
                if (sPort.ReadLine() == null)
                {
                    return;
                }
                else
                    receiveData = sPort.ReadLine();
                string pattern = @"\d{1,10}";
                MatchCollection match = Regex.Matches(receiveData, pattern);

                for (int iCount = 0; iCount < 5;iCount++ )
                {
                    a[iCount] = Convert.ToInt32(match[iCount].ToString());
                }

            }

            //receiveBox.Text = receiveData;
        }
        private void ReceiveData()
        {
            Thread threadReceive = new Thread(new ThreadStart(SynReceiveData));
            threadReceive.Start();
            //while (threadReceive.IsAlive) ;
            //Thread.Sleep(1);
            //threadReceive.Abort();


        }


    }
}
