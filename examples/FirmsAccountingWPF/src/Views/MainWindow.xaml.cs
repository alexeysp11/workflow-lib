﻿using System;
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
using WorkflowLib.Examples.FirmsAccounting.ViewModels;

namespace WorkflowLib.Examples.FirmsAccounting.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FirmWindowTitle 
        { 
            get { return "Firms-Accounting: firms";  } 
        }
        
        public string DocWindowTitle 
        { 
            get { return "Firms-Accounting: documents"; } 
        }

        public MainWindow()
        {
            InitializeComponent();
            this.Title = FirmWindowTitle;
            DataContext = new MainVM(this);
        }
    }
}
