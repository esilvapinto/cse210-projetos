public class AtividadeListagem : Atividade
{
    private int _contagem;

    private ListaSemRepeticao _mensagens = new ListaSemRepeticao(new List<string>
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu o Espírito Santo neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    });

    public AtividadeListagem()
        : base("Atividade de Listagem",
               "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, " +
               "fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
    {
    }

    protected override void ExecutarAtividade()
    {
        Console.WriteLine("Liste o máximo de respostas que puder para a seguinte mensagem:");
        Console.WriteLine($" --- {_mensagens.Sortear()} --- ");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.WriteLine();

        _contagem = ObterListaDoUsuario().Count;
        Console.WriteLine($"Você listou {_contagem} itens!");
    }

    private List<string> ObterListaDoUsuario()
    {
        List<string> itens = new List<string>();
        DateTime fim = DateTime.Now.AddSeconds(GetDuracao());

        while (DateTime.Now < fim)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itens.Add(item);
            }
        }
        return itens;
    }
}
