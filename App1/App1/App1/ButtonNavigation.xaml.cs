
using App1.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonNavigation : TabbedPage
    {
        public ButtonNavigation()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasBackButtonProperty, false);
            SetValue(NavigationPage.HasNavigationBarProperty, false);
        

        }
   /*     public string Id_UsuariosB { get; set; }
        public void Publish_Load(object sender, EventArgs e)
        {
            Publish destino2 = new Publish();
            destino2.Id_Usuarios = Id_UsuariosB;

        }*/
    }
}