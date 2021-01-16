using System;
using System.Collections.Generic;

namespace UASPAW_115.Models
{
    public partial class JenisKendaraan
    {
        public JenisKendaraan()
        {
            FormKeluar = new HashSet<FormKeluar>();
        }

        public int IdKendaraan { get; set; }
        public string JenisKendaraan1 { get; set; }

        public ICollection<FormKeluar> FormKeluar { get; set; }
    }
}
