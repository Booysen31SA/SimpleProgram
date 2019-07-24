using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleProgram.Multiplication_Table
{
    class Multiply
    {
        public void multiplyTable()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("       Multiply Table");
            Console.WriteLine("===============================");
            Console.Write("Enter The First Integer - ");
            String FirstInt = Console.ReadLine();

            Console.Write("Enter The Second Integer - ");
            String SecondInt = Console.ReadLine();

            Console.WriteLine("First Number  " + FirstInt);
            Console.WriteLine("Second Number " + SecondInt);

            for (int i = 1; i <= Convert.ToInt32(FirstInt); i++)
            {
                for (int y = 1; y <= Convert.ToInt32(SecondInt); y++)
                {
                    Console.Write(i * y + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
