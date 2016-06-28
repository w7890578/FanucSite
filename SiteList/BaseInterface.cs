using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteList
{
    /// <summary>
    /// 定义网站抓取函数
    /// </summary>
    public interface SiteGrabIn
    {
        //抓取数据
        void Grab(object i);
        //保存数据
        //void SaveData();
    }


}
