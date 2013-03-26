
using BrainMessApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrainMessTestCases
{
    [TestClass]
    public class BrainMessUnitTest
    {
        [TestMethod]
        public void TestIncrementAddress()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();
            //objBrainMessInterpreter.IncrementAddress();
            //objBrainMessInterpreter.IncrementAddress();
            //objBrainMessInterpreter.DecrementAddress();

            objBrainMessInterpreter.IncrementAddress();
            Assert.AreEqual(1,objBrainMessInterpreter.pointer);
        }

        [TestMethod]
        public void TestDecrementAddress()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();

            objBrainMessInterpreter.DecrementAddress();
            objBrainMessInterpreter.IncrementAddress();
            objBrainMessInterpreter.IncrementAddress();
            Assert.AreEqual(1, objBrainMessInterpreter.pointer);

            //objBrainMessInterpreter.DecrementAddress();
            //Assert.AreEqual(65534, objBrainMessInterpreter.pointer);
        }

        [TestMethod]
        public void TestIncrementValue()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();

            objBrainMessInterpreter.IncrementValue();
            Assert.AreEqual(1, objBrainMessInterpreter.pointer+1);
        }

        [TestMethod]
        public void TestDecrementValue()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();

            objBrainMessInterpreter.DecrementValue();
            Assert.AreEqual(-1, objBrainMessInterpreter.pointer-1);
        }

        [TestMethod]
        public void TestOutput()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();
            string[] array = new string[1];
            array[0] = "true";
            BrainMessInterpreter.Main(array);

            //objBrainMessInterpreter.IncrementAddress();
            //objBrainMessInterpreter.Output();
            //Assert.AreEqual(1, objBrainMessInterpreter.pointer);
        }

        [TestMethod]
        public void TestInput()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();
            
            objBrainMessInterpreter.Input();
            Assert.AreEqual(1, objBrainMessInterpreter.pointer);
        }



    }
}
