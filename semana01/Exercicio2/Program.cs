using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual é a sua nota (em porcentagem)? ");
        string resposta = Console.ReadLine();
        int nota = int.Parse(resposta);

        // Requisito 3: guardar a letra numa variável
        string letra = "";

        if (nota >= 90)
        {
            letra = "A";
        }
        else if (nota >= 80)
        {
            letra = "B";
        }
        else if (nota >= 70)
        {
            letra = "C";
        }
        else if (nota >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        // Desafio 1: sinal + ou -
        string sinal = "";
        int ultimoDigito = nota % 10;

        if (ultimoDigito >= 7)
        {
            sinal = "+";
        }
        else if (ultimoDigito < 3)
        {
            sinal = "-";
        }

        // Desafio 2: não existe A+
        if (letra == "A" && sinal == "+")
        {
            sinal = "";
        }

        // Desafio 3: não existe F+ nem F-
        if (letra == "F")
        {
            sinal = "";
        }

        Console.WriteLine($"Sua nota é: {letra}{sinal}");

        // Requisito 2: aprovado ou não
        if (nota >= 70)
        {
            Console.WriteLine("Parabéns, você foi aprovado!");
        }
        else
        {
            Console.WriteLine("Não desanime, na próxima vez você consegue!");
        }
    }
}