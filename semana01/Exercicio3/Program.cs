using System;

class Program
{
    static void Main(string[] args)
    {
        Random geradorAleatorio = new Random();
        string jogarDeNovo = "sim";

        while (jogarDeNovo == "sim")
        {
            int numeroMagico = geradorAleatorio.Next(1, 101);

            int palpite = -1;
            int tentativas = 0;

            while (palpite != numeroMagico)
            {
                Console.Write("Qual é o seu palpite? ");
                palpite = int.Parse(Console.ReadLine());
                tentativas++;

                if (palpite < numeroMagico)
                {
                    Console.WriteLine("Mais alto");
                }
                else if (palpite > numeroMagico)
                {
                    Console.WriteLine("Mais baixo");
                }
                else
                {
                    Console.WriteLine("Você adivinhou!");
                }
            }

            Console.WriteLine($"Você precisou de {tentativas} palpites.");

            Console.Write("Deseja jogar de novo? ");
            jogarDeNovo = Console.ReadLine().ToLower();
        }
    }
}