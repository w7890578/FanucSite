using System;
using ORM;
namespace FanucSite.Models
{
    [Serializable]
    [DbTable("ExplainBook")]
    public class ExplainBook
    {
		public ExplainBook() { }			
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
        protected string _bookNumber = string.Empty;
		///<summary>
        ///说明书编号
        ///</summary>
		[DbField("bookNumber", "NVARCHAR", 50)]
        public string BookNumber
        {
            get { return _bookNumber; }
            set { _bookNumber = value; }
        }
        protected string _bookName = string.Empty;
		///<summary>
        ///名称
        ///</summary>
		[DbField("bookName", "NVARCHAR", 50)]
        public string BookName
        {
            get { return _bookName; }
            set { _bookName = value; }
        }
        protected string _version = string.Empty;
		///<summary>
        ///版本
        ///</summary>
		[DbField("version", "NVARCHAR", 50)]
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        protected string _language = string.Empty;
		///<summary>
        ///语言
        ///</summary>
		[DbField("language", "NVARCHAR", 50)]
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        protected string _oneLevelSort = string.Empty;
		///<summary>
        ///一级分类
        ///</summary>
		[DbField("oneLevelSort", "NVARCHAR", 50)]
        public string OneLevelSort
        {
            get { return _oneLevelSort; }
            set { _oneLevelSort = value; }
        }
        protected string _twoLeverSort = string.Empty;
		///<summary>
        ///二级分类
        ///</summary>
		[DbField("twoLeverSort", "NVARCHAR", 50)]
        public string TwoLeverSort
        {
            get { return _twoLeverSort; }
            set { _twoLeverSort = value; }
        }
        protected string _downLoadLink = string.Empty;
		///<summary>
        ///下载链接
        ///</summary>
		[DbField("downLoadLink", "NVARCHAR", 200)]
        public string DownLoadLink
        {
            get { return _downLoadLink; }
            set { _downLoadLink = value; }
        }
        protected string _extractPwd = string.Empty;
		///<summary>
        ///提取密码
        ///</summary>
		[DbField("extractPwd", "NVARCHAR", 50)]
        public string ExtractPwd
        {
            get { return _extractPwd; }
            set { _extractPwd = value; }
        }
        protected string _unzipPwd = string.Empty;
		///<summary>
        ///解压密码
        ///</summary>
		[DbField("unzipPwd", "NVARCHAR", 50)]
        public string UnzipPwd
        {
            get { return _unzipPwd; }
            set { _unzipPwd = value; }
        }
        protected int _isLoginCheck = 0;
		///<summary>
        ///登录查看
        ///</summary>
		[DbField("isLoginCheck", "INT")]
        public int IsLoginCheck
        {
            get { return _isLoginCheck; }
            set { _isLoginCheck = value; }
        }
        protected string _remark = string.Empty;
		///<summary>
        ///备注
        ///</summary>
		[DbField("remark", "NVARCHAR", 200)]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        protected int _accessCount = 0;
		///<summary>
        ///访问量
        ///</summary>
		[DbField("accessCount", "INT")]
        public int AccessCount
        {
            get { return _accessCount; }
            set { _accessCount = value; }
        }
        protected int _isDel = 0;
		///<summary>
        ///
        ///</summary>
		[DbField("isDel", "INT")]
        public int IsDel
        {
            get { return _isDel; }
            set { _isDel = value; }
        }
        protected int _isVisable = 0;
		///<summary>
        ///
        ///</summary>
		[DbField("isVisable", "INT")]
        public int IsVisable
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
		#endregion
	}
}
