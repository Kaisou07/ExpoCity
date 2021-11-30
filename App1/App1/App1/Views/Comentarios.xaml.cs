
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Comentarios : ContentPage
    {
        public Comentarios()
        {

            InitializeComponent();
            Title = "Comentarios";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#FFB427");
        }
    }
}