using System.Collections.Generic;
using Zenject;
using UnityEngine;
using UnityEngine.UI;

// _____________________________________________
// Тестовый класс для проверки функциональностей 
// _____________________________________________

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

        Dictionary<int, IState> dictForSaves = new Dictionary<int, IState>();
        dictForSaves.Add(1,new StateNoOne());
        dictForSaves.Add(2,new StateNoTwo());

        
        LocalSaveProvider.SaveSaves(dictForSaves);
    }
}

public class StateNoOne: IState
{
    public int intField = 12;
}

public class StateNoTwo: IState
{
    public string stringField = "hello world";

}
