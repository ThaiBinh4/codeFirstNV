using System.ComponentModel.DataAnnotations;

namespace codeFirstNV.Models
{
    public class phongban
    {
        [Key]
        public int Idphongban { get; set; }
        public string Namephongban { get; set; }
        public int idcongty { get; set; }
       
    }
}
