using System;

namespace _11_owned_entities.Entities
{
    public class ObjetoFila
    {
        public int Id { get; set; }
        public int ProcessoId { get; set; }
        public int FilaId { get; set; }
        public DateTime Data { get; set; }

        public Processo Processo { get; set; }
        public Fila Fila { get; set; }
    }
}
