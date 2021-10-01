using Zenject;

public class DefaultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ITemplateManager>().To<TemplateManager>().AsSingle();
    }
}