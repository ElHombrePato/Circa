using Circa.Models;
using Circa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Circa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VotingEventPage : TabbedPage
    {
        private MainPage listener;
        public MainPage Listener { get => listener; set => listener = value; }

        /*
        public VotingEventPage()
        {
            InitializeComponent();

            //this.BindingContext = new VotingEventViewModel();

            FieldPicker.ItemsSource = GenericEvent.eventFieldArray;
            MaxPropositionsPerUserPicker.ItemsSource = GenericEvent.maxPropositionsPerUserArray;
        }
        */

        public VotingEventPage(DateEvent dateEvent)
        {
            InitializeComponent();

            this.BindingContext = new VotingEventViewModel(dateEvent);

            FieldPicker.ItemsSource = GenericEvent.eventFieldArray;
            MaxPropositionsPerUserPicker.ItemsSource = GenericEvent.maxPropositionsPerUserArray;

            TitleEntry.Text = dateEvent.Title;
            DescriptionEntry.Text = dateEvent.Description;
            UbicationEntry.Text = dateEvent.Ubication;
            FieldPicker.SelectedItem = dateEvent.Field;
            VotingDeadlineDatePicker.Date = dateEvent.VotingDeadline.Date;
            VotingDeadlineTimePicker.Time = dateEvent.VotingDeadline.TimeOfDay;

            if (!dateEvent.Admin.Equals(App.myUser))
            {
                TitleEntry.IsEnabled = false;
                //RESTO
            }
        }

        private async void ConfirmNewEvent_Clicked(object sender, EventArgs e)
        {
            var votingDeadline = VotingDeadlineDatePicker.Date;
            votingDeadline = votingDeadline.Add(VotingDeadlineTimePicker.Time);

            var fieldString = "";
            if (FieldPicker.SelectedItem != null)
            {
                fieldString = FieldPicker.SelectedItem.ToString();
            }

            //var dateEvent = BindingContext as DateEvent;
            //System.Diagnostics.Debug.WriteLine("Date en NewEvent: " + dateEvent.Admin);

            var vm = BindingContext as VotingEventViewModel;
            var i = 0;

            /*
            foreach (DateTime dT in vm.MyDates)
            {
                i++;
                System.Diagnostics.Debug.WriteLine(i + ") " + dT);
            }
            */

            var newDateEvent = new DateEvent(
                TitleEntry.Text,
                DescriptionEntry.Text,
                UbicationEntry.Text,
                fieldString,
                App.myUser,
                votingDeadline,
                new List<DateOption>());

            //  EventViewModel.DatesToDateOptions(vm.MyDates)

            //PASAR LA CREACIÖN DEL EVENTO AQUÍ, PERO AÑADIRLO AL USER EN EL MAIN

            /*
            var vm = BindingContext as MainPage;
            var vm = BindingContext as OnNewUserEventListener;
            vm.CreateEvent(
                titleEntry.Text,
                descriptionEntry.Text,
                fieldString,
                //App.admin,
                votingDeadline);

            System.Diagnostics.Debug.WriteLine(votingDeadline);
            */

            //App.admin.Events.Add(inCreationEvent);

            //Notify listener
            if (Listener != null)
            {
                Listener.OnNewUserEvent(newDateEvent);
            }


            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private async void CancelNewEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }


        private void ProposingIsEnabledSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ProposingUsersBlock.IsVisible = !ProposingUsersBlock.IsVisible;
        }
    }
}