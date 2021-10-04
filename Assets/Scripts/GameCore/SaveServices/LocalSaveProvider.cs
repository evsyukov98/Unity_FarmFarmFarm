using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class LocalSaveProvider
{
    private static readonly string _path = Application.streamingAssetsPath + "/Saves.json";

    public static Dictionary<int, IState> LoadSave()
    {
        //TODO: JsonUtility не поддерживает сохранение словарей.
        //TODO: Как вариант думаю сохранять словарь в бинарном формате и вытаскивать его в бинарке тоже после конвертировать его в словарь.
        var loadedSaves = JsonUtility.FromJson<Dictionary<int, IState>>(File.ReadAllText(_path));
        return loadedSaves;
    }

    public static void SaveSaves(Dictionary<int, IState> saves)
    { 
        File.WriteAllText(_path, JsonUtility.ToJson(saves));
    }

    public static void RemoveSaves()
    {
        //TODO: remove saves
    }
}
