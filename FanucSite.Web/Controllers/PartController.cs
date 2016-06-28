using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FanucSite.Models;
using FanucSite.BLL;
using System.Xml;
using System.Data;

namespace FanucSite.Web.Controllers
{
    public class PartController : BaseController
    {
        /// <summary>
        /// 第一次访问
        /// </summary> 
        public ActionResult Index(string id,string name="")
        {
            // Response 
            //
            // Request.Cookies
            return View();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="entity">视图查询对象</param>
        /// <returns>Json字符串</returns>
        [HttpPost]
        public JsonResult Query(PartView entity)
        {
            entity.CurrentPage = new PageNation<PartView>()
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
        public JsonResult Get_Details(PartView entity)
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
        public ContentResult Delete(Part entity)
        {
            bool result = PartBLL.Instance.Where("ID=@ID").Parms(entity.ID)
                .Update("IsDel=1");
            return Content(result ? "ok" : "no", "text/html");
        }

        /// <summary>
        /// 保存（添加/编辑）
        /// </summary>
        /// <param name="entity">操作对象</param>
        /// <returns>ok=操作成功,no=操作失败</returns>
        [HttpPost]
        public ContentResult Save(PartView entity)
        { 
            bool result = false;
            if (!string.IsNullOrEmpty(entity.ID)) //编辑
            {
                entity.UpdateTime = DateTime.Now;
                result = PartBLL.Instance.Update(entity,
              new string[] {  
                         "MaterialNumber",
                         "MaterialDescription",
                         "OldModel",
                         "OneLevelSort",
                         "TwoLevelSort",
                         "Name",
                         "Explain",
                         "IsStop",
                         "Price",
                         "AccessCount",
                         "GoodComment",
                         "BadComment",
                         "CommentCount",
                         "UpdateTime"
                        });
                SetChildren(entity);
            }
            else//添加
            {
                entity.ID = Guid.NewGuid().ToString();
                object ob = PartBLL.Instance.Add(entity,
                new string[] { 
                         "MaterialNumber",
                         "MaterialDescription",
                         "OldModel",
                         "OneLevelSort",
                         "TwoLevelSort",
                         "Name",
                         "Explain",
                         "IsStop",
                         "Price",
                         "AccessCount",
                         "GoodComment",
                         "BadComment",
                         "CommentCount",
                        });
                SetChildren(entity);
                result = ob != null;
            }
            return Content(result ? "ok" : "no", "text/html");
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ContentResult UploadImg()
        {
            string msg = string.Empty;
            string error = string.Empty;
            string imgurl = string.Empty;
            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase hpf = Request.Files["user_log"] as HttpPostedFileBase;
                    string savepath = "/images/Part";
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + System.IO.Path.GetExtension(hpf.FileName);
                    hpf.SaveAs(string.Concat(Server.MapPath(savepath), @"\", fileName));

                    msg = "success";
                    imgurl = string.Concat(savepath, "/" + fileName);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                msg = "error";
            }
            return Content("{ error:'" + error + "', msg:'" + msg + "',imgurl:'" + imgurl + "'}", "text/html");
        }

        public void SetChildren(PartView entity)
        {
            entity.Part_PicList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Part_Pic>>(Request["Part_PicList"]);
            entity.Part_ChildrenList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Part_Children>>(Request["Part_ChildrenList"]);


            bool resultchild = Part_ChildrenBLL.Instance.Where("PartID=@PartID").Parms(entity.ID)
                 .Update("IsDel=1");
            if (resultchild)
            {
                foreach (var item in entity.Part_ChildrenList)
                {
                    item.PartID = entity.ID;
                    Part_ChildrenBLL.Instance.Add(item, new string[] { "PartID", "ChildMaterialNumber", "Remark" });
                }
            }
            bool resultpic = Part_PicBLL.Instance.Where("PartID=@PartID").Parms(entity.ID)
                 .Update("IsDel=1");
            if (resultpic)
            {
                foreach (var item in entity.Part_PicList)
                {
                    item.PartID = entity.ID;
                    Part_PicBLL.Instance.Add(item, new string[] { "PartID", "ImgUrl", "ImgDescription" });
                }
            }
        }
    }
}
