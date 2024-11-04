namespace EarClip.Geometry;

public class Point : Geometry
{
    public Point(List<Coordinate> coordinates) : base(coordinates) { }

    public override string ToString()
    {
        return $"POINT ({CoordinatesToWkt()})";
    }

    public static Point ReadFromWkt(string wkt)
    {
        string strippedCoords = wkt.Replace("POINT (", "").Replace(")", "");
        return new Point(CoordinatesFromWkt(strippedCoords));
    }
}