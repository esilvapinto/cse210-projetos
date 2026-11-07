using System;
using System.Collections.Generic;
using System.IO;

// Guarda a lista de registros e sabe exibir, salvar e carregar o diário.
public class Diario
{
    public List<Registro> _registros = new List<Registro>();

    private const string Cabecalho = "Data,Pergunta,Resposta,Humor";

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        if (_registros.Count == 0)
        {
            Console.WriteLine("O diário está vazio.\n");
            return;
        }

        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void SalvarEmArquivo(string arquivo)
    {
        using (StreamWriter arquivoSaida = new StreamWriter(arquivo))
        {
            arquivoSaida.WriteLine(Cabecalho);
            foreach (Registro registro in _registros)
            {
                arquivoSaida.WriteLine(registro.ParaCsv());
            }
        }
    }

    // Substitui todos os registros atuais pelos do arquivo.
    public void CarregarDeArquivo(string arquivo)
    {
        string[] linhas = File.ReadAllLines(arquivo);
        _registros.Clear();

        foreach (string linha in linhas)
        {
            if (string.IsNullOrWhiteSpace(linha) || linha == Cabecalho)
            {
                continue;
            }
            _registros.Add(Registro.DeCsv(linha));
        }
    }

    // Extra: verifica se já existe registro na data informada.
    public bool TemRegistroNaData(string data)
    {
        foreach (Registro registro in _registros)
        {
            if (registro._data == data) return true;
        }
        return false;
    }
}
