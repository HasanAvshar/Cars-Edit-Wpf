using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp15
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Car _selectedCar;
        private Car _newCar;

        public ObservableCollection<Car> Cars { get; set; }

        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
            }
        }

        public Car NewCar
        {
            get { return _newCar; }
            set
            {
                _newCar = value;
                OnPropertyChanged(nameof(NewCar));
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; 
            Cars = new ObservableCollection<Car>
            {
                new Car { Make = "Toyota", Model = "Corolla", Year = "2020", StNumber = "1234" }
            };
            NewCar = new Car();
            AddCommand = new RelayCommand(Add);
            UpdateCommand = new RelayCommand(OpenUpdateWindow);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void Add(object parameter)
        {
            if (string.IsNullOrWhiteSpace(NewCar.Make) ||
                string.IsNullOrWhiteSpace(NewCar.Model) ||
                string.IsNullOrWhiteSpace(NewCar.StNumber) ||
                string.IsNullOrWhiteSpace(NewCar.Year))
            {
                MessageBox.Show("Wrong Entered");
                return;
            }

            Cars.Add(new Car
            {
                Make = NewCar.Make,
                Model = NewCar.Model,
                Year = NewCar.Year,
                StNumber = NewCar.StNumber
            });

            NewCar = new Car();
            OnPropertyChanged(nameof(NewCar));
        }

        private void OpenUpdateWindow(object parameter)
        {
            if (SelectedCar == null) return;

            UpdateWindow updateWindow = new UpdateWindow
            {
                Car = SelectedCar
            };
            updateWindow.DataContext = updateWindow;

            if (updateWindow.ShowDialog() == true)
            {
                OnPropertyChanged(nameof(Cars));
            }
        }

        private void Delete(object parameter)
        {
            if (SelectedCar != null)
            {
                Cars.Remove(SelectedCar);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
