using System;


namespace BrainMessApplication
{
    public class BrainMessInterpreter
    {

        private readonly int[] buffer = new int[Constants.Bufsize];
        public int Pointer { get; set; }

        public BrainMessInterpreter()
        {
            this.Pointer = 0;
        }

        public void Interpret(string bmInstruction,bool isUnitTest)
        {
            int i = 0;
            int inputInstructionLength = bmInstruction.Length;
            try
            {
                while (i < inputInstructionLength)
                {
                    switch (bmInstruction[i])
                    {
                        case (char)Enums.Instruction.IncrementAddress:
                            {
                                IncrementAddress();
                                break;
                            }
                        case (char)Enums.Instruction.DecrementAddress:
                            {
                                DecrementAddress();
                                break;
                            }
                        case (char)Enums.Instruction.Output:
                            {
                                Output();
                                break;
                            }
                        case (char)Enums.Instruction.IncrementValue:
                            {
                                IncrementValue();
                                break;
                            }
                        case (char)Enums.Instruction.DecrementValue:
                            {
                                DecrementValue();
                                break;
                            }
                        case (char)Enums.Instruction.BeginLoop:
                            {
                                if (this.buffer[this.Pointer] == 0)
                                {
                                    int loop = 1;
                                    while (loop > 0)
                                    {
                                        i++;
                                        char c = bmInstruction[i];
                                        if (c == (char)Enums.Instruction.BeginLoop)
                                        {
                                            loop++;
                                        }
                                        else
                                            if (c == (char)Enums.Instruction.EndLoop)
                                            {
                                                loop--;
                                            }
                                    }
                                }
                                break;
                            }
                        case (char)Enums.Instruction.EndLoop:
                            {
                                int loop = 1;
                                while (loop > 0)
                                {
                                    i--;
                                    char c = bmInstruction[i];
                                    if (c == (char)Enums.Instruction.BeginLoop)
                                    {
                                        loop--;
                                    }
                                    else
                                        if (c == (char)Enums.Instruction.EndLoop)
                                        {
                                            loop++;
                                        }
                                }
                                i--;
                                break;
                            }
                        case (char)Enums.Instruction.Input:
                            {
                                // read a key from console..
                                Input(isUnitTest,i);
                                break;
                            }
                    }

                    i++;
                }
            
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured." + e);
                Console.ReadLine();
            }
        }

        public void IncrementAddress()
        {
            this.Pointer++;
            if (this.Pointer >= Constants.Bufsize)
            {
                this.Pointer = 0;
            }
        }

        public void DecrementAddress()
        {
            this.Pointer--;
            if (this.Pointer < 0)
            {
                this.Pointer = Constants.Bufsize - 1;
            }
        }

        public void IncrementValue()
        {
            this.buffer[this.Pointer]++;
        }

        public void DecrementValue()
        {
            this.buffer[this.Pointer]--;
        }

        public void Output()
        {
            Console.Write((char)this.buffer[this.Pointer]);
        }

        public void Input(bool isUnitTest,int currentIndex )
        {
            if (isUnitTest)
            {
                Console.WriteLine((char)this.buffer[currentIndex]);
                Console.ReadLine();
            }
            else
            {
                ConsoleKeyInfo key = Console.ReadKey();
                this.buffer[this.Pointer] = (int)key.KeyChar;
            }
        }

        public static void Main(string[] isUnitTest)
        {
            bool isTest = false;
            BrainMessInterpreter bmInterpreter = new BrainMessInterpreter();
            string userInput = Console.ReadLine();
            if (isUnitTest.Length > 0 && isUnitTest[0] == "true")
            {
                userInput = Constants.TestInputInstruction;
                isTest = true;
            }
            if (!string.IsNullOrEmpty(userInput))
                bmInterpreter.Interpret(userInput,isTest);
            else
            {
                Console.WriteLine("Sorry! Please enter the brainmess instructions.");
                Console.ReadLine();
            }
        }
    }
}
