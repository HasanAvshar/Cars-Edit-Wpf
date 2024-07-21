using System.ComponentModel;

namespace WpfApp15
{
    public class Car : INotifyPropertyChanged
    {
        private string _make;
        private string _model;
        private string _year;
        private string _stNumber;

        public string Make
        {
            get => _make;
            set
            {
                _make = value;
                OnPropertyChanged(nameof(Make));
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public string Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public string StNumber
        {
            get => _stNumber;
            set
            {
                _stNumber = value;
                OnPropertyChanged(nameof(StNumber));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
