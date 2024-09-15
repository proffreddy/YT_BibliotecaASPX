using MySql.Data.MySqlClient;
using System;
using System.Data;

public class Banco
{
    MySqlConnection conexao = null;

    public void Conectar()
    {
        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=ALTERE_AQUI";
        conexao = new MySqlConnection(linhaConexao);
        try
        {
            conexao.Open();
        }
        catch 
        {
            throw new Exception("Erro ao conectar ao Servidor");
        }
    }

    public void Desconectar()
    { 
        if (conexao != null)
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }

    public MySqlDataReader Consultar(string comando)
    {
        try
        { 
            MySqlCommand cSQL = new MySqlCommand(comando, conexao);
            return cSQL.ExecuteReader();
        }
        catch
        {
            throw new Exception("Erro na consulta");
        }
    }

    public void Executar(string comando)
    { 
        try
        { 
            MySqlCommand cSQL = new MySqlCommand(comando, conexao);
            cSQL.ExecuteNonQuery();
        }
        catch
        {
            throw new Exception("Erro na execucao");
        }
    }
}

