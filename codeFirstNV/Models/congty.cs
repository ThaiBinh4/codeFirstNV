using System.ComponentModel.DataAnnotations;

namespace codeFirstNV.Models
{
    public class congty
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public String diachi { get; set; }
    }
}
