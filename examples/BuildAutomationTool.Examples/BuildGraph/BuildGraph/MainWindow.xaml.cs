using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BuildGraph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SaveFileDialog sfd;
        OpenFileDialog ofd;
        Graph gr;

        const string filter = "Text file|*.txt|All files|*.*";

        public MainWindow()
        {
            InitializeComponent();
            sfd = new SaveFileDialog();
            ofd = new OpenFileDialog();
            gr = new Graph();
           // ofd.Filter = filter;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            ofd.Filter = filter;
            if (ofd.ShowDialog() == false)
                return;
            tb.Text = File.ReadAllText(ofd.FileName);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(tb.Text))
            {
                MessageBox.Show("No data to save");
                return;
            }
            sfd.Filter = filter;
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllText(sfd.FileName, tb.Text);
            }
        }

        private void SavePicture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            generate();
        }

        private void generate()
        {
            string s = "";
            s += "---------------------------\n";
            s += "|  t  |    x    |    y    |\n";
            s += "---------------------------\n";
            for(double t=0.0; t<7.01; t=t+0.1)
            {
                double x = Math.Sin(t);
                double y = Math.Cos(t);
                s+= String.Format("| {0, 3:0.0} | {1,7:0.0000} | {2,7:0.0000} |\n", t, x, y);
            }
            s += "---------------------------\n";
            tb.Text = s;
        }

        private void Graph_Click(object sender, RoutedEventArgs e)
        {
            gr.Show();
        }
    }
}
