using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PenPortfolio.Model
{
    public class LookUp
    {
        Menu objMenu;
        protected string mMsgFlg;
        protected Database db;
        protected Database dbcc;
        protected Database dbPay;
        protected string mConnectionName;
        protected DataSet mMemberDs;
        protected long mParentID;
        protected long mPensionNo;
        protected long mMemberID;
        protected long mFormerCoID;
        protected long mOldPensionNo;
        protected long mFundGroup;
        protected long mLastModifiedBy;
        protected string mLastPayDate;
        protected string mLastPayIncreaseDate;
        protected string mDateOfBirth;
        protected string mDateJoinedPayroll;
        protected string mPensionStartDate;
        protected string mTerminationDate;
        protected string mFormerDOB;
        protected string mFormerDJF;
        protected string mFormerDJC;
        protected string mFormerExitDate;
        protected string mLastExistanceDate;
        protected string mDateUploaded;
        protected string mDateModified;
        protected float mAnnualSalary;
        protected float mMonthlySalary;
        protected float mFormerAnnualSalaryExit;
        protected float mPrevMonthlySalary;
        protected bool mActive;
        protected bool mDeclared;
        protected string mMonthsSuspended;
        protected string mPayPeriod;
        protected string mPensionType;
        protected string mRegNo;
        protected string mCostCentre;
        protected string mLastName;
        protected string mFirstName;
        protected string mGender;
        protected string mPensionBasis;
        protected string mFormerfirstName;
        protected string mFormerLastName;
        protected string mFormerCoName;
        protected string mAddressLine1;
        protected string mAddressLine2;
        protected string mAddressLine3;
        protected string mTelephoneNo;
        protected string mMobileNo;
        protected string mEmail;
        protected string mBankAccountNo;
        protected string mBankName;
        protected string mBankBranchName;
        protected string mBankBranchCode;
        protected string mBankAccountSurname;
        protected string mBankAccountFirstName;
        protected string mTitle;
        protected string mMaritalStatus;
        protected string mNationalID;
        protected string mPassportNo;
        protected string mTerminationCode;

        protected string mTaxCode;
        public DataSet MemberDs
        {
            get { return mMemberDs; }
            set { mMemberDs = value; }
        }
        public long ParentID
        {
            get { return mParentID; }
            set { mParentID = value; }
        }




        protected long mObjectUserID;
        public DataSet getRoles()
        {
            string str = "select * from Portal_Roles";
            return ReturnDs(str);
        }
        public string MsgFlg
        {
            get { return mMsgFlg; }
            set { mMsgFlg = value; }
        }
        public Database Database
        {
            get { return db; }
        }
        public long PensionNo
        {
            get { return mPensionNo; }
            set { mPensionNo = value; }
        }

        public long MemberID
        {
            get { return mMemberID; }
            set { mMemberID = value; }
        }

        public long FormerCoID
        {
            get { return mFormerCoID; }
            set { mFormerCoID = value; }
        }

        public long OldPensionNo
        {
            get { return mOldPensionNo; }
            set { mOldPensionNo = value; }
        }

        public long FundGroup
        {
            get { return mFundGroup; }
            set { mFundGroup = value; }
        }

        public long LastModifiedBy
        {
            get { return mLastModifiedBy; }
            set { mLastModifiedBy = value; }
        }

        public string LastPayDate
        {
            get { return mLastPayDate; }
            set { mLastPayDate = value; }
        }

        public string LastPayIncreaseDate
        {
            get { return mLastPayIncreaseDate; }
            set { mLastPayIncreaseDate = value; }
        }

        public string DateOfBirth
        {
            get { return mDateOfBirth; }
            set { mDateOfBirth = value; }
        }

        public string DateJoinedPayroll
        {
            get { return mDateJoinedPayroll; }
            set { mDateJoinedPayroll = value; }
        }

        public string PensionStartDate
        {
            get { return mPensionStartDate; }
            set { mPensionStartDate = value; }
        }

        public string TerminationDate
        {
            get { return mTerminationDate; }
            set { mTerminationDate = value; }
        }

        public string FormerDOB
        {
            get { return mFormerDOB; }
            set { mFormerDOB = value; }
        }

        public string FormerDJF
        {
            get { return mFormerDJF; }
            set { mFormerDJF = value; }
        }

        public string FormerDJC
        {
            get { return mFormerDJC; }
            set { mFormerDJC = value; }
        }

        public string FormerExitDate
        {
            get { return mFormerExitDate; }
            set { mFormerExitDate = value; }
        }

        public string LastExistanceDate
        {
            get { return mLastExistanceDate; }
            set { mLastExistanceDate = value; }
        }

        public string DateUploaded
        {
            get { return mDateUploaded; }
            set { mDateUploaded = value; }
        }

        public string DateModified
        {
            get { return mDateModified; }
            set { mDateModified = value; }
        }

        public float AnnualSalary
        {
            get { return mAnnualSalary; }
            set { mAnnualSalary = value; }
        }

        public float MonthlySalary
        {
            get { return mMonthlySalary; }
            set { mMonthlySalary = value; }
        }

        public float FormerAnnualSalaryExit
        {
            get { return mFormerAnnualSalaryExit; }
            set { mFormerAnnualSalaryExit = value; }
        }

        public float PrevMonthlySalary
        {
            get { return mPrevMonthlySalary; }
            set { mPrevMonthlySalary = value; }
        }

        public bool Active
        {
            get { return mActive; }
            set { mActive = value; }
        }

        public bool Declared
        {
            get { return mDeclared; }
            set { mDeclared = value; }
        }

        public string MonthsSuspended
        {
            get { return mMonthsSuspended; }
            set { mMonthsSuspended = value; }
        }

        public string PayPeriod
        {
            get { return mPayPeriod; }
            set { mPayPeriod = value; }
        }

        public string PensionType
        {
            get { return mPensionType; }
            set { mPensionType = value; }
        }

        public string RegNo
        {
            get { return mRegNo; }
            set { mRegNo = value; }
        }

        public string CostCentre
        {
            get { return mCostCentre; }
            set { mCostCentre = value; }
        }

        public string LastName
        {
            get { return mLastName; }
            set { mLastName = value; }
        }

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string Gender
        {
            get { return mGender; }
            set { mGender = value; }
        }

        public string PensionBasis
        {
            get { return mPensionBasis; }
            set { mPensionBasis = value; }
        }

        public string FormerfirstName
        {
            get { return mFormerfirstName; }
            set { mFormerfirstName = value; }
        }

        public string FormerLastName
        {
            get { return mFormerLastName; }
            set { mFormerLastName = value; }
        }

        public string FormerCoName
        {
            get { return mFormerCoName; }
            set { mFormerCoName = value; }
        }

        public string AddressLine1
        {
            get { return mAddressLine1; }
            set { mAddressLine1 = value; }
        }

        public string AddressLine2
        {
            get { return mAddressLine2; }
            set { mAddressLine2 = value; }
        }

        public string AddressLine3
        {
            get { return mAddressLine3; }
            set { mAddressLine3 = value; }
        }

        public string TelephoneNo
        {
            get { return mTelephoneNo; }
            set { mTelephoneNo = value; }
        }

        public string MobileNo
        {
            get { return mMobileNo; }
            set { mMobileNo = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string BankAccountNo
        {
            get { return mBankAccountNo; }
            set { mBankAccountNo = value; }
        }

        public string BankName
        {
            get { return mBankName; }
            set { mBankName = value; }
        }

        public string BankBranchName
        {
            get { return mBankBranchName; }
            set { mBankBranchName = value; }
        }

        public string BankBranchCode
        {
            get { return mBankBranchCode; }
            set { mBankBranchCode = value; }
        }

        public string BankAccountSurname
        {
            get { return mBankAccountSurname; }
            set { mBankAccountSurname = value; }
        }

        public string BankAccountFirstName
        {
            get { return mBankAccountFirstName; }
            set { mBankAccountFirstName = value; }
        }

        public string Title
        {
            get { return mTitle; }
            set { mTitle = value; }
        }

        public string MaritalStatus
        {
            get { return mMaritalStatus; }
            set { mMaritalStatus = value; }
        }

        public string NationalID
        {
            get { return mNationalID; }
            set { mNationalID = value; }
        }

        public string PassportNo
        {
            get { return mPassportNo; }
            set { mPassportNo = value; }
        }

        public string TerminationCode
        {
            get { return mTerminationCode; }
            set { mTerminationCode = value; }
        }

        public string TaxCode
        {
            get { return mTaxCode; }
            set { mTaxCode = value; }
        }
        public string OwnerType
        {
            get { return this.GetType().Name; }
        }

        public string ConnectionName
        {
            get { return mConnectionName; }
        }

        public LookUp(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);
            dbPay = new DatabaseProviderFactory().Create("pr");
            dbcc = new DatabaseProviderFactory().Create("accCon");
        }
        public bool CheckBeneficiaryRecordExists(int MemberId)
        {
            try
            {
                string str = "select * from MemberBeneficiaries where MemberID='" + MemberId + "' ";
                if (ReturnDs(str) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public DataSet getClaimsByStatus()
        {
            string str = "select Cl.ID,M.EmployeeReferenceNumber,M.LastName+' '+m.FirstName AS  MemberName, cts.Description as ClaimType,convert(varchar,Cl.ClaimReportDate,103) as DateLodged  from ClaimsLogs Cl inner join Member M on M.ID = Cl.MemberID inner join ClaimTypes cts on cts.ID = Cl.ClaimTypeID ";
            return ReturnDs(str);
        }
        public DataSet getePeriodDateDiff(DateTime dt1, DateTime dt2)
        {
            string dt1s = dt1.ToString("yyyy-MM-dd");
            string dt2s = dt2.ToString("yyyy-MM-dd");

            string str = "select (DATEDIFF(MM,'" + dt1s + "','" + dt2s + "')) as result";
            return ReturnDs(str);
        }
        public DataSet ViewPortalQuery(string Regno, long PensionNo)
        {
            string str = "select top 1 convert(date,a.DateCreated) as LoggedDate, * from PortalLoggedQueries a where a.RegNo='" + Regno + "' and a.ID ='" + PensionNo + "' order by a.id desc";
            return ReturnDs(str);
        }
        public DataSet GetAdminUsers(string  Email)
        {
            string str = "select * from Users where Email='"+ Email + "'";
            return ReturnDs(str);
        }
        public DataSet getRetDateDiff(DateTime dt1, DateTime dt2)
        {
            string dt1s = dt1.ToString("yyyy-MM-dd");
            string dt2s = dt2.ToString("yyyy-MM-dd");

            string str = "select (DATEDIFF(MM,'" + dt1s + "','" + dt2s + "'))/12 as result";
            return ReturnDs(str);
        }
        public DataSet getFundEligibilityRequirements(string RegNo)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("EligibilityRequirements_Sel_ByRegNo");
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetUploads(bool ProcessID, long Batch, string Reg)
        {
            string str = "select * from ClientsFileUpload where ProcessStatusID='"+ ProcessID + "' and RegNo='"+ Reg + "' and UploadBatchID='"+ Batch + "'";
            return ReturnDs(str);
        }
        public string getRegName(long FundID)
        {
            try
            {
                string str = "select RegName from FUND where [Key]=" + FundID + "";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }

        public DataSet GetFailedMemberUploads(string RegNo)
        {
            string str = "select * from FailedMemberUploads where RegNo='" + RegNo + "'";
            return ReturnDs(str);
        }
        public DataSet getclientuploaded(long UploadID, string Reg)
        {
            string str = "SELECT [ID],[EmployerName],[Surname],[Forenames],[IDNumber],[Gender],[DateOfBirth] FROM ClientsFileUpload where UploadBatchID = '" + UploadID + "' and ProcessStatusID = 0 and RegNo = '" + Reg + "'";
            return ReturnDs(str);
        }
        public bool ValidateMemberIDNumber(string IDNumber, string RegNo)
        {
            try
            {
                string str = "SELECT top 1 * FROM member where IdentityNo='" + IDNumber + "' and RegNo='" + RegNo + "'";
                if (ReturnDs(str) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public bool ValidateEmailAddress(string LoginCode)
        {
            try
            {
                string str = "select * from Portal_Users where LoginCode='"+ LoginCode + "'";
                if (ReturnDs(str) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public bool ValidatePassword(string Password, string LoginCode)
        {
            try
            {
                string str = "select * from Portal_Users where Password = '"+ Password + "' and LoginCode='"+ LoginCode + "'";
                if (ReturnDs(str) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public DataSet ChangePassword(string LoginCode, string newPass)
        {
            string str = " UPDATE Portal_Users SET Password = '" + newPass + "' WHERE LoginCode = '"+ LoginCode + "'";

            return ReturnDs(str);
        }
        public DataSet GetUploadedEmployee(int empid)
        {
            try
            {
                string str = "SELECT TOP 1 * from EmployeesUploadBatch where EmployerID='" + empid + "' order by id DESC";
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getPayRollBranches()
        {
            string str = "select * from BankBranches";
            return ReturnDsPayRoll(str);
        }
        public DataSet getPayRollBanks()
        {
            string str = "Select * from Banks";
            return ReturnDsPayRoll(str);
        }
        public DataSet getDependants(long PensionNo)
        {
            string str = "select * from PayPensioner where PensionBasis not in('member') and PensionNo='"+ PensionNo + "'";
            return ReturnDsPayRoll(str);
        }
        //public DataSet getQueries(long PensionNo)
        //{
        //    string str = "SELECT * FROM PortalLoggedQueries where PensionNo='"+ PensionNo + "'";
        //    return ReturnDs(str);
        //}
        public DataSet getQueries(long PensionNo, string RegNo,string Type)
        {
            try
            {
                string str = "SELECT PensionNo,City,QueryType,ID,Description,Subject,case when isSolved =1 then 'Actioned' else 'Pending' End as isSolved,convert(varchar(12),DateCreated,110) DateCreated FROM PortalLoggedQueries where PensionNo='" + PensionNo + "' and RegNo='"+RegNo+"' and Type='"+Type+"'";

                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getFundDetails(string RegNo)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Fund_Sel_ByRegNo_Fund_In_Use");
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetReceiptsUtilisationHistory(string RegNo,int BranchCode, DateTime PeriodDate)
        {
            try
            {
                System.Data.Common.DbCommand cmd = dbcc.GetStoredProcCommand("Receipts_Sel_ByPeriod_BranchCode");
                dbcc.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                dbcc.AddInParameter(cmd, "@PeriodDate", DbType.Date, PeriodDate);
                dbcc.AddInParameter(cmd, "@BranchCode", DbType.Int32, BranchCode);
                DataSet ds = dbcc.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetContributionPeriodDates(string RegNo, int BranchCode, DateTime PeriodFromDate, DateTime PeriodToDate)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetContributionPeriodDates");
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@BranchCode", DbType.Int32, BranchCode);
                db.AddInParameter(cmd, "@PaymentDateFrom", DbType.Date, PeriodFromDate);
                db.AddInParameter(cmd, "@PaymentDateTo", DbType.Date, PeriodToDate);
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        
        public string getRegNo(long FundID)
        {
            try
            {
                string str = "select RegNo from FUND where [Key]=" + FundID + "";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }
        public string getBranchId(int memberId)
        {
            try
            {
                string str = "select BranchId from Member where ID ="+memberId;
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }
        //public string getSplittedRegNo(long FundID)
        //{
        //    try
        //    {
        //        string str = "select SplittedRegNo from FUND where [Key]=" + FundID + "";
        //        DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            return ds.Tables[0].Rows[0][0].ToString();
        //        }
        //        else
        //        {
        //            return "XXX";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        mMsgFlg = ex.Message;
        //        return "XXX";
        //    }
        //}

        public string getFundCurrency(string FundID)
        {
            try
            {
                string str = "SELECT c.Code  FROM FUND f left join FundType ft on f.FundType=ft.ID left join Currencies c on f.DefaultCurrencyID =c.ID  WHERE RegNo = '"+ FundID + "'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "ZWL";
                }
            }
            catch (Exception ex)


            {
                mMsgFlg = ex.Message;
                return "ZWL";
            }
        }
        public string getFundID(string Reg)
        {
            try
            {
                string str = "select [Key] from FUND where [RegNo]= '"+Reg+"'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }
        public string getSystemRef(string FundID,string LoginCode)
        {
            try
            {
                string str = "Select SystemRef from Portal_Users where RegNo ='" + FundID + "' and LoginCode='"+ LoginCode + "'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }

        //public DataSet getFundDetails(string RegNo)
        //{
        //    try
        //    {
        //        System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Fund_Sel_ByRegNo_Fund_In_Use");
        //        db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
        //        DataSet ds = db.ExecuteDataSet(cmd);


        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            return ds;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        mMsgFlg = ex.Message;
        //        return null;
        //    }
        //}
        public DataSet getBonusBranches(string Regno)
        {
            string str = "select  distinct(BranchId),b.Name,b.CompanyID,a.RegNo,b.RegNo from Member a inner join ParticipatingEmployer b on a.BranchId = b.ID where a.RegNo = '" + Regno + "' and b.RegNo=Replace( Replace('" + Regno + "','/#',''),'#','') ";
            return ReturnDs(str);
        }
        public DataSet getDocumentTypes()
        {
            string str = "select * from IdentityDocumentTypes";
            return ReturnDs(str);
        }
        public DataSet getCostCenter(string branchId)
        {
            try
            {
                string str = "select c.Name,* from ParticipatingEmployer pe inner join Companies c on pe.CompanyID=c.ID where pe.ID =" + branchId;
                return ReturnDs(str);
            }
            catch (Exception cx)
            {

                MsgFlg= cx.Message;
                return null;
            }
            
        }
        public DataSet getcostcenter(int fundID,int BranchCode)
        {
            string str = "";
            string RegNo = getRegNo(fundID);
            string newReg = "";

            //if (RegNo.StartsWith("N"))
            //{
            //    str = "select ID,Name from Companies where RegNo=Replace( Replace('" + RegNo + "','/#',''),'#','') and and ID='" + BranchCode + "'";
            //}
            //else if (RegNo.Contains("#"))
            //{
            //    newReg = RegNo.Substring(0, RegNo.LastIndexOf("/"));
            //    str = "select ID,Name from Companies where RegNo='" + newReg + "' and ID='" + BranchCode + "'";
            //}
            //else
            //{
                //newReg = RegNo.Substring(0, RegNo.LastIndexOf("/"));
                str = "select ID,Name from Companies where RegNo='" + RegNo + "' and ID='"+ BranchCode + "'";

            //}

            //string newRegNO = RegNo.Substring(0, RegNo.LastIndexOf("/"));

            return ReturnDs(str);
        }
        public DataSet getFundUploadPeriods(int FundID)
        {
            try
            {
                string str = "";
                string RegNo = "";
                //Fund f = new Fund(mConnectionName, mObjectUserID);
                RegNo = getRegNo(FundID);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("PeriodSetup_SelByActive");
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getCalendarMonths()
        {
            try
            {
                string str = "select * from MonthsCalendar";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet ValidateIdentityNumberMember(string IDnum, string reg)
        {
            int ID = int.Parse(IDnum);
            string str = "select * from Member where ID ='" + ID + "' and RegNo='" + reg + "'";
            //string str = "select * from Member where IdentityNo ='" + IDnum + "'";

            return ReturnDs(str);
        }
        public DataSet getcontributionuploaded(string UploadID, string RegNo)
        {
            string str = "SELECT [SystemRefNo],[IDNumber],[MemberSalary],[Surname],[Forenames],[MemberContributions],EmployerContributions as CompanyContributions,[VoluntaryContributions] FROM ContributionsFileUpload where BatchNo = '" + UploadID + "' and Isprocessed = 0 and RegNo='" + RegNo + "' order by id desc";
            return ReturnDs(str);
        }
        public DataSet GetFailedContributions(string RegNo)
        {
            string str = "select * from FailedContributionUploads where RegNo='" + RegNo + "'";
            return ReturnDs(str);
        }
        public DataSet getInterestRates(string BatchID, string RegNo, DateTime EffectiveDate,string Type)
        {
            string gg = EffectiveDate.ToString("yyyy-MM-dd");
            try
            {
                string str = "";
                if (Type == "C")
                {
                    str = "SELECT TOP (1) MemberContPerc,CompanyContPerc FROM  dbo.ContributionsRates WHERE (EffectiveDate <= '" + gg + "') AND (FundCategory ='" + BatchID + "')and (RegNo = Replace( Replace( '" + RegNo + "','/#',''),'#',''))  ORDER BY EffectiveDate DESC ";
                }
                else
                {
                    str = "SELECT TOP (1) MemberContPerc,CompanyContPerc FROM  dbo.ContributionsRates WHERE (EffectiveDate <= '" + gg + "') AND (FundCategory ='" + BatchID + "')and RegNo='"+ RegNo + "'  ORDER BY EffectiveDate DESC ";
                }
                
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getExpenses(string BatchID, string RegNo, DateTime EffectiveDate,string Type)
        {
            string gg = EffectiveDate.ToString("yyyy-MM-dd");
            try
            {
                string str = "";
                if (Type == "C")
                {
                    str = "SELECT TOP (1) Percentage as CostPercentage  FROM  dbo.CostBasis AS CostBasis  WHERE (EffectiveDate <= '" + gg + "') AND (FundCategory = '" + BatchID + "') and (RegNo = Replace( Replace('" + RegNo + "','/#',''),'#','')) ORDER BY EffectiveDate DESC";
                }
                else
                {
                    str = "SELECT TOP (1) Percentage as CostPercentage  FROM  dbo.CostBasis AS CostBasis  WHERE (EffectiveDate <= '" + gg + "') AND (FundCategory = '" + BatchID + "') and RegNo = '"+ RegNo + "' ORDER BY EffectiveDate DESC";
                }
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public string getFundCategory(int id)
        {
            try
            {
                string str = "select FundCategory_ID from member where [ID]=" + id + "";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }
        public string getDetails(string LoginCode)
        {
            try
            {
                string str = "select FullName from Portal_Users where LoginCode='" + LoginCode + "'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }
        public DataSet CheckContributionsExists(string period, string nationaid, string RegNo)
        {

            string str = "select top 1 * from Contributions where Period ='" + period + "' and RegNo='" + RegNo + "' and NationalID='" + nationaid + "' and isStartup=0";
            //string str = "select * from Member where IdentityNo ='" + IDnum + "'";

            return ReturnDs(str);
        }
        public string GetBranchID(int ID)
        {
            try
            {

                //string newRegNO = "";
                //if (RegNo.Contains("/"))
                //{
                //    newRegNO = RegNo.Substring(0, RegNo.LastIndexOf("/"));
                //}
                //else
                //{
                //    newRegNO = RegNo;
                //}
                string str = "select a.ID from ParticipatingEmployer a left join Companies b on a.CompanyID=b.id where a.ID='" + ID + "'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "0";
            }
        }
        public DataSet getBranches(int fundID,int BrancCode)
        {
            string RegNo = getRegNo(fundID);
            //if (RegNo.Contains("/"))
            //{
            //    RegNo = RegNo.Substring(0, RegNo.LastIndexOf("/"));
            //}
            //string newRegNO = RegNo.Substring(0, RegNo.LastIndexOf("/"));
            //string str = "select ID,CompanyID,Name from ParticipatingEmployer where RegNo=Replace( Replace('" + RegNo + "','/#',''),'#','') and CompanyID='"+ BrancCode + "'";
            string str = "select ID,CompanyID,Name from ParticipatingEmployer where  CompanyID='" + BrancCode + "'";
            return ReturnDs(str);
        }
        public DataSet getPensionerbASICdETAILS(int PensionNo)
        {
            try
            {
                string str = "SELECT PP.MemberID,PP.PensionNo,PP.PensionType,PP.PensionBasis,PP.NationalID,PP.FirstName,PP.LastName,PP.Title,convert(varchar(12),PP.DateOfBirth,110) as DateOfBirth,pp.MaritalStatus,pp.Gender,convert(varchar(12),pp.DateJoinedPayroll,110) as DateJoinedPayroll,convert(varchar(12),pp.TerminationDate,110) as TerminationDate,case pp.Declared when 0 then 'Not Declared' else'Declared' end as Declared, convert(varchar(12),pp.PensionStartDate ,110) as PensionStartDate,Pp.TerminationCode, Ptr.Reason as TerminationReason,pp.PayPeriod,PP.MonthlySalary,convert(varchar(12),pp.LastExistanceDate,110) as LastExistanceDate ,Pg.Description as FundGroup,pp.BankBranchName,pp.BankAccountFirstName,pp.BankBranchCode,pp.BankName,pp.BankAccountSurname,pp.BankAccountNo,pp.AddressLine1,pp.AddressLine2,pp.AddressLine3,pp.TelephoneNo,pp.MobileNo,pp.Email,case when Active = 1 then 'live' else 'suspended' end as Active FROM PayPensioner PP left join PayTermReasons Ptr on Ptr.Code = PP.TerminationCode left join PensionerGroups Pg on Pg.ID = PP.FundGroup WHERE PensionNo=" + PensionNo + "";
                DataSet ds = dbPay.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getActiveContributingMembers(int FundID,int BranchID)
        {
            
            string RegNo = getRegNo(FundID);
            string str = "select  M.ID, m.FirstName,m.LastName,m.IdentityNo,convert(varchar(12),m.DateJoinedFund,110) as DateJoinedFund,convert(varchar(12),m.DateOfBirth,110) as DateOfBirth,convert(varchar(12),m.DateUploaded,110) as DateUploaded,DATEDIFF(YYYY,DateOfBirth,GETDATE())age from Member m where RegNo ='"+RegNo+"' and m.ExitCode=-1 and  m.CompanyNo='"+BranchID+"'";
            return ReturnDs(str);
        }

        public DataSet getEmployeeClaim(int FundID, int MemberID)
        {
            string RegNo = getRegNo(FundID);
            string str = "select ID, CASE ClaimStatusID WHEN 1 THEN 'Awaiting Payment' WHEN 2 THEN 'Awaiting Checking' WHEN 4 THEN 'Authorised/Paid Claim' ELSE 'Awaiting Authorisation' END AS ClaimStatus,SystemRef AS MemberID,  convert(varchar(12), DateOfExit, 110)  AS[ExitDate],FirstName,SecondSurname as LastName,ExitType from FundExitsQuotations where SystemRef = '" + MemberID + "' and RegNo = '" + RegNo + "'";
            return ReturnDs(str);
        }
        public DataSet getCompanyIDClaim(int FundID, int CompanyID)
        {
            string RegNo = getRegNo(FundID);
            string str = "select ID, CASE ClaimStatusID WHEN 1 THEN 'Awaiting Payment' WHEN 2 THEN 'Awaiting Checking' WHEN 4 THEN 'Authorised/Paid Claim' ELSE 'Awaiting Authorisation' END AS ClaimStatus,SystemRef AS MemberID,  convert(varchar(12), DateOfExit, 110)  AS[ExitDate],FirstName,SecondSurname as LastName,ExitType from FundExitsQuotations where RegNo = '" + RegNo + "' and CompanyCode ='"+ CompanyID + "'";
            return ReturnDs(str);
        }
        public DataSet getDeferredMembers(int FundID, int BranchID)
        {

            string RegNo = getRegNo(FundID);
            string str = "select distinct M.ID, m.FirstName,m.LastName,m.IdentityNo,c.CompanyID,c.BranchCode  from Member m left join Contributions c on c.MemberID = m.ID and c.RegNo = m.RegNo where c.RegNo = '" + RegNo + "' and m.ExitCode=9 and C.CompanyID='" + BranchID + "'";
            return ReturnDs(str);
        }
        public bool CheckAlreadyPosted(string NationalID, int MemberId)
        {
            try
            {
                string str = "select * from FundExitsQuotations where NationalID='"+ NationalID + "' and SystemRef='"+ MemberId + "'";
                if (ReturnDs(str) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public DataSet getActivePensioners(int FundID, int BranchID)
        {
            string RegNo = getRegNo(FundID);
            if (RegNo.Contains("/"))
            {
                RegNo = RegNo.Substring(0, RegNo.LastIndexOf("/"));
            }
            string str = "select PensionNo, FirstName,LastName,NationalID,FormerCoID,PensionType from PayPensioner where RegNo='" + RegNo + "' and Active=1 AND FormerCoID='"+ BranchID + "'";
            return ReturnDsPayRoll(str);
        }
        public DataSet getlblExitedMemberss(int FundID, int BranchID)
        {

            string RegNo = getRegNo(FundID);
            string str = "select distinct M.ID, m.FirstName,m.LastName,m.IdentityNo,c.CompanyID,c.BranchCode,w.Description,convert(varchar(12),f.DateOfExit,110) as DateOfExit  from Member m left join Contributions c  on c.MemberID = m.ID and c.RegNo = m.RegNo inner join WithdrawalTypes w on w.ID=m.ExitCode inner join FundExitsQuotations f on c.MemberID=f.SystemRef where c.RegNo = '" + RegNo + "' and m.ExitCode not in(-1,9) and  C.CompanyID='" + BranchID + "'";
            return ReturnDs(str);
        }
        public DataSet getPensionerDetails(int PensionNo)
        {
            try
            {
                string str = "select top 1 NetSalary,convert(varchar(12),LastPayDate,110) as LastPayDate,PayslipType from PayPayslips where PensionNo='" + PensionNo + "' order by LastPayDate desc";
                DataSet ds = dbPay.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getFundCompanies(string RegNo)
        {
            //string RegNo = getRegNo(fundID);
            //string newRegNO = "";
            //if (RegNo.Contains("/"))
            //{
            //    newRegNO = RegNo.Substring(0, RegNo.LastIndexOf("/"));
            //}
            //else
            //{
            //    newRegNO = RegNo;
            //}
            //string newRegNO = RegNo.Substring(0, RegNo.LastIndexOf("/"));
            string str = "Select ID,Name from Companies where RegNo=Replace( Replace( '" + RegNo + "','/#',''),'#','')";
            return ReturnDs(str);
        }
        public DataSet getSubMenu(long ModuleID)
        {
            DataSet ds;
            try
            {
                string str = "select * from ModuleSubMenu where ModuleID=" + ModuleID + "";
                ds = db.ExecuteDataSet(CommandType.Text, str);
                return ds;
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }


        
        public DataSet IntRatesMultDeclarations_Sel_MaxByCriterion(string ActiveFundID, int DeclarationCriterionValue, int BonusTypeID)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("IntRatesMultDeclarations_Sel_MaxByCriterion");
                db.AddInParameter(cmd, "@RegNo", DbType.String, ActiveFundID);
                db.AddInParameter(cmd, "@CriterionValue", DbType.Int32, DeclarationCriterionValue);
                db.AddInParameter(cmd, "@BonusTypeID", DbType.String, BonusTypeID);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getBatchUploadDetails(string BatchNo, string RegNo)
        {
            try
            {
                string str = "select * from ContributionsFileUpload where batchNo = '" + BatchNo + "' and isprocessed=0 and RegNo='" + RegNo + "'";
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public void PostTransactions(string RegNo, System.DateTime EntryDate, int BranchCode, double MemberPort, double EmployerPort, double AVC, double Stabilization, System.DateTime PaymentDate, string BranchName, DateTime PeriodDate, string ActualReference, bool isReversal, string Oldref, string CompanyName, string Reference, int Userid)
        {
            try
            {
                bool AccPostContributionsEnabled = true;
                if (AccPostContributionsEnabled == false)
                    return;

                string TransBatchNo = DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString() + DateTime.Today.Hour.ToString() + DateTime.Today.Second.ToString();
                EntryDate = EntryDate.Date;

                string newRegNO = "";
                if (RegNo.Contains("/"))
                {
                    newRegNO = RegNo.Substring(0, RegNo.LastIndexOf("/"));
                }
                else
                {
                    newRegNO = RegNo;

                }


                //================================================= Get Posting settings =====================================
                //string newRegNO = RegNo;
                System.Data.Common.DbCommand cmd = dbcc.GetStoredProcCommand("AccContSettings_Sel_ForPosting");
                long MainFundCostCenter = BranchCode;
                //int BranchCodes = 0;
                //Fund f = new Fund(mConnectionName, mObjectUserID);

                //DataSet x = f.getMainFundCostcenter(BranchCode, newRegNO);
                //if (x != null)
                //{
                //    BranchCodes = int.Parse(x.Tables[0].Rows[0][0].ToString());
                //}


                dbcc.AddInParameter(cmd, "@RegNo", DbType.String, newRegNO);
                dbcc.AddInParameter(cmd, "@BranchCode", DbType.Int32, MainFundCostCenter);

                DataSet ds = dbcc.ExecuteDataSet(cmd);
                DataSet SettingsDT = ds;

                foreach (DataRow rwSet in SettingsDT.Tables[0].Rows)
                {
                    double MyDR = 0;
                    double MyCR = 0;


                    if (rwSet["Component"].ToString() == "Employee Contribution")
                    {
                        MyDR = MemberPort;
                        MyCR = 0;
                    }
                    else if (rwSet["Component"].ToString() == "Employer Contribution")
                    {
                        MyDR = EmployerPort;
                        MyCR = 0;


                    }
                    else if (rwSet["Component"].ToString() == "Voluntary Contribution")
                    {
                        MyDR = AVC;
                        MyCR = 0;


                    }
                    else if (rwSet["Component"].ToString() == "Stabilisation")
                    {
                        MyDR = Stabilization;
                        MyCR = 0;


                    }
                    else if (rwSet["Component"].ToString() == "Customer")
                    {
                        MyDR = MemberPort + EmployerPort + AVC + Stabilization;
                        MyCR = 0;

                    }
                    if (BranchName == "Select a company" || BranchName == "")
                    {
                        BranchName = Oldref;
                    }
                    if (MyDR > 0)
                    {

                        cmd = dbcc.GetStoredProcCommand("AccTransactions_Ins");
                        dbcc.AddInParameter(cmd, "@RegNo", DbType.String, newRegNO);
                        dbcc.AddInParameter(cmd, "@EntryType", DbType.String, "Pensions Manager");
                        dbcc.AddInParameter(cmd, "@EntryDate", DbType.Date, Convert.ToDateTime(EntryDate).ToString("yyyy/MM/dd"));
                        dbcc.AddInParameter(cmd, "@Reference", DbType.String, ActualReference);

                        dbcc.AddInParameter(cmd, "@AccCode", DbType.String, rwSet["DRAccCode"].ToString());
                        dbcc.AddInParameter(cmd, "@AccSubCode", DbType.String, rwSet["DRSubAccCode"].ToString());
                        dbcc.AddInParameter(cmd, "@ContraCode", DbType.String, rwSet["CRAccCode"].ToString());
                        dbcc.AddInParameter(cmd, "@ContraSubCode", DbType.String, rwSet["CRSubAccCode"].ToString());
                        //Reversal not posting to the correct side
                        //When it is a reversal ,it should post to the opposite side in the pensions admin
                        if (isReversal == false)
                        {
                            dbcc.AddInParameter(cmd, "@Narration", DbType.String, BranchName);
                            dbcc.AddInParameter(cmd, "@Dr", DbType.Double, Math.Round(MyDR, 2));
                            dbcc.AddInParameter(cmd, "@Cr", DbType.Double, Math.Round(MyCR, 2));
                        }
                        else
                        {
                            dbcc.AddInParameter(cmd, "@Narration", DbType.String, BranchName + "(Contributions Reversal)");
                            dbcc.AddInParameter(cmd, "@Dr", DbType.Double, Math.Round(MyCR, 2));
                            dbcc.AddInParameter(cmd, "@Cr", DbType.Double, Math.Round(MyDR, 2));
                        }
                        dbcc.AddInParameter(cmd, "@IsYearEndValue", DbType.Boolean, false);
                        dbcc.AddInParameter(cmd, "@AddedBy", DbType.Int32, mObjectUserID);
                        dbcc.AddInParameter(cmd, "@BatchNo", DbType.String, Reference);
                        dbcc.AddInParameter(cmd, "@BranchCode", DbType.Int32, MainFundCostCenter);
                        DataSet dsacc = dbcc.ExecuteDataSet(cmd);

                    }


                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;

            }
        }

        public bool UploadUnreceiptedAmount(string RegNo, int CostCenterID, string Period, DateTime PeriodDate, DateTime PaymentDate, double TotalUploadValue, string CompanyName)
        {
            try
            {
                //get Main Fund CostCenterID 
                int reg = RegNo.LastIndexOf("/"); // Character to remove "?"
                if (reg > 0)
                    RegNo = RegNo.Substring(0, reg);
                string newRegNO = RegNo;

                long MainFundCostCenter = CostCenterID;
                //int BranchCodes = 0;
                //Fund f = new Fund("cn", 1);

                //if (CostCenterID <= 0 )
                //{
                //    MainFundCostCenter = 0;
                //}
                //else
                //{
                //    DataSet x = f.getMainFundCostcenter(CostCenterID);
                //    if (x != null)
                //    {
                //        MainFundCostCenter = long.Parse(x.Tables[0].Rows[0][0].ToString());
                //    }
                //}
                //DataSet x = f.getMainFundCostcenter(CostCenterID, newRegNO);
                //if (x != null)
                //{
                //    BranchCodes = int.Parse(x.Tables[0].Rows[0][0].ToString());
                //}



                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("UnreceiptedPeriods_Ins");
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@CostCentreID", DbType.Int32, MainFundCostCenter);
                db.AddInParameter(cmd, "@Period", DbType.String, Period);
                db.AddInParameter(cmd, "@PeriodDate", DbType.Date, PeriodDate);
                db.AddInParameter(cmd, "@PaymentDate", DbType.Date, PaymentDate);
                db.AddInParameter(cmd, "@UnreceiptedTotal", DbType.Double, TotalUploadValue);
                db.AddInParameter(cmd, "@AddedBy", DbType.Int32, mObjectUserID);
                DataSet ds = db.ExecuteDataSet(cmd);

                return true;

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public DataSet GetPortalUsers(string ActiveFundID)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("GetPortalUsers");
                db.AddInParameter(cmd, "@Empcode", DbType.String, ActiveFundID);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet Get_Participarting_Employer(string CompID,string RegNo)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Get_Participarting_Employer");
                //System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Get_Participarting_Employer_Portal");
                db.AddInParameter(cmd, "@SystemRef", DbType.String, CompID);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    MsgFlg = "Nothing Found";
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet getActiveMembersByFilterSearch(int BranchId, string ssn = "", string firstnames = "", string lastname = "", string idnumber = "")
        {
            string str = "";

            if (firstnames.Length > 0 && lastname.Length <= 0 && idnumber.Length <= 0)
            {
                str = "select * from vwFundMemberDetails where ISNULL(StatusID,1)=1 and BranchId='" + BranchId + "' and FirstName like '%" + firstnames + "%' and ExitCode in (-1)";

            }
            if (firstnames.Length > 0 && lastname.Length > 0 && idnumber.Length <= 0)
            {
                str = "select * from vwFundMemberDetails where ISNULL(StatusID,1)=1 and BranchId='" + BranchId + "' and FirstName like '%" + firstnames + "%' and LastName like '%" + lastname + "%' and ExitCode in (-1)";

            }
            if (firstnames.Length > 0 && lastname.Length > 0 && idnumber.Length > 0)
            {
                str = "select * from vwFundMemberDetails where ISNULL(StatusID,1)=1 and BranchId='" + BranchId + "' and FirstName like '%" + firstnames + "%' and LastName like '%" + lastname + "%' and IdentityNo like '" + idnumber + "' and ExitCode in (-1)";
            }
            if (firstnames.Length <= 0 && lastname.Length > 0 && idnumber.Length <= 0)
            {
                str = "select * from vwFundMemberDetails where ISNULL(StatusID,1)=1 and BranchId='" + BranchId + "' and LastName like '%" + lastname + "%' and ExitCode in (-1)";

            }
            if (firstnames.Length <= 0 && lastname.Length <= 0 && idnumber.Length > 0)
            {
                str = "select * from vwFundMemberDetails where ISNULL(StatusID,1)=1 and BranchId='" + BranchId + "' and IdentityNo like '" + idnumber + "' and ExitCode in (-1)";

            }
            if (ssn.Length > 0)
            {
                str = "select * from vwFundMemberDetails where ISNULL(StatusID,1)=1 and BranchId='" + BranchId + "' and ID like '" + ssn + "' and ExitCode in (-1)";

            }
            return ReturnDs(str);
        }

        public DataSet getActivePensionersByFilterSearch(string RegNo, string ssn = "", string firstnames = "", string lastname = "", string idnumber = "",string BranchCode="")
        {
            string str = "";

            if (firstnames.Length > 0 && lastname.Length <= 0 && idnumber.Length <= 0)
            {
                str = "select top 1 PensionNo, FirstName,LastName,NationalID,FormerCoID,PensionType from PayPensioner where RegNo=Replace( Replace('"+RegNo+"','/#',''),'#','')  and Active=1 AND FormerCoID='"+ BranchCode + "' and FirstName like '%" + firstnames + "%'";

            }
            if (firstnames.Length > 0 && lastname.Length > 0 && idnumber.Length <= 0)
            {
                str = "select top 1 PensionNo, FirstName,LastName,NationalID,FormerCoID,PensionType from PayPensioner where RegNo=Replace( Replace('" + RegNo + "','/#',''),'#','')  and Active=1 AND FormerCoID='" + BranchCode + "' and FirstName like '%" + firstnames + "%' and LastName like '%" + lastname + "%'";

            }
            if (firstnames.Length > 0 && lastname.Length > 0 && idnumber.Length > 0)
            {
                str = "select top 1 PensionNo, FirstName,LastName,NationalID,FormerCoID,PensionType from PayPensioner where RegNo=Replace( Replace('" + RegNo + "','/#',''),'#','')  and Active=1 AND FormerCoID='" + BranchCode + "' and FirstName like '%" + firstnames + "%' and LastName like '%" + lastname + "%' and NationalID like '" + idnumber + "'";
            }
            if (firstnames.Length <= 0 && lastname.Length > 0 && idnumber.Length <= 0)
            {
                str = "select top 1 PensionNo, FirstName,LastName,NationalID,FormerCoID,PensionType from PayPensioner where RegNo=Replace( Replace('" + RegNo + "','/#',''),'#','')  and Active=1 AND FormerCoID='" + BranchCode + "' and LastName like '%" + lastname + "%'";

            }
            if (firstnames.Length <= 0 && lastname.Length <= 0 && idnumber.Length > 0)
            {
                str = "select top 1 PensionNo, FirstName,LastName,NationalID,FormerCoID,PensionType from PayPensioner where RegNo=Replace( Replace('" + RegNo + "','/#',''),'#','')  and Active=1 AND FormerCoID='" + BranchCode + "' and NationalID like '" + idnumber + "' 8";

            }
            if (ssn.Length > 0)
            {
                str = "select top 1 PensionNo, FirstName,LastName,NationalID,FormerCoID,PensionType from PayPensioner where RegNo=Replace( Replace('" + RegNo + "','/#',''),'#','')  and Active=1 AND FormerCoID='" + BranchCode + "' and  PensionNo like '" + ssn + "'";

            }
            return ReturnDsPayRoll(str);
        }
        //public DataSet getFundMembersByFundID(string RegNo,int BranchCode)
        //{
        //    string str = "select top 10 * from vwFundMemberDetails WHERE ISNULL(StatusID,1)=1 AND ExitCode=-1 and RegNo ='"+RegNo+ "' and Company_ID='"+ BranchCode + "' ORDER BY ID Desc";
        //    return ReturnDs(str);
        //}
        public DataSet getMemberContributions(long MemberID, string RegNo)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_Member_PureCont_Portal");
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, MemberID);
                //db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getMemberDocuments(int MemberID,int CreatedBy)
        {
            string str = "select i.ID as IDs, * from Portal_Documents p inner join IdentityDocumentTypes i on p.DocTypeID=i.ID where PensionNo='" + MemberID + "' and CreatedBy='"+ CreatedBy + "'";
            return ReturnDs(str);
        }
       
        public DataSet BenefitProjectionsNRA_Sel_By_MemberID(int MemberID, DateTime ExitDate)
        {
            try
            {
                string sql = "BenefitProjectionsNRA_Sel_By_MemberID";

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, MemberID);
                db.AddInParameter(cmd, "@DateTo", DbType.DateTime, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet getFundMemberDetails(int MemberID, int FundID)
        {
            string RegNo = getRegNo(FundID);
            string str = "select top 1 * from vwFundMemberDetails_Portal vw inner join WithdrawalTypes w on vw.ExitCode = w.ID where vw.ID=" + MemberID ;
            return ReturnDs(str);
        }

        public DataSet getBankingDetails(int MemberID)
        {
            //string RegNo = getRegNo(FundID);
            string str = "select top 1 * from vwMemberBankingDetails where MemberID='" + MemberID + "'";
            return ReturnDs(str);
        }
        public DataSet Contributions_Sel_ByRegNoPaymentDate(string ActiveFundID, DateTime PrevDeclarationDate, DateTime EndDate, int DeclarationCriterion, int DeclarationCriterionValue)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_ByRegNoPaymentDate");
                db.AddInParameter(cmd, "@RegNo", DbType.String, ActiveFundID);
                db.AddInParameter(cmd, "@StartDate", DbType.DateTime, PrevDeclarationDate);
                db.AddInParameter(cmd, "@LastDeclarationDate", DbType.DateTime, EndDate);
                db.AddInParameter(cmd, "@Criterion", DbType.Int32, DeclarationCriterion);
                db.AddInParameter(cmd, "@CriterionValue", DbType.Int32, DeclarationCriterionValue);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet Fund_Sel(string ActiveFundID)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Fund_Sel");
                if (ActiveFundID == null || ActiveFundID == "")
                {
                    db.AddInParameter(cmd, "@RegNo", DbType.String, null);
                }
                else
                {
                    db.AddInParameter(cmd, "@RegNo", DbType.String, ActiveFundID);
                }

                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getPortalMemberDetails(int MemberID, string FundID)
        {
            //string RegNo = getRegNo(FundID);
            string str = "select top 1 * from vwFundMemberDetails_Portal vw inner join WithdrawalTypes w on vw.ExitCode = w.ID where vw.ID=" + MemberID + " and RegNo='" + FundID + "'";
            return ReturnDs(str);
        }
        public DataSet Contributions_Sel_SalaryByPeriod(string CurrentFund, string PrevPeriod, string PremiumPeriod)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_SalaryByPeriod");
                db.AddInParameter(cmd, "@RegNo", DbType.String, CurrentFund);
                db.AddInParameter(cmd, "@PremPeriod", DbType.String, PrevPeriod);
                db.AddInParameter(cmd, "@Period", DbType.String, PremiumPeriod);
                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet Contributions_Sel_SalaryByPeriod1(string CurrentFund, string PrevPeriod, string PremiumPeriod)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_SalaryByPeriod");
                db.AddInParameter(cmd, "@RegNo", DbType.String, CurrentFund);
                db.AddInParameter(cmd, "@Period", DbType.String, PrevPeriod);
                db.AddInParameter(cmd, "@PremPeriod", DbType.String, PremiumPeriod);
                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet Contributions_Sel_ByRegNoAndMemberID(string CurrentFund, DateTime PreviousDate, DateTime LastBonusDate, int MemberID)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_ByRegNoAndMemberID");
                db.AddInParameter(cmd, "@RegNo", DbType.String, CurrentFund);
                db.AddInParameter(cmd, "@Paymentdate", DbType.DateTime, PreviousDate);
                db.AddInParameter(cmd, "@BonusDate", DbType.DateTime, LastBonusDate);
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, MemberID);
                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet MedicalFreeLimits_Sel_ByRegNo_DistinctCategories(string CurrentFund)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("MedicalFreeLimits_Sel_ByRegNo_DistinctCategories");
                db.AddInParameter(cmd, "@RegNo", DbType.String, CurrentFund);
                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet MedicalFreeLimits_Sel_ByRegNo_Premiums(string CurrentFund, int FundCategory, DateTime EffectiveDate)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("MedicalFreeLimits_Sel_ByRegNo_Premiums");
                db.AddInParameter(cmd, "@RegNo", DbType.String, CurrentFund);
                db.AddInParameter(cmd, "@FundCategory", DbType.Int32, FundCategory);
                db.AddInParameter(cmd, "@EffectiveDate", DbType.DateTime, EffectiveDate);
                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet CostBasis_Sel_ByRegNoEffectiveDate(string CurrentFund, DateTime EffectiveDate)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("CostBasis_Sel_ByRegNoEffectiveDate");
                db.AddInParameter(cmd, "@RegNo", DbType.String, CurrentFund);
                db.AddInParameter(cmd, "@EffectiveDate", DbType.DateTime, EffectiveDate);
                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet InterestBasis_Sel_ByRegNo_Active(string CurrentFund, DateTime EffectiveDate)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("InterestBasis_Sel_ByRegNo_Active");
                db.AddInParameter(cmd, "@RegNo", DbType.String, CurrentFund);
                db.AddInParameter(cmd, "@EffectiveDate", DbType.DateTime, EffectiveDate);
                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet InterestRates_Sel_Last(string CurrentFund)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("InterestRates_Sel_Last");
                db.AddInParameter(cmd, "@RegNo", DbType.String, CurrentFund);

                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet InterimBonus_Sel()
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("InterimBonus_Sel");
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet ContributionsTemp2_Sel()
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("ContributionsTemp2_Sel");
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet Contributions_Sel_Sum_ByMemberID_AfterLastRemmitted(int MemberID, DateTime DateLastContributed, DateTime PrevDeclarationDate, int BonusTypeID)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_Sum_ByMemberID_AfterLastRemmitted");
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, MemberID);
                db.AddInParameter(cmd, "@DateLastRemmitted", DbType.DateTime, DateLastContributed);
                db.AddInParameter(cmd, "@PrevDeclarationDate", DbType.DateTime, PrevDeclarationDate);
                db.AddInParameter(cmd, "@BonusTypeID", DbType.Int32, BonusTypeID);
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
      

        public DataSet GetSalaryBill(string RegNo, DateTime dt)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("ContribSummary_Sel_ByRegNo");
                db.AddInParameter(cmd, "@PaymentDate", DbType.DateTime, dt);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetCertificateList(string RegNo, string Criteria)
        {
            try
            {
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_CertificateIssueList_Web");
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@Criterion", DbType.String, Criteria);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet Contributions_Sel_ActurialData(string RegNo, string BranchCode, int BonusTypeID, int IntExitCode, DateTime fdate, DateTime tdate)
        {
            try
            {
                if (BranchCode == "0")
                {
                    BranchCode = "";
                }

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_ActurialData");
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@StartDate", DbType.DateTime, fdate);
                db.AddInParameter(cmd, "@EndDate", DbType.DateTime, tdate);
                db.AddInParameter(cmd, "@IntExitCode", DbType.Int32, IntExitCode);
                db.AddInParameter(cmd, "@BranchCode", DbType.String, BranchCode);
                db.AddInParameter(cmd, "@BonusTypeID", DbType.String, BonusTypeID);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet Contributions_Sel_ActurialData_Deferred(string RegNo, string BranchCode, int BonusTypeID, DateTime fdate, DateTime tdate)
        {
            try
            {
                if (BranchCode == "0")
                {
                    BranchCode = "";
                }

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_ActurialData_Deferred");
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@StartDate", DbType.DateTime, fdate);
                db.AddInParameter(cmd, "@EndDate", DbType.DateTime, tdate);
                db.AddInParameter(cmd, "@BranchCode", DbType.String, BranchCode);
                db.AddInParameter(cmd, "@BonusTypeID", DbType.String, BonusTypeID);

                DataSet ds = db.ExecuteDataSet(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetAccumulativeReserves(string RegNo, string Criteria, DateTime PaymentDate, int BranchCode, int MemberId)
        {
            try
            {
                string type = "ID";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Contributions_Sel_ByRegNoAndBranch");
                if (Criteria == "BC")
                {
                    cmd = db.GetStoredProcCommand("Contributions_Sel_ByRegNoAndBranch");
                    db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                    db.AddInParameter(cmd, "@Paymentdate", DbType.DateTime, PaymentDate);
                    db.AddInParameter(cmd, "@BranchCode", DbType.Int32, BranchCode);
                }
                else
                {
                    cmd = db.GetStoredProcCommand("Member_Sel_ByField");
                    db.AddInParameter(cmd, "@Criteria", DbType.String, type);
                    db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                    db.AddInParameter(cmd, "@Value", DbType.Int32, MemberId);

                }


                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        

        
        public DataSet GetEmploymentType()
        {
            try
            {
                string str = "select ID,Description from EmploymentType";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetClientTypes()
        {
            try
            {
                string str = "select ID,Name from ClientTypes ";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getGender()
        {
            try
            {
                string str = "select ID,Description from Gender ";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetTitles()
        {
            try
            {
                string str = "select ID,Description from Titles";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetPeriod(string reg)
        {
            try
            {
                string str = "select distinct(Period) from Contributions where RegNo='" + reg + "'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetuploadCompany(string reg)
        {
            try
            {
                //string str = "select distinct(Name) from Contributions a inner join contributionsfileupload b on a.batchno=b.batchno left join participatingemployer c on a.companyid=c.companyid where a.RegNo = '" + reg + "'";
                //string str = "select distinct(Name) from Contributions a left join Companies b on a.CompanyID=b.id where a.RegNo = '" + reg + "'";
                string str = "select ID,CompanyID,Name from ParticipatingEmployer where RegNo=Replace( Replace('" + reg + "','/#',''),'#','')";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetMaritalStatus()
        {
            try
            {
                string str = "select ID,Description from MaritalStatus";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetCountries()
        {
            try
            {
                string str = "select ID,CountryName,CountryCode,CountryTelCode from Countries";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetMemberStatus()
        {
            try
            {
                string str = "select ID,Description from MemberStatus ";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetNonAssignedBusinessActivities(int IndID, int ClientID)
        {
            string str = "select ID,ClassCode from CountryIndustryBusinessClasses where ID not in (select CountryIndustryBusinessClassID from InstitutionBusinessClassActivities_Dummy where ClientID=" + ClientID + " ) and  IndustryID = " + IndID + "";
            return ReturnDs(str);
        }

        public DataSet GetNonAssignedBusinessActivitiesLive(int IndID, int ClientID)
        {
            string str = "select ID,ClassCode from CountryIndustryBusinessClasses where ID not in (select CountryIndustryBusinessClassID from InstitutionBusinessClassActivities where ClientID=" + ClientID + " ) and  IndustryID = " + IndID + "";
            return ReturnDs(str);
        }
        public DataSet GetAssignedBusinessActivities(int IndID, int ClientID)
        {
            //string str = "select ID,ClassCode from CountryIndustryBusinessClasses where ID in (select CountryIndustryBusinessClassID from InstitutionBusinessClassActivities_Dummy where ClientID=" + ClientID + " ) and  IndustryID = " + IndID + "";
            string str = "select IBCAD.ID,CIBC.ClassCode from CountryIndustryBusinessClasses CIBC inner join InstitutionBusinessClassActivities_Dummy IBCAD on CIBC.ID = IBCAD.CountryIndustryBusinessClassID  where CIBC.IndustryID=" + IndID + " AND IBCAD.ClientID=" + ClientID + "";
            return ReturnDs(str);
        }

        public DataSet GetAssignedBusinessActivitiesLive(int IndID, int ClientID)
        {
            //string str = "select ID,ClassCode from CountryIndustryBusinessClasses where ID in (select CountryIndustryBusinessClassID from InstitutionBusinessClassActivities_Dummy where ClientID=" + ClientID + " ) and  IndustryID = " + IndID + "";
            string str = "select IBCAD.ID,CIBC.ClassCode from CountryIndustryBusinessClasses CIBC inner join InstitutionBusinessClassActivities IBCAD on CIBC.ID = IBCAD.CountryIndustryBusinessClassID  where CIBC.IndustryID=" + IndID + " AND IBCAD.ClientID=" + ClientID + "";
            return ReturnDs(str);
        }

        public DataSet GetBusinessActivitiesByIndustry(int IndID)

        {
            try
            {
                string str = "select ID,ClassCode from CountryIndustryBusinessClasses where IndustryID = " + IndID + "";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetBusinessActivities()

        {
            try
            {
                string str = "select ID,ClassCode from CountryIndustryBusinessClasses";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetIndustries()

        {
            try
            {
                string str = "select ID,Name from CountryIndustries";

                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetAddressTypes()

        {
            try
            {
                string str = "select ID,Description from AddressTypes";

                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getPensionerHistory(string FundID, int PensionerNo)
        {
            try
            {
                //Fund f = new Fund(mConnectionName, mObjectUserID);
                //string RegNo = f.getRegNo(FundID);
                System.Data.Common.DbCommand cmd = dbPay.GetStoredProcCommand("PayPayslipHist_Sel_ByPensionNo_ByRegNo");
                dbPay.AddInParameter(cmd, "@PensionNo", DbType.Int32, PensionerNo);
                dbPay.AddInParameter(cmd, "@RegNo", DbType.String, FundID);
                DataSet ds = dbPay.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public virtual bool Retrieve(long PensionNo)
        {

            string sql = null;

            if (PensionNo > 0)
            {
                sql = "SELECT * FROM PayPensioner WHERE PensionNo = " + PensionNo;
            }
            else
            {
                sql = "SELECT * FROM PayPensioner WHERE PensionNo = " + mPensionNo;
            }

            return Retrieve(sql);

        }
        protected virtual bool Retrieve(string sql)
        {


            try
            {
                DataSet dsRetrieve = dbPay.ExecuteDataSet(CommandType.Text, sql);


                if (dsRetrieve != null && dsRetrieve.Tables.Count > 0 && dsRetrieve.Tables[0].Rows.Count > 0)
                {
                    LoadDataRecord(dsRetrieve.Tables[0].Rows[0]);

                    dsRetrieve = null;
                    return true;


                }
                else
                {
                    mMsgFlg = ("PayPensioner not found.");

                    return false;

                }


            }
            catch (Exception e)
            {
                mMsgFlg = e.ToString();
                return false;

            }

        }
        protected internal virtual void LoadDataRecord(DataRow rw)
        {
            mPensionNo = ((object)rw["PensionNo"] == DBNull.Value) ? 0 : int.Parse(rw["PensionNo"].ToString());
            mMemberID = ((object)rw["MemberID"] == DBNull.Value) ? 0 : int.Parse(rw["MemberID"].ToString());
            mFormerCoID = ((object)rw["FormerCoID"] == DBNull.Value) ? 0 : int.Parse(rw["FormerCoID"].ToString());
            mOldPensionNo = ((object)rw["OldPensionNo"] == DBNull.Value) ? 0 : int.Parse(rw["OldPensionNo"].ToString());
            mFundGroup = ((object)rw["FundGroup"] == DBNull.Value) ? 0 : int.Parse(rw["FundGroup"].ToString());
            mLastModifiedBy = ((object)rw["LastModifiedBy"] == DBNull.Value) ? 0 : int.Parse(rw["LastModifiedBy"].ToString());
            mLastPayDate = ((object)rw["LastPayDate"] == DBNull.Value) ? string.Empty : rw["LastPayDate"].ToString();
            mLastPayIncreaseDate = ((object)rw["LastPayIncreaseDate"] == DBNull.Value) ? string.Empty : rw["LastPayIncreaseDate"].ToString();
            mDateOfBirth = ((object)rw["DateOfBirth"] == DBNull.Value) ? string.Empty : rw["DateOfBirth"].ToString();
            mDateJoinedPayroll = ((object)rw["DateJoinedPayroll"] == DBNull.Value) ? string.Empty : rw["DateJoinedPayroll"].ToString();
            mPensionStartDate = ((object)rw["PensionStartDate"] == DBNull.Value) ? string.Empty : rw["PensionStartDate"].ToString();
            mTerminationDate = ((object)rw["TerminationDate"] == DBNull.Value) ? string.Empty : rw["TerminationDate"].ToString();
            mFormerDOB = ((object)rw["FormerDOB"] == DBNull.Value) ? string.Empty : rw["FormerDOB"].ToString();
            mFormerDJF = ((object)rw["FormerDJF"] == DBNull.Value) ? string.Empty : rw["FormerDJF"].ToString();
            mFormerDJC = ((object)rw["FormerDJC"] == DBNull.Value) ? string.Empty : rw["FormerDJC"].ToString();
            mFormerExitDate = ((object)rw["FormerExitDate"] == DBNull.Value) ? string.Empty : rw["FormerExitDate"].ToString();
            mLastExistanceDate = ((object)rw["LastExistanceDate"] == DBNull.Value) ? string.Empty : rw["LastExistanceDate"].ToString();
            mDateUploaded = ((object)rw["DateUploaded"] == DBNull.Value) ? string.Empty : rw["DateUploaded"].ToString();
            mDateModified = ((object)rw["DateModified"] == DBNull.Value) ? string.Empty : rw["DateModified"].ToString();
            mAnnualSalary = ((object)rw["AnnualSalary"] == DBNull.Value) ? 0 : float.Parse(rw["AnnualSalary"].ToString());
            mMonthlySalary = ((object)rw["MonthlySalary"] == DBNull.Value) ? 0 : float.Parse(rw["MonthlySalary"].ToString());
            mFormerAnnualSalaryExit = ((object)rw["FormerAnnualSalaryExit"] == DBNull.Value) ? 0 : float.Parse(rw["FormerAnnualSalaryExit"].ToString());
            mPrevMonthlySalary = ((object)rw["PrevMonthlySalary"] == DBNull.Value) ? 0 : float.Parse(rw["PrevMonthlySalary"].ToString());
            mActive = ((object)rw["Active"] == DBNull.Value) ? false : bool.Parse(rw["Active"].ToString());
            mDeclared = ((object)rw["Declared"] == DBNull.Value) ? false : bool.Parse(rw["Declared"].ToString());
            mMonthsSuspended = ((object)rw["MonthsSuspended"] == DBNull.Value) ? string.Empty : rw["MonthsSuspended"].ToString();
            mPayPeriod = ((object)rw["PayPeriod"] == DBNull.Value) ? string.Empty : rw["PayPeriod"].ToString();
            mPensionType = ((object)rw["PensionType"] == DBNull.Value) ? string.Empty : rw["PensionType"].ToString();
            mRegNo = ((object)rw["RegNo"] == DBNull.Value) ? string.Empty : rw["RegNo"].ToString();
            mCostCentre = ((object)rw["CostCentre"] == DBNull.Value) ? string.Empty : rw["CostCentre"].ToString();
            mLastName = ((object)rw["LastName"] == DBNull.Value) ? string.Empty : rw["LastName"].ToString();
            mFirstName = ((object)rw["FirstName"] == DBNull.Value) ? string.Empty : rw["FirstName"].ToString();
            mGender = ((object)rw["Gender"] == DBNull.Value) ? string.Empty : rw["Gender"].ToString();
            mPensionBasis = ((object)rw["PensionBasis"] == DBNull.Value) ? string.Empty : rw["PensionBasis"].ToString();
            mFormerfirstName = ((object)rw["FormerfirstName"] == DBNull.Value) ? string.Empty : rw["FormerfirstName"].ToString();
            mFormerLastName = ((object)rw["FormerLastName"] == DBNull.Value) ? string.Empty : rw["FormerLastName"].ToString();
            mFormerCoName = ((object)rw["FormerCoName"] == DBNull.Value) ? string.Empty : rw["FormerCoName"].ToString();
            mAddressLine1 = ((object)rw["AddressLine1"] == DBNull.Value) ? string.Empty : rw["AddressLine1"].ToString();
            mAddressLine2 = ((object)rw["AddressLine2"] == DBNull.Value) ? string.Empty : rw["AddressLine2"].ToString();
            mAddressLine3 = ((object)rw["AddressLine3"] == DBNull.Value) ? string.Empty : rw["AddressLine3"].ToString();
            mTelephoneNo = ((object)rw["TelephoneNo"] == DBNull.Value) ? string.Empty : rw["TelephoneNo"].ToString();
            mMobileNo = ((object)rw["MobileNo"] == DBNull.Value) ? string.Empty : rw["MobileNo"].ToString();
            mEmail = ((object)rw["Email"] == DBNull.Value) ? string.Empty : rw["Email"].ToString();
            mBankAccountNo = ((object)rw["BankAccountNo"] == DBNull.Value) ? string.Empty : rw["BankAccountNo"].ToString();
            mBankName = ((object)rw["BankName"] == DBNull.Value) ? string.Empty : rw["BankName"].ToString();
            mBankBranchName = ((object)rw["BankBranchName"] == DBNull.Value) ? string.Empty : rw["BankBranchName"].ToString();
            mBankBranchCode = ((object)rw["BankBranchCode"] == DBNull.Value) ? string.Empty : rw["BankBranchCode"].ToString();
            mBankAccountSurname = ((object)rw["BankAccountSurname"] == DBNull.Value) ? string.Empty : rw["BankAccountSurname"].ToString();
            mBankAccountFirstName = ((object)rw["BankAccountFirstName"] == DBNull.Value) ? string.Empty : rw["BankAccountFirstName"].ToString();
            mTitle = ((object)rw["Title"] == DBNull.Value) ? string.Empty : rw["Title"].ToString();
            mMaritalStatus = ((object)rw["MaritalStatus"] == DBNull.Value) ? string.Empty : rw["MaritalStatus"].ToString();
            mNationalID = ((object)rw["NationalID"] == DBNull.Value) ? string.Empty : rw["NationalID"].ToString();
            mPassportNo = ((object)rw["PassportNo"] == DBNull.Value) ? string.Empty : rw["PassportNo"].ToString();
            mTerminationCode = ((object)rw["TerminationCode"] == DBNull.Value) ? string.Empty : rw["TerminationCode"].ToString();
            mTaxCode = ((object)rw["TaxCode"] == DBNull.Value) ? string.Empty : rw["TaxCode"].ToString();


        }
        public DataSet GetCities()

        {
            try
            {
                string str = "select ID,Name from countryCities";

                DataSet ds = dbPay.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetBands()

        {
            try
            {
                string str = "select * from TaxTables order by EffectiveDate desc";

                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetCitiesByCountry(int ID)

        {
            try
            {
                string str = "select ID,Name from countryCities where CountryID=" + ID + "";

                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getFileUploadTypes()
        {
            string str = "select * from FileUploadTypes";
            return ReturnDs(str);
        }
        public string getIDNumber(long MemberID)
        {
            try
            {
                string str = "select IdentityNo from Member where id='" + MemberID + "'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }
        public string getLastPaymentDate(long CompanyID,string RegNo)
        {
            try
            {
                string str = "select top 1 convert(varchar(12), PaymentDate, 110)  AS [PaymentDate] from Contributions where CompanyID='"+ CompanyID + "' and RegNo='"+ RegNo + "' order by PaymentDate desc";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "XXX";
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return "XXX";
            }
        }
        public DataSet getClaimTypes()
        {
            //string str = "select * from WithdrawalTypes where ID in (2,4,5)";
            string str = "select * from WithdrawalTypes where id not in (-1)";
            return ReturnDs(str);
        }

        public DataSet getAGMEvents()
        {
            string events = "select (EventName) from AGMEvents";
            return ReturnDs(events);
        }

        public DataSet getMedicalFreeLimits(DateTime ExitDate, int FundID, string MemberCategory, DataSet EligibilityDs = null)
        {
            try
            {
                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("MedicalFreeLimits_Sel_ByRegNoDateCategory");
                db.AddInParameter(cmd, "@Date", DbType.Date, ExitDate);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@Category", DbType.String, MemberCategory);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (EligibilityDs != null && EligibilityDs.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow rwMFL in ds.Tables[0].Rows)
                        {
                            foreach (DataRow rwElds in EligibilityDs.Tables[0].Rows)
                            {
                                if (rwMFL["FundCategory"].ToString().Replace(" ", "") == rwElds["FundCategory"].ToString().Replace(" ", ""))
                                {
                                    rwElds["GLACoverMultiple"] = rwMFL["CoverMultiple"];
                                    rwElds["DeathLumpsumPayableFactor"] = rwMFL["LumpsumMultiple"];
                                    rwElds["DeathBenefitFormular"] = rwMFL["BenefitFormular"];
                                }
                            }
                            ds.AcceptChanges();
                        }
                    }
                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetExitedMemberDetails(int FundID, int MemberID)
        {
            try
            {
                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("FundExits_Sel_ByFund_ByMemberID");
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, MemberID);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet BenefitParameters(string ExitType, int FundID, DateTime ExitDate)
        {
            string str = "";
            //Fund f = new Fund(mConnectionName, mObjectUserID);
            string RegNo = getRegNo(FundID);

            System.Data.Common.DbCommand cmd;

            if (ExitType == "Death")
            {
                str = "InterestRates_Sel_Last_forExits";
                cmd = db.GetStoredProcCommand(str);

                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@ExitDate", DbType.Date, ExitDate);
            }
            else
            {
                str = "InterestRates_Sel_Last";
                cmd = db.GetStoredProcCommand(str);

                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);

            }



            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
        public DataSet MemberStartupValues(int FundID, int refnumber, DateTime bonusdate, string CalType)
        {
            try
            {
                string sql = "";
                if (CalType == "N")
                {
                    sql = "Contributions_sel_startupValueMember";
                }
                else if (CalType == "A")
                {
                    sql = "Contributions_Sel_StartupValueMember_fundA";
                }
                else
                {
                    sql = "Contributions_Sel_StartupValueMember_fundB";
                }


                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@memberId", DbType.Int32, refnumber);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@Bonusdate", DbType.Date, bonusdate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet MemberLastSalary(int FundID, int SystemRef, DateTime ExitDate, string CalType)
        {
            try
            {
                string sql = "";
                sql = "Contributions_Sel_MemberLatestSalary_web";
                //if (CalType == "N")
                //{
                //    sql = "Contributions_Sel_MemberLatestSalary_web";
                //}
                //else if (CalType == "A")
                //{
                //    sql = "Contributions_Sel_MemberLatestSalary_FundA";
                //}
                //else
                //{
                //    sql = "Contributions_Sel_MemberLatestSalary_FundB";
                //}


                //string sql = "Contributions_Sel_MemberLatestSalary";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, SystemRef);
                db.AddInParameter(cmd, "@PaymentDate", DbType.Date, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet MemberLastBonusWithInterest(int FundID, int SystemRef, DateTime LastBonusDate, DateTime ExitDate, string CalType)
        {
            try
            {
                string sql = "";
                if (CalType == "N")
                {
                    sql = "Contributions_Sel_MemberAfterReview_Startup";
                }
                else if (CalType == "A")
                {
                    sql = "Contributions_Sel_MemberAfterReview_Startup_FundA";
                }
                else
                {
                    sql = "Contributions_Sel_MemberAfterReview_Startup_FundB";
                }

                //string sql = "Contributions_Sel_MemberAfterReview_Startup";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, SystemRef);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@BonusDate", DbType.DateTime, LastBonusDate);
                db.AddInParameter(cmd, "@ExitDate", DbType.DateTime, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet Contributions_Sel_StartupValueMember_ForExits(int FundID, int refnumber, DateTime bonusdate, string CalType)
        {
            try
            {
                string sql = "";
                if (CalType == "N")
                {
                    sql = "Contributions_Sel_StartupValueMember_ForExits";
                }
                else if (CalType == "A")
                {
                    sql = "Contributions_Sel_StartupValueMember_ForExits";
                }
                else
                {
                    sql = "Contributions_Sel_StartupValueMember_ForExits";
                }


                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@memberId", DbType.Int32, refnumber);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@MyLastBonusDate", DbType.Date, bonusdate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet InterestRates_Sel_Last_forExits_AfterExitDate(int FundID, DateTime BonusDate)
        {
            try
            {
                string sql = "InterestRates_Sel_Last_forExits_AfterExitDate";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@MyLastBonusDate", DbType.DateTime, BonusDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet geteDateDiff(DateTime dt1, DateTime dt2)
        {
            string dt1s = dt1.ToString("yyyy-MM-dd");
            string dt2s = dt2.ToString("yyyy-MM-dd");

            string str = "select (DATEDIFF(MM,'" + dt1s + "','" + dt2s + "'))/12 as result";
            return ReturnDs(str);
        }
        public DataSet Contributions_Sel_MemberAfterReview_forExits(int FundID, int SystemRef, DateTime LastBonusDate, DateTime ExitDate)
        {
            try
            {
                string sql = "Contributions_Sel_MemberAfterReview_forExits";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, SystemRef);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@MyLastBonusDate", DbType.DateTime, LastBonusDate);
                db.AddInParameter(cmd, "@ExitDate", DbType.DateTime, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet InterestBasisAfterBonusDate(int FundID, DateTime BonusDate, DateTime CalDate)
        {
            try
            {
                string sql = "InterestBasis_Sel_Last_forExits_AfterLastBonusDate";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@BonusDate", DbType.DateTime, BonusDate);
                db.AddInParameter(cmd, "@CalcDate", DbType.DateTime, CalDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetBenefitFormula(int FundID)
        {
            //Fund f = new Fund("cn", 1);
            string RegNo = getRegNo(FundID);

            string str = "select top 1 * from MedicalFreeLimits where RegNo=Replace(Replace('" + RegNo + "','/#',''),'#','') order by id desc";
            return ReturnDs(str);
        }
        public double ValidateDouble(string exp)
        {
            double defaultValue = 0;
            if (double.TryParse(exp, out defaultValue))
            {
                return double.Parse(exp);
            }
            else
            {
                return defaultValue;
            }
        }
        public bool CheckRecordExists(string IDNumber, string RegNo, int MemberId)
        {
            try
            {
                string str = "SELECT top 1 * FROM FundExitsTemp where MemberID='" + MemberId + "' and RegNo='" + RegNo + "' and IDNumber='" + IDNumber + "'";
                if (ReturnDs(str) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public bool ValidateClaim(string IDNumber, string RegNo, int MemberId)
        {
            try
            {
                string str = "SELECT top 1 * FROM FundExitsQuotations where SystemRef='" + MemberId + "' and RegNo='" + RegNo + "' and NationalID='" + IDNumber + "'";
                if (ReturnDs(str) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public bool ValidateBranch(int BranchCode, int CompanyID)
        {
            try
            {
                string str = "select * from ParticipatingEmployer where CompanyID='"+ CompanyID + "' and id='"+ BranchCode + "'";
                if (ReturnDs(str) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public DataSet RetirementillHealthParameters(int FundID, int ExitMemberCategory, DateTime ExitDate)
        {
            try
            {
                string sql = "RetirementIllHealth_Sel_ByCategory";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@Category", DbType.Int32, ExitMemberCategory);
                db.AddInParameter(cmd, "@EffectiveDate", DbType.Date, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet StatutoryRequirements(int FundID, DateTime LastBonusDate)
        {
            try
            {
                string sql = "StatutaryRequirements_Sel_Active";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);

                db.AddInParameter(cmd, "@Date", DbType.Date, LastBonusDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet DeathStatutaryRequirements_Sel_Active(int FundID, DateTime LastBonusDate)
        {
            try
            {
                string sql = "DeathStatutaryRequirements_Sel_Active";

               
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);

                db.AddInParameter(cmd, "@Date", DbType.Date, LastBonusDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet InterestBasis(int FundID, DateTime ExitDate)
        {
            try
            {
                string sql = "InterestBasis_Sel_ByRegNo_Active";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@EffectiveDate", DbType.DateTime, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet MemberContributionsAfterReview(int FundID, int SystemRef, DateTime LastBonusDate, DateTime ExitDate, string CalType)
        {
            try
            {
                string sql = "";
                if (CalType == "N")
                {
                    sql = "Contributions_Sel_MemberAfterReview";
                }
                else if (CalType == "A")
                {
                    sql = "Contributions_Sel_MemberAfterReview_FundA";
                }
                else
                {
                    sql = "Contributions_Sel_MemberAfterReview_FundB";
                }

                //string sql = "Contributions_Sel_MemberAfterReview";

                //Fund f = new Fund(mConnectionName, mObjectUserID);
                string RegNo = getRegNo(FundID);

                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);
                db.AddInParameter(cmd, "@MemberID", DbType.Int32, SystemRef);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@BonusDate", DbType.DateTime, LastBonusDate);
                db.AddInParameter(cmd, "@ExitDate", DbType.DateTime, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public double FillCommutation(DateTime DateOfBirth, DateTime ExitDate, string Gender, int FundID, double Age, string ExitType)
        {
            double LowerCommutation = 0;
            double UpperCommutation = 0;
            double ConversionFactor = 0;
            string str = "";
            str = "AnnuityFactors_Sel_ByRegNoAge";
            //Fund f = new Fund(mConnectionName, mObjectUserID);
            string RegNo = getRegNo(FundID);
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(str);

            db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
            db.AddInParameter(cmd, "@Age", DbType.Int32, Age);


            DataSet ds = db.ExecuteDataSet(cmd);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (ExitType == "Death")
                    {
                        if (Gender == "M")
                        {
                            LowerCommutation = double.Parse(row["DMale"].ToString());
                        }
                        else
                        {
                            LowerCommutation = double.Parse(row["DFemale"].ToString());
                        }

                    }
                    else
                    {
                        if (Gender == "M")
                        {
                            LowerCommutation = double.Parse(row["RMale"].ToString());
                        }
                        else
                        {
                            LowerCommutation = double.Parse(row["RFemale"].ToString());
                        }
                    }
                }
            }
            else
            {
                return 0;
            }

            cmd = db.GetStoredProcCommand(str);

            db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
            db.AddInParameter(cmd, "@Age", DbType.Int32, Age + 1);


            DataSet dsi = db.ExecuteDataSet(cmd);
            if (dsi != null && dsi.Tables.Count > 0 && dsi.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsi.Tables[0].Rows)
                {
                    if (ExitType == "Death")
                    {
                        if (Gender == "M")
                        {
                            UpperCommutation = double.Parse(row["DMale"].ToString());
                        }
                        else
                        {
                            UpperCommutation = double.Parse(row["DFemale"].ToString());
                        }

                    }
                    else
                    {
                        if (Gender == "M")
                        {
                            UpperCommutation = double.Parse(row["RMale"].ToString());
                        }
                        else
                        {
                            UpperCommutation = double.Parse(row["RFemale"].ToString());
                        }
                    }
                }
            }

            int a = (int)Age;
            int b = a + 1;
            ConversionFactor = (b - Age) * LowerCommutation + (Age - a) * UpperCommutation;

            return ConversionFactor;
        }
        public DataSet GetMemberEligibilityRequirements(DateTime ExitDate, int FundID, string MemberCategory)
        {
            try
            {
                
                string RegNo = getRegNo(FundID);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("EligibilityRequirements_Sel_ByRegNoByCategory");
                db.AddInParameter(cmd, "@Date", DbType.Date, ExitDate);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                db.AddInParameter(cmd, "@Category", DbType.String, MemberCategory);

                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Columns.Add("DeathBenefitFormular");
                    ds.AcceptChanges();
                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetMemberDetails(int MemberID, int FundID)
        {
            try
            {
               
                string RegNo = getRegNo(FundID);
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("Member_Sel_ByIDAndRegNo_Portal");
                db.AddInParameter(cmd, "@ID", DbType.Int32, MemberID);
                db.AddInParameter(cmd, "@RegNo", DbType.String, RegNo);
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetApprovalDecisions()
        {
            try
            {
                string str = "select ID,Status from RegistrationStatuses";
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetContactTypes()
        {
            try
            {
                string str = "select ID,Description from ContactTypes";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getDs(string str)
        {
            return ReturnDs(str);
        }
        public DataSet getClientSavedDocuments(int TokenID)
        {
            string str = "select ad.id,ad.Name,dt.DocumentType from tblApplicationDocs ad inner join LuDocumentTypes dt on dt.ID= ad.DocTypeID  where ApplicationID=" + TokenID + "";
            return ReturnDs(str);
        }

        public DataSet getClientDummySavedDocuments(int ClientID)
        {
            string str = "select ad.id,ad.Name,dt.IdentityDocument as DocumentType  from tblApplicationDocs ad inner join IdentityDocumentTypes dt on dt.ID= ad.DocTypeID  where ApplicationID=" + ClientID + "";
            return ReturnDs(str);
        }

        public DataSet getRegisteredEmployerSavedDocuments(int TokenID)
        {
            string str = "select ad.id,ad.Name,dt.DocumentType from tblApplicationDocs ad inner join LuDocumentTypes dt on dt.ID= ad.DocTypeID  where MemberID=" + TokenID + "";
            return ReturnDs(str);
        }
        public DataSet GetJobTitles()
        {
            try
            {
                string str = "select ID,JobTitle from TitlesJob ";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getmembershipdetails()
        {
            try
            {
                string str = "select ID,Description from WithdrawalTypes ";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetThirdPartyTypes()
        {
            string str = "select ID,Description from ThirdPartyTypes";
            return ReturnDs(str);
        }
        public DataSet getActiveFunds()
        {
            string str = "select [Key],RegNo,RegName,RegName+' '+RegNo as Fund from FUND where [statusid]=1 order by RegName ";
            return ReturnDs(str);
        }

        public DataSet getActiveFunds(string Regname)
        {
            string str = "select [Key],RegNo,RegName,RegName+' '+RegNo as Fund from FUND where Regname like '%" + Regname + "%' order by RegName ";
            return ReturnDs(str);
        }

        public DataSet getSpouseRelations()
        {
            string str = "select * from RelationType  where ID in (7,8)";
            return ReturnDs(str);
        }
        public DataSet getGeneralRelations()
        {
            string str = "select * from RelationType  --where ID not in (7,8,1,3,10,11)";
            return ReturnDs(str);
        }
        public DataSet getChildRelations()
        {
            string str = "select * from RelationType  where ID  in (3,10,11)";
            return ReturnDs(str);
        }
        public DataSet GetIndentityDocs()
        {
            try
            {
                string str = "select * from IdentityDocumentTypes";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet GetFundTypes()
        {
            try
            {
                string str = "select ID,Description from FundType";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetSelectedFund(int ID)
        {
            try
            {
                string str = "select * from FUND where [Key] in (" + ID + ")";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetPresevationFunds(int ID)
        {
            try
            {
                string str = "select [KEY] as ID,RegName as Fund from FUND where [Key] not in (" + ID + ")";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet GetFundCategories(int ID)
        {
            try
            {
                string str = "select * from FundCategory fc inner join FUND f  on f.RegNo = fc.RegNo where f.[Key]=" + ID + "";
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        protected DataSet ReturnDs(string str)
        {
            try
            {
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        protected DataSet ReturnDsPayRoll(string str)
        {
            try
            {
                DataSet ds = dbPay.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getCurrency()
        {
            try
            {
                string str = "select ID,[Name] as Currency from Currencies ";
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getBanks()
        {
            try
            {
                string str = "select Id,Code,BankName from Banks order by BankName asc";
                return ReturnDsPayRoll(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getBankAccountTypes()
        {
            try
            {
                string str = "select ID,Description from BankAccountTypes ";
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getBankBranches(int ID)
        {
            try
            {
                string str = "select Id,BranchCode,Name from BankBranches where BankId=" + ID + "";
                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet getBranches()
        {
            try
            {
                string str = "select Id,BranchCode,Name from BankBranches order by name asc";
                return ReturnDsPayRoll(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        //Fund Quiries
        public DataSet getFundParticipatingEmployers(int FundID)
        {
            //string str = "select Pe.ID, M.ID AS MemberID , C.Surname as Company,Ids.TradeName,Ba.Description as BusinessClass, I.Description as Industry from ParticipatingEmployer Pe inner join Clients C on C.ID = Pe.CompanyID ";
            //str += "left join InstitutionDetails Ids on Ids.ClientID = C.ID left join BusinessActivities Ba on Ba.ID = Ids.BusinessActivityID ";
            //str += "inner join Member M on M.BranchId = C.ID left join Industries I on I.ID = Ids.IndustryID where C.ClientType = 2 and Pe.RegNo = (select RegNo from FUND where[Key] = " + FundID +")";
            string str = "select * from vwCompanyRegistrationDetails where RegNo=(select RegNo from Fund where [Key]=" + FundID + ")";
            return ReturnDs(str);
        }
        public DataSet getParticipatingEmployers()
        {
            //string str = "select Pe.ID, M.ID AS MemberID , C.Surname as Company,Ids.TradeName,Ba.Description as BusinessClass, I.Description as Industry from ParticipatingEmployer Pe inner join Clients C on C.ID = Pe.CompanyID ";
            //str += "left join InstitutionDetails Ids on Ids.ClientID = C.ID left join BusinessActivities Ba on Ba.ID = Ids.BusinessActivityID ";
            //str += "inner join Member M on M.BranchId = C.ID left join Industries I on I.ID = Ids.IndustryID where C.ClientType = 2 and Pe.RegNo = (select RegNo from FUND where[Key] = " + FundID +")";
            string str = "select * from ParticipatingEmployer where RegNo='R203/#'";
            return ReturnDs(str);
        }
        public DataSet getTestingEmployers()
        {
            //string str = "select Pe.ID, M.ID AS MemberID , C.Surname as Company,Ids.TradeName,Ba.Description as BusinessClass, I.Description as Industry from ParticipatingEmployer Pe inner join Clients C on C.ID = Pe.CompanyID ";
            //str += "left join InstitutionDetails Ids on Ids.ClientID = C.ID left join BusinessActivities Ba on Ba.ID = Ids.BusinessActivityID ";
            //str += "inner join Member M on M.BranchId = C.ID left join Industries I on I.ID = Ids.IndustryID where C.ClientType = 2 and Pe.RegNo = (select RegNo from FUND where[Key] = " + FundID +")";
            string str = "select * from companies where RegNo='R203/#'";
            return ReturnDs(str);
        }


        //

        public DataSet GeneralQuery(string str)
        {
            try
            {
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        

        public DataSet MemberContributionsCummulativeSalary(int SystemRef, DateTime ExitDate)
        {
            try
            {
                string sql = "Contributions_Sel_CumSalary";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);

                db.AddInParameter(cmd, "@MemberID", DbType.Int32, SystemRef);
                db.AddInParameter(cmd, "@ExitDate", DbType.Date, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }

        public DataSet TaxTables(double CumSalary, double BenefitAmount, DateTime ExitDate)
        {
            try
            {
                string sql = "TaxTables_Sel_ByAmount";
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand(sql);

                db.AddInParameter(cmd, "@Amount", DbType.Double, CumSalary);
                db.AddInParameter(cmd, "@BenefitAmount", DbType.Double, BenefitAmount);
                db.AddInParameter(cmd, "@EffectiveDate", DbType.Date, ExitDate);
                DataSet ds = db.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        //End Mmember Contribution Functions

    }

    public enum ReportTypes
    {
        WithdrawalExitQuotation,
        IllHealthExitQuotation,
        EarlyRetirementExitQuotation,
        NormalRetirementExitQuotation,
        LateRetirementExitQuotation,
        DeathExitEQuotation,
        MemberExitsRegister
    }
}