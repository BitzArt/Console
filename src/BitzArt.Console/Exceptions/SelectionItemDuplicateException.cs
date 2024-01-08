namespace BitzArt.Console;

internal class SelectionItemDuplicateException(string actionName) : Exception($"Duplicate selection item '{actionName}'")
{
}