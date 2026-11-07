using System;
using System.IO;

/*
 * S02 - Projeto: Programa de Diário
 *
 * INDO ALÉM DOS REQUISITOS:
 * 1. Salva e carrega em formato CSV de verdade (abre no Excel), tratando
 *    corretamente vírgulas e aspas no conteúdo (classe Csv), com cabeçalho.
 * 2. Salva uma informação extra em cada registro: o humor do dia (1 a 5),
 *    para a pessoa acompanhar como tem se sentido ao longo do tempo.
 * 3. As perguntas não se repetem até que todas tenham sido usadas, para o
 *    diário não ficar monótono (um dos motivos de as pessoas desistirem).
 * 4. Ao abrir, o programa lembra o usuário se ele ainda não escreveu hoje
 *    (ataca o problema "nós esquecemos").
 * 5. Tratamento de erros: arquivo inexistente e respostas vazias não
 *    derrubam o programa. Se o usuário não digitar extensão, usa ".csv".
 */
class Program
{
    static void Main(string[] args)
    {
        Diario diario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();
        string hoje = DateTime.Now.ToShortDateString();

        Console.WriteLine("Bem-vindo ao Programa de Diário!");

        string opcao = "";
        while (opcao != "5")
        {
            if (!diario.TemRegistroNaData(hoje))
            {
                Console.WriteLine("(Lembrete: você ainda não escreveu no diário hoje.)");
            }

            Console.WriteLine("Por favor, selecione uma das seguintes opções:");
            Console.WriteLine("1. Escrever");
            Console.WriteLine("2. Exibir");
            Console.WriteLine("3. Carregar");
            Console.WriteLine("4. Salvar");
            Console.WriteLine("5. Sair");
            Console.Write("O que você gostaria de fazer? ");
            opcao = Console.ReadLine()?.Trim() ?? "5";
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    Escrever(diario, gerador, hoje);
                    break;
                case "2":
                    diario.ExibirTodos();
                    break;
                case "3":
                    Carregar(diario);
                    break;
                case "4":
                    Salvar(diario);
                    break;
                case "5":
                    Console.WriteLine("Até amanhã! Continue escrevendo.");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Digite um número de 1 a 5.\n");
                    break;
            }
        }
    }

    static void Escrever(Diario diario, GeradorDePerguntas gerador, string hoje)
    {
        string pergunta = gerador.ObterPerguntaAleatoria();
        Console.WriteLine(pergunta);
        Console.Write("> ");
        string resposta = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(resposta))
        {
            Console.WriteLine("Registro vazio não foi salvo.\n");
            return;
        }

        Console.Write("Como você se sentiu hoje, de 1 (mal) a 5 (ótimo)? (Enter para pular) ");
        string humor = Console.ReadLine()?.Trim() ?? "";
        if (humor != "" && !(humor.Length == 1 && humor[0] >= '1' && humor[0] <= '5'))
        {
            Console.WriteLine("Valor inválido, humor não registrado.");
            humor = "";
        }

        diario.AdicionarRegistro(new Registro(hoje, pergunta, resposta, humor));
        Console.WriteLine("Registro adicionado!\n");
    }

    static void Salvar(Diario diario)
    {
        string arquivo = PedirNomeArquivo();
        try
        {
            diario.SalvarEmArquivo(arquivo);
            Console.WriteLine($"Diário salvo em {arquivo}.\n");
        }
        catch (Exception erro)
        {
            Console.WriteLine($"Não foi possível salvar: {erro.Message}\n");
        }
    }

    static void Carregar(Diario diario)
    {
        string arquivo = PedirNomeArquivo();
        if (!File.Exists(arquivo))
        {
            Console.WriteLine($"Arquivo {arquivo} não encontrado.\n");
            return;
        }

        try
        {
            diario.CarregarDeArquivo(arquivo);
            Console.WriteLine($"Diário carregado de {arquivo}.\n");
        }
        catch (Exception erro)
        {
            Console.WriteLine($"Não foi possível carregar: {erro.Message}\n");
        }
    }

    static string PedirNomeArquivo()
    {
        Console.Write("Qual é o nome do arquivo? ");
        string arquivo = Console.ReadLine()?.Trim() ?? "";
        if (arquivo == "") arquivo = "diario";
        if (!Path.HasExtension(arquivo)) arquivo += ".csv";
        return arquivo;
    }
}
