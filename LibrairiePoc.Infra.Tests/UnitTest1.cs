using FluentAssertions;
using Xunit;

namespace LibrairiePoc.Infra.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            true.Should().BeFalse();
        }
    }
}