using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Assignment_1.Models
{
    public class ValueKey
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
