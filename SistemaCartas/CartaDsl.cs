using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace SistemaCartas
{
    /// <summary>
    /// Classe que salva no banco
    /// </summary>
    sealed class CartaDsl
    {
        private string connectionString = @"Server=WIN-XLJ1Y19EFM\SQLEXPRESS;Database=Mercearia;Uid=sa;Pwd=123";
        public void Salvar(ICarta carta)
        {
            if(carta.LocalSalvar == LocalSalvar.Disco)
            {
                var caminho = $"{carta.GetType().Name}.csv";
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    var colunasDb = new List<string>();
                    var valoresDb = new List<string>();
                    foreach (var propiedade in carta.GetType().GetProperties())
                    {
                        colunasDb.Add(propiedade.Name);
                        var valor = carta.GetType().GetProperty(propiedade.Name).GetValue(carta).ToString();
                        valoresDb.Add(valor);
                    }
                    writer.WriteLine(string.Join(";", colunasDb.ToArray()));
                    writer.WriteLine(string.Join(";", valoresDb.ToArray()));
                }
            }
            else if (carta.LocalSalvar == LocalSalvar.DB)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var colunasDb = new List<string>();
                    var parametrosDb = new List<string>();
                    foreach (var propiedade in carta.GetType().GetProperties())
                    {
                        NaoUsaSalvarAttribute[] pAttNaoUsaSalvar = (NaoUsaSalvarAttribute[])propiedade.GetCustomAttributes(typeof(NaoUsaSalvarAttribute), false);
                        if (pAttNaoUsaSalvar == null || pAttNaoUsaSalvar.Length == 0)
                        {
                            colunasDb.Add(propiedade.Name);
                            parametrosDb.Add($"@{propiedade.Name}");
                        }
                    }

                    var colunas = string.Join(",", colunasDb.ToArray());
                    var parametros = string.Join(",", parametrosDb.ToArray());

                    var queryString = $"insert into {carta.GetType().Name} ({colunas}) values({parametros});";
                    SqlCommand command = new SqlCommand(queryString, connection);

                    foreach(var colunaDb in colunasDb)
                    {
                        command.Parameters.Add($"@{colunaDb}", System.Data.SqlDbType.Int);
                        command.Parameters[$"@{colunaDb}"].Value = carta.GetType().GetProperty(colunaDb).GetValue(carta);
                    }

                    connection.Open();

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void Buscar(ICarta carta)
        {

            if (carta.LocalSalvar == LocalSalvar.Disco)
            {
                Console.WriteLine("Encontrado no local");
            }
            if (carta.LocalSalvar == LocalSalvar.DB)
            {
                Console.WriteLine("Encontado no banco de dados");
            }
        }
        public void Excluir(ICarta carta)
        {

            if (carta.LocalSalvar == LocalSalvar.Disco)
            {
                Console.WriteLine("Excluído do local");
            }
            if (carta.LocalSalvar == LocalSalvar.DB)
            {
                Console.WriteLine("Excluído do banco de dados");
            }
        }
        public void Atualizar(ICarta carta)
        {

            if (carta.LocalSalvar == LocalSalvar.Disco)
            {
                Console.WriteLine("Atualizado no local");
            }
            if (carta.LocalSalvar == LocalSalvar.DB)
            {
                Console.WriteLine("Atualizado no banco de dados");
            }
        }
    }
}
