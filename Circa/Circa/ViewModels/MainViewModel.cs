using Circa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Circa.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DateEvent selectedDateEvent;
        private ObservableCollection<DateEvent> myEvents;

        public MainViewModel()
        {
            //SelectedDateEvent = new DateEvent(App.myUser);
            SelectedDateEvent = null;
            MyEvents = new ObservableCollection<DateEvent>(App.myUser.Events);
            //MyEvents = new ObservableCollection<DateEventVM>(DateEventsToVM(App.admin.Events));

        }

        //public ObservableCollection<DateEventVM> MyEvents

        public ObservableCollection<DateEvent> MyEvents
        {
            get
            {
                return myEvents;
            }
            set
            {
                myEvents = value;
                RaisePropertyChanged("MyEvents");
            }
        }

        /*
        public static List<DateEventVM> DateEventsToVM(List<DateEvent> dateEvents)
        {
            int i = 0;
            var dateEventsVM = new List<DateEventVM>();

            if (dateEvents != null)
            {
                foreach (DateEvent dE in dateEvents)
                {
                    i++;
                    dateEventsVM.Add(new DateEventVM(dE, i.ToString()));
                }
            }

            return dateEventsVM;
        }
        */

        public Command<DateEvent> AddCommand
        {
            get
            {
                return new Command<DateEvent>((dateEvent) =>
                {
                    MyEvents.Add(dateEvent);
                    //MyEvents.Sort();
                    RaisePropertyChanged("MyEvents");
                });
            }
        }

        public DateEvent SelectedDateEvent
        {
            get
            {
                return selectedDateEvent;
            }
            set
            {
                if (selectedDateEvent != value)
                {
                    selectedDateEvent = value;
                }
            }
        }


        /*
        public bool CreateEvent(string title, string description, string field, DateTime votingDeadline)
        {
            var newDateEvent = new DateEvent(
                title,
                description,
                field,
                App.
                
            
            
            ,
                votingDeadline,
                datesToDateOptions(new List<DateTime>()));

            //App.admin.Events.Add(newDateEvent);
            

            return true;
        }
        */

        internal void PropertyChangedEventHandler()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                //MyEvents.Sort();
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }

        /*
        public void printDate(String str)
        {
            int i = 0;
            System.Diagnostics.Debug.WriteLine(str + ":");
            foreach (DateTime dT in SelectedDates)
            {
                i++;
                System.Diagnostics.Debug.WriteLine("" + i + ") " + dT);
            }
        }
        */
    }
}