using AutoFixture;
using NUnit.Framework;
using System.Linq;
using Reusable.SizeExtensions;
using FluentAssertions;

namespace ReusableTests.Extensions
{
    [TestFixture]
    public class SizeExtensions
    {
        [TestCase]
        public void ToFileSize_LessThanKilobyte_ReturnsBytes()
        {
            var fixture = new Fixture();
            var size = fixture.Create<Generator<long>>().FirstOrDefault(z => z < 1024);

            var message = size.ToFileSize();

            message.Should().BeEquivalentTo($"{size.ToString("F0")}B");
        }
    }
}
