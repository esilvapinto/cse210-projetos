public class AtividadeReflexao : Atividade
{
    private ListaSemRepeticao _mensagens = new ListaSemRepeticao(new List<string>
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que você fez algo realmente difícil.",
        "Pense em uma ocasião em que você ajudou alguém necessitado.",
        "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
    });

    private ListaSemRepeticao _perguntas = new ListaSemRepeticao(new List<string>
    {
        "Por que essa experiência foi significativa para você?",
        "Você já fez algo assim antes?",
        "Como você começou?",
        "Como você se sentiu quando terminou?",
        "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
        "Qual é a sua coisa favorita sobre essa experiência?",
        "O que você pode aprender com essa experiência que se aplica a outras situações?",
        "O que você aprendeu sobre si mesmo por meio dessa experiência?",
        "Como você pode manter essa experiência em mente no futuro?"
    });

    public AtividadeReflexao()
        : base("Atividade de Reflexão",
               "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você " +
               "demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você " +
               "tem e como pode usá-lo em outros aspectos da sua vida.")
    {
    }

    protected override void ExecutarAtividade()
    {
        ExibirMensagem();
        ExibirPerguntas();
    }

    private void ExibirMensagem()
    {
        Console.WriteLine("Considere a seguinte mensagem:");
        Console.WriteLine();
        Console.WriteLine($" --- {_mensagens.Sortear()} --- ");
        Console.WriteLine();
        Console.WriteLine("Quando tiver algo em mente, pressione Enter para continuar.");
        Console.ReadLine();

        Console.WriteLine("Agora reflita sobre cada uma das perguntas a seguir, relacionadas a essa experiência.");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.Clear();
    }

    private void ExibirPerguntas()
    {
        DateTime fim = DateTime.Now.AddSeconds(GetDuracao());

        while (DateTime.Now < fim)
        {
            Console.Write($"> {_perguntas.Sortear()} ");
            ExibirSpinner(10);
            Console.WriteLine();
        }
    }
}
