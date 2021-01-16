using System;
using System.Collections.Generic;

namespace UASPAW_115.Models
{
    public partial class Tarif
    {
        public Tarif()
        {
            FormKeluar = new HashSet<FormKeluar>();
        }

        public int IdTarif { get; set; }
        public string TarifHarga { get; set; }

        public ICollection<FormKeluar> FormKeluar { get; set; }
    }
}
