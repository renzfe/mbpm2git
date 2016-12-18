using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using NLog;

namespace mbpm2git.Operations
{
    class FormatterForXML
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void XmlSearch(string rootDirectory)
        {
            try
            {
                foreach (string f in Directory.GetFiles(rootDirectory))
                {
                    FileInfo fi = new FileInfo(f);
                    if ((fi.Extension.ToUpper() == ".XML") || (fi.Extension.ToUpper() == ".XEF"))
                    {
                        logger.Debug("Converting.. {0}", fi.FullName);
                        FormatFile(fi.FullName);
                    }
                }
                foreach (string d in Directory.GetDirectories(rootDirectory))
                {
                    XmlSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                logger.Error("Error formatting {0}", excpt.Message);
            }
        }

        private static void FormatFile(string filePath)
        {
            String xml = String.Empty;

            try
            {
                xml = File.ReadAllText(filePath);
                logger.Debug("Read: {0}", filePath);
                xml = PrintXML(xml);
                logger.Debug("Printed: {0}", filePath);
                File.WriteAllText(filePath, xml);
                logger.Debug("Saved: {0}", filePath);
            }
            catch(Exception ex)
            {
                logger.Error("Error converting {0}", filePath);
            }

        }

        private static String PrintXML(String XML)
        {
            String Result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(XML);
                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                String FormattedXML = sReader.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException xmlex)
            {
                logger.Error("Error:{0}", xmlex.Message);
                Result = XML;
            }

            mStream.Close();
            writer.Close();

            return Result;
        }

    }
}
