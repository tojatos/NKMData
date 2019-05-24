using System.Collections.Generic;
using NUnit.Framework;

namespace NKMData.Tests
{
    public class DatabaseTests
    {
        [Test]
        public void CharacterNamesNotEmpty()
        {
			List<string> names = Database.GetCharacterNames();
			Assert.True(names.Count > 0);
        }
    }
}
