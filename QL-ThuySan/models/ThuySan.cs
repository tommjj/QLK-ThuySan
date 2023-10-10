namespace QL_ThuySan.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuySan")]
    public partial class ThuySan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThuySan()
        {
            TonKhoes = new HashSet<TonKho>();
            TTPhieuNhaps = new HashSet<TTPhieuNhap>();
            TTPhieuXuats = new HashSet<TTPhieuXuat>();
        }

        [Key]
        public int Id_ts { get; set; }

        [Required]
        [StringLength(30)]
        public string ten { get; set; }

        [Column(TypeName = "money")]
        public decimal gia_ban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TonKho> TonKhoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPhieuNhap> TTPhieuNhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPhieuXuat> TTPhieuXuats { get; set; }
    }
}
