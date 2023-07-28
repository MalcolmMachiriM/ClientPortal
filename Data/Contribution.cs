namespace PenPortfolio.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contribution
    {
        public int ID { get; set; }

        public int? MemberID { get; set; }

        [StringLength(50)]
        public string NationalID { get; set; }

        [Required]
        [StringLength(50)]
        public string Period { get; set; }

        public double Salary { get; set; }

        [StringLength(50)]
        public string RegNo { get; set; }

        public DateTime PaymentDate { get; set; }

        public double XContribution { get; set; }

        public double YContribution { get; set; }

        public double ZContribution { get; set; }

        public double? GrossYContribution { get; set; }

        public double? Expenses { get; set; }

        public double? ExpectedX { get; set; }

        public double? ExpectedY { get; set; }

        public int? UserID { get; set; }

        public DateTime DateCaptured { get; set; }

        public Guid TransID { get; set; }

        public Guid? BatchID { get; set; }

        public double TransferInMember { get; set; }

        public double TransferInEmployer { get; set; }

        public double OtherMember { get; set; }

        public double OtherEmployer { get; set; }

        public double Total { get; set; }

        public bool? isStartup { get; set; }

        [Column(TypeName = "numeric")]
        public decimal BackPay { get; set; }

        [StringLength(20)]
        public string BranchCode { get; set; }

        [StringLength(20)]
        public string Platform { get; set; }

        public DateTime LatestUpdateDate { get; set; }

        public bool? IsHistory { get; set; }

        public DateTime? PeriodDate { get; set; }

        [StringLength(50)]
        public string MyKey { get; set; }

        public int? CompanyID { get; set; }

        [StringLength(50)]
        public string SplittedRegNo { get; set; }

        public int? SplittedMemberID { get; set; }

        public int? SplittedBrachCode { get; set; }

        public DateTime? DateSplitted { get; set; }

        public int? BonusTypeID { get; set; }

        public string BatchNo { get; set; }
    }
}
