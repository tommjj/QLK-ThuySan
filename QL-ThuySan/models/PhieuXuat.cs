namespace QL_ThuySan.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuat")]
    public partial class PhieuXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuat()
        {
            TTPhieuXuats = new HashSet<TTPhieuXuat>();
        }

        [Key]
        public int Id_px { get; set; }

        public int Id_kho { get; set; }

        public int id_kh { get; set; }

        public DateTime ngay_xuat { get; set; }

        public bool da_xuat { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Kho Kho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPhieuXuat> TTPhieuXuats { get; set; }
    }
}
