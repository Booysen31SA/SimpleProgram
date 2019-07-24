using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleProgram.Reverse_Word
{
    class ReverseWord
    {
        public void Sentence()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("       Reverse Words");
            Console.WriteLine("===============================");
            Console.Write("Please Enter a Sentence ");
            String sentence = Console.ReadLine();

            var reversedWords = string.Join(" ",
           sentence.Split(' ')
          .Select(x => new String(x.Reverse().ToArray())));
            Console.WriteLine(reversedWords);
        }
    }
}
