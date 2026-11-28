public class AtividadeRespiracao : Atividade
{
    public AtividadeRespiracao()
        : base("Atividade de Respiração",
               "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. " +
               "Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    protected override void ExecutarAtividade()
    {
        DateTime fim = DateTime.Now.AddSeconds(GetDuracao());

        while (DateTime.Now < fim)
        {
            Console.WriteLine();
            Console.Write("Inspire... ");
            ExibirContagemRegressiva(4);

            Console.WriteLine();
            Console.Write("Expire... ");
            ExibirContagemRegressiva(6);
            Console.WriteLine();
        }
    }
}
