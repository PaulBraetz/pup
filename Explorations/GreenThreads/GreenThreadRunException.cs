sealed class GreenThreadRunException(GreenThreadRunOptions options, String message) :
    Exception(message)
{
    public GreenThreadRunOptions Options { get; } = options;

    public static GreenThreadRunException NegativeRetries(GreenThreadRunOptions options) =>
        new(options, "Options contain negative attempt count.");
    public static GreenThreadRunException ThreadStarvation(GreenThreadRunOptions options) =>
        new(options, "Unable to run green thread, no threads available.");
    public static GreenThreadRunException NullCtsFactory(GreenThreadRunOptions options) =>
        new(options, "CtsFactory produced null cancellation token source.");
}