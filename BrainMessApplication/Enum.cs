
namespace BrainMessApplication
{
    public class Enums
    {
        /// <summary>
        /// Enums for Brainmess instructions.
        /// </summary>
        public enum Instruction
        {

            IncrementAddress = '>',
            DecrementAddress = '<',
            IncrementValue = '+',
            DecrementValue = '-',
            Output = '.',
            Input = ',',
            BeginLoop = '[',
            EndLoop = ']',
        }
    }
}
