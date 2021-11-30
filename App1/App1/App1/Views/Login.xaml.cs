
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Provider.Telephony.Mms;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        public class Dados
        {
            public int Id { get; set; }

            public string email { get; set; }
            public string nome { get; set; }
            public string imgPerfil { get; set; }
            public string imgFundo { get; set; }
            public string senha { get; set; }

        }

        public Login()
        {
            InitializeComponent();
          
            //  Login = new NavigationPage(new Feed());

        }

        private void btnRegisterPage_Clicked(object sender, EventArgs e)
        {
            //    if(btnRegisterPage.BackgroundColor == Color.LightGray)
            //  {   
            //   btnRegisterPage = BackgroundColor == Color.Black;


            // }
        }





        private async void Login_Feed(object sender, EventArgs e)
        {



            /*  String email = request.getParameter("inputEMail");
              String senha = request.getParameter("inputSenha");

              HttpSession session = request.getSession();

              String sqlLogin = "SELECT * FROM cliente WHERE email_cliente = '" + email + "' AND senha_cliente = '" + senha + "'"; */
            /*     if (rsLogin.next())
                 {
                     //criando uma sessao chamado logado
                     session.setAttribute("erro", 0);
                     session.setAttribute("logado", "TRUE");
                     session.setAttribute("nome", rsLogin.getString("nome_cliente"));
                     session.setAttribute("email", rsLogin.getString("email_cliente"));
                     session.setAttribute("senha", rsLogin.getString("senha_cliente"));
                     session.setAttribute("id", rsLogin.getInt("id_cliente"));
                     response.sendRedirect("conta.jsp");
                 }
                 else
                 {
                     //criando uma sessao chamado erro
                     session.setAttribute("erro", 1);
                     session.setAttribute("logado", "FALSE");
                     response.sendRedirect("login.jsp");*/




            if (entLoginNome.Text != null && entLoginPassword.Text != null)
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
                    string queryString = "SELECT * FROM Usuarios WHERE email = '" + entLoginNome.Text + "' AND senha = '" + entLoginPassword.Text + "' AND ativo = 1";
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
                        }
                        await Navigation.PushAsync(new ButtonNavigation());
                        entLoginNome.Text = "";
                        entLoginPassword.Text = "";
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
            else {
                incorreto.IsVisible = true;
                incorreto.Text = "Preencha as campos";
            }
        }
    }
}