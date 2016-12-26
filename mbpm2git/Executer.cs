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

            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                procedureName = options.InputFile;
                procedureDirecory = options.OutputPath;

                if (options.FormatExtractedXML)
                {
                    formatExtractedXML = true;
                }

                logger.Debug("checking file {0}", procedureName);
                Procedure p = new Procedure(procedureName);

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
            else
            {
                options.GetUsage();
            }
        }

    }
}
