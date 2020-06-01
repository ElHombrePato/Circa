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
        private List<DateOption> otherDateOptions;


        //New event
        public ProposingDateEventVM() : base()
        {
            //Generic Event?
            //DateEvent = new DateEvent(App.myUser);
            MyDates = new List<DateTime>();
        }
        
        public ProposingDateEventVM(DateEvent dateEvent) : base(dateEvent)
        {
            MyDates = new List<DateTime>();
            OtherDateOptions = new List<DateOption>();

            DevideDateOptionsList();
        }

        public void DevideDateOptionsList()
        {
            var dateOptions = DateEvent.DateOptions;

            if (dateOptions != null)
            {
                //Se cogen las fechas de los eventos propuestos por myUser
                foreach (DateOption dO in dateOptions)
                {
                    if (dO.Proposer.Equals(App.myUser))
                    {
                        MyDates.Add(dO.Date);
                        dateOptions.Remove(dO);
                    }
                }
                //Se introducen las fechas del resto de usuarios
                OtherDateOptions = dateOptions;
            }

        }

        public void JoinDateOptionsList()
        {
            var myDateOptions = DatesToDateOptions(MyDates);

            DateEvent.DateOptions = OtherDateOptions.Concat(myDateOptions) as List<DateOption>;
        }

        public static List<DateOption> DatesToDateOptions(List<DateTime> dates)
        {
            var dateOptions = new List<DateOption>();

            foreach (DateTime dT in dates)
            {
                dateOptions.Add(new DateOption(dT, App.myUser));
            }

            return dateOptions;
        }

        //SOLO FUNCIONA PARA EVENTOS SIN PROPOSING
        public DateEvent ConfirmProposingDateEvent()
        {
            var dateEvent = ConfirmDateEvent(DatesToDateOptions(MyDates));

            return dateEvent;
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
                myDates = value;
                RaisePropertyChanged("MyDates");
            }
        }

        public List<DateOption> OtherDateOptions
        {
            get { return otherDateOptions; }
            set
            {
                otherDateOptions = value;
                RaisePropertyChanged("OtherDateOptions");
            }
                
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                MyDates.Sort();
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
                
        }

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
    }
}
