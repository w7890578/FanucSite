using System;
using ORM;
namespace FanucSite.Models
{
    [Serializable]
    [DbTable("Part_Children")]
    public class Part_Children
    {
		public Part_Children() { }			
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
        protected string _partID = string.Empty;
		///<summary>
        ///部件ID(外键)
        ///</summary>
		[DbField("partID", "NVARCHAR", 50)]
        public string PartID
        {
            get { return _partID; }
            set { _partID = value; }
        }
        protected string _childMaterialNumber = string.Empty;
		///<summary>
        ///子物料编号
        ///</summary>
		[DbField("childMaterialNumber", "NVARCHAR", 200)]
        public string ChildMaterialNumber
        {
            get { return _childMaterialNumber; }
            set { _childMaterialNumber = value; }
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
