namespace PenPortfolio.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContributionsFileUpload")]
    public partial class ContributionsFileUpload
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfUpload { get; set; }

        public int? CompanyID { get; set; }

        public int? CreatedBy { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberSalary { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberContributions { get; set; }

        [Column(TypeName = "money")]
        public decimal? EmployerContributions { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberTransferIn { get; set; }

        [Column(TypeName = "money")]
        public decimal? EmployerTransferIn { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberOther { get; set; }

        [Column(TypeName = "money")]
        public decimal? EmployerOther { get; set; }

        [Column(TypeName = "money")]
        public decimal? VoluntaryContributions { get; set; }

        public DateTime? DateCreated { get; set; }

        [StringLength(50)]
        public string Period { get; set; }

        [StringLength(50)]
        public string EmployerCode { get; set; }

        [StringLength(50)]
        public string EmployerName { get; set; }

        [StringLength(50)]
        public string SystemRefNo { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Forenames { get; set; }

        [StringLength(50)]
        public string IDNumber { get; set; }

        [StringLength(50)]
        public string BranchCode { get; set; }

        [StringLength(50)]
        public string RegNo { get; set; }

        public int? UploadBatchID { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberContPerc { get; set; }

        [Column(TypeName = "money")]
        public decimal? CompanyContPerc { get; set; }

        [Column(TypeName = "money")]
        public decimal? CostPercentage { get; set; }

        [Column(TypeName = "money")]
        public decimal? GrossEmployerContribution { get; set; }

        [Column(TypeName = "money")]
        public decimal? Expenses { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExpectedMember { get; set; }

        [Column(TypeName = "money")]
        public decimal? ExpectedEmployer { get; set; }

        [StringLength(250)]
        public string ValidationMessage { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberPort { get; set; }

        [Column(TypeName = "money")]
        public decimal? EmployerPort { get; set; }

        public int? ProcessStatusID { get; set; }

        public string BatchNo { get; set; }

        public bool? Isprocessed { get; set; }
    }
}
