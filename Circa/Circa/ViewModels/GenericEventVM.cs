using Circa.Models;
using Circa.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Circa.ViewModels
{
    public abstract class GenericEventVM : INotifyPropertyChanged
    {
        //private MainPage listener;

        private GenericEvent genericEvent;

        private bool titleEntryIsEnabled;
        private bool descriptionEntryIsEnabled;
        private bool ubicationEntryIsEnabled;
        private bool fieldPickerIsEnabled;
        private bool votingDeadlinePickerIsEnabled;

        private bool proposingUsersSwitchIsEnabled;
        //private bool proposingUsersBlockIsVisible;

        private bool maxPropositionsPerUserPickerIsEnabled;
        private bool proposingDeadlinePickerIsEnabled;

        private string titleEntryText;
        private string descriptionEntryText;
        private string ubicationEntryText;
        private int fieldPickerSelectedIndex;
        private DateTime votingDeadlineDatePickerDate;
        private TimeSpan votingDeadlineTimePickerTime;

        private bool proposingUsersSwitchIsToggled;
        private int maxPropositionsPerUserPickerSelectedItem;
        private DateTime proposingDeadlineDatePickerDate;
        private TimeSpan proposingDeadlineTimePickerTime;


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String Name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }

        }



        //Not used directly, but it is neccesary to implement inheritance in New events
        protected GenericEventVM()
        {
            GenericEvent = new GenericEvent(App.myUser);
            //GenericEvent.Admin = App.myUser;
            FillForm();
            SetAllEnableAttributesTo(true);
            ProposingUsersSwitchIsEnabled = true;
            ProposingUsersSwitchIsToggled = false;
            //proposingUsersBlockIsVisible = false;
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

            //TODO ewnable NO funciona!!!!!!
            ProposingUsersSwitchIsEnabled = false;
            ProposingUsersSwitchIsToggled = false;
            //ProposingUsersBlockIsVisible = false;

            if (GenericEvent.ProposingIsEnabled)
            {
                //ProposingUsersSwitchIsEnabled = true;
                ProposingUsersSwitchIsToggled = true;
                //proposingUsersBlockIsVisible = true;
            }
        }

        protected void EnableAdminFields()
        {
            TitleEntryIsEnabled = true;
            DescriptionEntryIsEnabled = true;
            UbicationEntryIsEnabled = true;
            FieldPickerIsEnabled = true;
        }

        protected void FillForm()
        {
            TitleEntryText = GenericEvent.Title;
            DescriptionEntryText = GenericEvent.Description;
            UbicationEntryText = GenericEvent.Ubication;
            FieldPickerSelectedIndex = GenericEvent.FieldKey;
            VotingDeadlineDatePickerDate = GenericEvent.VotingDeadline.Date;
            VotingDeadlineTimePickerTime = GenericEvent.VotingDeadline.TimeOfDay;

            //TODO meter atributos de interfaz?

            MaxPropositionsPerUserPickerSelectedItem = GenericEvent.MaxPropositionsPerUser;
            ProposingDeadlineDatePickerDate = GenericEvent.ProposingDeadline.Date;
            ProposingDeadlineTimePickerTime = GenericEvent.ProposingDeadline.TimeOfDay;
        }

        protected void SetAllEnableAttributesTo(bool b)
        {
            TitleEntryIsEnabled = b;
            DescriptionEntryIsEnabled = b;
            UbicationEntryIsEnabled = b;
            FieldPickerIsEnabled = b;
            VotingDeadlinePickerIsEnabled = b;

            MaxPropositionsPerUserPickerIsEnabled = b;
            ProposingDeadlinePickerIsEnabled = b;


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

                var fieldIndex = 404;
                if (FieldPickerSelectedIndex != null)
                {
                    fieldIndex = FieldPickerSelectedIndex;
                }

                //Even if some cannot be change after creation, all are neccesary for New events
                GenericEvent.Title = TitleEntryText;
                GenericEvent.Description = DescriptionEntryText;
                GenericEvent.Ubication = UbicationEntryText;
                GenericEvent.FieldKey = fieldIndex;
                //Admin stays the same always (the Admin is set when the VM is called)
                GenericEvent.VotingDeadline = votingDeadline;

                GenericEvent.ProposingIsEnabled = ProposingUsersSwitchIsToggled;
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
        public bool FieldPickerIsEnabled { get => fieldPickerIsEnabled; set => fieldPickerIsEnabled = value; }
        public bool VotingDeadlinePickerIsEnabled { get => votingDeadlinePickerIsEnabled; set => votingDeadlinePickerIsEnabled = value; }
        public bool ProposingUsersSwitchIsEnabled { get => proposingUsersSwitchIsEnabled; set => proposingUsersSwitchIsEnabled = value; }
        public bool ProposingUsersSwitchIsToggled
        {
            get
            {
                return proposingUsersSwitchIsToggled;
            }
            set
            {
                proposingUsersSwitchIsToggled = value;
                //RaisePropertyChanged("ProposingUsersSwitchIsToggled");
            }
        }

        //public bool ProposingUsersBlockIsVisible { get => proposingUsersBlockIsVisible; set => proposingUsersBlockIsVisible = value; }
        public bool MaxPropositionsPerUserPickerIsEnabled { get => maxPropositionsPerUserPickerIsEnabled; set => maxPropositionsPerUserPickerIsEnabled = value; }
        public bool ProposingDeadlinePickerIsEnabled { get => proposingDeadlinePickerIsEnabled; set => proposingDeadlinePickerIsEnabled = value; }
        public string TitleEntryText { get => titleEntryText; set => titleEntryText = value; }
        public string DescriptionEntryText { get => descriptionEntryText; set => descriptionEntryText = value; }
        public string UbicationEntryText { get => ubicationEntryText; set => ubicationEntryText = value; }
        public int FieldPickerSelectedIndex { get => fieldPickerSelectedIndex; set => fieldPickerSelectedIndex = value; }
        public DateTime VotingDeadlineDatePickerDate { get => votingDeadlineDatePickerDate; set => votingDeadlineDatePickerDate = value; }
        public TimeSpan VotingDeadlineTimePickerTime { get => votingDeadlineTimePickerTime; set => votingDeadlineTimePickerTime = value; }
        public int MaxPropositionsPerUserPickerSelectedItem { get => maxPropositionsPerUserPickerSelectedItem; set => maxPropositionsPerUserPickerSelectedItem = value; }
        public DateTime ProposingDeadlineDatePickerDate { get => proposingDeadlineDatePickerDate; set => proposingDeadlineDatePickerDate = value; }
        public TimeSpan ProposingDeadlineTimePickerTime { get => proposingDeadlineTimePickerTime; set => proposingDeadlineTimePickerTime = value; }
        
    }
}
