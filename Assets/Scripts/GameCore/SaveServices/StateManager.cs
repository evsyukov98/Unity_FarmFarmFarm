using Zenject;

namespace SaveServices
{
    public abstract class StateManager <TState> where TState : class, IState
    {
        private IStateProvider _stateProvider;

        protected TState State;

        [Inject]
        public void Inject(IStateProvider stateProvider)
        {
            _stateProvider = stateProvider;
            
            Setup();
        }
        
        private void Setup()
        {
            var type = GetType();
            
            if (!_stateProvider.TryGetState(type, out State))
            {
                CreateNewState();
            }
            
            RegisterState();
            Save();
        }
        
        /// <summary>
        /// Создать сейв.
        /// </summary>
        protected abstract void CreateNewState();
        
        /// <summary>
        /// Регистрируем его.
        /// </summary>
        private void RegisterState() => _stateProvider.RegisterState(GetType(), State);

        /// <summary>
        /// Сохраняем сейв.
        /// </summary>
        protected void Save(bool sendToServer = false)
        {
            _stateProvider.Save();
        }
    }
}
