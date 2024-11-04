namespace EarClip;

/// <summary>
/// Boundary object for input (console) arguments.
/// </summary>
public class ProgramParameters
{
    /// <summary>
    /// Run mode. Can be console or file.
    /// </summary>
    public RunType Mode { get; set; }

    /// <summary>
    /// The input file's path.
    /// </summary>
    public string[]? Inputs { get; set; } 

    /// <summary>
    /// The output file's path, if mode is file.
    /// </summary>
    public string? Output { get; set; }
}