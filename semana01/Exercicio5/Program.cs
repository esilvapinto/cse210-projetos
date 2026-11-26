using System;

class Program
{
    static void Main(string[] args)
    {
        ExibirBoasVindas();

        string nome = PerguntarNomeUsuario();
        int numero = PerguntarNumeroFavorito();

        int quadrado = ElevarAoQuadrado(numero);

        ExibirResultado(nome, quadrado);
    }

    static void ExibirBoasVindas()
    {
        Console.WriteLine("Bem-vindo ao programa!");
    }

    static string PerguntarNomeUsuario()
    {
        Console.Write("Por favor, insira seu nome: ");
        string nome = Console.ReadLine();
        return nome;
    }

    static int PerguntarNumeroFavorito()
    {
        Console.Write("Por favor, insira seu número favorito: ");
        int numero = int.Parse(Console.ReadLine());
        return numero;
    }

    static int ElevarAoQuadrado(int numero)
    {
        int quadrado = numero * numero;
        return quadrado;
    }

    static void ExibirResultado(string nome, int quadrado)
    {
        Console.WriteLine($"{nome}, o quadrado do seu número é {quadrado}");
    }
}