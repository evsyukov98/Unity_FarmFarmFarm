using UnityEngine;

public interface ITemplateManager
{
    void ConsoleWrite();
}

public class TemplateManager : ITemplateManager
{
    public void ConsoleWrite()
    {
        Debug.Log("Template alert");
    }
}
