using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;

namespace App1.Droid
{
    /*
     class Conexao
    {
        public string conec = "SERVER=bp2cngothbkecsmssaeg-mysql.services.clever-cloud.com; DATABASE=bp2cngothbkecsmssaeg; UID=unk4gc6jr3mlzjvk; PWD=tmdD2MfreUEJjbjwS1jt; PORT=3306";
        public MySqlConnection con = null;

        public void AbrirCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void FecharCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

   
  public static class Constants
    {
       #region MYSQL CONNECTION STRING

        public static string connectionString = "server=bp2cngothbkecsmssaeg-mysql.services.clever-cloud.com;port=3306;user=unk4gc6jr3mlzjvk;password=tmdD2MfreUEJjbjwS1jt;database=bp2cngothbkecsmssaeg;";

        #endregion

        #region MYSQL SELECT ALL QUERY

        public static string selectAllQuery = "select * from usuario order by nomeCompleto desc";

        #endregion

        #region MYSQL INSERT COMMAND

        public static string insertNote = "insert into usuario(nomeCompleto,telefone,email,senha) values(@nomeCompleto,@telefone,@email,@senha)";

        #endregion
    }

    */
}