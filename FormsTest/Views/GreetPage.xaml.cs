using System;
using System.Timers;
using System.Dynamic;
using System.Collections.Generic;
using Xamarin.Forms;
using FormsTest.Services;

namespace FormsTest
{
    public partial class GreetPage : ContentPage
    {

        private GetDate _dateService = new GetDate();

        private DateTime targetDate;

        public System.TimeSpan difference;

        public GreetPage()
        {
            this.difference = DateTime.Now.AddSeconds(2) - DateTime.Now;

            InitializeComponent();

            switch (Device.RuntimePlatform) {
                case Device.iOS:
                    Padding = new Thickness(0, 20, 0, 0);
                    break;
                default:
                    Padding = new Thickness(0, 0, 0, 0);
                    break;
            }

        }

        protected override async void OnAppearing() {
            BindingContext = this.difference;

            var d = await _dateService.GetInfo();
            this.targetDate = new System.DateTime(d.year, d.month, d.day, d.hour, d.minute, d.second);

            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(RefreshCountdown);
            timer.Interval = 1000;
            timer.Start();

            base.OnAppearing();
        }

        public void RefreshCountdown(object source, ElapsedEventArgs e) {
            if (this.targetDate != null)
            {
                DateTime now = DateTime.Now;

                this.difference = this.targetDate - now;

                this.updateCountdown();

                Console.WriteLine(String.Format("{0} days, {1} seconds", this.difference.Days, this.difference.Seconds));


            }
        }

        protected void updateCountdown() {

            //List<string> countdown = new List<string>();

            //if (this.difference.Days != 0) {
            //    countdown.Add(String.Format("{0} days", this.difference.Days));
            //}

            //if (this.difference.Days != 0 && this.difference.Hours != 0) {
            //    countdown.Add(String.Format("{0} hours", this.difference.Hours));
            //}

            //if (this.difference.Days != 0 && this.difference.Hours != 0 && this.difference.Minutes != 0) {
            //    countdown.Add(String.Format("{0} minutes", this.difference.Minutes));
            //}

            //if (this.difference.Days != 0 && this.difference.Hours != 0 && this.difference.Minutes != 0 && this.difference.Seconds != 0) {
            //    countdown.Add(String.Format("{0} seconds", this.difference.Seconds));
            //}

            //string[] finalCountdownArray = countdown.ToArray();

            Device.BeginInvokeOnMainThread(() => {
                //label.Text = String.Format(string.Join(", ", finalCountdownArray));
                days.Text = String.Format("{0} days", this.difference.Days);
                hours.Text = String.Format("{0} hours", this.difference.Hours);
                minutes.Text = String.Format("{0} minutes", this.difference.Minutes);
                seconds.Text = String.Format("{0} seconds", this.difference.Seconds);
            });
        }

    }


}
