namespace EarClip;

public class Triangle
{
    public Coordinate P1 {get; set;}

    public Coordinate P2 {get; set;}

    public Coordinate P3 {get; set;}


    public Triangle (Coordinate p1ln, Coordinate p2ln, Coordinate p3ln)
    {
        P1 = p1ln;
        P2 = p2ln;
        P3 = p3ln;
    }

    public override string ToString() {
        // return "POLYGON((" + P1.ToString()  + ", " +
        //     P2.ToString() + ", " + P3.ToString() + "))";
        return $"POLYGON(({P1}, {P2}, {P3}))";
    }
   
    public void DisplayInfo()
    {

        P1.DisplayInfo();
        P2.DisplayInfo();
        P3.DisplayInfo();
    }
    
}
