using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace PenPortfolio.Model
{
    public class PortalAccesssUsers
    {
		#region "Variables"

		protected string mMsgFlg;
		protected string mLastPasswordUpdate;
		protected long mID;
		protected long mCreatedBy;
		protected string mDateCreated;
		protected string mRegNo;
		protected string mCode;
		protected string mUsername;
		protected string mPassword;
		protected string mFirstname;
		protected string mSurname;
        //protected string mRegNo;
        protected int mSystemRef;
        protected DataSet mUserDetails;
        protected string mRoleType;
		protected Database db;
        protected Database dbPay;
        protected string mConnectionName;

		protected long mObjectUserID;
		#endregion

		#region "Properties"
		public int SystemRef
        {
			get { return mSystemRef; }
			set { mSystemRef = value; }
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

		public string OwnerType
		{
			get { return this.GetType().Name; }
		}

		public string ConnectionName
		{
			get { return mConnectionName; }
		}

		public string LastPasswordUpdate
		{
			get { return mLastPasswordUpdate; }
			set { mLastPasswordUpdate = value; }
		}

		public long ID
		{
			get { return mID; }
			set { mID = value; }
		}

		public long CreatedBy
		{
			get { return mCreatedBy; }
			set { mCreatedBy = value; }
		}

		public string DateCreated
		{
			get { return mDateCreated; }
			set { mDateCreated = value; }
		}

		public string RegNo
		{
			get { return mRegNo; }
			set { mRegNo = value; }
		}

		public string Username
		{
			get { return mUsername; }
			set { mUsername = value; }
		}

		public string Password
		{
			get { return mPassword; }
			set { mPassword = value; }
		}

		public string Firstname
		{
			get { return mFirstname; }
			set { mFirstname = value; }
		}

		public string Surname
		{
			get { return mSurname; }
			set { mSurname = value; }
		}

		public string RoleType
		{
			get { return mRoleType; }
			set { mRoleType = value; }
		}

		public string Code
		{
			get { return mCode; }
			set { mCode = value; }
		}

		#endregion

		#region "Methods"

		#region "Constructors"


		public PortalAccesssUsers(string ConnectionName, long ObjectUserID)
		{
			mObjectUserID = ObjectUserID;
			mConnectionName = ConnectionName;
			db = new DatabaseProviderFactory().Create(ConnectionName);
            dbPay = new DatabaseProviderFactory().Create("cn");
        }

		#endregion


		public void Clear()
		{
			mLastPasswordUpdate = null;
			mID = 0;
			mCreatedBy = mObjectUserID;
			mDateCreated = "";
			mRegNo = "";
			mUsername = "";
			mPassword = "";
			mFirstname = "";
			mSurname = "";
			mRoleType = "";
			mSystemRef = 0;

		}

		#region "Retrieve Overloads"

		public virtual bool Retrieve()
		{

			return this.Retrieve(mID);

		}

		public virtual bool Retrieve(long ID)
		{

			string sql = null;

			if (ID > 0)
			{
				sql = "SELECT * FROM PortalAccessUsers WHERE ID = " + ID;
			}
			else
			{
				sql = "SELECT * FROM PortalAccessUsers WHERE ID = " + mID;
			}

			return Retrieve(sql);

		}

		protected virtual bool Retrieve(string sql)
		{


			try
			{
				DataSet dsRetrieve = db.ExecuteDataSet(CommandType.Text, sql);


				if (dsRetrieve != null && dsRetrieve.Tables.Count > 0 && dsRetrieve.Tables[0].Rows.Count > 0)
				{
					LoadDataRecord(dsRetrieve.Tables[0].Rows[0]);

					dsRetrieve = null;
					return true;


				}
				else
				{
					SetErrorDetails("PortalAccesssUsers not found.");

					return false;

				}


			}
			catch (Exception e)
			{
				SetErrorDetails(e.Message);
				return false;

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
        public DataSet getQueryTypes()
        {
            try
            {
				string str = "select * from QueryTypes";
				return ReturnDs(str);
            }
			catch(Exception ex)
            {
				mMsgFlg = ex.Message;
				return null;

            }
        }
		public DataSet getSearchOptions()
        {
			string str = "select * from SearchOption";
			return ReturnDs(str);

		}
		public DataSet getACtiveEmployees(string RegNo)
        {
            try
            {
				string str = "select top 20 PensionNo as ID,'Head Office' as Branch,FirstName,LastName,CONVERT(varchar(12),DateOfBirth,110) as Dob,CONVERT(varchar(12),DateJoinedPayroll,110) as DJC,CONVERT(varchar(12),PensionStartDate,110) as DJF,'Executive' as MemberCategory from PayPensioner  where RegNo='R101' order by PensionNo desc";
				return ReturnDs(str);
            }
			catch(Exception ex)
            {
				mMsgFlg = ex.Message;
				return null;
            }
        }
		public DataSet getACtivePensioners(string RegNo)
		{
			try
			{
				string str = "select top 20 PensionNo as ID,PensionBasis as Branch,FirstName,LastName,CONVERT(varchar(12),DateOfBirth,110) as Dob,CONVERT(varchar(12),DateJoinedPayroll,110) as DJC,CONVERT(varchar(12),PensionStartDate,110) as DJF,PensionType as MemberCategory from PayPensioner  where RegNo='R101' order by Lastname desc";
				return ReturnDs(str);
			}
			catch (Exception ex)
			{
				mMsgFlg = ex.Message;
				return null;
			}
		}

		public bool GetFundName(string RegNo)
		{
			string str = "select * from FUND where RegName like 'Fintrust%' ";
			ReturnDs(str);
			return true;
		}
        public DataSet getActiveFunds(string RegNo, int id)
        {
            try
            {
				//string str = "select f.RegName,c.PhysicalAddress1,c.PhysicalAddress2,c.PhysicalAddress3,c.Name,c.BusinessClassification from FUND f inner join Companies c on f.RegNo=c.RegNo  where f.RegNo='"+RegNo+"' and c.ID='"+id+"'";
				string str = "select f.RegName,c.Address,c.Name,c.BusinessClassification from FUND f inner join ParticipatingEmployer c on f.RegNo=c.RegNo  where  c.ID=" + id;

                return ReturnDs(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
        public DataSet PensionerLoginAccountDetails(int PensionerNo,string Reg )
        {
            try
            {
                string str = "select convert(varchar(12),pp.DateOfBirth,110) DOB,convert(varchar(12),pp.PensionStartDate,110) PSD,convert(varchar(12),pp.DateOfBirth,110) AS DFP, PP.*,(select MAX(convert(varchar(12),LastPayDate,110)) from PayPayslips where PensionNo = PP.PensionNo) as LastPaymentDate,(select MIN(convert(varchar(12),RunDate,110)) from PayPayrollCalendar where RegNo = PP.RegNo and PayPeriod = PP.PayPeriod AND RunDone='N') as NextRunDATE from PayPensioner PP  where PP.PensionNo=" + PensionerNo + " and PP.RegNo='" + Reg + "'";
                return ReturnDsPayRoll(str);
            }
			catch(Exception ex)
            {
				mMsgFlg = ex.Message;
				return null;
            }
        }
        public DataSet GetArrears(int PensionerNo, string Reg)
        {
            try
            {
                string str = "select top 1 Arrears,MonthlySalary,BankAccountNo from PayPayslips where PensionNo='" + PensionerNo + "' and RegNo='" + Reg + "' order by LastPayDate desc";
                return ReturnDsPayRoll(str);
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return null;
            }
        }
		public DataSet getLoginCode(long systemRef)
		{
			try
			{
				string str = "select * from Portal_Users where SystemRef="+systemRef;
				return ReturnDs(str);
			}
			catch (Exception ex)
			{
				MsgFlg = ex.Message;
				return null;
			}
		}

		public Boolean ValidateUser(string username)
		{
            try
            {
                string str = "select * from Portal_Users where LoginCode ='" + username + "'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ReturnDs(str) != null)
                {
                    DataRow rw = ds.Tables[0].Rows[0];
                    EncryptDecryptClass ep = new EncryptDecryptClass();
                    
                        mUserDetails = ds;
                        mSystemRef = int.Parse(ReturnDs(str).Tables[0].Rows[0]["SystemRef"].ToString());
                        mRoleType = ReturnDs(str).Tables[0].Rows[0]["RoleID"].ToString();
                        mRegNo = ReturnDs(str).Tables[0].Rows[0]["RegNo"].ToString();
                        mCode = ReturnDs(str).Tables[0].Rows[0]["LoginCode"].ToString();
                        return true;
                    
                    

                }
                else
                {
                    mMsgFlg = "Invalid UserName";
                    return false;
                }
            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;
            }
        }
        public Boolean ValidateUserLogin(string username, string password)
		{
			try
			{
				string str = "select * from Portal_Users where LoginCode ='" + username + "'";
                DataSet ds = db.ExecuteDataSet(CommandType.Text, str);
                if (ReturnDs(str) != null)
				{
                    DataRow rw = ds.Tables[0].Rows[0];
                    EncryptDecryptClass ep = new EncryptDecryptClass();
                    if (password == ep.DecryptPassword(rw["password"].ToString()))
                    {
                        mUserDetails = ds;
                        mSystemRef = int.Parse(ReturnDs(str).Tables[0].Rows[0]["SystemRef"].ToString());
                        mRoleType = ReturnDs(str).Tables[0].Rows[0]["RoleID"].ToString();
                        mRegNo = ReturnDs(str).Tables[0].Rows[0]["RegNo"].ToString();
						mCode = ReturnDs(str).Tables[0].Rows[0]["LoginCode"].ToString();
						return true;
                    }
                    else
                    {
                        //Put code to increase password failed attempts and also to lock account here
                        mMsgFlg = "Invalid PasswOrd";
                        return false;
                    }
                 
				}
				else
				{
                    mMsgFlg = "Invalid UserName";
                    return false;
                }
			}
			catch (Exception ex)
			{
				mMsgFlg = ex.Message;
				return false;
			}
		}

		public virtual System.Data.DataSet GetPortalAccesssUsers()
		{

			return GetPortalAccesssUsers(mID);

		}

		public virtual DataSet GetPortalAccesssUsers(long ID)
		{

			string sql = null;

			if (ID > 0)
			{
				sql = "SELECT * FROM PortalAccessUsers WHERE ID = " + ID;
			}
			else
			{
				sql = "SELECT * FROM PortalAccessUsers WHERE ID = " + mID;
			}

			return GetPortalAccesssUsers(sql);

		}

		protected virtual DataSet GetPortalAccesssUsers(string sql)
		{

			return db.ExecuteDataSet(CommandType.Text, sql);

		}

		#endregion


		protected internal virtual void LoadDataRecord(DataRow rw)
		{


			mLastPasswordUpdate = (rw["LastPasswordUpdate"] == DBNull.Value) ? string.Empty : rw["LastPasswordUpdate"].ToString();
			mID = ((object)rw["ID"] == DBNull.Value) ? 0 : int.Parse(rw["ID"].ToString());
			mCreatedBy = ((object)rw["CreatedBy"] == DBNull.Value) ? 0 : int.Parse(rw["CreatedBy"].ToString());
			mDateCreated = rw["DateCreated"] == DBNull.Value ? DateTime.Today.ToString() : rw["DateCreated"].ToString();
			mRegNo = (rw["RegNo"] == DBNull.Value) ? string.Empty : rw["RegNo"].ToString();
			mUsername = (rw["Username"] == DBNull.Value) ? string.Empty : rw["Username"].ToString();
			mPassword = (rw["Password"] == DBNull.Value) ? string.Empty : rw["Password"].ToString();
			mFirstname = (rw["Firstname"] == DBNull.Value) ? string.Empty : rw["Firstname"].ToString();
			mSurname = (rw["Surname"] == DBNull.Value) ? string.Empty : rw["Surname"].ToString();
			mRoleType = (rw["RoleType"] == DBNull.Value) ? string.Empty : rw["RoleType"].ToString();


		}

		#region "Save"


		public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
		{
			db.AddInParameter(cmd, "@LastPasswordUpdate", DbType.Date, mLastPasswordUpdate);
			db.AddInParameter(cmd, "@ID", DbType.Int32, mID);
			db.AddInParameter(cmd, "@DateCreated", DbType.String, mDateCreated);
			db.AddInParameter(cmd, "@RegNo", DbType.String, mRegNo);
			db.AddInParameter(cmd, "@Username", DbType.String, mUsername);
			db.AddInParameter(cmd, "@Password", DbType.String, mPassword);
			db.AddInParameter(cmd, "@Firstname", DbType.String, mFirstname);
			db.AddInParameter(cmd, "@Surname", DbType.String, mSurname);
			db.AddInParameter(cmd, "@RoleType", DbType.String, mRoleType);

		}

		public virtual bool Save()
		{

			System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_PortalAccesssUsers");

			GenerateSaveParameters(ref db, ref cmd);


			try
			{
				DataSet ds = db.ExecuteDataSet(cmd);


				if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
				{
					mID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

				}

				return true;


			}
			catch (Exception ex)
			{
				SetErrorDetails(ex.Message);
				return false;

			}

		}

		#endregion

		#region "Delete"

		public virtual bool Delete()
		{

			//Return Delete("UPDATE PortalAccessUsers SET Deleted = 1 WHERE ID = " & mID) 
			return Delete("DELETE FROM PortalAccessUsers WHERE ID = " + mID);

		}

		protected virtual bool Delete(string DeleteSQL)
		{


			try
			{
				db.ExecuteNonQuery(CommandType.Text, DeleteSQL);
				return true;


			}
			catch (Exception e)
			{
				SetErrorDetails(e.Message);
				return false;

			}

		}
		protected void SetErrorDetails(string str)
		{
			mMsgFlg = str;
		}

		#endregion

		#endregion
	}
}