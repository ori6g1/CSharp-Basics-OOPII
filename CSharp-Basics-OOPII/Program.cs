// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

using System.Numerics;

class Program
{
    static void TaskA()
    {
        Console.WriteLine("A - Method Overloading (W.I.C)");
        Printer p = new Printer("ABCDEFG", 3);

        p.Print();
        p.Print(OverflowBehavior.Overflow);
        p.Print(OverflowBehavior.Clip);
        p.Print(OverflowBehavior.Ellipsis);
    }
    
    static void TaskB() 
    {
        Console.WriteLine("B - Properties (W.I.C)");
        Rectangle r1 = new Rectangle(4f, 4f, Vector2.Zero);
        Rectangle r2 = new Rectangle(4f, 4f, new Vector2(4.1f, 4f));

        if (r1.IsPointInRectangle(new Vector2(1f, 2.1f)))
            Console.WriteLine("The point is in the rectangle.");
        else
            Console.WriteLine("The point is not in the rectangle.");

        if (r1.DoRectanglesIntersect(r2))
            Console.WriteLine("The rectangles intersect.");
        else
            Console.WriteLine("The rectangles don't intersect.");
    }

    static void TaskC()
    {
        Console.WriteLine("C - Units, Combat, and the Beauty of RPGs");
        Game game = new Game();
        game.StartGame();
    }

    static void Main(String[] args)
    {
        string LineBreak = "\r\n";

        // A - Method Overloading (W.I.C)
        TaskA();
        Console.WriteLine(LineBreak);

        // B - Properties (W.I.C)
        TaskB();
        Console.WriteLine(LineBreak);

        // C - Units, Combat, and the Beauty of RPGs
        TaskC();
        Console.WriteLine(LineBreak);
    }
}