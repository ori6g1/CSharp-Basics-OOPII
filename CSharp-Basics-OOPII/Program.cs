// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------

// A - Method Overloading (W.I.C)

Printer p = new Printer("ABCDEFG", 3);

p.Print();
p.Print(OverflowBehavior.Overflow);
p.Print(OverflowBehavior.Clip);
p.Print(OverflowBehavior.Ellipsis);