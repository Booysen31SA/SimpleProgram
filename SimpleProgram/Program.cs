using System;

namespace SimpleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type 0 to Exit or Enter to Continue");
            String anwser = Console.ReadLine();
            do
            {
                run();
            } while (anwser.Equals("0"));
            {
                Environment.Exit(0);
            }
        }
        private static void run()
        {
            Console.WriteLine("Please Select a Number Below");
            Console.WriteLine("1) Multiply Table");
            Console.WriteLine("2) Reverse Words");
            Console.WriteLine("3) Password Strength check");
            Console.WriteLine("0) Exit");

            String Answer = Console.ReadLine();
            if (Answer.Equals("1"))
            {
                Multiplication_Table.Multiply m = new Multiplication_Table.Multiply();
                m.multiplyTable();
                Console.WriteLine();
                run();
            }
            else if (Answer.Equals("2"))
            {
                Reverse_Word.ReverseWord r = new Reverse_Word.ReverseWord();
                r.Sentence();
                Console.WriteLine();
                run();
            }
            else if (Answer.Equals("3"))
            {
                Console.WriteLine("Password Should Include:");
                Console.WriteLine("At least 8 characters,\nall strong conditions met: \n>= 8 chars with 1 or more UC letters,\nLC letters,\ndigits & special chars");
                Console.WriteLine("Please Enter a Password");
                String password = Console.ReadLine();
                Console.WriteLine(Password_Strength.PasswordStrengthCheck.GetPasswordStrength(password));
                Console.WriteLine();
                run();
            }
            else if (Answer.Equals("0"))
            {
                Environment.Exit(0);
            }
        }

    }
}
