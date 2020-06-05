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
    public partial class ProposingDateEventPage : TabbedPage
    {
        private MainPage listener;
        public MainPage Listener { get => listener; set => listener = value; }

        //private static List<DateTime> inCreationVotedDates = new List<DateTime>();
        //private DateEvent calEvent = new DateEvent(App.admin);
        //private static List<VotedDate> inCreationVotedDates = new List<VotedDate>();
        //private CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();

        public ProposingDateEventPage(MainPage listener) //TODO Listenber como atributo!!!!!!!
        {
            InitializeComponent();

            Listener = listener;
            
            FieldPicker.ItemsSource = GenericEvent.EVENT_FIELDS.Values.ToList<String>();
            MaxPropositionsPerUserPicker.ItemsSource = GenericEvent.maxPropositionsPerUserArray;

            this.BindingContext = new ProposingDateEventVM();

            //inCreationVotedDates = new ObservableCollection<DateTime>(inCreationVotedDates.Distinct());
            //votedDatesListView.ItemsSource = inCreationVotedDates;
            //CalendarEventCollection CalendarInlineEvents = CalendarInlineEvents.Distinct().To;
            //votedDatesListView.ItemsSource = CalendarInlineEvents;
        }

        public ProposingDateEventPage(DateEvent dateEvent, MainPage listener)
        {
            InitializeComponent();

            Listener = listener;

            FieldPicker.ItemsSource = GenericEvent.EVENT_FIELDS.Values.ToList<String>();
            MaxPropositionsPerUserPicker.ItemsSource = GenericEvent.maxPropositionsPerUserArray;

            this.BindingContext = new ProposingDateEventVM(dateEvent);

            //LIDIAR CON LAS FECHAS
            //HACER DOS LISTAS, UNA PARA TI Y OTRA CON EL RESTO DE FECHAS (esta QUE SEAN DATEOPTION)
            //HACER MYEVENTS OBSERVABLE
        }

        private async void ConfirmNewEvent_Clicked(object sender, EventArgs e)
        {
            var vm = BindingContext as ProposingDateEventVM;

            //Mandamos el evento al MainPage para que lo guarde en la BD y lo muestre
            if (Listener != null)
            {
                Listener.OnNewUserEvent(vm.ConfirmProposingDateEvent());
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