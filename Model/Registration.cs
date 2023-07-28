using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PenPortfolio.Model
{
    internal class Registration
    {
        #region "Variables"

        protected long mId;
        protected long mEventID;
        protected long mRegTypeID;
        protected string mDateAdded;
        protected bool mIsApproved;
        protected string mFirstName;
        protected string mLastName;
        protected string mCompany;
        protected string mCategory;
        protected string mPhoneNumber;
        protected string mEmail;
        protected string mNationalID;
        protected string mMsgFlg;


        protected Database db;
        protected string mConnectionName;

        protected long mObjectUserID;
        #endregion

        #region "Properties"

        public string Msgflg
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

        public long Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public long EventID
        {
            get { return mEventID; }
            set { mEventID = value; }
        }

        public long RegTypeID
        {
            get { return mRegTypeID; }
            set { mRegTypeID = value; }
        }

        public string DateAdded
        {
            get { return mDateAdded; }
            set { mDateAdded = value; }
        }

        public bool IsApproved
        {
            get { return mIsApproved; }
            set { mIsApproved = value; }
        }

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string LastName
        {
            get { return mLastName; }
            set { mLastName = value; }
        }

        public string Company
        {
            get { return mCompany; }
            set { mCompany = value; }
        }

        public string Category
        {
            get { return mCategory; }
            set { mCategory = value; }
        }

        public string PhoneNumber
        {
            get { return mPhoneNumber; }
            set { mPhoneNumber = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string NationalID
        {
            get { return mNationalID; }
            set { mNationalID = value; }
        }

        #endregion

        #region "Methods"

        #region "Constructors"


        public Registration(string ConnectionName, long ObjectUserID)
        {
            mObjectUserID = ObjectUserID;
            mConnectionName = ConnectionName;
            db = new DatabaseProviderFactory().Create(ConnectionName);

        }

        #endregion


        public void Clear()
        {
            mId = 0;
            mEventID = 0;
            mRegTypeID = 0;
            mDateAdded = "";
            mIsApproved = false;
            mFirstName = "";
            mLastName = "";
            mCompany = "";
            mCategory = "";
            mPhoneNumber = "";
            mEmail = "";
            mNationalID = "";

        }

        #region "Retrieve Overloads"

        public virtual bool Retrieve()
        {

            return this.Retrieve(mId);

        }

        public virtual bool Retrieve(long Id)
        {

            string sql = null;

            if (Id > 0)
            {
                sql = "SELECT * FROM RegistrationMembers WHERE Id = " + Id;
            }
            else
            {
                sql = "SELECT * FROM RegistrationMembers WHERE Id = " + mId;
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
                    mMsgFlg = "Registration not found.";

                    return false;

                }


            }
            catch (Exception e)
            {
                mMsgFlg = e.Message;
                return false;

            }

        }

        public virtual System.Data.DataSet GetRegistration()
        {

            return GetRegistration(mId);

        }

        public virtual DataSet GetRegistration(long Id)
        {

            string sql = null;

            if (Id > 0)
            {
                sql = "SELECT * FROM RegistrationMembers WHERE Id = " + Id;
            }
            else
            {
                sql = "SELECT * FROM RegistrationMembers WHERE Id = " + mId;
            }

            return GetRegistration(sql);

        }

        protected virtual DataSet GetRegistration(string sql)
        {

            return db.ExecuteDataSet(CommandType.Text, sql);

        }

        #endregion


        protected internal virtual void LoadDataRecord(DataRow rw)
        {


            mId = ((object)rw["ID"] == DBNull.Value) ? 0 : int.Parse(rw["ID"].ToString());
            mEventID = ((object)rw["EventID"] == DBNull.Value) ? 0 : int.Parse(rw["EventID"].ToString());
            mRegTypeID = ((object)rw["RegTypeID"] == DBNull.Value) ? 0 : int.Parse(rw["RegTypeID"].ToString());
            mDateAdded = ((object)rw["DateAdded"] == DBNull.Value) ? "" : rw["DateAdded"].ToString();
            mIsApproved = ((object)rw["IsApproved"] == DBNull.Value) ? false : bool.Parse(rw["IsApproved"].ToString());
            mFirstName = ((object)rw["FirstName"] == DBNull.Value) ? "" : rw["FirstName"].ToString();
            mLastName = ((object)rw["LastName"] == DBNull.Value) ? "" : rw["LastName"].ToString();
            mCompany = ((object)rw["Company"] == DBNull.Value) ? "" : rw["Company"].ToString();
            mCategory = ((object)rw["Category"] == DBNull.Value) ? "" : rw["Category"].ToString();
            mPhoneNumber = ((object)rw["PhoneNumber"] == DBNull.Value) ? "" : rw["PhoneNumber"].ToString();
            mEmail = ((object)rw["Email"] == DBNull.Value) ? "" : rw["Email"].ToString();
            mNationalID = ((object)rw["NationalID"] == DBNull.Value) ? "" : rw["NationalID"].ToString();


        }

        #region "Save"


        public virtual void GenerateSaveParameters(ref Database db, ref System.Data.Common.DbCommand cmd)
        {
            db.AddInParameter(cmd, "@Id", DbType.Int32, mId);
            db.AddInParameter(cmd, "@EventID", DbType.Int32, mEventID);
            db.AddInParameter(cmd, "@RegTypeID", DbType.Int32, mRegTypeID);
            db.AddInParameter(cmd, "@DateAdded", DbType.String, mDateAdded);
            db.AddInParameter(cmd, "@IsApproved", DbType.Boolean, mIsApproved);
            db.AddInParameter(cmd, "@FirstName", DbType.String, mFirstName);
            db.AddInParameter(cmd, "@LastName", DbType.String, mLastName);
            db.AddInParameter(cmd, "@Company", DbType.String, mCompany);
            db.AddInParameter(cmd, "@Category", DbType.String, mCategory);
            db.AddInParameter(cmd, "@PhoneNumber", DbType.String, mPhoneNumber);
            db.AddInParameter(cmd, "@Email", DbType.String, mEmail);
            db.AddInParameter(cmd, "@NationalID", DbType.String, mNationalID);

        }

        public virtual bool Save()
        {

            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("sp_Save_Registration");

            GenerateSaveParameters(ref db, ref cmd);


            try
            {
                DataSet ds = db.ExecuteDataSet(cmd);


                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    mId = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

                }

                return true;


            }
            catch (Exception ex)
            {
                mMsgFlg = ex.Message;
                return false;

            }

        }

        #endregion

        #region "Delete"

        public virtual bool Delete()
        {

            //Return Delete("UPDATE RegistrationMembers SET Deleted = 1 WHERE Id = " & mId) 
            return Delete("DELETE FROM RegistrationMembers WHERE Id = " + mId);

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
                mMsgFlg = e.Message;
                return false;

            }

        }

        #endregion

        #endregion
    }
}