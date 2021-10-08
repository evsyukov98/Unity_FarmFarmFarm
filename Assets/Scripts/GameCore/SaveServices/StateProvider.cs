using System;
using System.Collections.Generic;

namespace SaveServices
{
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
            LocalSaveProvider.SaveObjectToJson(_saveData);
        }

        public void LoadSave()
        {
            _saveData = LocalSaveProvider.LoadSave();
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
        int ID { get; }
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
                state = (TState) States[key];
                return true;
            }

            return false;
        }
    }
}
