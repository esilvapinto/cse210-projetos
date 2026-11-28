// =====================================================================
// PROGRAMA DE INTROSPECÇÃO - CSE 210, Semana 05
//
// SUPERANDO OS REQUISITOS (criatividade):
// 1. Mensagens e perguntas aleatórias NÃO se repetem até que todas
//    tenham sido usadas pelo menos uma vez (classe ListaSemRepeticao).
// 2. O programa mantém um registro de quantas vezes cada atividade foi
//    concluída (classe Registro), com a opção "4. Ver histórico" no menu.
// 3. Esse registro é salvo e carregado do arquivo "registro_atividades.txt",
//    então o histórico continua existindo depois de fechar o programa.
// 4. A classe base Atividade usa um método abstrato (ExecutarAtividade),
//    então o fluxo início -> atividade -> fim fica escrito em um só lugar.
// 5. Validação da duração: o programa não quebra se o usuário digitar
//    texto ou um número negativo.
// =====================================================================

class Program
{
    static void Main(string[] args)
    {
        Registro registro = new Registro("registro_atividades.txt");

        // Criadas uma vez só, para que a regra de "não repetir" valha
        // durante toda a execução do programa.
        AtividadeRespiracao respiracao = new AtividadeRespiracao();
        AtividadeReflexao reflexao = new AtividadeReflexao();
        AtividadeListagem listagem = new AtividadeListagem();

        string escolha = "";

        while (escolha != "5")
        {
            Console.Clear();
            Console.WriteLine("Opções do menu:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            Console.WriteLine("  4. Ver histórico");
            Console.WriteLine("  5. Sair");
            Console.Write("Selecione uma opção do menu: ");
            escolha = Console.ReadLine();

            Atividade atividade = null;

            switch (escolha)
            {
                case "1":
                    atividade = respiracao;
                    break;
                case "2":
                    atividade = reflexao;
                    break;
                case "3":
                    atividade = listagem;
                    break;
                case "4":
                    registro.Exibir();
                    break;
                case "5":
                    Console.WriteLine("Até a próxima!");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    Thread.Sleep(1500);
                    break;
            }

            if (atividade != null)
            {
                atividade.Executar();
                registro.RegistrarConclusao(atividade.GetNome());
            }
        }
    }
}
