using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using codeFirstNV.Models;

namespace codeFirstNV.Data
{
    public class codeFirstNVContext : DbContext
    {
        public codeFirstNVContext (DbContextOptions<codeFirstNVContext> options)
            : base(options)
        {
        }

        public DbSet<codeFirstNV.Models.nhanvien> nhanvien { get; set; } = default!;
        public DbSet<codeFirstNV.Models.phongban> phongban { get; set; } = default!;
        public DbSet<codeFirstNV.Models.congty> congty { get; set; } = default!;
    }
}
