using System;
using ORM;
namespace FanucSite.Models
{
    [Serializable]
    [DbTable("Part_Pic")]
    public class Part_Pic
    {
		public Part_Pic() { }			
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
        protected string _partID = string.Empty;
		///<summary>
        ///部件ID
        ///</summary>
		[DbField("partID", "NVARCHAR", 50)]
        public string PartID
        {
            get { return _partID; }
            set { _partID = value; }
        }
        protected string _imgUrl = string.Empty;
		///<summary>
        ///图片路径
        ///</summary>
		[DbField("imgUrl", "NVARCHAR", 300)]
        public string ImgUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
        }
        protected string _imgDescription = string.Empty;
		///<summary>
        ///图片描述
        ///</summary>
		[DbField("imgDescription", "NVARCHAR", 200)]
        public string ImgDescription
        {
            get { return _imgDescription; }
            set { _imgDescription = value; }
        }
		#endregion
	}
}
