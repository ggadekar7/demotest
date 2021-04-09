using demo.Controllers;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class PrimeTests
    {
        [Fact]
        public async void CheckNumberIsPrime_Success()
        {
            Service service = new Service();
            ModelCls modelCls = new ModelCls();
            modelCls.Number = 2;
            bool result = service.isPrime(modelCls);
            Assert.True(result);
        }

        [Fact]
        public async void CheckNumberIsPrime_Fail()
        {
            Service service = new Service();
            ModelCls modelCls = new ModelCls();
            modelCls.Number = 4;
            bool result = service.isPrime(modelCls);
            Assert.False(result);
        }
    }
}
