using System.Collections.Generic;

namespace _11_owned_entities.Entities
{
    public class Processo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Parte> Partes { get; set; }
        public DataReferencia Data { get; set; }
    }
}