using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using FanucSite.Models;

namespace FanucSite.DAL
{
	public class Part_PicDAL : DAL<Part_Pic>
    {
        public Part_PicDAL()
        {
			initDb(ORMDAL.GetNormal, ORMDAL.GetRead, ORMDAL.GetWrite);
        }
    }
}