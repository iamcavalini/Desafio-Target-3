using System;
using System.Globalization;

public class Program3
{
    public static void Main()
    {
        Console.WriteLine("=== CÁLCULO DE JUROS POR ATRASO ===");

        // 1. Leitura e validação do valor base
        decimal valorBase = 0;
        bool valorValido = false;

        while (!valorValido)
        {
            Console.Write("Informe o valor da conta: R$ ");
            string entradaValor = Console.ReadLine() ?? "";

            // Suporta vírgula e ponto como separadores decimais
            if (decimal.TryParse(entradaValor.Replace('.', ','), CultureInfo.GetCultureInfo("pt-BR"), out valorBase) && valorBase > 0)
            {
                valorValido = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor inválido! Por favor, insira um número positivo.");
                Console.ResetColor();
            }
        }

        // 2. Leitura e validação da data de vencimento
        DateTime dataVencimento = DateTime.MinValue;
        bool dataValida = false;
        string[] formatosData = { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" };

        while (!dataValida)
        {
            Console.Write("Informe a data de vencimento (informe no seguinte formato __/__/___): ");
            string entradaData = Console.ReadLine() ?? "";

            if (DateTime.TryParseExact(entradaData, formatosData, CultureInfo.InvariantCulture, DateTimeStyles.None, out dataVencimento))
            {
                dataValida = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Data inválida! Utilize o formato DD/MM/AAAA.");
                Console.ResetColor();
            }
        }

        // 3. Execução do cálculo
        Console.WriteLine();
        CalcularEMostrarJuros(valorBase, dataVencimento);
    }

    public static void CalcularEMostrarJuros(decimal valorOriginal, DateTime vencimento)
    {
        DateTime hoje = DateTime.Today;
        TimeSpan diferenca = hoje - vencimento.Date;
        int diasAtraso = diferenca.Days;

        if (diasAtraso <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("O pagamento está em dia. Não há juros a aplicar!");
            Console.WriteLine($"Valor Total: R$ {valorOriginal:F2}");
            Console.ResetColor();
            return;
        }

        const decimal taxaMultaDiaria = 0.025m; // 2,5% ao dia
        decimal valorJuros = valorOriginal * taxaMultaDiaria * diasAtraso;
        decimal valorTotal = valorOriginal + valorJuros;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("       RESUMO DO CÁLCULO");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Data de Vencimento : {vencimento:dd/MM/yyyy}");
        Console.WriteLine($"Data Atual          : {hoje:dd/MM/yyyy}");
        Console.WriteLine($"Dias em Atraso      : {diasAtraso} dia(s)");
        Console.WriteLine($"Valor Original     : R$ {valorOriginal:F2}");
        Console.WriteLine($"Valor dos Juros     : R$ {valorJuros:F2} (2,5%/dia)");
        Console.WriteLine($"Valor Total a Pagar : R$ {valorTotal:F2}");
        Console.WriteLine("-----------------------------------");
        Console.ResetColor();
    }
}