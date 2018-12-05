using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    public static class FileReader
    {
        public static string[] Read(string worldListFileName)
        {
            string[] fileConent;
            try
            {
                fileConent = File.ReadAllLines(worldListFileName);
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return fileConent;

        }
    }
}
