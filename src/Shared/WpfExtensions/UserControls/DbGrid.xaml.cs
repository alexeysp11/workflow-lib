using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace WorkflowLib.Shared.WpfExtensions.UserControls
{
    /// <summary>
    /// Interaction logic for DbGrid.xaml
    /// </summary>
    public partial class DbGrid : UserControl
    {
        public static new readonly DependencyProperty HeightProperty
            = DependencyProperty.Register("Height", typeof(double), typeof(DbGrid),
                new PropertyMetadata(0.0));
        
        public static new readonly DependencyProperty WidthProperty
            = DependencyProperty.Register("Width", typeof(double), typeof(DbGrid),
                new PropertyMetadata(0.0));
        
        public static readonly DependencyProperty IsReadOnlyProperty
            = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(DbGrid),
                new PropertyMetadata(false));
        
        public static readonly DependencyProperty AutoGenerateColumnsProperty
            = DependencyProperty.Register("AutoGenerateColumns", typeof(bool), typeof(DbGrid),
                new PropertyMetadata(false));

        public static readonly DependencyProperty ItemsSourceProperty
            = DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(DbGrid),
                new PropertyMetadata(null));
        
        public new double Height
        {
            get => (double)GetValue(HeightProperty);
            set 
            {
                SetValue(HeightProperty, value);
                grBrowse.Height = value;
            }
        }

        public new double Width
        {
            get => (double)GetValue(WidthProperty);
            set 
            {
                SetValue(WidthProperty, value);
                grBrowse.Width = value;
            }
        }

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set 
            {
                SetValue(IsReadOnlyProperty, value);
                dgrBrowse.IsReadOnly = value;
            }
        }

        public bool AutoGenerateColumns
        {
            get => (bool)GetValue(AutoGenerateColumnsProperty);
            set 
            {
                SetValue(AutoGenerateColumnsProperty, value);
                dgrBrowse.AutoGenerateColumns = value;
            }
        }

        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set 
            {
                SetValue(ItemsSourceProperty, value);
                dgrBrowse.ItemsSource = value;
            }
        }

        public DbGrid()
        {
            InitializeComponent();

            Loaded += (o, e) => 
            {
                grBrowse.Height = this.Height;
                grBrowse.Width = this.Width;

                dgrBrowse.AutoGenerateColumns = this.AutoGenerateColumns;
                dgrBrowse.IsReadOnly = this.IsReadOnly;
                dgrBrowse.ItemsSource = this.ItemsSource;
            };
        }

        private void dgrBrowse_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string header = e.Column.Header.ToString();
            e.Column.Header = header.Replace("_", "__");
        }
    }
}
