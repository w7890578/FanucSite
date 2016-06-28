using System;
using System.Collections.Generic;
using System.Text;
using ORM;
using FanucSite.Models;

namespace FanucSite.DAL
{
	public class ExplainBookDAL : DAL<ExplainBook>
    {
        public ExplainBookDAL()
        {
			initDb(ORMDAL.GetNormal, ORMDAL.GetRead, ORMDAL.GetWrite);
        }
    }
}