using App1.Classes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();




        }

        private async void Registrar(object sender, System.EventArgs e)
        {


            if (UserName.Text != null && UserEmail.Text != null && UserSenha.Text != null && UserConfirm != null && UserSenha.Text == UserConfirm.Text)
            {

                try
                {
                    /*
                                    string srvrdbname = "Expocity";
                                    string srvrname = "MATOS-MURILO";
                                    string srvrusername = "muras";
                                    string srvrpassword = "12345";
                     */

                    string srvrdbname = "Expocity";
                    string srvrname = "10.0.10.173";
                    string srvrusername = "kiq";
                    string srvrpassword = "235910";

                    string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
                    SqlConnection sqlConnection = new SqlConnection(sqlconn);

                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Usuarios VALUES(@nome , @email, @senha, NULL, NULL, NULL, NULL, NULL, 1)", sqlConnection))
                    {

                        command.Parameters.Add(new SqlParameter("nome", UserName.Text));
                        command.Parameters.Add(new SqlParameter("email", UserEmail.Text));
                        command.Parameters.Add(new SqlParameter("senha", UserSenha.Text));
                        //command.Parameters.Add(new SqlParameter("imgPerfil", "https://www.thesun.co.uk/wp-content/uploads/2021/01/Capture.png"));
                        //command.Parameters.Add(new SqlParameter("imgFundo", "https://image.freepik.com/vetores-gratis/design-plano-de-fundo-primavera_23-2148438914.jpg"));


                        command.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                    await App.Current.MainPage.DisplayAlert("Alerta", "O Cadastro foi um sucesso!", "Ok");
                    await Navigation.PushAsync(new Tabbed());
                    UserName.Text = "";
                    UserEmail.Text = "";
                    UserSenha.Text = "";
                    UserConfirm.Text = "";
                    Error.IsVisible = false;
                    //   await Navigation.PushAsync(new Publish());
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "Ok");
                    throw;
                }
            }
            else
            {
                Error.IsVisible = true;
                Error.Text = "Preencha as campos e verifique se as senhas conferem";
            }
        }
    }
}