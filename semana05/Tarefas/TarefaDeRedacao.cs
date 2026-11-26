public class TarefaDeRedacao : Tarefa
{
    private string _titulo;

    public TarefaDeRedacao(string nomeEstudante, string topico, string titulo)
        : base(nomeEstudante, topico)
    {
        _titulo = titulo;
    }

    public string ObterInformacoesDaRedacao()
    {
        // _nomeEstudante é privado na classe base, então usamos o método público.
        return $"{_titulo}, por {ObterNomeEstudante()}";
    }
}
