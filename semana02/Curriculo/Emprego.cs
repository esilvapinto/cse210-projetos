// Responsabilidade: manter os dados de um emprego e exibi-los.
public class Emprego
{
    public string _empresa = "";
    public string _cargo = "";
    public int _anoInicio;
    public int _anoFim;

    public Emprego()
    {
    }

    // Exibe no formato: Cargo (Empresa) AnoInicio-AnoFim
    public void Exibir()
    {
        Console.WriteLine($"{_cargo} ({_empresa}) {_anoInicio}-{_anoFim}");
    }
}
