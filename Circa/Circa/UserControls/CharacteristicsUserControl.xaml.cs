using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Circa.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacteristicsUserControl : ContentPage
    {
        public CharacteristicsUserControl()
        {
            InitializeComponent();
            this.Title = "Características";
        }

        public string Lol
        {
            get
            {
                return TitleEntry.Text;
            }
            set
            {
                TitleEntry.Text = value;
            }
        }


    }
}