// Classe BASE: guarda o que é comum a TODAS as tarefas.
public class Tarefa
{
    // Privadas: só a própria classe Tarefa enxerga diretamente.
    private string _nomeEstudante;
    private string _topico;

    public Tarefa(string nomeEstudante, string topico)
    {
        _nomeEstudante = nomeEstudante;
        _topico = topico;
    }

    // Método público para as classes filhas (e quem mais precisar)
    // conseguirem LER o nome, já que _nomeEstudante é privado.
    public string ObterNomeEstudante()
    {
        return _nomeEstudante;
    }

    public string ObterResumo()
    {
        return $"{_nomeEstudante} - {_topico}";
    }
}
