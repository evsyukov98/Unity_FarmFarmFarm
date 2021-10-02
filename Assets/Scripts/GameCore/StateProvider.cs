using System;

public class StateProvider : IStateProvider
{
    private SaveData _saveData;

    public void Initialize()
    {
        
    }

    public bool TryGetState<TState>(Type type, out TState state) where TState : class, IState
    {
        throw new NotImplementedException();
    }

    public void RegisterState<TState>(Type type, TState state) where TState : class, IState
    {
        throw new NotImplementedException();
    }

    public void Save(bool sendToServer = false)
    {
        throw new NotImplementedException();
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
