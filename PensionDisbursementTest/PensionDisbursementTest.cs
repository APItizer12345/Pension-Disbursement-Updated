using Moq;
using NUnit.Framework;
using PensionDisbursement;
using PensionDisbursement.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace PensionDisbursementTest
{
    public class Tests
    {
        PensionDisbursementController controller = new PensionDisbursementController();

        ProcessPensionInput pensionInput1 = new ProcessPensionInput();
        
        //pensionInput1.aadharNumber = "BCFPN1234F";
        //pensionInput1.pensionAmount = 25500;
        //pensionInput1.bankType = 2;

        public List<ProcessPensionInput> pensioner = new List<ProcessPensionInput>
           {
               new ProcessPensionInput{aadharNumber = "BCFPN1234F",
                                        pensionAmount = 25500,
                                        bankType = 2
                                   },
               new ProcessPensionInput{aadharNumber = "ABCDE2345G",
                                        pensionAmount = 28500,
                                        bankType = 1
                                   }

           };

        [SetUp]
        public void Setup()
        {
            var processPension = pensioner.AsQueryable();
            var mockset = new Mock<ProcessPensionInput>();
            mockset.As<IQueryable<ProcessPensionInput>>().Setup(m => m.Provider).Returns(processPension.Provider);
            mockset.As<IQueryable<ProcessPensionInput>>().Setup(m => m.Expression).Returns(processPension.Expression);
            mockset.As<IQueryable<ProcessPensionInput>>().Setup(m => m.ElementType).Returns(processPension.ElementType);
            mockset.As<IQueryable<ProcessPensionInput>>().Setup(m => m.GetEnumerator()).Returns(processPension.GetEnumerator());

        }

        [Test]
        public void Test1()
        {
            var result = controller.GetDisbursePension(pensionInput1);
            var type1 = result;
            //var type1 = 10;
            Assert.IsNotNull(type1);
        }

        [Test]
        public void Test2()
        {
            var result = controller.GetDisbursePension(pensionInput1);
            var type1 = result;
            //var type1 = 10;

            Assert.Positive(type1);
        }

        [Test]
        public void ProcessPension_Person_Valid()
        {
            var result = controller.GetDisbursePension(pensionInput1);
            var type = result;
            var status = 10;
            Assert.AreEqual(result, status);
        }

        //[Test]
        //public void ProcessPension_Person_Invalid()
        //{
        //    var result = controller.GetDisbursePension();
        //    var type = result;
        //    var status = 21;
        //    Assert.AreEqual(result, status);
        //}

    }
}