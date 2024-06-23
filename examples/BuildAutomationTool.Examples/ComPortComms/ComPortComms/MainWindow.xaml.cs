using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComPortComms
{
    /// <summary>
    /// Logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ComPort cp;
        public MainWindow()
        {
            InitializeComponent();
            cp = new ComPort(Fd);
            cBaudRate.SelectedIndex = 5;
            cParity.SelectedIndex = 0;
            cStopBits.SelectedIndex = 0;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            cp.Config(cPortName.Text, cBaudRate.Text, cParity.SelectedIndex.ToString(), cStopBits.Text);
            cp.Open();
        }

        private void PortName_DropDownOpened(object sender, EventArgs e)
        {
            cPortName.Items.Clear();
            string[] st = ComPort.Ports;
            for (int i = 0; i < st.Length; i++)
                cPortName.Items.Add(st[i]);
            if (cPortName.Items.Count > 0)
                cPortName.SelectedIndex = 0;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendCommand();
        }

        private void btnCRC_Click(object sender, RoutedEventArgs e)
        {
            tbCmd.Text = AddCRC(tbCmd.Text);
        }

        private string AddCRC(string message)
        {
            byte[] newMsg = cp.HexToByte(message);
            int CRC = 0xFFFF;
            for (int p = 0; p < newMsg.Length; p++)
            {
                // XOR byte into least sig. byte of crc.
                CRC ^= (int)newMsg[p];
                
                // Loop over each bit.
                for (int i = 8; i != 0; i--)
                {
                    // Check if the LSB is set.
                    if ((CRC & 0x0001) != 0)
                    {
                        // Shift right and XOR 0xA001
                        CRC >>= 1;
                        CRC ^= 0xA001;
                    }
                    else            
                    {
                        // Just shift right.
                        CRC >>= 1; 
                    }
                }
            }
            byte[] crc = new byte[2];
            crc[0] = (byte)(CRC & 0xFF);
            crc[1] = (byte)((CRC & 0xFF00) >> 8);
            message += " " + cp.ByteToHex(crc);
            message = message.Replace("  ", " ");
            return message;

        }

        private void tbCmd_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void SendCommand()
        {
            cp.Send(tbCmd.Text);
        }

        private void tbCmd_KeyUp(object sender, KeyEventArgs e)
        {
            string key = "";
            if(e.Key == Key.Enter)
            {
                SendCommand();
                return;
            }
            switch(e.Key)
            {
                case Key.A: key = "A"; break;
                case Key.B: key = "B"; break;
                case Key.C: key = "C"; break;
                case Key.D: key = "D"; break;
                case Key.E: key = "E"; break;
                case Key.F: key = "F"; break;
                case Key.D0: key = "0"; break;
                case Key.D1: key = "1"; break;
                case Key.D2: key = "2"; break;
                case Key.D3: key = "3"; break;
                case Key.D4: key = "4"; break;
                case Key.D5: key = "5"; break;
                case Key.D6: key = "6"; break;
                case Key.D7: key = "7"; break;
                case Key.D8: key = "8"; break;
                case Key.D9: key = "9"; break;
                case Key.Back: return;
                case Key.Delete: return;
                case Key.Left: return;
                case Key.Right: return;
                case Key.LeftShift: return;
                case Key.RightShift: return;
                case Key.LeftCtrl: return;
                case Key.RightCtrl: return;
                case Key.LeftAlt: return;
                case Key.RightAlt: return;
                case Key.CapsLock: return;
            }
            string text = tbCmd.Text.Substring(0, tbCmd.CaretIndex) + 
                          key + 
                          tbCmd.Text.Substring(tbCmd.CaretIndex, tbCmd.Text.Length-tbCmd.CaretIndex);
            text = text.Replace(" ", "");
            string txt2 = "";
            for (int i = 0; i < text.Length; i += 2)
            {
                txt2 += text[i];
                if ((i + 1) < text.Length)
                    txt2 += text[i + 1] + " ";
            }
            tbCmd.Text = txt2;
            tbCmd.CaretIndex = tbCmd.Text.Length;
            
        }

        private void rtb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Fd.Blocks.Clear();
        }
    }
}
