// Classe base: guarda tudo o que as três atividades têm em comum.
// As classes filhas só escrevem a parte que é diferente (ExecutarAtividade).
public abstract class Atividade
{
    private string _nome;
    private string _descricao;
    private int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public string GetNome()
    {
        return _nome;
    }

    protected int GetDuracao()
    {
        return _duracao;
    }

    // Fluxo padrão de TODAS as atividades: início -> parte específica -> fim.
    public void Executar()
    {
        ExibirMensagemInicial();
        ExecutarAtividade();
        ExibirMensagemFinal();
    }

    // Cada classe filha é obrigada a escrever a sua versão deste método.
    protected abstract void ExecutarAtividade();

    private void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à {_nome}.");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();
        _duracao = PerguntarDuracao();

        Console.Clear();
        Console.WriteLine("Prepare-se...");
        ExibirSpinner(3);
        Console.WriteLine();
    }

    private void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem!!");
        ExibirSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"Você completou mais {_duracao} segundos da {_nome}.");
        ExibirSpinner(4);
    }

    private int PerguntarDuracao()
    {
        while (true)
        {
            Console.Write("Quantos segundos você gostaria para esta sessão? ");
            if (int.TryParse(Console.ReadLine(), out int segundos) && segundos > 0)
            {
                return segundos;
            }
            Console.WriteLine("Digite um número inteiro maior que zero.");
        }
    }

    // Animação de "rodinha girando" durante as pausas.
    protected void ExibirSpinner(int segundos)
    {
        string[] quadros = { "|", "/", "-", "\\" };
        DateTime fim = DateTime.Now.AddSeconds(segundos);
        int i = 0;

        while (DateTime.Now < fim)
        {
            Console.Write(quadros[i % quadros.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    // Contagem regressiva: 5 4 3 2 1 no mesmo lugar da tela.
    protected void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            string numero = i.ToString();
            Console.Write(numero);
            Thread.Sleep(1000);
            // Apaga quantos caracteres o número tiver (funciona com 10, 11...)
            for (int j = 0; j < numero.Length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}
