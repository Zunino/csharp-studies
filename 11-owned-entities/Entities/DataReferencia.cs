using System;

namespace _11_owned_entities.Entities
{
    public class DataReferencia
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ProcessoId { get; set; }
        public Processo Processo { get; set; }
    }
}