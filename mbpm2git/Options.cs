using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using System.Reflection;

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

        [Option('c', "copy", Required = false, HelpText = "Copy xep or xel file")]
        public bool CopyZippedFile { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            string v = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
            var help = new HelpText
            {
                Heading = new HeadingInfo("mbpm2git.exe", v ),
                AdditionalNewLineAfterOption = false,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Usage: mbpm2git.exe -i xep_file_path -o output_directory_path [-f] [-c]");
            help.AddOptions(this);

            return help;
        }

    }
}
