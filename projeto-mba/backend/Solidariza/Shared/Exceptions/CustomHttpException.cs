using Microsoft.AspNetCore.Mvc;

public class CustomHttpException : Exception
{
    public ProblemDetails ProblemDetails { get; }

    public CustomHttpException(ProblemDetails problemDetails)
    {
        ProblemDetails = problemDetails;
    }
}