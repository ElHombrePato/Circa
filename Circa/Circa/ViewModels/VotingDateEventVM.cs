using Circa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Circa.ViewModels
{
    class VotingDateEventVM : DateEventVM
    {
        private ObservableCollection<DateOption> dateOptions;

        public ObservableCollection<DateOption> DateOptions { get => dateOptions; set => dateOptions = value; }
        public VotingDateEventVM(DateEvent dateEvent) : base(dateEvent)
        {
            //TODO functionality
        }

        //TODO guardar lo9s cambios en la lista
        public GenericEvent ConfirmVotingDateEvent()
        {
            ConfirmDateEvent(new List<DateOption>());

            return GenericEvent;
        }
    }
}
