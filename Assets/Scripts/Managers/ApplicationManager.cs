///
///
///
using UnityEngine;

using System.Collections.Generic;
using System;

namespace Application.Managers
{
  public static class ApplicationManager
  {
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadMethod()
    {
      foreach(var type in GetInitializationTypes())
      {
        System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(
          type.TypeHandle
        );
      }

      Events.RequestReset();
    }

    private static List<Type> GetInitializationTypes()
    {
      var types = new List<Type>();

      foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        foreach(var type in assembly.GetTypes())
        {
          if(type.Namespace == "Application.Managers" && type.IsAbstract)
          {
            types.Add(type);
          }
        }
      }

      return types;
    }
  }
}
