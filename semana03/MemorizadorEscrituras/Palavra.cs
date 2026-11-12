// Representa uma única palavra da escritura e sabe se está oculta ou não.
public class Palavra
{
    private string _texto;
    private bool _oculta;

    public Palavra(string texto)
    {
        _texto = texto;
        _oculta = false;
    }

    public void Ocultar()
    {
        _oculta = true;
    }

    public void Mostrar()
    {
        _oculta = false;
    }

    public bool EstaOculta()
    {
        return _oculta;
    }

    // Retorna o texto da palavra sem ocultação (usado para mostrar o resultado da recitação).
    public string ObterTextoOriginal()
    {
        return _texto;
    }

    // Confere se a palavra digitada pelo usuário é a mesma desta palavra.
    // Ignora maiúsculas/minúsculas, pontuação e acentos ("próximo" = "proximo").
    public bool Corresponde(string tentativa)
    {
        return Normalizar(_texto) == Normalizar(tentativa);
    }

    private static string Normalizar(string texto)
    {
        string semAcento = texto.ToLower().Normalize(System.Text.NormalizationForm.FormD);
        string resultado = "";
        foreach (char c in semAcento)
        {
            if (char.IsLetterOrDigit(c))
            {
                resultado += c;
            }
        }
        return resultado;
    }

    // Quando oculta, troca apenas as letras e números por "_".
    // A pontuação (vírgulas, pontos etc.) continua visível para ajudar no ritmo da leitura.
    public string ObterTextoExibicao()
    {
        if (!_oculta)
        {
            return _texto;
        }

        string resultado = "";
        foreach (char c in _texto)
        {
            resultado += char.IsLetterOrDigit(c) ? '_' : c;
        }
        return resultado;
    }
}
