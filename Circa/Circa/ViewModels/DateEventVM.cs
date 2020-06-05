using Circa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Circa.ViewModels
{
    //Código sacado de https://www.syncfusion.com/kb/10087/how-to-bind-selecteddates-of-calendar-in-mvvm
    public abstract class DateEventVM : GenericEventVM, INotifyPropertyChanged
    {
        private DateEvent dateEvent;

        private DateTime calendarMinDate;
        private DateTime calendarMaxDate;
        private List<DateTime> calendarBlackoutDates;

        //private ObservableCollection<DateOption> dateOptions;

        //Used if it is a new Date event
        public DateEventVM() : base()
        {
            DateEvent = new DateEvent(App.myUser);
            //DateOptions = new ObservableCollection<DateOption>();

            CalendarMinDate = DateEvent.VotingDeadline;
            CalendarMaxDate = DateTime.MaxValue;
            CalendarBlackoutDates = new List<DateTime>();

        }

        //When Proposing/Voting
        public DateEventVM(DateEvent dateEvent) : base(dateEvent)
        {
            //GenericEvent = (GenericEvent)dateEvent;
            DateEvent = dateEvent;

            //TODO check values
            CalendarMinDate = DateEvent.VotingDeadline;
            CalendarMaxDate = DateTime.MaxValue;
            CalendarBlackoutDates = new List<DateTime>();
        }

        public DateEvent ConfirmDateEvent(List<DateOption> dateOptions)
        {
            ConfirmGenericEvent();

            //This is not the DateEvent attribute
            var dateEvent = new DateEvent(GenericEvent)
            {
                DateOptions = dateOptions
            };

            return dateEvent;

        }

        /*
        public Command<DateTime> RemoveCommand
        {
            get
            {
                return new Command<DateTime>((date) =>
                {
                    MyDates.Remove(date);
                    RaisePropertyChanged("SelectedDates");

                    //System.Diagnostics.Debug.WriteLine("Se elimina (VM): " + date);
                });
            }
        }
        */

        /*
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                //MyDates.Sort();
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }

        }
        */

        public override DateTime VotingDeadlineDatePickerDate
        {
            get { return base.VotingDeadlineDatePickerDate; }
            set
            {
                base.VotingDeadlineDatePickerDate = value;
                RaisePropertyChanged();

                var votingDeadline = VotingDeadlineDatePickerDate;
                votingDeadline = votingDeadline.Add(VotingDeadlineTimePickerTime);
                CalendarMinDate = votingDeadline;
            }
        }


        public override TimeSpan VotingDeadlineTimePickerTime
        {
            get { return base.VotingDeadlineTimePickerTime; }
            set
            {
                base.VotingDeadlineTimePickerTime = value;
                RaisePropertyChanged();

                var votingDeadline = VotingDeadlineDatePickerDate;
                votingDeadline = votingDeadline.Add(VotingDeadlineTimePickerTime);
                CalendarMinDate = votingDeadline;
            }
        }

        public DateEvent DateEvent { get => dateEvent; set => dateEvent = value; }
        public DateTime CalendarMinDate
        {
            get{ return calendarMinDate; }
            set
            {
                calendarMinDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime CalendarMaxDate { get => calendarMaxDate; set => calendarMaxDate = value; }
        public List<DateTime> CalendarBlackoutDates { get => calendarBlackoutDates; set => calendarBlackoutDates = value; }

        //public ObservableCollection<DateOption> DateOptions { get => dateOptions; set => dateOptions = value; }

    }
}

