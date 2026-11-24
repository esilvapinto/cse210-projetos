using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Como Fazer Pão Caseiro", "Cozinha da Vó", 615);
        video1.AdicionarComentario(new Comentario("Ana", "Fiz hoje e ficou perfeito!"));
        video1.AdicionarComentario(new Comentario("Carlos", "Qual farinha você usou?"));
        video1.AdicionarComentario(new Comentario("Beatriz", "Receita fácil e deliciosa."));
        videos.Add(video1);

        Video video2 = new Video("Review do Novo Smartphone", "Tech Brasil", 842);
        video2.AdicionarComentario(new Comentario("Lucas", "A câmera parece excelente."));
        video2.AdicionarComentario(new Comentario("Fernanda", "E a bateria, dura quanto?"));
        video2.AdicionarComentario(new Comentario("Rafael", "Vale a pena trocar o meu?"));
        video2.AdicionarComentario(new Comentario("Juliana", "Ótima análise, obrigado!"));
        videos.Add(video2);

        Video video3 = new Video("Treino de 20 Minutos em Casa", "Fit Sem Desculpas", 1230);
        video3.AdicionarComentario(new Comentario("Pedro", "Suei muito, adorei!"));
        video3.AdicionarComentario(new Comentario("Mariana", "Perfeito para quem não tem tempo."));
        video3.AdicionarComentario(new Comentario("Thiago", "Vou fazer todos os dias."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.ExibirDetalhes();
            Console.WriteLine();
        }
    }
}
