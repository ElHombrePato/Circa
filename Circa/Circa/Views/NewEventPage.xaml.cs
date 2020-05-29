using Circa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Circa.ViewModels;

namespace Circa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEventPage : TabbedPage
    {
        //private OnNewUserEventListener listener = null;

        //private DateEvent onNewUserEventListener = null;
        private MainPage listener;

        //public DateEvent OnNewUserEventListener { get => onNewUserEventListener; set => onNewUserEventListener = value; }
        public MainPage Listener { get => listener; set => listener = value; }

        //private static List<DateTime> inCreationVotedDates = new List<DateTime>();
        //private DateEvent calEvent = new DateEvent(App.admin);
        //private static List<VotedDate> inCreationVotedDates = new List<VotedDate>();
        //private CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();

        public NewEventPage()
        {
            InitializeComponent();

            this.BindingContext = new EventViewModel();

            FieldPicker.ItemsSource = GenericEvent.eventFieldArray;
            MaxPropositionsPerUserPicker.ItemsSource = GenericEvent.maxPropositionsPerUserArray;

            //inCreationVotedDates = new ObservableCollection<DateTime>(inCreationVotedDates.Distinct());
            //votedDatesListView.ItemsSource = inCreationVotedDates;
            //CalendarEventCollection CalendarInlineEvents = CalendarInlineEvents.Distinct().To;
            //votedDatesListView.ItemsSource = CalendarInlineEvents;
        }

        public NewEventPage(DateEvent dateEvent)
        {
            InitializeComponent();

            this.BindingContext = new EventViewModel();

            FieldPicker.ItemsSource = DateEvent.eventFieldArray;

            //Ya hay un evento creado (votar, proponer, modificar) 
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

            /*
            if ()
            {

            }
            */


            //LIDIAR CON LAS FECHAS
            //HACER DOS LISTAS, UNA PARA TI Y OTRA CON EL RESTO DE FECHAS (esta QUE SEAN DATEOPTION)
            //HACER MYEVENTS OBSERVABLE


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

            var vm = BindingContext as EventViewModel;
            var i = 0;

            foreach (DateTime dT in vm.MyDates)
            {
                i++;
                System.Diagnostics.Debug.WriteLine(i + ") " + dT);
            }

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

        private void Calendar_OnCalendarTapped(object sender, Syncfusion.SfCalendar.XForms.CalendarTappedEventArgs e)
        {
            //var calendar = sender as SfCalendar;
            //var dateOption = new DateOption(calendar.SelectedDate.Value, App.admin);


            //var dateOption = new DateOption(Calendar.SelectedDate.Value, App.admin);
            //var vm = BindingContext as DateOptionsViewModel;
            //vm.AddCommand.Execute(dateOption);

            //Calendar.SelectedDate = new List<DateTime>();


            /*
            inCreationVotedDates.Add(calendar.SelectedDate.Value);
            var votedEventDate = new CalendarInlineEvent();
            votedEventDate.IsAllDay = true;
            CalendarInlineEvents.Add(votedEventDate);
            */

            //inCreationVotedDates.Add(calendar.SelectedDate.Value);
        }
 
        void Handle_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            //var datesList = new List<DateTime>(e.DateAdded);
            //datesList.Sort();
            //var vm = BindingContext as DateOptionsViewModel;


            /*

            if (e.DateAdded != null)
            {
                inCreationVotedDates = new List<DateTime>(e.DateAdded);
                inCreationVotedDates.Sort();
                votedDatesListView.ItemsSource = inCreationVotedDates;
            }
            else
            {
                votedDatesListView.ItemsSource = new string[1] { "<Sin fechas seleccionadas>" };
            }

            //inCreationVotedDates = new ObservableCollection<DateTime>(e.DateAdded);
            //votedDatesListView.ItemsSource = inCreationVotedDates;
            //IList<DateTime> deselectedDates = e.DateRemoved;
            //new VotedDate(voteLimit, new User(App.admin.Id, App.admin.Nickname)),

            */
        }

        private void ProposingIsEnabledSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            //MaxPropositionsPerUserGrid.IsVisible = !MaxPropositionsPerUserGrid.IsVisible;
            //ProposingDeadlineLabel.IsVisible = !ProposingDeadlineLabel.IsVisible;
            //ProposingDeadlineGrid.IsVisible = !ProposingDeadlineGrid.IsVisible;

            ProposingUsersBlock.IsVisible = !ProposingUsersBlock.IsVisible;
        }

        /*
        private void RemoveDate_Clicked(object sender, EventArgs e)
        {
            var imageButton = sender as ImageButton;

            //var date = imageButton.BindingContext as DateTime;
            var date = (DateTime) imageButton.BindingContext;
            System.Diagnostics.Debug.WriteLine("Se elimina (Page): " + date);

            var vm = BindingContext as CalendarViewModel;

            vm.RemoveCommand.Execute(date);

            
            var imageButton = sender as ImageButton;
            //var imageButton = (ImageButton)sender;

            var dateOption = imageButton.BindingContext as DateOption;
            //var dateOption = imageButton?.BindingContext as DateOption;

            var vm = BindingContext as DateOptionsViewModel;

            vm.RemoveCommand.Execute(dateOption);
            //vm?.RemoveCommand.Execute(dateOption);
           
        }
        */

        /*
        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);

            inCreationVotedDates.Remove(new DateTime(mi.CommandParameter));

            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }
        */

    }
}