namespace QL_ThuySan.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhap()
        {
            TTPhieuNhaps = new HashSet<TTPhieuNhap>();
        }

        [Key]
        public int Id_pn { get; set; }

        public int id_kho { get; set; }

        public int id_ncp { get; set; }

        public DateTime ngay_nhap { get; set; }

        public bool da_nhap { get; set; }

        public virtual Kho Kho { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPhieuNhap> TTPhieuNhaps { get; set; }
    }
}
