using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using FanucSite.Models;

namespace FanucSite.DAL
{
	public class GCodeDAL : DAL<GCode>
    {
        public GCodeDAL()
        {
			initDb(ORMDAL.GetNormal, ORMDAL.GetRead, ORMDAL.GetWrite);
        }
    }
}