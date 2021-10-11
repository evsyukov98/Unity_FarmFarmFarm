using SaveServices;
using Zenject;

/// <summary>
/// Класс для биндинга менеджеров. (Инициализация и добавление менеджеров в DI container)
/// Классы добавленные в контейнер могут быть переданы в другие классы - Dependency Inversion.
/// </summary>
public class DefaultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IStateProvider>().To<StateProvider>().AsSingle();
        Container.Bind<ITemplateManager>().To<TemplateManager>().AsSingle();
    }
}