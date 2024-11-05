namespace EarClip;

public class FileWriter_new : GeomWriter
{
    public FileWriter_new(ProgramParameters programParameters) : base(programParameters) { }

    public override void WriteGeometry(List<Geometry.Geometry> geometries)
    {
        // Write to file
        List<string> strGeoms = GeometriesToString(geometries);

        File.WriteAllLines(Parameters.Output!, strGeoms);
    }
}