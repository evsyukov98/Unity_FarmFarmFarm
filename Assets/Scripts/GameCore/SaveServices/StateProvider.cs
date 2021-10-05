using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class StateProvider : IStateProvider
{
    private SaveData _saveData;

    public void Initialize()
    {
        
    }

    public bool TryGetState<TState>(Type type, out TState state) where TState : class, IState
    {
        return _saveData.TryGetState(type, out state);
    }

    public void RegisterState<TState>(Type type, TState state) where TState : class, IState
    {
        var key = type.ToString();

        if (!_saveData.States.ContainsKey(key))
        {
            if (state != null)
                _saveData.States.Add(key, state);
        }
        else
        {
            if (state == null)
                _saveData.States.Remove(key);
            else
                _saveData.States[key] = state;
        }
    }

    public void Save(bool sendToServer = false)
    {
        var encodedData = FromStatesToByteArray(_saveData);
        
        LocalSaveProvider.SaveByteSaves(encodedData);

        
    }
    
    public static byte[] FromStatesToByteArray(SaveData saveData)
    {
        //var jsonNuget = JsonConvert.SerializeObject(saveData);
        var jsonUnity = JsonUtility.ToJson(saveData);
        var jsonBytes = Encoding.UTF8.GetBytes(jsonUnity);

        var base64 = Convert.ToBase64String(jsonBytes);
        return Encoding.UTF8.GetBytes(base64);
    }
}

public interface IStateProvider
{
    bool TryGetState<TState>(Type type, out TState state) where TState : class, IState;

    void RegisterState<TState>(Type type, TState state) where TState : class, IState;

    void Save(bool sendToServer = false);
}

public interface IState
{

}

public class SaveData
{
    // Список стейтов
    public Dictionary<string, IState> States;
    
    public bool TryGetState<TState>(Type type, out TState state) where TState : class, IState
    {
        state = null;

        var key = type.ToString();

        if (States.ContainsKey(key))
        {
            state = (TState)States[key];
            return true;
        }

        return false;
    }
}
