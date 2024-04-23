using System.ComponentModel.DataAnnotations;

namespace codeFirstNV.Models
{
    public class nhanvien
    {
        [Key]
        public int IdNV { get; set; }
        public String TenNV { get; set; }
        public int tuoi { get; set; }
        public int idphongban { get; set; }
    }
}
