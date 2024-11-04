using System.Diagnostics.Contracts;

namespace EarClip;

public static class Triangulator
{
    public static List<Triangle> Triangulate(List<Coordinate> coordinates)
    {
        
        var triangles = new List<Triangle>();

        while(coordinates.Count > 2)
        {
            triangles.Add(new Triangle(coordinates[0], coordinates[1], coordinates[2]));
            coordinates.RemoveAt(index: 1);
        }

            return triangles;

    }
}