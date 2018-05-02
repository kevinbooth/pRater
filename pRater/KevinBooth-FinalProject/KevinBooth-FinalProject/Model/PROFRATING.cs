namespace KevinBooth_FinalProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROFRATING")]
    public partial class PROFRATING
    {
        [Key]
        public int RatingId { get; set; }

        public int ProfessorId { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

        public bool UseText { get; set; }

        [Column("ProfRating")]
        public int ProfRating1 { get; set; }

        public int DiffRating { get; set; }

        [Required]
        [StringLength(255)]
        public string ClassTaken { get; set; }

        [Required]
        [StringLength(1)]
        public string GradeReceived { get; set; }

        public DateTime UploadDate { get; set; }

        public virtual PROFESSOR PROFESSOR { get; set; }
    }
}
