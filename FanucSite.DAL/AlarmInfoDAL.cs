using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using FanucSite.Models;

namespace FanucSite.DAL
{
	public class AlarmInfoDAL : DAL<AlarmInfo>
    {
        public AlarmInfoDAL()
        {
			initDb(ORMDAL.GetNormal, ORMDAL.GetRead, ORMDAL.GetWrite);
        }
    }
}