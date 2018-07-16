using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Biblionary.BLL
{
    public static class LogBLL
    {
        private static ILog _log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return _log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
