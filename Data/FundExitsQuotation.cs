namespace PenPortfolio.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FundExitsQuotation
    {
        public int ID { get; set; }


        [StringLength(50)]
        public string RegNo { get; set; }

        public int SystemRef { get; set; }


        [StringLength(25)]
        public string NationalID { get; set; }


        [StringLength(100)]
        public string Surname { get; set; }


        [StringLength(50)]
        public string SecondSurname { get; set; }


        [StringLength(50)]
        public string Firstname { get; set; }


        [StringLength(10)]
        public string Gender { get; set; }

        public DateTime DateOfExit { get; set; }

        public DateTime CalculationDate { get; set; }

        public DateTime DateJoinedFund { get; set; }

        public DateTime DOB { get; set; }

        public int ExitCode { get; set; }

        public double MemberAge { get; set; }

        public double TotalPS { get; set; }

        public double Salary { get; set; }

        public double MemberCont { get; set; }

        public double EmployerCont { get; set; }

        public double MemberContInt { get; set; }

        public double EmployerContInt { get; set; }

        public double MemberPortLastReview { get; set; }

        public double MemberPortExit { get; set; }

        public double EmployerPortExit { get; set; }

        public double EmployerPortLastReview { get; set; }

        public double MemberPortionAtPayment { get; set; }

        public double EmployerPortionAtPayment { get; set; }

        public DateTime NormalRet { get; set; }

        public DateTime BonusDate { get; set; }


        [StringLength(200)]
        public string FundName { get; set; }

        [StringLength(50)]
        public string FundTaxNum { get; set; }

        [StringLength(150)]
        public string FundPostalAdd { get; set; }


        public double? BenefitAmount { get; set; }

        [StringLength(200)]
        public string BenefitDescription { get; set; }

        public double? ThirdCommutation { get; set; }

        public double? ThirdComutationWithInterest { get; set; }

        public double? AccumulationWithInterest { get; set; }

        public double? ResidualConsid { get; set; }

        public double? ConversionFactor { get; set; }

        public double? AnnualPension { get; set; }

        public double? MonthlyPension { get; set; }

        [StringLength(50)]
        public string ExitType { get; set; }

        public double? MinAnnualPension { get; set; }

        public double? CapitalValue { get; set; }

        public double? EnhResCons { get; set; }

        public double? EnhResAnnualP { get; set; }

        public double? EnhMontlyP { get; set; }

        public double? CoverMultiple { get; set; }

        public double? GLAEntitlement { get; set; }

        public double? ReassuredCover { get; set; }

        public double? LumpsumPayable { get; set; }

        public double? NetLumpsumPayable { get; set; }

        public double? NetLumpsumPayableWithInterest { get; set; }

        public double? MemberBenefitTax { get; set; }

        public double? AddAwardTax { get; set; }

        public DateTime? PensionCommenceDate { get; set; }

        public int? PeriodAfterExit { get; set; }

        public double? PensionArrears { get; set; }

        public double? AdvancePayment { get; set; }

        public DateTime? SpouseDOB { get; set; }

        public double? SpouseAge { get; set; }

        [StringLength(10)]
        public string SpouseGender { get; set; }

        public double? SpouseConversionFactor { get; set; }

        public double? SpouseAnnualPension { get; set; }

        public double? SpouseMonthlyPension { get; set; }

        [StringLength(50)]
        public string ChildAName { get; set; }

        [StringLength(50)]
        public string ChildBName { get; set; }

        [StringLength(50)]
        public string ChildCName { get; set; }

        public DateTime? ChildADOB { get; set; }

        public DateTime? ChildBDOB { get; set; }

        public DateTime? ChildCDOB { get; set; }

        public double? ChildAFactor { get; set; }

        public double? ChildBFactor { get; set; }

        public double? ChildCFactor { get; set; }

        public double? ChildAnnualPension { get; set; }

        public int? CompanyCode { get; set; }

        public double? ChildMonthlyPension { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public double? BenefitTransferedIn { get; set; }

        public DateTime? ActualExitDate { get; set; }

        public int? UserID { get; set; }

        public bool? Authorised { get; set; }

        public int? AuthorisedBy { get; set; }

        public DateTime? DateAuthorised { get; set; }

        public double? Paye { get; set; }

        public int? CheckedBy { get; set; }

        public bool? Checked { get; set; }

        [StringLength(5)]
        public string PaymentType { get; set; }

        [StringLength(5)]
        public string PensionType { get; set; }

        public DateTime? DateChecked { get; set; }

        public DateTime? DateCreated { get; set; }

        [Column(TypeName = "image")]
        public byte[] CheckSignature { get; set; }

        [Column(TypeName = "image")]
        public byte[] AuthorisationSignature { get; set; }

        [StringLength(50)]
        public string DeathLAccName { get; set; }

        [StringLength(50)]
        public string DeathLBankName { get; set; }

        [StringLength(50)]
        public string DeathLBankBranch { get; set; }

        [StringLength(50)]
        public string DeathLBankBranchCode { get; set; }

        [StringLength(50)]
        public string DeathLAccNumber { get; set; }

        public int? ReceivedBy { get; set; }

        public DateTime? DateReceived { get; set; }

        public DateTime? DateReported { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        public Guid msrepl_tran_version { get; set; }

        public int? ClaimStatusID { get; set; }
    }
}