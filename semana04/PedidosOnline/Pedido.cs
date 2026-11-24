using System;
using System.Collections.Generic;

public class Pedido
{
    private List<Produto> _produtos = new List<Produto>();
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
    }

    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    public double CalcularCustoEnvio()
    {
        if (_cliente.MoraNosEua())
        {
            return 5;
        }

        return 35;
    }

    public double CalcularCustoTotal()
    {
        double total = 0;

        foreach (Produto produto in _produtos)
        {
            total += produto.CalcularCustoTotal();
        }

        return total + CalcularCustoEnvio();
    }

    public string ObterEtiquetaEmbalagem()
    {
        string etiqueta = "ETIQUETA DE EMBALAGEM\n";

        foreach (Produto produto in _produtos)
        {
            etiqueta += $"- {produto.GetNome()} (ID: {produto.GetIdProduto()})\n";
        }

        return etiqueta;
    }

    public string ObterEtiquetaEnvio()
    {
        string etiqueta = "ETIQUETA DE ENVIO\n";
        etiqueta += $"{_cliente.GetNome()}\n";
        etiqueta += _cliente.GetEndereco().ObterEnderecoCompleto();

        return etiqueta;
    }
}
