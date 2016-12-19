using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;
using mbpm2git.Assets;
using mbpm2git.Operations;

namespace mbpm2git
{
    class Executer
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Execute(string[] args)
        {
            string procedureName = string.Empty;
            string procedureDirecory = string.Empty;
            bool formatExtractedXML = false;

            if (args.Length < 2)
            {
                throw new Exception("use mbpm2git [procedure file path] [destination path] [format xml:true|false]");
            }

            if (args.Length > 2)
            {
                if (args[2].ToLower() == "true".ToLower())
                {
                    formatExtractedXML = true;
                }
            }

            procedureName = args[0];
            logger.Debug("checking file {0}", procedureName);
            Procedure p = new Procedure(procedureName);

            procedureDirecory = args[1];
            logger.Debug("checking destination folder {0}", procedureDirecory);
            DestinationFolder d = new DestinationFolder(procedureDirecory);

            Extractor.Execute(p, d);
            if (formatExtractedXML)
            {
                logger.Debug("formatting xml files..");
                FormatterForXML.XmlSearch(d.FullName());
            }
            logger.Info("Extraction done");

 
        }
    }
}
