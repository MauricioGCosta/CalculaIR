using System;
using System.Globalization;
using System.Collections.Generic;
using CalculoIR.Entidades;

namespace CalculoIR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o número de contribuintes: ");
            int numContribuintes = int.Parse(Console.ReadLine());

            List<Contribuinte> contribuintes = new List<Contribuinte>();
            
            for (int i = 1; i <= numContribuintes; i++)
            {
                Console.WriteLine("Dados do contribuinte #{0}", i);
                Console.Write("Pessoa Física ou Pessoa Jurídica (f/j): ");
                char tipo = char.Parse(Console.ReadLine());

                Console.Write("Nome do contribuinte: ");
                string nome = Console.ReadLine();

                Console.Write("Renda anual: ");
                double rendaAnual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (tipo == 'f')
                {
                    Console.Write("Gastos com saúde: ");
                    double gastosSaude = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    contribuintes.Add(new PessoaFisica(nome, rendaAnual, gastosSaude));
                }
                else
                {
                    Console.Write("Número de funcionários: ");
                    int numFuncionarios = int.Parse(Console.ReadLine());
                    contribuintes.Add(new PessoaJuridica(nome, rendaAnual, numFuncionarios));
                }
            }

            double totalImpostos = 0.0;
            Console.WriteLine();
            Console.WriteLine("Imposto a pagar: ");
            foreach (var item in contribuintes)
            {
                totalImpostos += item.CalculaIR();
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Total de Impostos: " + totalImpostos.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
