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
    public partial class VotingDateEventPage : TabbedPage
    {
        private MainPage listener;
        public MainPage Listener { get => listener; set => listener = value; }

        public VotingDateEventPage(DateEvent dateEvent, MainPage listener)
        {
            InitializeComponent();

            Listener = listener;
            FieldPicker.ItemsSource = GenericEvent.EVENT_FIELDS.Values.ToList<String>();
            MaxPropositionsPerUserPicker.ItemsSource = GenericEvent.maxPropositionsPerUserArray;

            this.BindingContext = new VotingDateEventVM(dateEvent);
        }

        private async void ConfirmNewEvent_Clicked(object sender, EventArgs e)
        {
            /*
            foreach (DateTime dT in vm.MyDates)
            {
                i++;
                System.Diagnostics.Debug.WriteLine(i + ") " + dT);
            }
            */


            var vm = BindingContext as VotingDateEventVM;

            //Mandamos el evento al MainPage para que lo guarde en la BD y lo muestre
            if (Listener != null)
            {
                Listener.OnExistingUserEvent(vm.ConfirmVotingDateEvent());
            }

            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private async void CancelNewEvent_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync().ConfigureAwait(false);
        }

        private void ProposingUsersSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ProposingUsersBlock.IsVisible = !ProposingUsersBlock.IsVisible;
        }
        
    }
}