using System.Windows;

namespace WpfApp15
{
    public partial class UpdateWindow : Window
    {
        public Car Car { get; set; }

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }

}

