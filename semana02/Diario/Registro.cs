using System;

// Representa um único registro (entrada) do diário.
public class Registro
{
    public string _data;
    public string _pergunta;
    public string _resposta;
    public string _humor; // Extra: como o usuário se sentiu no dia

    public Registro(string data, string pergunta, string resposta, string humor)
    {
        _data = data;
        _pergunta = pergunta;
        _resposta = resposta;
        _humor = humor;
    }

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data} - Pergunta: {_pergunta}");
        Console.WriteLine(_resposta);
        if (!string.IsNullOrWhiteSpace(_humor))
        {
            Console.WriteLine($"Humor do dia: {_humor}");
        }
        Console.WriteLine();
    }

    // Converte o registro em uma linha CSV, tratando vírgulas e aspas.
    public string ParaCsv()
    {
        return $"{Csv.Escapar(_data)},{Csv.Escapar(_pergunta)},{Csv.Escapar(_resposta)},{Csv.Escapar(_humor)}";
    }

    // Cria um registro a partir de uma linha CSV.
    public static Registro DeCsv(string linha)
    {
        var partes = Csv.DividirLinha(linha);
        string humor = partes.Count > 3 ? partes[3] : "";
        return new Registro(partes[0], partes[1], partes[2], humor);
    }
}
