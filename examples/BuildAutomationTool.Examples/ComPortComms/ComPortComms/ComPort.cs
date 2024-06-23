using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Drawing;
using System.Windows.Documents;
using System.Windows.Media;

namespace ComPortComms
{
    class ComPort
    {
        protected SerialPort comPort = null;
        protected FlowDocument _fd;
        private object Obj;
        public static string[] Ports { get { return SerialPort.GetPortNames(); } }

        public ComPort(FlowDocument fd)
        {
            comPort = new SerialPort();
            _fd = fd;
            comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            Obj = new object();
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (Obj)
            {
                int bytes = comPort.BytesToRead;
                byte[] comBuffer = new byte[bytes];
                comPort.Read(comBuffer, 0, bytes);
                DisplayData(Brushes.Green, ByteToHex(comBuffer));
            }
        }

        public void Send(string msg)
        {
            if (comPort.IsOpen == false)
                Open();
            try
            {
                lock (Obj)
                {
                    byte[] newMsg = HexToByte(msg);
                    comPort.Write(newMsg, 0, newMsg.Length);
                    DisplayData(Brushes.Blue, ByteToHex(newMsg));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }


        public bool Open()
        {
            try
            {
                comPort.Open();
                DisplayData(Brushes.Black, "Порт " + comPort.PortName + " открыт " + DateTime.Now);
                return true;
            }
            catch (UnauthorizedAccessException p)
            {
                comPort.Close();
                DisplayData(Brushes.Black, "Порт " + comPort.PortName + " закрыт " + DateTime.Now);
                comPort.Open();
                DisplayData(Brushes.Black, "Порт " + comPort.PortName + " открыт " + DateTime.Now);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message + "\n" + ex.GetType().ToString());
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                comPort.Close();
                DisplayData(Brushes.Black, "Порт " + comPort.PortName + " закрыт " + DateTime.Now);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void Config(string portName, string baudRate, string parity, string stopBits)
        {
            if (comPort.IsOpen == true)
            {
                Close();
            }
            try
            {
                comPort.PortName = portName;
                comPort.BaudRate = Int32.Parse(baudRate);
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity);
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
                comPort.DataBits = 8;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        protected void DisplayData(Brush color, string msg)
        {
            _fd.Dispatcher.BeginInvoke(
                   new Action(() =>
                   {
                       Paragraph pg = new Paragraph();
                       pg.Inlines.Add(msg);
                       pg.Foreground = color;
                       _fd.Blocks.Add(pg);
                   }));
        }

        public byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length / 2; i++)
                comBuffer[i] = Convert.ToByte(msg.Substring(i * 2, 2), 16);
            return comBuffer;
        }

        public string ByteToHex(byte[] comByte)
        {
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            foreach (byte data in comByte)
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').
                    PadRight(3, ' '));
            return builder.ToString().ToUpper();
        }

    }
}
