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
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using System.Data;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Publish : ContentPage
    {

        public class Dados
        {

            public double Long { get; set; }
            public double Lat { get; set; }
            public int Id_Post { get; set; }
            public string Data_Post { get; set; }
            public string Descricao_Post { get; set; }

            public string Imagem_Post { get; set; }

            public int Id { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public string senha { get; set; }
            public double Latitude_Longitude { get; set; }
            public Position Position { get; set; }
            public string Descricao { get; set; }
            public string Address { get; set; }
            public string imgPerfil { get; set; }

            //public string imgFundo { get; set; }

        }



        public Publish()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasBackButtonProperty, false);
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            Task.Delay(1000);
            UpdateMap();
            // Id_Usuario.Text = ButtonNavigation.id;
        }

        public void UpdateMap()
        {
            /*
                        PlaceView.Pins.Add{

                        }
            */
            try
            {


                string srvrdbname = "Expocity";
                string srvrname = "10.0.10.173";
                string srvrusername = "kiq";
                string srvrpassword = "235910";

                string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
                SqlConnection sqlConnection = new SqlConnection(sqlconn);
                List<Dados> dados = new List<Dados>();
                sqlConnection.Open();

                string queryString = "SELECT Postagem.Id_Post, Postagem.Descricao_Post, Postagem.Lat, Postagem.Long, Postagem.Nome_Lugar FROM Postagem";


                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dados.Add(new Dados
                    {

                        Descricao = reader["Descricao_Post"].ToString(),
                        Address = reader["Nome_Lugar"].ToString(),
                        Position = new Position((double)reader["Lat"], (double)reader["Long"]),
                    });
                }



                reader.Close();
                sqlConnection.Close();
                PlaceView.ItemsSource = dados;

                PlaceView.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-23.6821604, -46.8754859), Distance.FromKilometers(100)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }
        public string Id_Usuarios { get; set; }


        public void Publish_Load(object sender, EventArgs e)
        {
          
        }
        async void Create(object sender, EventArgs e)
        {

            incorreto.IsVisible = false;
            Error.IsVisible = false;
            stkCreate.IsVisible = false;
            BtnCreate.IsVisible = false;
            stkValidar.IsVisible = true;

            try
            {
                var result = await Geolocation.GetLocationAsync(new
                GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromMinutes(1)));
                Latitude.Text = $"{Convert.ToDouble(result.Latitude)}";
                Longitude.Text = $"{Convert.ToDouble(result.Longitude)}";
                //  if (!this.Id_Usuarios.Equals(""))
                //   {
                // Id_Usuario.Text = Id_Usuarios;

                //   await App.Current.MainPage.DisplayAlert("Alerta", Id_Usuarios, "Ok");
                //    }
               
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "Ok");
                throw;
            }

        }

        private async void Validar(object sender, EventArgs e)
        {
            if (Nome_Validar.Text != null && Senha_Validar.Text != null)
            {
                try
                {
                    string srvrdbname = "Expocity";
                    string srvrname = "10.0.10.173";
                    string srvrusername = "kiq";
                    string srvrpassword = "235910";

                    string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
                    SqlConnection sqlConnection = new SqlConnection(sqlconn);

                    sqlConnection.Open();
                    string queryString = "SELECT * FROM Usuarios WHERE email = '" + Nome_Validar.Text + "' AND senha = '" + Senha_Validar.Text + "'";
                    List<Dados> dados = new List<Dados>();
                    SqlDataAdapter dp = new SqlDataAdapter(queryString, sqlConnection);
                    DataTable dt = new DataTable();
                    dp.Fill(dt);
                    SqlCommand command = new SqlCommand(queryString, sqlConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (dt.Rows.Count == 1)
                    {
                        while (reader.Read())
                        {
                            dados.Add(new Dados
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                email = reader["email"].ToString(),
                                nome = reader["nome"].ToString(),
                                senha = reader["senha"].ToString(),

                            });
                          //  Id_Usuario.Text = reader["id"].ToString();
                        }

                        reader.Close();
                        sqlConnection.Close();

                        stkCreate.IsVisible = true;
                        BtnCreate.IsVisible = false;
                        stkValidar.IsVisible = false;
                        Nome_Validar.Text = "";
                        Senha_Validar.Text = "";
                    }
                    else
                    {
                        incorreto.IsVisible = true;
                        incorreto.Text = "Usuário ou Senha incorretos";
                     

                    }
                }

                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "Verifique");
                    throw;
                }
            }
            else
            {
                incorreto.IsVisible = true;
                incorreto.Text = "Valide o Login, preencha os campos";
                Nome_Validar.Focus();
            }
            


        }
        private async void Salvar(object sender, EventArgs e)
        {
            if (Nome_LugarMap.Text != null && Descricao_PostMap.Text != null && Imagem_PostMap.Text != null)
            {
                try
                {
                    string srvrdbname = "Expocity";
                    string srvrname = "10.0.10.173";
                    string srvrusername = "kiq";
                    string srvrpassword = "235910";

                    string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
                    SqlConnection sqlConnection = new SqlConnection(sqlconn);

                    sqlConnection.Open();


                    using (SqlCommand command = new SqlCommand("INSERT INTO Postagem VALUES(@Data_Post, @Descricao_Post, @Lat, @Long, @Imagem_Post, @Nome_Lugar, @Id_Usuario)", sqlConnection))
                    {
                        command.Parameters.Add(new SqlParameter("Data_Post", DateTime.UtcNow));
                        command.Parameters.Add(new SqlParameter("Nome_Lugar", Nome_LugarMap.Text));
                        command.Parameters.Add(new SqlParameter("Descricao_Post", Descricao_PostMap.Text));
                        command.Parameters.Add(new SqlParameter("Lat", Convert.ToDouble(Latitude.Text)));
                        command.Parameters.Add(new SqlParameter("Long", Convert.ToDouble(Longitude.Text)));
                        command.Parameters.Add(new SqlParameter("Imagem_Post", Imagem_PostMap.Text));
                        command.Parameters.Add(new SqlParameter("Id_Usuario", Convert.ToInt32(Id_Usuario.Text)));
                        command.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                    await App.Current.MainPage.DisplayAlert("Alerta", "Salvo com sucesso!", "Ok");

                    Imagem_PostMap.Text = "";
                    Nome_LugarMap.Text = "";
                    Descricao_PostMap.Text = "";
                    Senha_Validar.Text = "";
                    stkCreate.IsVisible = false;
                    BtnCreate.IsVisible = true;
                    stkValidar.IsVisible = false;
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
                Error.Text = "Preencha as informações";
            }



        }
        private void Fechar(object sender, EventArgs e)
        {
            Task.Delay(1000);
            UpdateMap();
            stkCreate.IsVisible = false;
            stkValidar.IsVisible = false;
            BtnCreate.IsVisible = true;
            Nome_Validar.Text = "";
            Senha_Validar.Text = "";
            Nome_LugarMap.Text = "";
            Descricao_PostMap.Text = "";
            Senha_Validar.Text = "";
        }
    }

}