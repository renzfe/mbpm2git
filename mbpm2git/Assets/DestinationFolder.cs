using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;

namespace mbpm2git.Assets
{
    class DestinationFolder
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private DirectoryInfo dir = null;

        public string FullName()
        {
            return dir.FullName;
        }

        public string Name()
        {
            return dir.Name;
        }

        public bool Exists()
        {
            return dir.Exists;
        }

        public DestinationFolder(string d)
        {
            dir = new DirectoryInfo(d);

            if (dir == null) throw new Exception("invalid destination path");

            try
            {
                if (!dir.Parent.Exists) dir.Parent.Create();
            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
                throw ex;
            }
        }

    }
}
