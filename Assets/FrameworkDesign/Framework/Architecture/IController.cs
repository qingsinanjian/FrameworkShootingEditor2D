namespace FrameworkDesign
{
    public interface IController : IBelongToArchitecture, ICanGetSystem, ICanGetModel, ICanSendCommand, ICanRegisterEvent
    {
        
    }
}

