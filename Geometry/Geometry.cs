using System.Globalization;

namespace EarClip.Geometry;

public abstract class Geometry
{
    public List<Coordinate> Coordinates { get; private set; }

    public Geometry(List<Coordinate> coordinates)
    {
        Coordinates = coordinates;
    }

    protected string CoordinatesToWkt()
    {
        List<string> wktStrs = [];
        foreach (Coordinate coordinate in Coordinates)
        {
            wktStrs.Add($"{coordinate.X} {coordinate.Y}");
        }

        return string.Join(", ", wktStrs);
    }

    /// <summary>
    /// Returns a list of coordinates from a stripped list of singlepart WKT geometry.
    /// Example: "0 0, 0 2, 2 2, 2 0"
    /// </summary>
    /// <param name="strippedWkt"></param>
    /// <returns></returns>
    protected static List<Coordinate> CoordinatesFromWkt(string strippedWkt)
    {
        string[] coords = strippedWkt.Split(',');
        List<Coordinate> coordList = [];

        foreach (string coordPair in coords)
        {
            string[] splitCoords = coordPair.Trim().Split(' ');
            double x = double.Parse(splitCoords[0], CultureInfo.InvariantCulture.NumberFormat);
            double y = double.Parse(splitCoords[1], CultureInfo.InvariantCulture.NumberFormat);

            coordList.Add(new Coordinate(x, y));
        }

        return coordList;
    }
}