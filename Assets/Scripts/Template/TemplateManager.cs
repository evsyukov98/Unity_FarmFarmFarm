using UnityEngine;

public interface ITemplateManager
{
    void ConsoleWrite(string message);
}

public class TemplateManager : ITemplateManager
{
    public void ConsoleWrite(string message)
    {
        Debug.Log(message);
    }
}
