using System.ComponentModel.DataAnnotations;

namespace _16_ef_core_3
{
    public class Transcription
    {
        [Key]
        public int VideoId { get; set; }
        public string Text { get; set; }
    }
}