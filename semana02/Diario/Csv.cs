using System.Collections.Generic;
using System.Text;

// Classe auxiliar para ler e escrever CSV corretamente (compatível com Excel).
// Campos com vírgula, aspas ou quebra de linha ficam entre aspas,
// e aspas internas são duplicadas ("").
public static class Csv
{
    public static string Escapar(string valor)
    {
        if (valor == null) return "";
        if (valor.Contains(',') || valor.Contains('"') || valor.Contains('\n') || valor.Contains('\r'))
        {
            return "\"" + valor.Replace("\"", "\"\"") + "\"";
        }
        return valor;
    }

    public static List<string> DividirLinha(string linha)
    {
        var campos = new List<string>();
        var atual = new StringBuilder();
        bool dentroDeAspas = false;

        for (int i = 0; i < linha.Length; i++)
        {
            char c = linha[i];

            if (dentroDeAspas)
            {
                if (c == '"')
                {
                    if (i + 1 < linha.Length && linha[i + 1] == '"')
                    {
                        atual.Append('"');
                        i++;
                    }
                    else
                    {
                        dentroDeAspas = false;
                    }
                }
                else
                {
                    atual.Append(c);
                }
            }
            else
            {
                if (c == '"') dentroDeAspas = true;
                else if (c == ',')
                {
                    campos.Add(atual.ToString());
                    atual.Clear();
                }
                else atual.Append(c);
            }
        }
        campos.Add(atual.ToString());
        return campos;
    }
}
