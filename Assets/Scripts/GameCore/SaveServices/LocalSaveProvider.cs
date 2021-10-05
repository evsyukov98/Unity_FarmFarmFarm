using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class LocalSaveProvider
{
    private static readonly string _path = Application.streamingAssetsPath + "/SavesBinaryTwo.bin";

    public static Dictionary<int, IState> LoadSave()
    {
        //TODO: JsonUtility не поддерживает сохранение словарей.
        //TODO: Как вариант думаю сохранять словарь в бинарном формате и вытаскивать его в бинарке тоже после конвертировать его в словарь.
        var loadedSaves = JsonUtility.FromJson<Dictionary<int, IState>>(File.ReadAllText(_path));
        return loadedSaves;
    }

    public static void SaveByteSaves(byte[] byteArray)
    {
        //TODO: реализация мк 
        using FileStream file = File.Open(_path, FileMode.Create);
        file.Write(byteArray, 0, byteArray.Length);
    }
    
    public static void SaveObjectSaves(SaveData saveData)
    {
        //TODO: реализация ютубера 
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_path, FileMode.Create);
        
        binaryFormatter.Serialize(fileStream, saveData);
        
        fileStream.Close();
    }

    public static void RemoveSaves()
    {
        //TODO: remove saves
    }
}
