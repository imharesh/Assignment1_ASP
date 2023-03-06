using System.ComponentModel.DataAnnotations;

namespace Assign1.Models
{
    public class KeyValues
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
