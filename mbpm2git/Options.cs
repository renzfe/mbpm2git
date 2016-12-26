using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace mbpm2git
{
    class Options
    {

        [Option('i', "input", Required = true, HelpText = "Input file to read")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output path to write")]
        public string OutputPath { get; set; }

        [Option('f', "formatxml", Required = false, HelpText = "Format xml file")]
        public bool FormatExtractedXML { get; set; }

        //[Option("length", DefaultValue = -1, HelpText = "The maximum number of bytes to process.")]
        //public int MaximumLength { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("mbpm2git.exe", "" ),
                AdditionalNewLineAfterOption = false,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Usage: mbpm2git.exe -i [xep file path] -o [output directory file path]");
            help.AddOptions(this);

            return help;
        }

    }
}
