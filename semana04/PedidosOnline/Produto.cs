using System;

public class Produto
{
    private string _nome;
    private string _idProduto;
    private double _preco;
    private int _quantidade;

    public Produto(string nome, string idProduto, double preco, int quantidade)
    {
        _nome = nome;
        _idProduto = idProduto;
        _preco = preco;
        _quantidade = quantidade;
    }

    public string GetNome()
    {
        return _nome;
    }

    public string GetIdProduto()
    {
        return _idProduto;
    }

    public double CalcularCustoTotal()
    {
        return _preco * _quantidade;
    }
}
