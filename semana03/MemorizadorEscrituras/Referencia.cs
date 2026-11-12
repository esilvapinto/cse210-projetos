// Guarda a referência da escritura, por exemplo "João 3:16" ou "Provérbios 3:5-6".
public class Referencia
{
    private string _livro;
    private int _capitulo;
    private int _versiculoInicial;
    private int _versiculoFinal;

    // Construtor para um único versículo: "João 3:16"
    public Referencia(string livro, int capitulo, int versiculo)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculoInicial = versiculo;
        _versiculoFinal = versiculo;
    }

    // Construtor para um intervalo de versículos: "Provérbios 3:5-6"
    public Referencia(string livro, int capitulo, int versiculoInicial, int versiculoFinal)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculoInicial = versiculoInicial;
        _versiculoFinal = versiculoFinal;
    }

    public string ObterTextoExibicao()
    {
        if (_versiculoInicial == _versiculoFinal)
        {
            return $"{_livro} {_capitulo}:{_versiculoInicial}";
        }
        return $"{_livro} {_capitulo}:{_versiculoInicial}-{_versiculoFinal}";
    }
}
