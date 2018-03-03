using System;
using Xunit;

namespace TDDSample.Web.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // テストコード、プログラム、ISSUE
            // テストコードは失敗から書き始める
            Assert.Equal(3,3);
        }
        
        [Fact]
        public void Test2()
        {
            // テストコード、プログラム、ISSUE
            // テストコードは失敗から書き始める
            Assert.Equal(2m,Math.Round((1.5m)));
        }
        
        [Fact]
        public void Test3()
        {
            // テストコード、プログラム、ISSUE
            // テストコードは失敗から書き始める
            Assert.Equal(2m,Math.Round((2.5m)));
        }
        
        
        
        
    }
}