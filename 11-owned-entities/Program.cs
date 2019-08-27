/**
 * Example demonstrating the ordering of records/entities based on a property
 * of a related entity (data de referência, in this example).
 *
 * The original goal of the example has been expanded into a more complex
 * scenario that more closely resembles the problem we were facing at the
 * office. In summary:
 *
 *   - A Processo can be in one or more Filas
 *   - ObjetoFila is the entity connecting Processo to Fila
 *   - Each ObjetoFila has a DataReferencia
 *   - Processo entities should be ordered by the DataReferencia field
 *   - Even if a Processo is associated with multiple Fila instances,
 *     only the 'selected' filas should be taken into account when
 *     comparing dates
 * 
 * dotnet ef migrations add InitialCreate
 * dotnet ef database update
 *
 * dotnet ef database drop
 * dotnet ef migrations remove
 *
 * Andre Zunino <neyzunino@gmail.com>
 *
 * Created on 8 August 2019
 *
 * Last modified on 26 August 2019
 */

using System;
using System.Linq;
using System.Collections.Generic;
using _11_owned_entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace _11_owned_entities
{
    internal static class Program
    {
        private static void Print(Processo processo)
        {
            Console.WriteLine($"{processo.Descricao}");
/*
            foreach (var objFila in processo.ObjetoFilas)
            {
                var fila = objFila.Fila;
                Console.WriteLine($"    - {fila.Descricao} ({objFila.Data})");
            }
*/
        }
        
        // Return a list of Processo, ordered by the reference date of the specified Fila.
        // The Processo should not be included if it's not in the specified Fila.
        private static IEnumerable<Processo> GetProcessos(int cdFila)
        {
            using (var db = new ProcessoContext())
            {
                var processos = db.Processos
                    //.Include(p => p.ObjetoFilas)
                    //.ThenInclude(o => o.Fila)
                    .Where(p => p.ObjetoFilas.Any(o => o.FilaId == cdFila));

                return processos.ToList();

/*
                foreach (var processo in processos)
                {
                    var objfilas = db.Entry(processo)
                        .Collection(p => p.ObjetoFilas)
                        .Query()
                        .Where(o => o.FilaId == cdFila)
                        .ToList();
                    processo.ObjetoFilas = objfilas;
                }

                return processos.OrderBy(p => p.ObjetoFilas.FirstOrDefault().Data).ToList();
*/
            }
        }

        private static IEnumerable<Processo> GetProcessos2(int cdFila)
        {
            using (var db = new ProcessoContext())
            {
                var processos = db.Processos
                    .Where(p => p.ObjetoFilas.Any(o => o.FilaId == cdFila))
                    .OrderBy(p => p.ObjetoFilas.FirstOrDefault(f => f.FilaId == cdFila).Data);

                return processos.ToList();
            }
        }

        private static IEnumerable<Processo> GetProcessos3(IEnumerable<int> cdFilas)
        {
            using (var db = new ProcessoContext())
            {
                var processos = db.Processos
                    .Where(p => p.ObjetoFilas.Any(o => cdFilas.Contains(o.FilaId)))
                    .OrderBy(p => p.ObjetoFilas.Min(f => f.Data));

                return processos.ToList();
            }
        }

        private static void Main()
        {
            //var processos = GetProcessos2(2);
            var processos = GetProcessos3(new int[] {2, 1});
            var i = 0;
            foreach (var processo in processos)
            {
                Console.Write($"[{++i}] ");
                Print(processo);
            }
        }
    }
}
