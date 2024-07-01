using System;

namespace FrameworkDesign
{
    public interface ICanRegisterEvent : IBelongToArchitecture
    {

    }

    public static class CanRegisterEventExtension
    {
        public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self, Action<T> Event)
        {
            return  self.GetArchitecture().RegisterEvent<T>(Event);
        }
        public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> Event)
        {
            self.GetArchitecture().UnRegisterEvent<T>(Event);
        }
    }
}


