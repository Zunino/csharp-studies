/**
 * Example demonstrating the ordering of records/entities based on a property of
 * a related entity (data de referência, in this example).
 * 
 * dotnet ef migrations add InitialCreate
 * dotnet ef database update
 *
 * dotnet ef database drop
 * dotnet ef migrations remove
 *
 * 8 August 2019
 */

using System;
using System.Linq;
using _11_owned_entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace _11_owned_entities
{
    class Program
    {
        static void Print(Processo processo)
        {
            Console.WriteLine($"{processo.Descricao} ({processo.Data.Data})");
            foreach (var parte in processo.Partes)
            {
                Console.WriteLine($"  - {parte.Nome}");
            }
        }
        
        static void Main()
        {
            using (var db = new ProcessoContext())
            {
                int i = 0;
                var processos = db.Processos
                    .Include(p => p.Data)
                    .Include(p => p.Partes)
                    .OrderBy(p => p.Data.Data);
                foreach (var processo in processos)
                {
                    Console.Write($"[{++i}] ");
                    Print(processo);
                }
            }
        }
    }
}
