using MintaZH3.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH3.Test
{
    public class ChildTest
    {
        [
            Test,
            TestCase(1,true),
            TestCase(2, true),
            TestCase(3, true),
            TestCase(4, true),
            TestCase(5, true),
            TestCase(0, true),
            TestCase(455, true)

        ]
        public void TestCheckBehaviour(int value, bool expectedResult)
        {
            var c = new Child();

            var actualResult = c.CheckBehaviour(value);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
