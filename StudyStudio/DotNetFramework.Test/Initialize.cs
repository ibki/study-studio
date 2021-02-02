using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace DotNetFramework.Test
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // 테스트 출력결과에 콘솔 출력내용이 표시
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }
    }
}
