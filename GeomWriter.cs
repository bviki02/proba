namespace EarClip;

public abstract class GeomWriter
{
    /// <summary>
    /// Parametrization of the current run
    /// </summary>
    protected ProgramParameters Parameters { get; private set; }

    /// <summary>
    /// Creates a new instance with program parameters stored in it
    /// </summary>
    /// <param name="programParameters"></param>
    public GeomWriter(ProgramParameters programParameters)
    {
        Parameters = programParameters;
    }

    protected List<string> GeometriesToString(List<Geometry.Geometry> geometries)
    {
        List<string> geomStrList = [];

        foreach (Geometry.Geometry geometry in geometries)
        {
            geomStrList.Add(geometry.ToString());
        }

        return geomStrList;
    }

    public abstract void WriteGeometry(List<Geometry.Geometry> geometries);
}