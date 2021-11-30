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

    public partial class NewFeed : ContentPage
    {
       

        public class MyTableList
        {
            public int Id_Post { get; set; }
            public string Data_Post { get; set; }
            public string Descricao_Post { get; set; }
           // public string Latitude { get; set; }
          //  public string Longitude { get; set; }
            public string Imagem_Post { get; set; }
            public int Id_Usuario { get; set; }
           
            public int Id { get; set; }
            public string nome { get; set; }

            public string imgPerfil { get; set; }
            //public string imgFundo { get; set; }

        }


       

        //criar uma nova Objeto e instanciar ela
        public NewFeed()
        {
            InitializeComponent();
            SetValue(NavigationPage.HasBackButtonProperty, false);
            SetValue(NavigationPage.HasNavigationBarProperty, false);

            //open connection
            /*
             string srvrname = "MATOS-MURILO";
             string srvrdbname = "Expocity";
             string srvrusername = "Muras";
             string srvrpassword = "12345";
            string srvrport = "18832";

             string sqlconn = $"Server ={srvrname}; Port ={srvrport}; Database ={srvrdbname}; Uid ={srvrusername}; Pwd ={srvrpassword};";
            */


            // Server = myServerAddress; Port = 1234; Database = myDataBase; Uid = myUsername; Pwd = myPassword;




        }


        private async void Btn_Consulta(object sender, EventArgs e)
             {


                 try
                 {


                
                    string srvrdbname = "Expocity";
                    string srvrname = "MATOS-MURILO";
                    string srvrusername = "muras";
                    string srvrpassword = "12345";


                /*  string srvrdbname = "Expocity";
               string srvrname = "10.0.10.173";
               string srvrusername = "kiq";
               string srvrpassword = "235910"; */

                string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
                SqlConnection sqlConnection = new SqlConnection(sqlconn);
            


                sqlConnection.Open();
                await App.Current.MainPage.DisplayAlert("Alert", "Connection Established", "Ok");
                sqlConnection.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }


        private async void getbutton_Clicked(object sender, EventArgs e)
        {
            try
            {

                /* string srvrdbname = "Expocity";
              string srvrname = "10.0.10.173";
              string srvrusername = "kiq";
              string srvrpassword = "235910";*/

                string srvrdbname = "Expocity";
                string srvrname = "MATOS-MURILO";
                string srvrusername = "muras";
                string srvrpassword = "12345";

                string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
              SqlConnection sqlConnection = new SqlConnection(sqlconn);

              List<MyTableList> myTableLists = new List<MyTableList>();
              sqlConnection.Open();
             // string queryString = "Select * from Usuarios";
             string queryString = "SELECT Postagem.Id_Post, Postagem.Data_Post, Postagem.Descricao_Post, Postagem.Imagem_Post, Usuarios.Id, Usuarios.nome, Usuarios.imgPerfil FROM Usuarios, Postagem WHERE Usuarios.Id = Postagem.Id_Usuario";


             SqlCommand command = new SqlCommand(queryString, sqlConnection);
             SqlDataReader reader = command.ExecuteReader();
              while (reader.Read())
              {
                  myTableLists.Add(new MyTableList
                  {
                      Id = Convert.ToInt32(reader["Id"]),
                      nome = reader["nome"].ToString(),
                      imgPerfil = reader["imgPerfil"].ToString(),
                     // imgFundo = reader["imgFundo"].ToString(),
                      Id_Post = Convert.ToInt32(reader["Id_Post"]),
                      Data_Post = reader["Data_Post"].ToString(),
                      Descricao_Post = reader["Descricao_Post"].ToString(),
                      /*Latitude = reader["Latitude"].ToString(),
                      Longitude = reader["Longitude"].ToString(),*/
                Imagem_Post = reader["Imagem_Post"].ToString(),
                       // Id_Usuario = Convert.ToInt32(reader["Id_Usuario"]),
                    });
                }
                reader.Close();
                sqlConnection.Close();

                MyListView.ItemsSource = myTableLists;
                
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                throw;
            }
        }



        private async void Btn_ComentarioAbrir(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Comentarios());
        }

    }

}