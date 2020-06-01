using Circa.Models;
using Circa.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circa.ViewModels
{
    public abstract class GenericEventVM
    {
        //private MainPage listener;

        private GenericEvent genericEvent;

        private bool titleEntryIsEnabled;
        private bool descriptionEntryIsEnabled;
        private bool ubicationEntryIsEnabled;
        private bool fieldEntryIsEnabled;
        private bool votingDeadlineDatePickerIsEnabled;
        private bool votingDeadlineTimePickerIsEnabled;

        //PropisongSwitch mejor?
        private bool proposingUsersSwitchIsEnabled;
        private bool proposingUsersBlockIsVisible;

        private bool maxPropositionsPerUserPickerIsEnabled;
        private bool proposingDeadlineDatePickerIsEnabled;
        private bool proposingDeadlineTimePickerIsEnabled;

        private string titleEntryText;
        private string descriptionEntryText;
        private string ubicationEntryText;
        private string fieldPickerSelectedItem;
        private DateTime votingDeadlineDatePickerDate;
        private TimeSpan votingDeadlineTimePickerTime;

        private int maxPropositionsPerUserPickerSelectedItem;
        private DateTime proposingDeadlineDatePickerDate;
        private TimeSpan proposingDeadlineTimePickerTime;


        //Not used directly, but it is neccesary to implement inheritance in New events
        protected GenericEventVM()
        {
            GenericEvent = new GenericEvent(App.myUser);
            //GenericEvent.Admin = App.myUser;
            FillForm();
            SetAllEnableAttributesTo(false);
            proposingUsersSwitchIsEnabled = false;
        }
        
        protected GenericEventVM(GenericEvent genericEvent)
        {
            GenericEvent = genericEvent;

            FillForm();
            //SetAllEnableAttributesTo(false);

            if (GenericEvent.Admin.Equals(App.myUser))
            {
                EnableAdminFields();
            }

            if (GenericEvent.ProposingIsEnabled)
            {
                proposingUsersSwitchIsEnabled = false;
                proposingUsersBlockIsVisible = true;
            }
        }

        protected void EnableAdminFields()
        {
            TitleEntryIsEnabled = true;
            DescriptionEntryIsEnabled = true;
            UbicationEntryIsEnabled = true;
            FieldEntryIsEnabled = true;

        }

        protected void FillForm()
        {
            TitleEntryText = GenericEvent.Title;
            DescriptionEntryText = GenericEvent.Description;
            UbicationEntryText = GenericEvent.Ubication;
            FieldPickerSelectedItem = GenericEvent.Field;
            VotingDeadlineDatePickerDate = GenericEvent.VotingDeadline.Date;
            VotingDeadlineTimePickerTime = GenericEvent.VotingDeadline.TimeOfDay;

            MaxPropositionsPerUserPickerSelectedItem = GenericEvent.MaxPropositionsPerUser;
            ProposingDeadlineDatePickerDate = GenericEvent.ProposingDeadline.Date;
            ProposingDeadlineTimePickerTime = GenericEvent.ProposingDeadline.TimeOfDay;
        }

        protected void SetAllEnableAttributesTo(bool b)
        {
            TitleEntryIsEnabled = b;
            DescriptionEntryIsEnabled = b;
            UbicationEntryIsEnabled = b;
            FieldEntryIsEnabled = b;
            VotingDeadlineDatePickerIsEnabled = b;
            VotingDeadlineTimePickerIsEnabled = b;

            MaxPropositionsPerUserPickerIsEnabled = b;
            ProposingDeadlineDatePickerIsEnabled = b;
            ProposingDeadlineTimePickerIsEnabled = b;


        }

        protected void ConfirmGenericEvent()
        {
            //You only admit changes in the attributes if the user is admin
            if (GenericEvent.Admin == App.myUser)
            {
                var votingDeadline = VotingDeadlineDatePickerDate;
                votingDeadline = votingDeadline.Add(VotingDeadlineTimePickerTime);

                var proposingDeadline = ProposingDeadlineDatePickerDate;
                proposingDeadline = proposingDeadline.Add(ProposingDeadlineTimePickerTime);

                var fieldString = "";
                if (FieldPickerSelectedItem != null)
                {
                    fieldString = FieldPickerSelectedItem.ToString();
                }

                //Even if some cannot be change after creation, all are neccesary for New events
                GenericEvent.Title = TitleEntryText;
                GenericEvent.Description = DescriptionEntryText;
                GenericEvent.Ubication = UbicationEntryText;
                GenericEvent.Field = fieldString;
                //Admin stays the same always (the Admin is set when the VM is called)
                GenericEvent.VotingDeadline = votingDeadline;

                GenericEvent.ProposingIsEnabled = ProposingUsersSwitchIsEnabled;
                GenericEvent.MaxPropositionsPerUser = MaxPropositionsPerUserPickerSelectedItem;
                GenericEvent.ProposingDeadline = proposingDeadline;
            }

            /*
            genericEvent.Title = GenericEvent.Title;
            genericEvent.Description = GenericEvent.Description;
            genericEvent.Ubication = GenericEvent.Ubication;
            genericEvent.Field = GenericEvent.Field;

            genericEvent.Admin = GenericEvent.Admin;
            genericEvent.VotingDeadline = GenericEvent.VotingDeadline;

            genericEvent.ProposingIsEnabled = GenericEvent.ProposingIsEnabled;
            genericEvent.MaxPropositionsPerUser = GenericEvent.MaxPropositionsPerUser;
            genericEvent.ProposingDeadline = GenericEvent.ProposingDeadline;

            return genericEvent;
            */
        }

        //public MainPage Listener { get => listener; set => listener = value; }
        public GenericEvent GenericEvent { get => genericEvent; set => genericEvent = value; }
        public bool TitleEntryIsEnabled { get => titleEntryIsEnabled; set => titleEntryIsEnabled = value; }
        public bool DescriptionEntryIsEnabled { get => descriptionEntryIsEnabled; set => descriptionEntryIsEnabled = value; }
        public bool UbicationEntryIsEnabled { get => ubicationEntryIsEnabled; set => ubicationEntryIsEnabled = value; }
        public bool FieldEntryIsEnabled { get => fieldEntryIsEnabled; set => fieldEntryIsEnabled = value; }
        public bool VotingDeadlineDatePickerIsEnabled { get => votingDeadlineDatePickerIsEnabled; set => votingDeadlineDatePickerIsEnabled = value; }
        public bool VotingDeadlineTimePickerIsEnabled { get => votingDeadlineTimePickerIsEnabled; set => votingDeadlineTimePickerIsEnabled = value; }
        public bool ProposingUsersSwitchIsEnabled { get => proposingUsersSwitchIsEnabled; set => proposingUsersSwitchIsEnabled = value; }
        public bool ProposingUsersBlockIsIsVisible { get => proposingUsersBlockIsVisible; set => proposingUsersBlockIsVisible = value; }
        public bool MaxPropositionsPerUserPickerIsEnabled { get => maxPropositionsPerUserPickerIsEnabled; set => maxPropositionsPerUserPickerIsEnabled = value; }
        public bool ProposingDeadlineDatePickerIsEnabled { get => proposingDeadlineDatePickerIsEnabled; set => proposingDeadlineDatePickerIsEnabled = value; }
        public bool ProposingDeadlineTimePickerIsEnabled { get => proposingDeadlineTimePickerIsEnabled; set => proposingDeadlineTimePickerIsEnabled = value; }
        public string TitleEntryText { get => titleEntryText; set => titleEntryText = value; }
        public string DescriptionEntryText { get => descriptionEntryText; set => descriptionEntryText = value; }
        public string UbicationEntryText { get => ubicationEntryText; set => ubicationEntryText = value; }
        public string FieldPickerSelectedItem { get => fieldPickerSelectedItem; set => fieldPickerSelectedItem = value; }
        public DateTime VotingDeadlineDatePickerDate { get => votingDeadlineDatePickerDate; set => votingDeadlineDatePickerDate = value; }
        public TimeSpan VotingDeadlineTimePickerTime { get => votingDeadlineTimePickerTime; set => votingDeadlineTimePickerTime = value; }
        public int MaxPropositionsPerUserPickerSelectedItem { get => maxPropositionsPerUserPickerSelectedItem; set => maxPropositionsPerUserPickerSelectedItem = value; }
        public DateTime ProposingDeadlineDatePickerDate { get => proposingDeadlineDatePickerDate; set => proposingDeadlineDatePickerDate = value; }
        public TimeSpan ProposingDeadlineTimePickerTime { get => proposingDeadlineTimePickerTime; set => proposingDeadlineTimePickerTime = value; }

    }
}
