using System.Collections.Generic;

namespace WorkflowLib.Examples.EmployeesMvc.Models;

/// <summary>
/// Represent an abstract pipe component that is used for composing sequences of the generators of initial datasets 
/// </summary>
public abstract class AbstractPipe
{
    /// <summary>
    /// The function that is going to be invoked next 
    /// </summary>
    protected System.Action<PipeResult> _function;

    /// <summary>
    /// Constructor of the abstract dataset generator 
    /// </summary>
    public AbstractPipe(System.Action<PipeResult> function)
    {
        _function = function;
    }

    /// <summary>
    /// Generates a DateTime object 
    /// </summary>
    protected System.DateTime GenerateDate(System.DateTime start, System.DateTime end)
    {
        var range = (end - start).Days;
        return start.AddDays(new Random().Next(range));
    }

    /// <summary>
    /// Method that implements a generating algorithm 
    /// </summary>
    public abstract void Handle(PipeResult result);
}