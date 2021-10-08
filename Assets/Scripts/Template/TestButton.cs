using System.Collections.Generic;
using Newtonsoft.Json;
using SaveServices;
using Zenject;
using UnityEngine;
using UnityEngine.UI;

// _____________________________________________
// Тестовый класс для проверки функциональностей 
// _____________________________________________

public class TestButton : MonoBehaviour
{
    private ITemplateManager _templateManager;

    [Inject]
    public void Inject(ITemplateManager templateManager)
    {
        _templateManager = templateManager;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
        
        _templateManager.ConsoleWrite("DI check message");
    }

    private SaveData SaveDataMock()
    {
        var dictForSaves = new Dictionary<string, IState>
        {
            {typeof(StateNoOne).ToString(), new StateNoOne()}, 
            {typeof(StateNoTwo).ToString(), new StateNoTwo()}
        };

        return new SaveData {States = dictForSaves};
    }

    private void OnButtonClick()
    {
        SaveData saveData = SaveDataMock();

        LocalSaveProvider.SaveObjectToJson(saveData);
        
        SaveData loadedSaveData = LocalSaveProvider.LoadSave();
    }
}

public class StateNoOne: IState
{
    [JsonProperty("intField")] private int _intField = 12;
    [JsonProperty("id")] private int _id = 1;

    [JsonIgnore] public int ID => _id;
    [JsonIgnore] public int IntField => _intField;
}

public class StateNoTwo: IState
{
    [JsonProperty("stringField")] private string _stringField = "hello world";
    [JsonProperty("id")] private int _id = 2;

    [JsonIgnore] public int ID => _id;
    [JsonIgnore] public string StringField => _stringField;
}
