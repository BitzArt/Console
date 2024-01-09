using System.Reflection;

namespace BitzArt.Console;

internal record SelectionMethod(string Name, MethodInfo Method, bool PauseOnComplete);
