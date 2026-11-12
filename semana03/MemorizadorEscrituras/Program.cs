/*
 * CSE 210 - Semana 03 - Programa de Memorização de Escrituras
 *
 * O QUE FIZ PARA IR ALÉM DOS REQUISITOS:
 *  1. Biblioteca de escrituras: o programa trabalha com várias escrituras
 *     (classe BibliotecaEscrituras) e sorteia uma delas a cada execução.
 *  2. Escrituras carregadas de arquivo: as escrituras ficam no arquivo
 *     "escrituras.txt", então é possível adicionar novas sem mexer no código.
 *     Se o arquivo não existir, o programa usa João 3:16 como padrão.
 *  3. Oculta apenas palavras que ainda estão visíveis (desafio adicional),
 *     garantindo que cada Enter realmente avance o exercício.
 *  4. A pontuação continua visível nas palavras ocultas (ex.: "______,"),
 *     o que ajuda a lembrar o ritmo e as pausas do texto.
 *  5. Comando "dica": se o usuário travar, ele digita "dica" e uma palavra
 *     oculta volta a aparecer — ajuda quem ainda não consegue recitar tudo.
 *  6. Comando "reiniciar": mostra a escritura inteira de novo para recomeçar.
 *  7. Barra de progresso mostrando quanto da escritura já foi ocultado.
 *  8. Teste final de recitação: quando tudo está oculto, o usuário digita a
 *     escritura de memória e o programa mostra as palavras certas em verde, as
 *     que faltaram em vermelho e o percentual de acerto. A comparação ignora
 *     acentos, maiúsculas e pontuação, e tolera uma palavra esquecida sem
 *     marcar todas as seguintes como erro.
 */

class Program
{
    static void Main(string[] args)
    {
        BibliotecaEscrituras biblioteca = new BibliotecaEscrituras();
        biblioteca.CarregarDoArquivo(Path.Combine(AppContext.BaseDirectory, "escrituras.txt"));

        if (biblioteca.Quantidade() == 0)
        {
            Referencia referenciaPadrao = new Referencia("João", 3, 16);
            biblioteca.Adicionar(new Escritura(referenciaPadrao,
                "Porque Deus amou o mundo de tal maneira que deu o seu Filho Unigênito, " +
                "para que todo aquele que nele crê não pereça, mas tenha a vida eterna."));
        }

        Escritura escritura = biblioteca.SortearEscritura();
        string mensagem = "";

        while (true)
        {
            Console.Clear();
            Console.WriteLine(escritura.ObterTextoExibicao());
            Console.WriteLine();
            Console.WriteLine(MontarBarraProgresso(escritura.ObterProgresso()));

            if (mensagem != "")
            {
                Console.WriteLine(mensagem);
                mensagem = "";
            }

            if (escritura.EstaCompletamenteOculta())
            {
                Console.WriteLine();
                Console.WriteLine("Todas as palavras foram ocultadas!");
                Console.WriteLine("Digite a escritura de memória e pressione Enter (ou digite 'pular'):");

                // Um Enter vazio (apertado sem querer) é ignorado: o programa espera o texto.
                string recitacao = Console.ReadLine();
                while (recitacao != null && recitacao.Trim() == "")
                {
                    recitacao = Console.ReadLine();
                }

                if (recitacao != null && recitacao.Trim().ToLower() != "pular")
                {
                    Console.WriteLine();
                    MostrarResultadoColorido(escritura.ObterReferencia(), escritura.ObterTextoCorrigido(recitacao));
                    int acerto = escritura.CalcularAcerto(recitacao);
                    Console.WriteLine();
                    Console.WriteLine($"Você acertou {acerto}% das palavras.");
                    Console.WriteLine(acerto == 100
                        ? "Perfeito! Você memorizou a escritura."
                        : "As palavras em vermelho [entre colchetes] faltaram ou estão diferentes. Continue praticando!");
                }
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Pressione Enter para continuar, digite 'dica', 'reiniciar' ou 'sair':");
            string entrada = Console.ReadLine();

            if (entrada == null)
            {
                break;
            }

            entrada = entrada.Trim().ToLower();

            if (entrada == "sair")
            {
                break;
            }
            else if (entrada == "dica")
            {
                if (!escritura.RevelarUmaPalavra())
                {
                    mensagem = "Nenhuma palavra oculta ainda. Pressione Enter primeiro.";
                }
            }
            else if (entrada == "reiniciar")
            {
                escritura.MostrarTodas();
            }
            else
            {
                escritura.OcultarPalavrasAleatorias(3);
            }
        }
    }

    // Mostra as palavras certas em verde e as que faltaram [entre colchetes] em vermelho.
    static void MostrarResultadoColorido(string referencia, string textoCorrigido)
    {
        Console.Write(referencia + " ");

        foreach (string palavra in textoCorrigido.Split(' '))
        {
            Console.ForegroundColor = palavra.StartsWith("[") ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write(palavra + " ");
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    static string MontarBarraProgresso(int percentual)
    {
        int tamanho = 20;
        int preenchido = percentual * tamanho / 100;
        return "Progresso: [" + new string('#', preenchido) + new string('-', tamanho - preenchido) + $"] {percentual}%";
    }
}
