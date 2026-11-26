using System;

class Program
{
    static void Main(string[] args)
    {
        // 1) Classe base
        Tarefa tarefa = new Tarefa("Samuel Silva", "Multiplicação");
        Console.WriteLine(tarefa.ObterResumo());
        Console.WriteLine();

        // 2) Matemática
        TarefaDeMatematica matematica = new TarefaDeMatematica("Roberto Rodriguez", "Frações", "7.3", "8-19");
        Console.WriteLine(matematica.ObterResumo());          // herdado da base
        Console.WriteLine(matematica.ObterListaDeTarefas());  // exclusivo da matemática
        Console.WriteLine();

        // 3) Redação
        TarefaDeRedacao redacao = new TarefaDeRedacao("Maria Antunes", "História da Europa", "As Causas da Segunda Guerra Mundial");
        Console.WriteLine(redacao.ObterResumo());                 // herdado da base
        Console.WriteLine(redacao.ObterInformacoesDaRedacao());   // exclusivo da redação
    }
}
