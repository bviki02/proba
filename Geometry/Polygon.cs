namespace EarClip.Geometry;

public class Polygon : Geometry
{
    public Polygon(List<Coordinate> coordinates) : base(coordinates) { }

    public override string ToString()
    {
        return $"POLYGON (({CoordinatesToWkt()}))";
    }

    public static Polygon ReadFromWkt(string wkt)
    {
        string strippedCoords = wkt.Replace("POLYGON ((", "").Replace("))", "");
        return new Polygon(CoordinatesFromWkt(strippedCoords));
    }
}