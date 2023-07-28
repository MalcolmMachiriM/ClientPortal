using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PenPortfolio.Data
{
    public partial class cn : DbContext
    {
        public cn()
            : base("name=cn")
        {
        }

        public virtual DbSet<Contribution> Contributions { get; set; }
        public virtual DbSet<FundExit> FundExits { get; set; }
        public virtual DbSet<FundExitsQuotation> FundExitsQuotations { get; set; }
        public virtual DbSet<FundExitsTemp> FundExitsTemps { get; set; }
        public virtual DbSet<ContributionsFileUpload> ContributionsFileUploads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribution>()
                .Property(e => e.BackPay)
                .HasPrecision(30, 8);

            modelBuilder.Entity<FundExit>()
                .Property(e => e.RegNo)
                .IsUnicode(false);

            modelBuilder.Entity<FundExit>()
                .Property(e => e.Paye)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExit>()
                .Property(e => e.TotalBenefit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExit>()
                .Property(e => e.LifeAssurance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExit>()
                .Property(e => e.ReassuredCover)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.RegNo)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.FundName)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.FundTaxNum)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.FundPostalAdd)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.SpouseGender)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.ChildAName)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.ChildBName)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.ChildCName)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsQuotation>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            //modelBuilder.Entity<FundExitsQuotation>()
            //    .HasOptional(e => e.FundExitsQuotations1)
            //    .WithRequired(e => e.FundExitsQuotation1);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.RegNo)
                .IsUnicode(false);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.MemberPortAtBonusDate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.EmployerPortAtBonusDate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.MemberContSinceLastReviewWithoutInt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.EmployerContSinceLastReviewWithoutInt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.MemberContSinceLastReviewWithInt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.EmployerContSinceLastReviewWithInt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.MemberPortAtExitDate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.EmployerPortAtExitDate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.AccumAtExit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.AccumAtPayment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.AccumAtReview)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.Third_Commutation)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.GLA_Entilement)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.Benefit_Transfered_In)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.Reassured_Cover)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.Lumpsum_payable)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.AdvancePayment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.NetLumpsumPayable)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.SpouseMonthlyPension)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.ChildMonthlyPension)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.PensionArrears)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.LumpsumPayableWithIntrest)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.ThirdComutationWithIntrest)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.ResidualConsideration)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.AnnualPension)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.MiAnnualPension)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.CapitalValue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.EnhResCons)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.EnhMonthlyP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.MonthlyPension)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FundExitsTemp>()
                .Property(e => e.EnhResAnnualP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.MemberSalary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.MemberContributions)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.EmployerContributions)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.MemberTransferIn)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.EmployerTransferIn)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.MemberOther)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.EmployerOther)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.VoluntaryContributions)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.MemberContPerc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.CompanyContPerc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.CostPercentage)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.GrossEmployerContribution)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.Expenses)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.ExpectedMember)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.ExpectedEmployer)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.MemberPort)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ContributionsFileUpload>()
                .Property(e => e.EmployerPort)
                .HasPrecision(19, 4);
        }
    }
}
