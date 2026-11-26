
public class Fracao
{
    // 1. Atributos privados
    private int _numerador;
    private int _denominador;

    // 2. Construtor padrão: 1/1
    public Fracao()
    {
        _numerador = 1;
        _denominador = 1;
    }

    // 3. Construtor com um parâmetro: 5/1
    public Fracao(int numerador)
    {
        _numerador = numerador;
        _denominador = 1;
    }

    // 4. Construtor com dois parâmetros: 3/4
    public Fracao(int numerador, int denominador)
    {
        if (denominador == 0)
        {
            throw new ArgumentException("O denominador não pode ser zero.");
        }

        _numerador = numerador;
        _denominador = denominador;
    }

    // 5. Getter e Setter do numerador
    public int GetNumerador()
    {
        return _numerador;
    }

    public void SetNumerador(int numerador)
    {
        _numerador = numerador;
    }

    // 6. Getter e Setter do denominador
    public int GetDenominador()
    {
        return _denominador;
    }

    public void SetDenominador(int denominador)
    {
        if (denominador == 0)
        {
            throw new ArgumentException("O denominador não pode ser zero.");
        }

        _denominador = denominador;
    }

    // 7. Retorna a fração em texto
    public string ObterFracaoEmTexto()
    {
        return $"{_numerador}/{_denominador}";
    }

    // 8. Retorna a fração em decimal
    public double ObterFracaoEmDecimal()
    {
        return (double)_numerador / _denominador;
    }
}
