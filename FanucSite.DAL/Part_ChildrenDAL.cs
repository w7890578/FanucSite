using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using FanucSite.Models;

namespace FanucSite.DAL
{
	public class Part_ChildrenDAL : DAL<Part_Children>
    {
        public Part_ChildrenDAL()
        {
			initDb(ORMDAL.GetNormal, ORMDAL.GetRead, ORMDAL.GetWrite);
        }
    }
}