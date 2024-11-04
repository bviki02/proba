namespace EarClip.Geometry;

public class Line : Geometry
{
    public Line(List<Coordinate> coordinates) : base(coordinates) { }

    public override string ToString()
    {
        return $"LINESTRING ({CoordinatesToWkt()})";
    }

    public static Line ReadFromWkt(string wkt)
    {
        string strippedCoords = wkt.Replace("LINESTRING (", "").Replace(")", "");
        return new Line(CoordinatesFromWkt(strippedCoords));
    }
}