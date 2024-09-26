using APPICHI.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPICHI.ViewModels.Home
{
    public class EditDayPlanViewModel : INotifyPropertyChanged
    {
        private DayPlanModel _currentDayPlan;

        public DayPlanModel CurrentDayPlan
        {
            get { return _currentDayPlan; }
            set
            {
                _currentDayPlan = value;
                OnPropertyChanged(nameof(CurrentDayPlan));
            }
        }

        public EditDayPlanViewModel()
        {
            CurrentDayPlan = App.DayPlanRepo.GetTodayDayPlan();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
