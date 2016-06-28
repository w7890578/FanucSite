using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

using FanucSite.Models;
using FanucSite.BLL;

namespace FanucSite.Web.Controllers
{
    public class Part_PicController : BaseController
    {
        /// <summary>
        /// 第一次访问
        /// </summary> 
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entity">视图查询对象</param>
        /// <returns>Json字符串</returns>
        [HttpPost]
        public JsonResult Query(Part_PicView entity)
        {
            entity.CurrentPage = new PageNation<Part_PicView>()
            {
                PageIndex = FunLayer.Transform.Int(Request["page"], 1),
                PageSize = FunLayer.Transform.Int(Request["rows"], 50)
            };
            entity.Get_List();
            return Json(entity.CurrentPage);
        }
        
        /// <summary>
        /// 获取明细
        /// </summary>
        /// <param name="entity">视图查询对象</param>
        /// <returns>Json字符串</returns>
        [HttpPost]
        public JsonResult Get_Details(Part_PicView entity)
        {
            entity.Get_Detail();
            return Json(entity.CurrentPage.Detail);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">操作对象</param>
        /// <returns>ok=操作成功,no=操作失败</returns>
        [HttpPost]
        public ContentResult Delete(Part_Pic entity)
        {
            bool result= Part_PicBLL.Instance.Where("ID=@ID").Parms(entity.ID)
                .Update("IsDel=1");
            return Content(result ? "ok" : "no", "text/html");
        }

        /// <summary>
        /// 保存（添加/编辑）
        /// </summary>
        /// <param name="entity">操作对象</param>
        /// <returns>ok=操作成功,no=操作失败</returns>
        [HttpPost]
        public ContentResult Save(Part_Pic entity)
        {
            bool result = false; 
            if (!string.IsNullOrEmpty(entity.ID)) //编辑
            {
                entity.UpdateTime = DateTime.Now;
                result = Part_PicBLL.Instance.Update(entity, 
              new string[] {  
                         "UpdateTime",
                         "PartID",
                         "ImgUrl",
                         "ImgDescription"
                        });
            }
            else//添加
            {
                object ob = Part_PicBLL.Instance.Add(entity, 
                new string[] { 
                         "PartID",
                         "ImgUrl",
                         "ImgDescription"
                        });
                result = ob != null;
            }
            return Content(result ? "ok" : "no", "text/html");
        }
    }  
}
