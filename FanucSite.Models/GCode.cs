using System;
using ORM;
namespace FanucSite.Models
{
    [Serializable]
    [DbTable("GCode")]
    public class GCode
    {
		public GCode() { }			
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
        protected string _codeNumber = string.Empty;
		///<summary>
        ///代码编号
        ///</summary>
		[DbField("codeNumber", "NVARCHAR", 50)]
        public string CodeNumber
        {
            get { return _codeNumber; }
            set { _codeNumber = value; }
        }
        protected string _functionDescription = string.Empty;
		///<summary>
        ///功能简述
        ///</summary>
		[DbField("functionDescription", "NVARCHAR", 100)]
        public string FunctionDescription
        {
            get { return _functionDescription; }
            set { _functionDescription = value; }
        }
        protected string _content = string.Empty;
		///<summary>
        ///内容
        ///</summary>
		[DbField("content", "NVARCHAR", -1)]
        public string Content
        {
            get { return _content; }
            set { _content = value; }
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
        protected int _goodComment = 0;
		///<summary>
        ///好评
        ///</summary>
		[DbField("goodComment", "INT")]
        public int GoodComment
        {
            get { return _goodComment; }
            set { _goodComment = value; }
        }
        protected int _badComment = 0;
		///<summary>
        ///差评
        ///</summary>
		[DbField("badComment", "INT")]
        public int BadComment
        {
            get { return _badComment; }
            set { _badComment = value; }
        }
        protected int _commentCount = 0;
		///<summary>
        ///评论数
        ///</summary>
		[DbField("commentCount", "INT")]
        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value; }
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
        protected bool _isDel = true;
		///<summary>
        ///是否删除： 0未删除，1已删除
        ///</summary>
		[DbField("isDel", "BIT")]
        public bool IsDel
        {
            get { return _isDel; }
            set { _isDel = value; }
        }
        protected bool _isVisable = true;
		///<summary>
        ///是否启用 ：0启用，1禁用
        ///</summary>
		[DbField("isVisable", "BIT")]
        public bool IsVisable
        {
            get { return _isVisable; }
            set { _isVisable = value; }
        }
        protected DateTime _createTime;
		///<summary>
        ///创建时间
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
        protected int _type = 0;
		///<summary>
        ///类型：1G代码，2M代码
        ///</summary>
		[DbField("type", "INT")]
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
		#endregion
	}
}
