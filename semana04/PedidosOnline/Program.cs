using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Pedido 1: cliente nos EUA (envio de $5)
        Endereco endereco1 = new Endereco("123 Main Street", "Rexburg", "ID", "EUA");
        Cliente cliente1 = new Cliente("John Smith", endereco1);
        Pedido pedido1 = new Pedido(cliente1);
        pedido1.AdicionarProduto(new Produto("Caderno", "P1001", 3.50, 4));
        pedido1.AdicionarProduto(new Produto("Caneta Azul", "P1002", 1.25, 10));
        pedido1.AdicionarProduto(new Produto("Mochila", "P1003", 45.00, 1));

        // Pedido 2: cliente fora dos EUA (envio de $35)
        Endereco endereco2 = new Endereco("Rua das Flores, 250", "Sombrio", "SC", "Brasil");
        Cliente cliente2 = new Cliente("Maria Souza", endereco2);
        Pedido pedido2 = new Pedido(cliente2);
        pedido2.AdicionarProduto(new Produto("Fone de Ouvido", "P2001", 59.90, 1));
        pedido2.AdicionarProduto(new Produto("Mouse Sem Fio", "P2002", 24.50, 2));

        List<Pedido> pedidos = new List<Pedido> { pedido1, pedido2 };

        int numero = 1;
        foreach (Pedido pedido in pedidos)
        {
            Console.WriteLine($"========== PEDIDO {numero} ==========");
            Console.WriteLine(pedido.ObterEtiquetaEmbalagem());
            Console.WriteLine(pedido.ObterEtiquetaEnvio());
            Console.WriteLine();
            Console.WriteLine($"Custo de envio: ${pedido.CalcularCustoEnvio():F2}");
            Console.WriteLine($"PREÇO TOTAL: ${pedido.CalcularCustoTotal():F2}");
            Console.WriteLine();
            numero++;
        }
    }
}
