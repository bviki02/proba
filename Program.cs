using NetTopologySuite.IO;

namespace EarClip;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Arguments: {string.Join('|', args)}");
        ProgramParameters parsedArguments = ProcessArguments(args);

        Geometry.Geometry geomA = WktParser.Parse(parsedArguments.Inputs[0]);
        Geometry.Geometry geomB = WktParser.Parse(parsedArguments.Inputs[1]);


        Console.WriteLine(geomA.ToString());
        Console.WriteLine(geomB.ToString());

        WKTReader rdr = new WKTReader();

    //HF ezt kijavítani, és el kell érni a végére hogy kiírjon egy metszett polgont 
    //ez egy minta
        NetTopologySuite.Geometries.Geometry poly1 = rdr.Read(geomA.ToString());
        NetTopologySuite.Geometries.Geometry poly2 = rdr.Read(geomB.ToString());


        NetTopologySuite.Geometries.Geometry intersection = poly1.Intersection(poly2);



        //Geometry.Geometry? intetsection = Intersector.Intersection(geomA, geomB);

        if(intersection != null){
            GeomWriter writer = CreateWriter(parsedArguments);
            Console.WriteLine(intersection);
        }

        /*List<Triangle> triangles = Triangulator.Triangulate(coordinates);

        GeomWriter writer = CreateWriter(parsedArguments);
        writer.WriteTriangles(triangles);*/
    }

    private static GeomWriter CreateWriter(ProgramParameters parameters)
    {
        if (parameters.Mode == RunType.CONSOLE)
        {
            return new ConsoleWriter(parameters);
        }
        else if (parameters.Mode == RunType.FILE)
        {
            return new FileWriter(parameters);
        }
        else
        {
            throw new Exception("Unsupported mode.");
        }
    }

    /// <summary>
    /// Processes user arguments and returns a strongly typed parameter object from them.
    /// </summary>
    /// <param name="args">The user arguments</param>
    /// <returns>The parameter object</returns>
    private static ProgramParameters ProcessArguments(string[] args)
    {
        string[] inputPaths = [];
        string outputPath = "", mode = "";
        foreach (string arg in args)
        {
            
            string[] kvp = arg.Split('=');
            if (kvp[0] == "mode")
            {
                mode = kvp[1];
            }
            else if (kvp[0] == "input")
            {
                string[] inputs = kvp[1].Split(',');
               // inputPaths = kvp[1];
            }
            else if (kvp[0] == "output")
            {
                outputPath = kvp[1];
            }
        }

        if (inputPaths.Length !=2)
        {
            throw new ArgumentException("Two input paths must be defined seperated with a coma.");
        }
        RunType modeEnum = default;
        if (mode == "file")
        {
            modeEnum = RunType.FILE;
        }
        if (modeEnum == RunType.FILE && outputPath == "")
        {
            throw new ArgumentException("Output path must be defined if mode is set to file.");
        }

        return new ProgramParameters
        {
            Inputs = inputPaths,
            Mode = modeEnum,
            Output = outputPath
        };
    }
}
