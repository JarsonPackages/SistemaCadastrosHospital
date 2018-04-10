using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesBanco
{
    class Program
    {
        static void Main(string[] args)
        {
           SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + @"C:\Users\CDS\Desktop\HospitalSistemaCadastro-master\SistemaHospital\App_Data\BancoHospital.mdf;"+"Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            con.Open();
            Console.WriteLine("Conexao Aberta - OK");
            con.Close();
            Console.WriteLine("Conexao fechada");
            Console.ReadKey();

        }
    }
}
