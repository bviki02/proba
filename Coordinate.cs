
namespace EarClip; //--> elérhető lesz a Coordinate osztályunk másik munkalapon is
public class Coordinate  //Akkor kell a public ha másik résznél is használni akarjuk 
{
    /// <summary>
    /// Kóddokumentáció létrehozása
    /// </summary>
    public double X {get; set;}  //Mindig nagy betű a változó
    public double Y {get; set;}  //Kettéválasztjuk egy tag értékadását 

    /// <summary>
    /// Konstruktor accepting a coordinate values
    /// </summary>
    /// <param name="x"> X component</param>
    /// <param name="y"> Y component</param>

    public Coordinate(double x, double y) 
    {   
        X = x;
        Y = y;
    }

    public override string ToString() {
        //return X + " " + Y;
        return $"{X} {Y}";
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"x: {X}, y: {Y}");
    }
    
}