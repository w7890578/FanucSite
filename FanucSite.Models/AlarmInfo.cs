using System;
using ORM;
namespace FanucSite.Models
{
    [Serializable]
    [DbTable("AlarmInfo")]
    public class AlarmInfo
    {
		public AlarmInfo() { }			
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
        protected string _alarmType = string.Empty;
		///<summary>
        ///报警类型
        ///</summary>
		[DbField("alarmType", "NVARCHAR", 50)]
        public string AlarmType
        {
            get { return _alarmType; }
            set { _alarmType = value; }
        }
        protected string _alarmNumber = string.Empty;
		///<summary>
        ///报警编号
        ///</summary>
		[DbField("alarmNumber", "NVARCHAR", 50)]
        public string AlarmNumber
        {
            get { return _alarmNumber; }
            set { _alarmNumber = value; }
        }
        protected string _alarmMeaning = string.Empty;
		///<summary>
        ///报警含义
        ///</summary>
		[DbField("alarmMeaning", "NVARCHAR", 50)]
        public string AlarmMeaning
        {
            get { return _alarmMeaning; }
            set { _alarmMeaning = value; }
        }
        protected string _brieflyNotes = string.Empty;
		///<summary>
        ///简要注释
        ///</summary>
		[DbField("brieflyNotes", "NVARCHAR", 200)]
        public string BrieflyNotes
        {
            get { return _brieflyNotes; }
            set { _brieflyNotes = value; }
        }
        protected string _excludeAdvice = string.Empty;
		///<summary>
        ///排查建议
        ///</summary>
		[DbField("excludeAdvice", "NVARCHAR", -1)]
        public string ExcludeAdvice
        {
            get { return _excludeAdvice; }
            set { _excludeAdvice = value; }
        }
        protected string _applicableSystem = string.Empty;
		///<summary>
        ///适用系统
        ///</summary>
		[DbField("applicableSystem", "NVARCHAR", 200)]
        public string ApplicableSystem
        {
            get { return _applicableSystem; }
            set { _applicableSystem = value; }
        }
        protected string _imgUrl = string.Empty;
		///<summary>
        ///图片
        ///</summary>
		[DbField("imgUrl", "NVARCHAR", 200)]
        public string ImgUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
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
