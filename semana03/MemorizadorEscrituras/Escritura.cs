// Representa a escritura completa: a referência e a lista de palavras.
public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras = new List<Palavra>();
    private Random _aleatorio = new Random();

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;

        string[] partes = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string parte in partes)
        {
            _palavras.Add(new Palavra(parte));
        }
    }

    // Oculta palavras aleatórias, escolhendo SOMENTE entre as que ainda estão visíveis
    // (desafio adicional do enunciado).
    public void OcultarPalavrasAleatorias(int quantidade)
    {
        List<Palavra> visiveis = _palavras.Where(p => !p.EstaOculta()).ToList();

        for (int i = 0; i < quantidade && visiveis.Count > 0; i++)
        {
            int indice = _aleatorio.Next(visiveis.Count);
            visiveis[indice].Ocultar();
            visiveis.RemoveAt(indice);
        }
    }

    // Mostra de novo uma palavra oculta escolhida ao acaso (usado no comando "dica").
    public bool RevelarUmaPalavra()
    {
        List<Palavra> ocultas = _palavras.Where(p => p.EstaOculta()).ToList();
        if (ocultas.Count == 0)
        {
            return false;
        }

        ocultas[_aleatorio.Next(ocultas.Count)].Mostrar();
        return true;
    }

    public void MostrarTodas()
    {
        foreach (Palavra palavra in _palavras)
        {
            palavra.Mostrar();
        }
    }

    public string ObterTextoExibicao()
    {
        string texto = string.Join(" ", _palavras.Select(p => p.ObterTextoExibicao()));
        return $"{_referencia.ObterTextoExibicao()} {texto}";
    }

    public bool EstaCompletamenteOculta()
    {
        return _palavras.All(p => p.EstaOculta());
    }

    // Compara o que o usuário digitou de memória com a escritura.
    // Mostra as palavras certas em verde e as que faltaram ou erraram em vermelho, entre [ ].
    // Retorna o percentual de acerto (0 a 100).
    public int MostrarResultadoRecitacao(string tentativa)
    {
        string[] digitadas = tentativa.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int posicao = 0;
        int acertos = 0;

        Console.Write(_referencia.ObterTextoExibicao() + " ");

        foreach (Palavra palavra in _palavras)
        {
            // Procura a palavra nas próximas 3 palavras digitadas,
            // assim uma palavra esquecida não faz todas as seguintes contarem como erro.
            int encontrada = -1;
            for (int j = posicao; j < digitadas.Length && j < posicao + 3; j++)
            {
                if (palavra.Corresponde(digitadas[j]))
                {
                    encontrada = j;
                    break;
                }
            }

            if (encontrada >= 0)
            {
                acertos++;
                posicao = encontrada + 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(palavra.ObterTextoOriginal() + " ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[" + palavra.ObterTextoOriginal() + "] ");
            }
        }

        Console.ResetColor();
        Console.WriteLine();
        return acertos * 100 / _palavras.Count;
    }

    // Percentual de palavras já ocultadas (0 a 100).
    public int ObterProgresso()
    {
        int ocultas = _palavras.Count(p => p.EstaOculta());
        return ocultas * 100 / _palavras.Count;
    }
}
