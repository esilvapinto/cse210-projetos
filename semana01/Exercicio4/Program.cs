using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");

        int numero = -1;
        while (numero != 0)
        {
            Console.Write("Insira o número: ");
            numero = int.Parse(Console.ReadLine());

            if (numero != 0)
            {
                numeros.Add(numero);
            }
        }

        // Requisito 1: soma
        int soma = 0;
        foreach (int n in numeros)
        {
            soma += n;
        }
        Console.WriteLine($"A soma é: {soma}");

        // Requisito 2: média
        double media = (double)soma / numeros.Count;
        Console.WriteLine($"A média é: {media.ToString(CultureInfo.InvariantCulture)}");

        // Requisito 3: maior número
        int maior = numeros[0];
        foreach (int n in numeros)
        {
            if (n > maior)
            {
                maior = n;
            }
        }
        Console.WriteLine($"O maior número é: {maior}");

        // Desafio 1: menor número positivo
        int menorPositivo = int.MaxValue;
        foreach (int n in numeros)
        {
            if (n > 0 && n < menorPositivo)
            {
                menorPositivo = n;
            }
        }
        Console.WriteLine($"O menor número positivo é: {menorPositivo}");

        // Desafio 2: lista ordenada
        numeros.Sort();
        Console.WriteLine("A lista reordenada é:");
        foreach (int n in numeros)
        {
            Console.WriteLine(n);
        }
    }
}