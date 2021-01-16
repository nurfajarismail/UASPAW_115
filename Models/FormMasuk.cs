using System;
using System.Collections.Generic;

namespace UASPAW_115.Models
{
    public partial class FormMasuk
    {
        public FormMasuk()
        {
            FormKeluar = new HashSet<FormKeluar>();
        }

        public int IdMasuk { get; set; }
        public string NoPolisi { get; set; }
        public DateTime? TanggalMasuk { get; set; }

        public ICollection<FormKeluar> FormKeluar { get; set; }
    }
}
