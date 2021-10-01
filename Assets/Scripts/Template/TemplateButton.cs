using Zenject;
using UnityEngine;
using UnityEngine.UI;

public class TemplateButton : MonoBehaviour
{
    private ITemplateManager _templateManager;

    [Inject]
    public void Inject(ITemplateManager templateManager)
    {
        _templateManager = templateManager;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClickManagerAlert);
    }

    private void ButtonClickManagerAlert()
    {
        _templateManager.ConsoleWrite();
    }
}
