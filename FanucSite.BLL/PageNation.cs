using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FanucSite.BLL
{
    /// <summary>
    /// 分页通用对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageNation<T> where T : new()
    {
        private int pageIndex = 1;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize = 15;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int _total = 0;

        public int total
        {
            get { return _total; }
            set { _total = value; }
        }
        private List<T> _rows = new List<T>();

        public List<T> rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        private T _detail = default(T);
        public T Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
    }
}
