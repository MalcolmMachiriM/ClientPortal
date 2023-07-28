namespace PenPortfolio.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FundExit
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegNo { get; set; }

        public int MemberID { get; set; }

        public DateTime ExitDate { get; set; }

        public DateTime CalculationDate { get; set; }

        public int ExitCode { get; set; }

        public double AgeOnExit { get; set; }

        public double PensionableService { get; set; }

        public double AnualSalary { get; set; }

        public DateTime? ReservationDate { get; set; }

        public double? AccruedReserve { get; set; }

        public double? XContribution { get; set; }

        public double? YContribution { get; set; }

        public double? AccruedReserveAtExit { get; set; }

        public double? ConversionFactor { get; set; }

        public double? PostReserveService { get; set; }

        public double? PensionBeforeCommutation { get; set; }

        public double? Commutation { get; set; }

        public double? ResidualPension { get; set; }

        public double? ResidualConsideration { get; set; }

        public double? EmployerAmountTo { get; set; }

        public int? UserID { get; set; }

        public bool Authorised { get; set; }

        public int? AuthorisedBy { get; set; }

        public DateTime? DateAuthorised { get; set; }

        [Column(TypeName = "money")]
        public decimal? Paye { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalBenefit { get; set; }

        [Column(TypeName = "money")]
        public decimal? LifeAssurance { get; set; }

        [Column(TypeName = "money")]
        public decimal? ReassuredCover { get; set; }

        public int? CheckedBy { get; set; }

        public bool? Checked { get; set; }

        [StringLength(5)]
        public string PaymentType { get; set; }

        [StringLength(5)]
        public string PensionType { get; set; }

        public bool? CheckRequestPrinted { get; set; }

        public int? CheckRequestPrintedBy { get; set; }

        public bool? TransferredToPayroll { get; set; }

        [StringLength(50)]
        public string TransferredBy { get; set; }

        [StringLength(50)]
        public string TransferReason { get; set; }

        public bool? AccountsPosted { get; set; }

        public int? AccountsPostedBy { get; set; }

        public DateTime? PaymentDate { get; set; }

        public DateTime? DateChecked { get; set; }

        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "image")]
        public byte[] CheckSignature { get; set; }

        [Column(TypeName = "image")]
        public byte[] AuthorisationSignature { get; set; }

        public Guid msrepl_tran_version { get; set; }

        public int? ClaimStatusID { get; set; }
    }
}
