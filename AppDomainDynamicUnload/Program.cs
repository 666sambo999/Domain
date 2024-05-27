using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainDynamicUnload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 Создаем домен приложения 
            AppDomain domain = AppDomain.CreateDomain("Console Domains");
            //2 звгружаем DLL в этот домен 
            //Assembly assembly = Assembly.LoadFrom("SampleLibrary.dll");
            Assembly assembly = domain.Load(AssemblyName.GetAssemblyName("SampleLibrary.dll"));
            // 3 получаем модуль из которого будeм получать вызов
            Module module = assembly.GetModule("SampleLibrary.dll");
            // 4 получаем класс из DLL - библиотеки 
            Type type = module.GetType("SampleLibrary.SampleLibrary");
            // 5 вытаскиваем из классa который будем вызовать 
            MethodInfo method = type.GetMethod("Hello");
            // 6 вызов метода 
            method.Invoke(null, null);
            
            AppDomain.Unload(domain);
        }

    }
}
