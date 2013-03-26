
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
            objBrainMessInterpreter.IncrementAddress();
            Assert.AreEqual(1, objBrainMessInterpreter.Pointer);
        }

        [TestMethod]
        public void TestDecrementAddress()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();

            objBrainMessInterpreter.DecrementAddress();
            objBrainMessInterpreter.IncrementAddress();
            objBrainMessInterpreter.IncrementAddress();
            Assert.AreEqual(1, objBrainMessInterpreter.Pointer);
        }

        [TestMethod]
        public void TestIncrementValue()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();

            objBrainMessInterpreter.IncrementValue();
            Assert.AreEqual(1, objBrainMessInterpreter.Pointer + 1);
        }

        [TestMethod]
        public void TestDecrementValue()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();

            objBrainMessInterpreter.DecrementValue();
            Assert.AreEqual(-1, objBrainMessInterpreter.Pointer - 1);
        }

        [TestMethod]
        public void TestOutput()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();
            string[] array = new string[1];
            array[0] = "true";
            BrainMessInterpreter.Main(array);
        }

        [TestMethod]
        public void TestInput()
        {
            BrainMessInterpreter objBrainMessInterpreter = new BrainMessInterpreter();
            string[] array = new string[1];
            array[0] = "true";
            BrainMessInterpreter.Main(array);
        }
        
    }
}
