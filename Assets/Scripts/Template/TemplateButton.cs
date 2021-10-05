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

        Dictionary<string, IState> dictForSaves = new Dictionary<string, IState>();
        dictForSaves.Add(typeof(StateNoOne).ToString(),new StateNoOne());
        dictForSaves.Add(typeof(StateNoTwo).ToString(),new StateNoTwo());

        SaveData saveData = new SaveData {States = dictForSaves};
        
        LocalSaveProvider.SaveObjectSaves(saveData);

        /*var byteSaves = StateProvider.FromStatesToByteArray(saveData);
        
        LocalSaveProvider.SaveByteSaves(byteSaves);*/
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
