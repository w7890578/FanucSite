using System;
using ORM;
namespace Company.Models
{
    [Serializable]
    [DbTable("UserInfo")]
    public class UserInfo
    {
        public UserInfo() { }
        #region 字段属性
        protected int _id = 0;
        ///<summary>
        ///
        ///</summary>
        [DbField("id", "INT", ORMType = ORMFieldType.Identity | ORMFieldType.Key | ORMFieldType.Unique)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        protected string _contactName = string.Empty;
        ///<summary>
        ///联系人
        ///</summary>
        [DbField("contactName", "NVARCHAR", 500)]
        public string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
        }
        protected string _contactPost = string.Empty;
        ///<summary>
        ///联系人职位
        ///</summary>
        [DbField("contactPost", "NVARCHAR", 500)]
        public string ContactPost
        {
            get { return _contactPost; }
            set { _contactPost = value; }
        }
        protected string _fixedTelephone = string.Empty;
        ///<summary>
        ///固定电话（多个以“,”号分隔）
        ///</summary>
        [DbField("fixedTelephone", "NVARCHAR", 200)]
        public string FixedTelephone
        {
            get { return _fixedTelephone; }
            set { _fixedTelephone = value; }
        }
        protected string _mobile = string.Empty;
        ///<summary>
        ///手机
        ///</summary>
        [DbField("mobile", "NVARCHAR", 500)]
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        protected string _fax = string.Empty;
        ///<summary>
        ///传真
        ///</summary>
        [DbField("fax", "NVARCHAR", 500)]
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        protected DateTime _createTime;
        ///<summary>
        ///记录创建时间
        ///</summary>
        [DbField("createTime", "DATETIME")]
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        protected DateTime _updateTime;
        ///<summary>
        ///更新时间
        ///</summary>
        [DbField("updateTime", "DATETIME")]
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
        protected DateTime _expTime;
        ///<summary>
        ///导出时间
        ///</summary>
        [DbField("expTime", "DATETIME")]
        public DateTime ExpTime
        {
            get { return _expTime; }
            set { _expTime = value; }
        }
        protected string _companyName = string.Empty;
        ///<summary>
        ///公司名称
        ///</summary>
        [DbField("companyName", "NVARCHAR", 200)]
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        protected string _siteUrl = string.Empty;
        ///<summary>
        ///网址
        ///</summary>
        [DbField("siteUrl", "NVARCHAR", 500)]
        public string SiteUrl
        {
            get { return _siteUrl; }
            set { _siteUrl = value; }
        }
        #endregion
    }
}
