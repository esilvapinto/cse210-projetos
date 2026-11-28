// EXTRA: conta quantas vezes cada atividade foi feita
// e salva/carrega essa contagem de um arquivo de texto.
public class Registro
{
    private string _arquivo;
    private Dictionary<string, int> _contagens = new Dictionary<string, int>();

    public Registro(string arquivo)
    {
        _arquivo = arquivo;
        Carregar();
    }

    public void RegistrarConclusao(string nomeAtividade)
    {
        if (_contagens.ContainsKey(nomeAtividade))
        {
            _contagens[nomeAtividade]++;
        }
        else
        {
            _contagens[nomeAtividade] = 1;
        }
        Salvar();
    }

    public void Exibir()
    {
        Console.Clear();
        Console.WriteLine("Seu histórico de atividades:");
        Console.WriteLine();

        if (_contagens.Count == 0)
        {
            Console.WriteLine("Nenhuma atividade concluída ainda.");
        }

        foreach (KeyValuePair<string, int> par in _contagens)
        {
            Console.WriteLine($"{par.Key}: {par.Value} vez(es)");
        }

        Console.WriteLine();
        Console.WriteLine("Pressione Enter para voltar ao menu.");
        Console.ReadLine();
    }

    private void Salvar()
    {
        using (StreamWriter escritor = new StreamWriter(_arquivo))
        {
            foreach (KeyValuePair<string, int> par in _contagens)
            {
                escritor.WriteLine($"{par.Key}|{par.Value}");
            }
        }
    }

    private void Carregar()
    {
        if (!File.Exists(_arquivo))
        {
            return;
        }

        foreach (string linha in File.ReadAllLines(_arquivo))
        {
            string[] partes = linha.Split("|");
            if (partes.Length == 2 && int.TryParse(partes[1], out int vezes))
            {
                _contagens[partes[0]] = vezes;
            }
        }
    }
}
