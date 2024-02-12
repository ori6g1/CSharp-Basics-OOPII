// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A - Method Overloading (W.I.C)

enum OverflowBehavior
{
    Clip,
    Overflow,
    Ellipsis,
}

internal class Printer
{
    public string Text;
    public int MaxLength;

    public Printer(string text, int maxLength)
    {
        Text = text;
        MaxLength = maxLength;
    }

    public void Print()
    {
        Print(OverflowBehavior.Clip);
    }

    public void Print(OverflowBehavior overflowBehavior)
    {
        switch (overflowBehavior)
        {
            case OverflowBehavior.Clip:
                for (int i = 0; i < MaxLength && i < Text.Length; i++)
                {
                    Console.Write(Text[i]);
                }
                Console.WriteLine();
                break;
            case OverflowBehavior.Overflow:
                Console.WriteLine(Text);
                break;
            case OverflowBehavior.Ellipsis:
                for (int i = 0; i < MaxLength && i < Text.Length; i++)
                {
                    Console.Write(Text[i]);
                }
                Console.WriteLine("...");
                break;
        }
    }
}
