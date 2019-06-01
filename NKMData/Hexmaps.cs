using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NKMData
{
    public class Hexmaps
    {
        private static string HexmapsFolderPath => Path.Combine(Program.DataPath, "HexMaps");

        private static List<(string map, string name)> _avaiableMapsWithNames; 
        public static List<(string map, string name)> AvaiableMapsWithNames => _avaiableMapsWithNames ?? (_avaiableMapsWithNames = new DirectoryInfo(HexmapsFolderPath).GetFiles()
            .Select(f => (File.ReadAllText(f.FullName), Path.GetFileNameWithoutExtension(f.Name))).ToList());


    }
}