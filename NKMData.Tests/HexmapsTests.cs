using System.Collections.Generic;
using NUnit.Framework;

namespace NKMData.Tests
{
    public class HexmapsTests
    {
        [Test]
        public void AvaiableMapsNotEmpty()
        {
            var maps = new List<(string, string)>(Hexmaps.AvaiableMapsWithNames);
			Assert.True(maps.Count > 0);
        }
    }
}