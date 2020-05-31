using Circa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Circa.ViewModels
{
    //Código sacado de https://www.syncfusion.com/kb/10087/how-to-bind-selecteddates-of-calendar-in-mvvm
    public abstract class DateEventVM : GenericEventVM, INotifyPropertyChanged
    {
        private DateEvent dateEvent;

        private ObservableCollection<DateOption> dateOptions;

        //Used if it is a new Date event
        public DateEventVM() : base()
        {
            DateEvent = GenericEvent as DateEvent;
            DateOptions = new ObservableCollection<DateOption>();
        }

        //When Proposing/Voting
        public DateEventVM(DateEvent dateEvent) : base(dateEvent)
        {
            GenericEvent = dateEvent;
            DateEvent = dateEvent;
            DateOptions = new ObservableCollection<DateOption>(DateEvent.DateOptions);


            foreach (DateOption i in DateOptions)
            {
                System.Diagnostics.Debug.WriteLine("DateOpt en VotingVM: " + i);
            }
        }

        public DateEvent ConfirmDateEvent()
        {
            var votingDeadline = VotingDeadlineDatePickerDate;
            votingDeadline = votingDeadline.Add(VotingDeadlineTimePickerTime);

            var fieldString = "";
            if (FieldPickerSelectedItem != null)
            {
                fieldString = FieldPickerSelectedItem.ToString();
            }

            var dateEvent = new DateEvent(
                TitleEntryText,
                DescriptionEntryText,
                UbicationEntryText,
                fieldString,
                App.myUser,
                votingDeadline,
                new List<DateOption>());

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

        public DateEvent DateEvent { get => dateEvent; set => dateEvent = value; }
        public ObservableCollection<DateOption> DateOptions { get => dateOptions; set => dateOptions = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                //MyDates.Sort();
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
                
        }

        /*
        public void printDate(String str)
        {
            int i = 0;
            System.Diagnostics.Debug.WriteLine(str + ":");
            foreach (DateTime dT in MyDates)
            {
                i++;
                System.Diagnostics.Debug.WriteLine("" + i + ") " + dT);
            }
        }
        */
    }
}
