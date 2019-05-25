using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NKMData
{
    public class Hexmaps
    {
        public static readonly List<(string map, string name)> AvaiableMapsWithNames = new DirectoryInfo("HexMaps").GetFiles()
            .Select(f => (File.ReadAllText(f.FullName), Path.GetFileNameWithoutExtension(f.Name))).ToList();

    }
}