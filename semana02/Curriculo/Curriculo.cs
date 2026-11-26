// Responsabilidade: manter o nome da pessoa e a lista de empregos.
public class Curriculo
{
    public string _nome = "";
    public List<Emprego> _empregos = new List<Emprego>();

    public Curriculo()
    {
    }

    // Exibe o nome e depois cada emprego da lista.
    public void Exibir()
    {
        Console.WriteLine($"Nome: {_nome}");
        Console.WriteLine("Empregos:");

        foreach (Emprego emprego in _empregos)
        {
            // Cada emprego sabe se exibir (abstração).
            emprego.Exibir();
        }
    }
}
