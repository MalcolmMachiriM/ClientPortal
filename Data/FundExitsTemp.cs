namespace PenPortfolio.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FundExitsTemp")]
    public partial class FundExitsTemp
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegNo { get; set; }

        public int MemberID { get; set; }

        public DateTime? ExitDate { get; set; }

        public DateTime? CalculationDate { get; set; }

        public int ExitCode { get; set; }

        public double AnualSalary { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string IDNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberPortAtBonusDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? EmployerPortAtBonusDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberContSinceLastReviewWithoutInt { get; set; }

        [Column(TypeName = "money")]
        public decimal? EmployerContSinceLastReviewWithoutInt { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberContSinceLastReviewWithInt { get; set; }

        [Column(TypeName = "money")]
        public decimal? EmployerContSinceLastReviewWithInt { get; set; }

        [Column(TypeName = "money")]
        public decimal? MemberPortAtExitDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? EmployerPortAtExitDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? AccumAtExit { get; set; }

        [Column(TypeName = "money")]
        public decimal? AccumAtPayment { get; set; }

        [Column(TypeName = "money")]
        public decimal? AccumAtReview { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? BonusDate { get; set; }

        public DateTime? DJF { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public decimal? TotalPensionableService { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? MemberPortAtBonusDateFundA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EmployerPortAtBonusDateFundA { get; set; }

        [StringLength(100)]
        public string PensionNo { get; set; }

        [Column(TypeName = "money")]
        public decimal? Third_Commutation { get; set; }

        [Column(TypeName = "money")]
        public decimal? GLA_Entilement { get; set; }

        [Column(TypeName = "money")]
        public decimal? Benefit_Transfered_In { get; set; }

        [Column(TypeName = "money")]
        public decimal? Reassured_Cover { get; set; }

        [Column(TypeName = "money")]
        public decimal? Lumpsum_payable { get; set; }

        [Column(TypeName = "money")]
        public decimal? AdvancePayment { get; set; }

        [Column(TypeName = "money")]
        public decimal? NetLumpsumPayable { get; set; }

        [Column(TypeName = "money")]
        public decimal? SpouseMonthlyPension { get; set; }

        [Column(TypeName = "money")]
        public decimal? ChildMonthlyPension { get; set; }

        [Column(TypeName = "money")]
        public decimal? PensionArrears { get; set; }

        [Column(TypeName = "money")]
        public decimal? LumpsumPayableWithIntrest { get; set; }

        [Column(TypeName = "money")]
        public decimal? ThirdComutationWithIntrest { get; set; }

        public int? MemberAge { get; set; }

        [Column(TypeName = "money")]
        public decimal? ResidualConsideration { get; set; }

        [Column(TypeName = "money")]
        public decimal? AnnualPension { get; set; }

        [Column(TypeName = "money")]
        public decimal? MiAnnualPension { get; set; }

        [Column(TypeName = "money")]
        public decimal? CapitalValue { get; set; }

        [Column(TypeName = "money")]
        public decimal? EnhResCons { get; set; }

        [Column(TypeName = "money")]
        public decimal? EnhMonthlyP { get; set; }

        public decimal? ConversionFactor { get; set; }

        [Column(TypeName = "money")]
        public decimal? MonthlyPension { get; set; }

        [StringLength(200)]
        public string Exit_Type { get; set; }

        public DateTime? DeathDate { get; set; }

        [StringLength(200)]
        public string TotalPS { get; set; }

        public DateTime? PensionCommencementDate { get; set; }

        public int? PeriodAfterExit { get; set; }

        [Column(TypeName = "money")]
        public decimal? EnhResAnnualP { get; set; }

        [StringLength(30)]
        public string Platform { get; set; }
    }
}
