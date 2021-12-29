using System;
using ExProHP1.Entities;
using System.Globalization;
using System.Collections.Generic;
namespace ExProHP1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)?");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if(ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double health = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayers.Add(new Individual(name, anualIncome, health));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int employee = int.Parse(Console.ReadLine());
                    taxPayers.Add(new Company(name, anualIncome, employee));
                }
            }

                double taxes = 0.0;
                Console.WriteLine();
                Console.WriteLine("TAXES PAID:");
                foreach (TaxPayer item in taxPayers)
                {
                    double tax = item.Tax();
                    Console.WriteLine(item.Name + ": $ " + item.Tax().ToString("F2", CultureInfo.InvariantCulture));
                    taxes += tax;
                }
                Console.WriteLine("TOTAL TAXES: " + taxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
