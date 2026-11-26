// Guarda várias escrituras, carregadas do arquivo "escrituras.txt",
// e sorteia uma delas para o usuário praticar.
//
// Formato de cada linha do arquivo (linhas vazias ou começando com # são ignoradas):
//   Livro|Capítulo|VersículoInicial|VersículoFinal|Texto
// Para um único versículo, deixe VersículoFinal vazio:
//   João|3|16||Porque Deus amou o mundo...
public class BibliotecaEscrituras
{
    private List<Escritura> _escrituras = new List<Escritura>();
    private Random _aleatorio = new Random();

    public void CarregarDoArquivo(string caminho)
    {
        if (!File.Exists(caminho))
        {
            return;
        }

        foreach (string linha in File.ReadAllLines(caminho))
        {
            if (string.IsNullOrWhiteSpace(linha) || linha.TrimStart().StartsWith("#"))
            {
                continue;
            }

            string[] partes = linha.Split('|');
            if (partes.Length < 5)
            {
                continue;
            }

            string livro = partes[0].Trim();
            int capitulo = int.Parse(partes[1]);
            int versiculoInicial = int.Parse(partes[2]);
            string texto = partes[4].Trim();

            Referencia referencia;
            if (string.IsNullOrWhiteSpace(partes[3]))
            {
                referencia = new Referencia(livro, capitulo, versiculoInicial);
            }
            else
            {
                referencia = new Referencia(livro, capitulo, versiculoInicial, int.Parse(partes[3]));
            }

            _escrituras.Add(new Escritura(referencia, texto));
        }
    }

    public void Adicionar(Escritura escritura)
    {
        _escrituras.Add(escritura);
    }

    public int Quantidade()
    {
        return _escrituras.Count;
    }

    public Escritura SortearEscritura()
    {
        return _escrituras[_aleatorio.Next(_escrituras.Count)];
    }
}
