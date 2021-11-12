using System;
using System.Collections.Generic;
using MyPayProject;
using NUnit.Framework;

namespace MyPayNUnitTestProject
{
    public class Tests
    {
        private List<PayRecord> _records;
        /// <summary>
        /// test impote csv files path
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _records = CsvLmporter.ImportPayRecords(@"/Users/sunrenfei/Projects/MyPaySolution/MyPayProject/Import/employee-payroll-data.csv");
            
        }
        /// <summary>
        /// test the csv file is not null
        /// </summary>
        [Test]
        public void TestImport()
        {
            Assert.NotNull(_records);
        }

        /// <summary>
        /// test gorss caculation is correct
        /// </summary>
        [Test]
        public void TestGross()
        {
            Assert.AreEqual(_records[0].Gross, 652.00, 0.1);
            Assert.AreEqual(_records[1].Gross, 418, 0.1);
            Assert.AreEqual(_records[2].Gross, 2202, 0.1);
            Assert.AreEqual(_records[3].Gross, 1104, 0.1);
            Assert.AreEqual(_records[4].Gross, 1797.45,0.1);
        }

        /// <summary>
        /// test tax caculation is correct
        /// </summary>
        [Test]
        public void TestTax()
        {
            Assert.AreEqual(_records[0].Tax, 182.4528, 0.1);
            Assert.AreEqual(_records[1].Tax, 133.76, 0.1);
            Assert.AreEqual(_records[2].Tax, 717.9589, 0.1);
            Assert.AreEqual(_records[3].Tax, 165.6, 0.1);
            Assert.AreEqual(_records[4].Tax, 578.38915, 0.1);
        }
        /// <summary>
        /// test net caculation is correct
        /// </summary>
        [Test]
        public void TestNet()
        {
            Assert.AreEqual(_records[0].Net, 469.5472, 0.1);
            Assert.AreEqual(_records[1].Net, 284.24, 0.1);
            Assert.AreEqual(_records[2].Net, 1484.0411, 0.1);
            Assert.AreEqual(_records[3].Net, 938.4, 0.1);
            Assert.AreEqual(_records[4].Net, 1219.06085, 0.1);

        }


        /// <summary>
        /// test export csv file's path and name
        /// </summary>
        [Test]
        public void TestExport()
        {
            string filePath = @"/Users/sunrenfei/Projects/MyPaySolution/MyPayNUnitTestProject/Export";

            string fileName = PayRecordWriter.write(_records, filePath, true);

            Assert.That(fileName, Does.Exist);
        }
        public Tests()
        {

        }
    }
}
