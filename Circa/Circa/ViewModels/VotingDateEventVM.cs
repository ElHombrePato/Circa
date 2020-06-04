using Circa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Circa.ViewModels
{
    class VotingDateEventVM : DateEventVM
    {
        private List<DateTime> dates;
        private ObservableCollection<DateOptionWrapper> dateOptions;

        public VotingDateEventVM(DateEvent dateEvent) : base(dateEvent)
        {
            //The order of the attributes is vital
            //TODO falta mySelectedDates

            Dates = new List<DateTime>();
            DateOptions = new ObservableCollection<DateOptionWrapper>();
            LoadListValues();

            if(Dates.Count != 0)
            {
                CalendarMinDate = Dates.First();
                CalendarMaxDate = Dates.Last();
                CalendarBlackoutDates = CreateBlackoutList(CalendarMinDate, CalendarMaxDate, Dates);
            }
        }

        private void LoadListValues()
        {
            var dateOptionsWrapper = new List<DateOptionWrapper>();

            if (DateEvent.DateOptions != null && DateEvent.DateOptions.Count != 0)
            {

                foreach(DateOption dE in DateEvent.DateOptions)
                {
                    dateOptionsWrapper.Add(new DateOptionWrapper(dE));
                    Dates.Add(dE.Date);
                }

                //It works with CompareTo(DateOptionWrapper)
                dateOptionsWrapper.Sort();
                
                Dates.Sort();
                DateOptions = new ObservableCollection<DateOptionWrapper>(dateOptionsWrapper);
            }
        }

        private static List<DateTime> CreateBlackoutList(DateTime minDate, DateTime maxDate, List<DateTime> excludedDates)
        {
            var blackOutdates = new List<DateTime>();

            if (maxDate < minDate)
            {
                System.Diagnostics.Debug.WriteLine("Error en CreateBlackOutList");
            }

            for (var dt = minDate; dt <= maxDate; dt = dt.AddDays(1))
            {
                if (!excludedDates.Contains(dt))
                {
                    blackOutdates.Add(dt);
                    System.Diagnostics.Debug.WriteLine("Blackout date: " + dt);
                }
            }

            return blackOutdates;
        }

        //TODO guardar los cambios en la lista
        public GenericEvent ConfirmVotingDateEvent()
        {
            //TODO NO TIENE SENTIDO 
            //Mejor borrar todos TUS votos y volverlos a poner (nuevos y viejos)
            ConfirmDateEvent(new List<DateOption>());

            return GenericEvent;
        }

        public List<DateTime> Dates { get => dates; set => dates = value; }
        public ObservableCollection<DateOptionWrapper> DateOptions { get => dateOptions; set => dateOptions = value; }
    }
}
