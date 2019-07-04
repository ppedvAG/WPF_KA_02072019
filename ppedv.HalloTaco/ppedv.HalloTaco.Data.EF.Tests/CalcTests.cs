using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.HalloTaco.Data.EF.Tests
{
    [TestFixture]
    public class CalcTests
    {
        [Test]
        public void Calc_Sum_2_and_1_result_3()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 1);

            //Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Calc_Sum_MAX_and_1_throws_OverflowsException()
        {
            //Arrange
            var calc = new Calc();

            //Acts
            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }
    }

    class Calc
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }
    }
}
