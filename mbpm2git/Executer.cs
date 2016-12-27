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

            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                procedureName = options.InputFile;
                procedureDirecory = options.OutputPath;

                logger.Debug("checking file: {0}", procedureName);
                Procedure p = new Procedure(procedureName);
                logger.Debug("procedure file: {0}", p.FullName());

                logger.Debug("checking destination folder: {0}", procedureDirecory);
                DestinationFolder d = new DestinationFolder(procedureDirecory);
                logger.Debug("destination folder: {0}", d.FullName());

                Extractor.Execute(p, d);

                if (options.FormatExtractedXML)
                {
                    logger.Debug("formatting xml files..");
                    FormatterForXML.XmlSearch(d.FullName());
                }

                if (options.CopyZippedFile)
                {
                    string dest = Path.Combine(d.FullName(), p.Name());
                    logger.Debug("copy file {0}..", dest);
                    File.Copy(p.FullName(), dest, true);
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
