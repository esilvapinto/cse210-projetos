using System;
using System.Collections.Generic;

// Responsável por fornecer perguntas aleatórias para o diário.
public class GeradorDePerguntas
{
    public List<string> _perguntas = new List<string>
    {
        "Quem foi a pessoa mais interessante com quem interagi hoje?",
        "Qual foi a melhor parte do meu dia?",
        "Como vi a mão do Senhor em minha vida hoje?",
        "Qual foi a emoção mais forte que senti hoje?",
        "Se eu pudesse fazer uma coisa hoje, o que seria?",
        "O que aprendi de novo hoje?",
        "Pelo que sou grato hoje?",
        "Que desafio enfrentei hoje e como lidei com ele?",
        "Quem eu ajudei hoje, ou quem me ajudou?",
        "O que quero fazer melhor amanhã?"
    };

    // Extra: guarda as perguntas já usadas para não repetir
    // até que todas tenham sido mostradas.
    private List<string> _perguntasUsadas = new List<string>();
    private Random _aleatorio = new Random();

    public string ObterPerguntaAleatoria()
    {
        if (_perguntasUsadas.Count >= _perguntas.Count)
        {
            _perguntasUsadas.Clear();
        }

        List<string> disponiveis = new List<string>();
        foreach (string pergunta in _perguntas)
        {
            if (!_perguntasUsadas.Contains(pergunta))
            {
                disponiveis.Add(pergunta);
            }
        }

        string escolhida = disponiveis[_aleatorio.Next(disponiveis.Count)];
        _perguntasUsadas.Add(escolhida);
        return escolhida;
    }
}
