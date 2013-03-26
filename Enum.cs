using System;

public class Enums
{
    
    enum Instruction
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
