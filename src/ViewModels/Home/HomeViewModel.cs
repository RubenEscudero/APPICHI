using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPICHI.ViewModels.Home
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _currentDate;

        public string CurrentDate
        {
            get { return _currentDate; } 
            set
            {
                _currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }

        public HomeViewModel()
        {
            CurrentDate = $"{DateTime.Now.Day} de {DateTime.Now.ToString("MMMM")}, {DateTime.Now.ToString("dddd")}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
