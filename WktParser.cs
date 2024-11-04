using System.Drawing;
using System.Globalization;
using EarClip.Geometry;
using Point = EarClip.Geometry.Point;

namespace EarClip;


/*public static class WktParser
{
    public static List<Coordinate> Parse(string filePath)       //Kell egy tároló ami visszaad egy listányi koordinátát
    {
        List<Coordinate> poly = [];
        string wktPoly = File.ReadAllText(filePath);
        string[] splitWkt = wktPoly.Split('(');     //Feldraboljuk a stringet egy karakter mentén --> ()
        wktPoly = splitWkt[2];                      //Vesszük a szétdarabolt elemünk harmadik elemét
        splitWkt = wktPoly.Split(')');
        wktPoly = splitWkt[0];                      //wktPolyba bementjük a darabolt első elemet
        splitWkt = wktPoly.Split(',');

        foreach (string coords in splitWkt)         //
        {
            string[] splitCoords = coords.Trim().Split(' ');  //Trimmel levágjuk a szóközök mentén

            double x = double.Parse(splitCoords[0], CultureInfo.InvariantCulture.NumberFormat); //CultureInfo... számformátum értelmezése
            double y = double.Parse(splitCoords[1], CultureInfo.InvariantCulture.NumberFormat);

            Coordinate coordinate = new Coordinate(x, y);
            poly.Add(coordinate);



        }
        return poly;
    }
}*/

public static class WktParser
{
public static Geometry.Geometry Parse(string filePath)
{
    string wkt = File.ReadAllText(filePath);
    if (wkt.Contains("POINT"))
    {
        return Point.ReadFromWkt(wkt);

    }
    else if (wkt.Contains("LINESTRING"))
    {
        return Line.ReadFromWkt(wkt);

    }
    else if (wkt.Contains("POLYGON"))
    {
        return Polygon.ReadFromWkt(wkt);
        
    }
    else
    {
        throw new Exception("Nem támogatott vagy invalid az egész");

    }
}   
}