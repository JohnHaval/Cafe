using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe.Tools;
using System;

namespace CafeUnitTests
{
    [TestClass]
    public class CheckActionsUnitTest
    {
        [TestMethod]
        public void __1TestHasHoldCount()//Проверка работы спуска до 0 остатков
        {
            Assert.IsTrue(CheckActions.HasHoldCount(new Cafe.Models.Products()
            {
                HoldCount = 2//задаем остатки
            }, 2));//задаем количество для списания
        }
        [TestMethod]
        public void __2TestHasHoldCount()//Проверка работы с остатками больше 0
        {
            Assert.IsTrue(CheckActions.HasHoldCount(new Cafe.Models.Products()
            {
                HoldCount = 3//задаем остатки
            }, 2));//задаем количество для списания
        }
        [TestMethod]
        public void __3TestHasHoldCount()//Проверка работы с остатками меньше 0
        {
            try
            {
                Assert.IsTrue(CheckActions.HasHoldCount(new Cafe.Models.Products()
                {
                    HoldCount = 1//задаем остатки
                }, 2));//задаем количество для списания
                throw new Exception();//Если ошибка метода - будет исключение здесь
            }
            catch { }
        }
        [TestMethod]
        public void __4TestGetDiscount()//Проверка работы скидки до 300 р. (должно быть 0)
        {
            Assert.IsTrue(CheckActions.GetDiscount(299) == 0);
        }
        [TestMethod]
        public void __5TestGetDiscount()//Проверка работы скидки от 300 р. (должно быть 9)
        {
            Assert.IsTrue(CheckActions.GetDiscount(300) == 9);
        }
        [TestMethod]
        public void __6TestGetDiscount()//Проверка работы скидки до 500 р. (должно быть 15)
        {
            Assert.IsTrue(CheckActions.GetDiscount(500) == 15);
        }
        [TestMethod]
        public void __7TestGetDiscount()//Проверка работы скидки от 501 р. (должно быть 25,05)
        {
            Assert.IsTrue(CheckActions.GetDiscount(501) == Convert.ToDecimal(25.05));
        }
        [TestMethod]
        public void __8TestGetDiscount()//Проверка работы скидки до 1000 р. (должно быть 50)
        {
            Assert.IsTrue(CheckActions.GetDiscount(1000) == 50);
        }
        [TestMethod]
        public void __9TestGetDiscount()//Проверка работы скидки от 1001 р. (должно быть 70,07)
        {
            Assert.IsTrue(CheckActions.GetDiscount(1001) == Convert.ToDecimal(70.07));
        }
        [TestMethod]
        public void _10TestGetDiscount()//Проверка работы скидки до 5000 р. (должно быть 350)
        {
            Assert.IsTrue(CheckActions.GetDiscount(5000) == 350);
        }
        [TestMethod]
        public void _11TestGetDiscount()//Проверка работы скидки от 5001 р. (должно быть 500,1)
        {
            Assert.IsTrue(CheckActions.GetDiscount(5001) == Convert.ToDecimal(500.1));
        }
    }
}
