using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DateAppXamarin
{
    public partial class MainPage : ContentPage
    {
        private DateTime _datetime;
        private TimeSpan _timespan;
        public DateTime DateTimeResult
        {
            get { return _datetime; }
            set
            {
                _datetime = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan TimeSpanResult
        {
            get { return _timespan; }
            set
            {
                _timespan = value;
                OnPropertyChanged();
            }
        }
        public MainPage()
        {
            InitializeComponent();
            DateTimeResult = DateTime.Now;
            TimeSpanResult = TimeSpan.FromSeconds(0);
            BindingContext = this;
        }

        private TimeSpan DateDifferenceDays(DateTime date)
        {
            // find date difference between two dates
            TimeSpanResult = date - DateTime.Now;
            return TimeSpanResult;
        }
        private DateTime DateAdd(DateTime date, double days = 0, int months = 0, int years = 0, int hours = 0, int minutes = 0)
        {
            if (years != 0)
            {
               date = date.AddYears(years);
            }
            if (months != 0)
            {
               date = date.AddMonths(months);
            }
            if (days != 0)
            {
               date = date.AddDays(days);
            }
            if (hours != 0)
            {
                date = date.AddHours(hours);
            }
            if (minutes != 0)
            {
                date = date.AddMinutes(minutes);
            }
            DateTimeResult = date;
            return DateTimeResult;

        }

        private void CalculateDate_Clicked(object sender, EventArgs e)
        {

           DateTimeResult = DateAdd(DateTime.Now, Double.Parse(EnterDays.Text), Int32.Parse(EnterMonths.Text), Int32.Parse(EnterYears.Text), Int32.Parse(EnterHours.Text), Int32.Parse(EnterMinutes.Text));
            
        }

        private void CalculateDifference_Clicked(object sender, EventArgs e)
        {
            TimeSpanResult = DateDifferenceDays(DatePicker1.Date);

            if (DatePicker2.Date <= DateTime.Now.AddDays(-1) || DatePicker2.Date >= DateTime.Now.AddDays(1))
            {
                TimeSpanResult = DatePicker2.Date - DatePicker1.Date;
            }
            
        }
    }
}
