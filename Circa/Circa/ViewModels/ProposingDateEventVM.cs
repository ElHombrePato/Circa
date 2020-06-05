using Circa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Circa.ViewModels
{
    //Código sacado de https://www.syncfusion.com/kb/10087/how-to-bind-selecteddates-of-calendar-in-mvvm
    public class ProposingDateEventVM : DateEventVM, INotifyPropertyChanged
    {
        private List<DateTime> myDates;
        private ObservableCollection<DateOptionWrapper> otherDateOptions;

        //New event
        public ProposingDateEventVM() : base()
        {
            MyDates = new List<DateTime>();
            OtherDateOptions = new ObservableCollection<DateOptionWrapper>();
        }
        
        public ProposingDateEventVM(DateEvent dateEvent) : base(dateEvent)
        {
            MyDates = new List<DateTime>();
            
            LoadListValues();
            /*
            if (DateEvent.ProposingIsEnabled)
            {
                CalendarMinDate = DateEvent.ProposingDeadline;
            }
            */
        }

        //public void DevideDateOptionsList()
        private void LoadListValues()
        {
            var otherDateOptionsWrapper = new List<DateOptionWrapper>();
            var otherDates = new List<DateTime>();

            if (DateEvent.DateOptions != null && DateEvent.DateOptions.Count != 0)
            {
                foreach (DateOption dE in DateEvent.DateOptions)
                {
                    if (dE.Proposer.Equals(App.myUser))
                    {
                        MyDates.Add(dE.Date);
                    }
                    else
                    {
                        otherDateOptionsWrapper.Add(new DateOptionWrapper(dE));
                        otherDates.Add(dE.Date);
                    }
                }

                //It works with CompareTo(DateOptionWrapper)
                otherDateOptionsWrapper.Sort();
                
                MyDates.Sort();
                OtherDateOptions = new ObservableCollection<DateOptionWrapper>(otherDateOptionsWrapper);
                CalendarBlackoutDates = otherDates;
            }
        }

        public void JoinDateOptionsList()
        {
            var myDateOptions = DatesToDateOptions(MyDates);


            //DateEvent.DateOptions = OtherDateOptions.Concat(myDateOptions) as List<Models.DateOption>;
        }

        

        //SOLO FUNCIONA PARA EVENTOS SIN PROPOSING
        public DateEvent ConfirmProposingDateEvent()
        {
            var dateOptionsAux = DatesToDateOptions(MyDates);

            if(DateEvent.DateOptions != null && DateEvent.DateOptions.Count != 0)
            {
                var otherDateOptionsAux = DateEvent.DateOptions;
                otherDateOptionsAux.RemoveAll(item => item.Proposer == App.myUser);

                dateOptionsAux = dateOptionsAux.Concat<DateOption>(otherDateOptionsAux).ToList();
            }

            var dateEvent = ConfirmDateEvent(dateOptionsAux);

            return dateEvent;

            /*
            if(DateEvent.DateOptions != null && DateEvent.DateOptions.Count != 0)
            {
                var dateOptionsAux = DateEvent.DateOptions;

                foreach (DateOption dE in dateOptionsAux)
                {
                    if (dE.Proposer.Equals(App.myUser))
                    {
                        dateOptionsAux.Rem
                    }
                }

                //It works with CompareTo(DateOptionWrapper)
                otherDateOptionsWrapper.Sort();
            */
        }

        public static List<DateOption> DatesToDateOptions(List<DateTime> dates)
        {
            var dateOptions = new List<DateOption>();

            if(dates != null && dates.Count != 0)
            {
                //dates.Sort();

                foreach (DateTime dT in dates)
                {
                    dateOptions.Add(new DateOption(dT, App.myUser));
                }
            }

            return dateOptions;
        }

        /*
        public void DateOptionsToDates(List<DateOption> dateOptions)
        {
            if (dateEvent != null)
            {
                //Se cogen las fechas de los eventos propuestos por myUser
                foreach (DateOption dO in dateEvent.DateOptions)
                {
                    if (dO.Proposer.Equals(App.myUser))
                    {
                        MyDates.Add(dO.Date);
                        dateEvent.DateOptions.Remove(dO);
                    }
                }
                //Se introducen las fechas del resto de usuarios
                OtherDateOptions = dateEvent.DateOptions;
            }
        }
        */

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

        public List<DateTime> MyDates
        {
            get { return myDates; }
            set
            {
                value.Sort();
                myDates = value;
                RaisePropertyChanged();
            }
        }

        //public List<DateTime> OtherDates { get => otherDates; set => otherDates = value; }

        public ObservableCollection<DateOptionWrapper> OtherDateOptions
        {
            get { return otherDateOptions; }
            set
            {
                otherDateOptions = value;
                RaisePropertyChanged("OtherDateOptions");
            }
                
        }

        public void PrintDate(String str)
        {
            int i = 0;
            System.Diagnostics.Debug.WriteLine(str + ":");
            foreach (DateTime dT in MyDates)
            {
                i++;
                System.Diagnostics.Debug.WriteLine("" + i + ") " + dT);
            }
        }
    }
}
