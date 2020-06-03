using Circa.Models;
using Circa.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Posible error en el UWP por falta de inicialización
//https://help.syncfusion.com/xamarin/calendar/getting-started

namespace Circa
{ 
    public partial class App : Application
    {
        public static AppUser myUser = AdminConfig();
        //public static AppUser myUser = new AppUser(1, "Yo", new List<DateEvent>());
        public static AppUser AdminConfig()
        {
            var myUser = new AppUser(1, "Yo", new List<DateEvent>());
            var anaUser = new AppUser(2, "Ana", new List<DateEvent>());
            var benitoUser = new AppUser(3, "Benito", new List<DateEvent>());

            var myEventDateOptions = new List<DateOption>()
            {
                new DateOption(new DateTime(2020, 10, 12), anaUser),
                new DateOption(new DateTime(2020, 10, 16), myUser)
            };

            myUser.AddEvent(new DateEvent(
                myUser,
                "Mi evento",
                "Descripción 1",
                "Lugar 1",
                1,
                DateTime.UtcNow,
                myEventDateOptions));

            myUser.AddEvent(new DateEvent(
                anaUser,
                "Evento de Ana",
                "Descripción 2",
                "Lugar 2",
                2,
                DateTime.Now,
                new List<DateOption>()));
            myUser.AddEvent(new DateEvent(
                benitoUser,
                "Evento de Benito",
                "Descripción 3",
                "Lugar 3",
                3,
                DateTime.Now,
                new List<DateOption>()));

            return myUser;
        }

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjIxNzU1QDMxMzcyZTM0MmUzMEZpQTRvWlpnei9nTUNZeTNWRHd3T244dlF4NjF6RGl0WjhYVjlXMTVRZHc9");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
