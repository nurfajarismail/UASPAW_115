using System;
using System.Collections.Generic;

namespace UASPAW_115.Models
{
    public partial class FormKeluar
    {
        public int IdKeluar { get; set; }
        public DateTime? TanggalKeluar { get; set; }
        public int? IdMasuk { get; set; }
        public int? IdKendaraan { get; set; }
        public int? IdTarif { get; set; }

        public JenisKendaraan IdKendaraanNavigation { get; set; }
        public FormMasuk IdMasukNavigation { get; set; }
        public Tarif IdTarifNavigation { get; set; }
    }
}
