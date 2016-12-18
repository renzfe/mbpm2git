using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using NLog;
using mbpm2git.Assets;

namespace mbpm2git.Operations
{
    class Extractor
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public static void Execute(Procedure p, DestinationFolder d)
        {
            DirectoryInfo finalDestination = null;

            if (d.Name().ToLower() == p.Name().ToLower())
            {
                string m = string.Format("destination name can not be {0}", p.Name());
                throw new Exception(m);
            }

            try
            {
                string subFolder = Path.Combine(d.FullName(), p.Name());
                finalDestination = new DirectoryInfo(subFolder);
                logger.Debug("checking procedure folder {0}..", finalDestination.FullName);
                if (finalDestination.Exists) 
                {
                    logger.Debug("cleaning folder {0}..", finalDestination.FullName);
                    finalDestination.Delete(true);
                }

                logger.Debug("creating folder {0}..", finalDestination.FullName);
                finalDestination.Create();

            }
            catch (Exception ex)
            {
                logger.Debug(ex.Message);
            }

            logger.Info("start extracting...");
            ZipFile.ExtractToDirectory(p.FullName(), finalDestination.FullName);
           
        }
    }
}
