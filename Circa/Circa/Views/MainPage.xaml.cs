using Circa.Models;
using Circa.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

public interface IOnNewUserEventListener
{
    void OnNewUserEvent(DateEvent dateEvent);
}

namespace Circa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage //implements OnNewUserEventListener
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void NewEventCreation_Clicked(object sender, EventArgs e)
        {
            var newEventPage = new NewEventPage();

            newEventPage.Listener = this;

            await Navigation.PushModalAsync(new NavigationPage(newEventPage)).ConfigureAwait(false);

        }

        async void myEventList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var eventPage = new Page(); //Padre de todas las page
            
            var vm = BindingContext as MainViewModel;

            if(vm.SelectedDateEvent.VotingDeadline < DateTime.UtcNow)
            {
                eventPage = new VotingEventPage(vm.SelectedDateEvent);
                //eventPage.Listener = this;
                await Navigation.PushModalAsync(new NavigationPage(eventPage)).ConfigureAwait(false);

            }
            else
            {
                eventPage = new NewEventPage(vm.SelectedDateEvent);
                //eventPage.Listener = this;
                await Navigation.PushModalAsync(new NavigationPage(eventPage)).ConfigureAwait(false);
            }

            //eventPage.Listener = this;

            //await Navigation.PushModalAsync(new NavigationPage(newEventPage)).ConfigureAwait(false);
        }


        //se desencadena cada vez que se pulsa un elemento (SOLO LISTVIEW)
        async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (myEventList.SelectedItem != null)
            {
                DateEvent tappedItem = e.Item as DateEvent;

                var newEventPage = new NewEventPage(tappedItem);

                newEventPage.Listener = this;

                await Navigation.PushModalAsync(new NavigationPage(newEventPage)).ConfigureAwait(false);
            }
        }

        public void OnNewUserEvent(DateEvent dateEvent)
        {
            var vm = BindingContext as MainViewModel;
            App.myUser.AddEvent(dateEvent);
            vm.MyEvents = new ObservableCollection<DateEvent>(App.myUser.Events);
        }
        
        
        //solo se desencadena cuando se selecciona un nuevo elemento en ListView,
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Monkey selectedItem = e.SelectedItem as Monkey;
        }




        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*
            if (listView.SelectedItem != null)
            {
                var detailPage = new DetailPage();
                detailPage.BindingContext = e.SelectedItem as Contact;
                listView.SelectedItem = null;
                await Navigation.PushModalAsync(detailPage);
            }
            */
        }

    }

}