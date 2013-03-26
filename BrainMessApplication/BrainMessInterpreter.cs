using System;


namespace BrainMessApplication
{
    public class BrainMessInterpreter
    {

        private int[] buffer = new int[Constants.BUFSIZE];
        public int pointer { get; set; }

        public BrainMessInterpreter()
        {
            this.pointer = 0;
        }

        public void Interpret(string bmInstruction)
        {
            int i = 0;
            int inputLength = bmInstruction.Length;
            try
            {
                while (i < inputLength)
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
                                if (this.buffer[this.pointer] == 0)
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
                                Input();
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
            }
        }

        public void IncrementAddress()
        {
            this.pointer++;
            if (this.pointer >= Constants.BUFSIZE)
            {
                this.pointer = 0;
            }
        }

        public void DecrementAddress()
        {
            this.pointer--;
            if (this.pointer < 0)
            {
                this.pointer = Constants.BUFSIZE - 1;
            }
        }

        public void IncrementValue()
        {
            this.buffer[this.pointer]++;
        }

        public void DecrementValue()
        {
            this.buffer[this.pointer]--;
        }

        public void Output()
        {
            Console.Write((char)this.buffer[this.pointer]);
        }

        public void Input()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            this.buffer[this.pointer] = (int)key.KeyChar;
        }



        public static void Main(string[] isUnitTest)
        {
            BrainMessInterpreter bmInterpreter = new BrainMessInterpreter();
            string userInput = Console.ReadLine();
            if (isUnitTest[0]=="true")
                userInput = Constants.TestInputInstruction;
            bmInterpreter.Interpret(userInput);
        }
    }
}
