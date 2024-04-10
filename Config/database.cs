using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Calculadora_C_.DbScripAsync
{
    public partial class dbScriptSybc
    {
        public string dbName = "calculadora_db.sqlite";

        public dbScriptSybc(string option)
        {
            switch (option)
            {
                case "criar":
                    createDB();
                    break;
                default:
                    // Caso a opção passada não seja reconhecida
                    throw new ArgumentException("Opção inválida para o construtor.");
            }
        }

        public void createDB()
        {
            if (!System.IO.File.Exists(dbName))
            {
                // Se o banco de dados não existe, criamos uma nova conexão
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbName};Version=3;"))
                {
                    conn.Open();

                    // Comando SQL para criar a tabela Historico
                    string createTableSQL = "CREATE TABLE Historico (ID INTEGER PRIMARY KEY AUTOINCREMENT, Calculo TEXT, Resultado DOUBLE)";

                    using (SQLiteCommand cmd = new SQLiteCommand(createTableSQL, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
        }

        public void inserirHistorico(string calculo, double resultado)
        {
            // Inserir um registro na tabela Historico
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbName};Version=3;"))
            {
                conn.Open();

                // Comando SQL para inserir valores na tabela Historico
                string insertSQL = "INSERT INTO Historico (Calculo, Resultado) VALUES (@Calculo, @Resultado)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertSQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Calculo", calculo);
                    cmd.Parameters.AddWithValue("@Resultado", resultado);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public List<(string, double)> getHistorico()
        {
            List<(string, double)> historico = new List<(string, double)>();

            // Consultar registros na tabela Historico
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbName};Version=3;"))
            {
                conn.Open();

                // Comando SQL para selecionar todos os registros da tabela Historico
                string selectSQL = "SELECT Calculo, Resultado FROM Historico";

                using (SQLiteCommand cmd = new SQLiteCommand(selectSQL, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string calculo = reader["Calculo"].ToString();
                            double resultado = Convert.ToDouble(reader["Resultado"]);

                            historico.Add((calculo, resultado));
                        }
                    }
                }

                conn.Close();
            }

            return historico;
        }

        public void limparHistorico()
        {
            // Executar comando SQL para limpar a tabela Historico
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbName};Version=3;"))
            {
                conn.Open();

                // Comando SQL para limpar a tabela Historico
                string clearTableSQL = "DELETE FROM Historico";

                using (SQLiteCommand cmd = new SQLiteCommand(clearTableSQL, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
        
    }
}
