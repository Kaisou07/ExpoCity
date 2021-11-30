using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {



        public class Dados
        {
            public int Id_Post { get; set; }
            public string Data_Post { get; set; }
            public string Descricao_Post { get; set; }
            public string Imagem_Post { get; set; }
            public string Nome_Lugar { get; set; }
            public int Id_Usuario { get; set; }
            public int Id { get; set; }
            public string nome { get; set; }
            public string imgPerfil { get; set; }
            public string email { get; set; }
            public string imgFundo { get; set; }
            public string senha { get; set; }
            public string descricao { get; set; }
            public string cidade { get; set; }
            public string estado { get; set; }

        }
        public string idp { get; set; }

        public Perfil()
        {
            InitializeComponent();


        }




        private async void Validar(object sender, EventArgs e)
        {
            if (Nome_Validar_Perfil.Text != null && Senha_Validar_Perfil.Text != null)
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
                    string queryString = "SELECT * FROM Usuarios WHERE email = '" + Nome_Validar_Perfil.Text + "' AND senha = '" + Senha_Validar_Perfil.Text + "' AND ativo = 1";
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
                                nome = reader["nome"].ToString(),
                                email = reader["email"].ToString(),
                                senha = reader["senha"].ToString(),
                                imgPerfil = reader["imgPerfil"].ToString(),
                                imgFundo = reader["imgFundo"].ToString(),
                                descricao = reader["descricao"].ToString(),
                                cidade = reader["cidade"].ToString(),
                                estado = reader["estado"].ToString(),
                            });
                            //     Id_Oculto_Perfil.Text = reader["Id"].ToString();
                            idp = reader["Id"].ToString();
                            Nome_Atualizar_Perfil.Text = reader["nome"].ToString();
                            Email_Atualizar_Perfil.Text = reader["email"].ToString();
                            ImgPerfil_Atualizar_Perfil.Text = reader["imgPerfil"].ToString();
                            ImgFundo_Atualizar_Perfil.Text = reader["imgFundo"].ToString();
                            Descricao_Atualizar_Perfil.Text = reader["descricao"].ToString();
                            Cidade_Atualizar_Perfil.Text = reader["cidade"].ToString();
                            Estado_Atualizar_Perfil.Text = reader["estado"].ToString();
                            Senha_Atualizar_Perfil.Text = "";
                        }

                        AutorizarPerfil.IsVisible = false;
                        UpdateListX.IsVisible = true;

                        UpdatePerfil();
                        FeedPerfilX.IsVisible = true;
                        FeedPerfilX.ItemsSource = dados;
                        reader.Close();
                        sqlConnection.Close();
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
                incorreto.Text = "Preencha as campos";
            }
        }

        private void Editar_Perfil(object sender, EventArgs e)
        {

            AutorizarPerfil.IsVisible = false;
            FeedPerfilX.IsVisible = false;
            AtualizarPerfil.IsVisible = true;
            UpdateListX.IsVisible = false;
            ExcluirPerfil.IsVisible = false;

        }
        private async void Atualizar_Perfil(object sender, EventArgs e)
        {
            if (Nome_Atualizar_Perfil.Text != null && Email_Atualizar_Perfil.Text != null && ImgPerfil_Atualizar_Perfil.Text != null && ImgFundo_Atualizar_Perfil.Text != null && Descricao_Atualizar_Perfil.Text != null && Cidade_Atualizar_Perfil.Text != null && Estado_Atualizar_Perfil.Text != null && Senha_Atualizar_Perfil.Text != null && Confirm_Atualizar_Perfil.Text != null)
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
                    string queryString = "UPDATE Usuarios SET nome = '" + Nome_Atualizar_Perfil.Text + "', email = '" + Email_Atualizar_Perfil.Text + "', senha = '" + Senha_Atualizar_Perfil.Text + "', imgPerfil = '" + ImgPerfil_Atualizar_Perfil.Text + "', imgFundo = '" + ImgFundo_Atualizar_Perfil.Text + "', descricao = '" + Descricao_Atualizar_Perfil.Text + "', cidade = '" + Cidade_Atualizar_Perfil.Text + "', estado  = '" + Estado_Atualizar_Perfil.Text + "' WHERE Id = '" + idp + "' AND ativo = 1";
                    SqlCommand command = new SqlCommand(queryString, sqlConnection);
                    SqlDataAdapter dp = new SqlDataAdapter(queryString, sqlConnection);
                    DataTable dt = new DataTable();
                    if (Senha_Atualizar_Perfil.Text == Confirm_Atualizar_Perfil.Text)
                    {
                        dp.Fill(dt);
                        Nome_Atualizar_Perfil.Text = "";
                        Email_Atualizar_Perfil.Text = "";
                        ImgPerfil_Atualizar_Perfil.Text = "";
                        ImgFundo_Atualizar_Perfil.Text = "";
                        Descricao_Atualizar_Perfil.Text = "";
                        Cidade_Atualizar_Perfil.Text = "";
                        Estado_Atualizar_Perfil.Text = "";
                        Senha_Atualizar_Perfil.Text = "";
                        Confirm_Atualizar_Perfil.Text = "";
                        await Navigation.PushAsync(new ButtonNavigation());
                        sqlConnection.Close();

                    }
                    else
                    {

                        Incorreto_Atualizar.IsVisible = true;
                        Incorreto_Atualizar.Text = "Senhas não conferem";

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
                Incorreto_Atualizar.Text = "Preencha as campos";
            }
        }

        private async void Btn_ComentarioAbrir(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Comentarios());
        }
        public void UpdatePerfil()
        {

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

                //string queryString = "SELECT * FROM Usuarios, Postagem WHERE Postagem.Id_Usuario & Id = 1";
                //string queryString = "SELECT * FROM Usuarios, Postagem WHERE Postagem.Id_Usuario & Id = '" + Id_Oculto_Perfil.Text + "'";
                string queryString = "SELECT * FROM Postagem WHERE Id_Usuario = '" + idp + "'";


                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dados.Add(new Dados
                    {

                        Id_Post = Convert.ToInt32(reader["Id_Post"]),
                        Data_Post = reader["Data_Post"].ToString(),
                        Descricao_Post = reader["Descricao_Post"].ToString(),
                        Nome_Lugar = reader["Nome_Lugar"].ToString(),
                        Imagem_Post = reader["Imagem_Post"].ToString(),
                        // Id_Usuario = Convert.ToInt32(reader["Id_Usuario"]),
                    });
                }
                reader.Close();
                sqlConnection.Close();

                UpdateListX.ItemsSource = dados;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }


        }

        private async void Fechar(object sender, EventArgs e)
        {
            Nome_Validar_Perfil.Text = "";
            Senha_Validar_Perfil.Text = "";

            await Navigation.PushAsync(new ButtonNavigation());

        }

        private void FeedPerfilX_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void Atualizar_Fechar(object sender, EventArgs e)
        {
            Nome_Atualizar_Perfil.Text = "";
            Senha_Atualizar_Perfil.Text = "";
            await Navigation.PushAsync(new ButtonNavigation());
        }

        private void Excluir_Perfil(object sender, EventArgs e)
        {
            AutorizarPerfil.IsVisible = false;
            FeedPerfilX.IsVisible = false;
            AtualizarPerfil.IsVisible = false;
            UpdateListX.IsVisible = false;
            ExcluirPerfil.IsVisible = true;

        }

        private async void Excluir_Usuario(object sender, EventArgs e)
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
                string queryString = "UPDATE Usuarios SET ativo = 0, WHERE Id = '" + idp + "'";
                await App.Current.MainPage.DisplayAlert("Alerta", "Excluido com sucesso", "Okay");
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Close();
                await Navigation.PushAsync(new Tabbed());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "Verifique");
                throw;
            }
        }
    }

}