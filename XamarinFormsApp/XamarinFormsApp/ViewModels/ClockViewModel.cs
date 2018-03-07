using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsApp.ViewModels
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        DateTime currentDateTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public ClockViewModel()
        {
            this.CurrentDateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.CurrentDateTime = DateTime.Now;
                return true;
            });
        }

        public DateTime CurrentDateTime
        {
            get
            {
                return this.currentDateTime;
            }
            private set
            {
                if (this.currentDateTime != value)
                {
                    this.currentDateTime = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDateTime"));
                }
            }
        }
    }
}
