namespace EarClip;

public class ConsoleWriter : GeomWriter
{
    /// <summary>
    /// Creates a new instance with program parameters stored in it
    /// </summary>
    /// <param name="programParameters"></param>
    public ConsoleWriter(ProgramParameters programParameters) : base(programParameters) { }

    public override void WriteGeometry(List<Geometry.Geometry> geometries)
    {
        List<string> strGeoms = GeometriesToString(geometries);

        foreach (string geom in strGeoms)
        {
            Console.Error.WriteLine(geom);
        }
    }
}