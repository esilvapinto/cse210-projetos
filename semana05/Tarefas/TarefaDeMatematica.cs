// ": Tarefa" significa "herda de Tarefa".
// Ela já ganha _nomeEstudante, _topico e ObterResumo() de graça.
public class TarefaDeMatematica : Tarefa
{
    // Só o que é EXCLUSIVO da matemática.
    private string _secaoLivro;
    private string _problemas;

    // ": base(...)" repassa nome e tópico para o construtor da classe Tarefa.
    public TarefaDeMatematica(string nomeEstudante, string topico, string secaoLivro, string problemas)
        : base(nomeEstudante, topico)
    {
        _secaoLivro = secaoLivro;
        _problemas = problemas;
    }

    public string ObterListaDeTarefas()
    {
        return $"Capítulo {_secaoLivro} Problemas {_problemas}";
    }
}
