using System;
using ORM;
namespace FanucSite.Models
{
    [Serializable]
    [DbTable("User")]
    public class User
    {
        #region 角色枚举
        public enum RoleEnum
        { 
            注册用户 = 1,
            内部用户 = 2
        }
        #endregion
        public User() { }
        #region 字段属性
        protected string _id = string.Empty;
        ///<summary>
        ///主键
        ///</summary>
        [DbField("id", "NVARCHAR", 50, ORMType = ORMFieldType.Key | ORMFieldType.Unique)]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        protected string _companyName = string.Empty;
        ///<summary>
        ///公司名称
        ///</summary>
        [DbField("companyName", "NVARCHAR", 50)]
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        protected string _post = string.Empty;
        ///<summary>
        ///职务
        ///</summary>
        [DbField("post", "NVARCHAR", 50)]
        public string Post
        {
            get { return _post; }
            set { _post = value; }
        }
        protected string _fullName = string.Empty;
        ///<summary>
        ///姓名
        ///</summary>
        [DbField("fullName", "NVARCHAR", 50)]
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        protected string _email = string.Empty;
        ///<summary>
        ///邮箱
        ///</summary>
        [DbField("email", "NVARCHAR", 50)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        protected string _nickname = string.Empty;
        ///<summary>
        ///昵称
        ///</summary>
        [DbField("nickname", "NVARCHAR", 50)]
        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        protected string _phone = string.Empty;
        ///<summary>
        ///手机
        ///</summary>
        [DbField("phone", "NVARCHAR", 50)]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        protected string _passWord = string.Empty;
        ///<summary>
        ///密码
        ///</summary>
        [DbField("passWord", "NVARCHAR", 50)]
        public string PassWord
        {
            get { return _passWord; }
            set { _passWord = value; }
        }
        protected bool _isDel = true;
        ///<summary>
        ///0未删除，1已删除
        ///</summary>
        [DbField("isDel", "BIT")]
        public bool IsDel
        {
            get { return _isDel; }
            set { _isDel = value; }
        }
        protected bool _isVisable = true;
        ///<summary>
        ///
        ///</summary>
        [DbField("isVisable", "BIT")]
        public bool IsVisable
        {
            get { return _isVisable; }
            set { _isVisable = value; }
        }
        protected DateTime _createTime;
        ///<summary>
        ///
        ///</summary>
        [DbField("createTime", "DATETIME")]
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        protected DateTime _updateTime;
        ///<summary>
        ///
        ///</summary>
        [DbField("updateTime", "DATETIME")]
        public DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }
        protected int _auditStatus = 0;
        ///<summary>
        ///审核状态，0未审核，1审核通过，2审核不通过
        ///</summary>
        [DbField("auditStatus", "INT")]
        public int AuditStatus
        {
            get { return _auditStatus; }
            set { _auditStatus = value; }
        }
        protected DateTime _auditTime;
        ///<summary>
        ///审核时间
        ///</summary>
        [DbField("auditTime", "DATETIME")]
        public DateTime AuditTime
        {
            get { return _auditTime; }
            set { _auditTime = value; }
        }
        protected int _role = 0;
        ///<summary>
        ///角色
        ///</summary>
        [DbField("role", "INT")]
        public int Role
        {
            get { return _role; }
            set { _role = value; }
        }

        protected string _remark = string.Empty;
        ///<summary>
        ///密码
        ///</summary>
        [DbField("remark", "NVARCHAR", 50)]
         public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        
        #endregion
    }
}
