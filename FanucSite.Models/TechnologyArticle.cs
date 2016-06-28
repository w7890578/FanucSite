using System;
using ORM;
namespace FanucSite.Models
{
    [Serializable]
    [DbTable("TechnologyArticle")]
    public class TechnologyArticle
    {
		public TechnologyArticle() { }			
		#region 字段属性
        protected string _id = string.Empty;
		///<summary>
        ///
        ///</summary>
		[DbField("id", "NVARCHAR", 50, ORMType = ORMFieldType.Key | ORMFieldType.Unique)]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        protected string _title = string.Empty;
		///<summary>
        ///标题
        ///</summary>
		[DbField("title", "NVARCHAR", 50)]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
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
        protected string _source = string.Empty;
		///<summary>
        ///来源
        ///</summary>
		[DbField("source", "NVARCHAR", 200)]
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        protected string _classify = string.Empty;
		///<summary>
        ///分类
        ///</summary>
		[DbField("classify", "NVARCHAR", 50)]
        public string Classify
        {
            get { return _classify; }
            set { _classify = value; }
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
        protected int _goodComment = 0;
		///<summary>
        ///好评数
        ///</summary>
		[DbField("goodComment", "INT")]
        public int GoodComment
        {
            get { return _goodComment; }
            set { _goodComment = value; }
        }
        protected int _badComment = 0;
		///<summary>
        ///差评数
        ///</summary>
		[DbField("badComment", "INT")]
        public int BadComment
        {
            get { return _badComment; }
            set { _badComment = value; }
        }
        protected bool _isDel = true;
		///<summary>
        ///
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
        ///发布日期
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
