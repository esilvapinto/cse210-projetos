// EXTRA: sorteia itens aleatórios sem repetir nenhum
// até que todos tenham sido usados pelo menos uma vez.
public class ListaSemRepeticao
{
    private List<string> _todos;
    private List<string> _restantes = new List<string>();
    private Random _aleatorio = new Random();

    public ListaSemRepeticao(List<string> itens)
    {
        _todos = itens;
    }

    public string Sortear()
    {
        // Quando acabar, recarrega a lista completa
        if (_restantes.Count == 0)
        {
            _restantes = new List<string>(_todos);
        }

        int indice = _aleatorio.Next(_restantes.Count);
        string item = _restantes[indice];
        _restantes.RemoveAt(indice);
        return item;
    }
}
