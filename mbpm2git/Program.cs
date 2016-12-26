using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace mbpm2git
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            try
            {
                Executer.Execute(args);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                System.Environment.ExitCode = 1;
            }
            finally
            {
                //logger.Info("Press a key to quit..");
                //Console.ReadKey();
            }
        }

    }
}
