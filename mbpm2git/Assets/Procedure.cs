using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mbpm2git.Assets
{
    class Procedure
    {
        private FileInfo _path;

        public bool IsLibrary()
        {
            bool lib = false;

            if (_path.Extension.ToLower() == "xel".ToLower())
            {
                lib = true;
            }

            return lib;
        }

        public string FullName()
        {
            return _path.FullName;
        }

        public string Name()
        {
            return _path.Name;
        }

        public Procedure(string path)
        {
            _path = new FileInfo(path);

            if (_path == null) throw new Exception("invalid procedure path");

            if (!_path.Exists)
            {
                throw new Exception("procedure file does not exist");
            }

            if ( (_path.Extension.ToLower() != ".xep".ToLower()) && (_path.Extension.ToLower() != ".xel".ToLower()) )
            {
                throw new Exception(string.Format("invalid file extension [{0}]",_path.Extension));
            }
        }

    }
}
