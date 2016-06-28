using System;
using ORM;
namespace FanucSite.Models
{
    [Serializable]
    [DbTable("Part")]
    public class Part
    {
		public Part() { }			
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
        protected string _materialNumber = string.Empty;
		///<summary>
        ///物料编号
        ///</summary>
		[DbField("materialNumber", "NVARCHAR", 200)]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { _materialNumber = value; }
        }
        protected string _materialDescription = string.Empty;
		///<summary>
        ///物料描述
        ///</summary>
		[DbField("materialDescription", "NVARCHAR", 200)]
        public string MaterialDescription
        {
            get { return _materialDescription; }
            set { _materialDescription = value; }
        }
        protected string _oldModel = string.Empty;
		///<summary>
        ///旧型号
        ///</summary>
		[DbField("oldModel", "NVARCHAR", 200)]
        public string OldModel
        {
            get { return _oldModel; }
            set { _oldModel = value; }
        }
        protected string _oneLevelSort = string.Empty;
		///<summary>
        ///一级分类
        ///</summary>
		[DbField("oneLevelSort", "NVARCHAR", 200)]
        public string OneLevelSort
        {
            get { return _oneLevelSort; }
            set { _oneLevelSort = value; }
        }
        protected string _twoLevelSort = string.Empty;
		///<summary>
        ///二级分类
        ///</summary>
		[DbField("twoLevelSort", "NVARCHAR", 200)]
        public string TwoLevelSort
        {
            get { return _twoLevelSort; }
            set { _twoLevelSort = value; }
        }
        protected string _name = string.Empty;
		///<summary>
        ///名称
        ///</summary>
		[DbField("name", "NVARCHAR", 200)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        protected string _explain = string.Empty;
		///<summary>
        ///说明
        ///</summary>
		[DbField("explain", "NVARCHAR", 200)]
        public string Explain
        {
            get { return _explain; }
            set { _explain = value; }
        }
        protected int _isStop = 0;
		///<summary>
        ///停产
        ///</summary>
		[DbField("isStop", "INT")]
        public int IsStop
        {
            get { return _isStop; }
            set { _isStop = value; }
        }
        protected decimal _price = 0M;
		///<summary>
        ///价格(元)
        ///</summary>
		[DbField("price", "DECIMAL(18,2)")]
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
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
		#endregion
	}
}
