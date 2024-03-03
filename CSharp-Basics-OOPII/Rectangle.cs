// ---- C# I (Dor Ben Dor) ----
// Ori Shacham-Barr
// ----------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

// B - Properties (W.I.C)
enum Vertex
{
    TopLeft,
    TopRight, 
    BottomLeft, 
    BottomRight,
}

internal class Rectangle
{
    public float Width { get; private set; }
    public float Height { get; private set; }
    public Vector2 Center { get; private set; }
    public Vector2[] Vertexes { get; private set; }

    public float Volume { get {  return Width * Height; } }
    public float Circumference { get {  return (Height + Width) * 2; } }

    public Rectangle(float width, float height, Vector2 center)
    {
        Width = width;
        Height = height;
        Center = center;

        Vertexes = new Vector2[4];
        for (int i = 0; i < Vertexes.Length; i++)
        {
            switch (i) 
            {
                case (int)Vertex.TopLeft:
                    Vertexes[i] = new Vector2(Center.X - (Width / 2), Center.Y + (Height / 2));
                    break;
                case (int)Vertex.TopRight:
                    Vertexes[i] = new Vector2(Center.X + (Width / 2), Center.Y + (Height / 2));
                    break;
                case (int)Vertex.BottomLeft:
                    Vertexes[i] = new Vector2(Center.X - (Width / 2), Center.Y - (Height / 2));
                    break;
                case (int)Vertex.BottomRight:
                    Vertexes[i] = new Vector2(Center.X + (Width / 2), Center.Y - (Height / 2));
                    break;
            }
        }
    }

    public bool IsPointInRectangle(Vector2 point)
    {
        if (point.X >= Vertexes[(int)Vertex.TopLeft].X && point.X <= Vertexes[(int)Vertex.BottomRight].X &&
            point.Y <= Vertexes[(int)Vertex.TopLeft].Y && point.Y >= Vertexes[(int)Vertex.BottomRight].Y)
            return true;
        return false;
    }

    public bool DoRectanglesIntersect(Rectangle rectangle)
    {
        for (int i = 0; i < Vertexes.Length; i++)
            if (IsPointInRectangle(rectangle.Vertexes[i]))
                return true;
        return false;
    }
}