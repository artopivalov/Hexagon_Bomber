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
      Debug.Log("init - ApplicationManager");

      foreach(var type in GetInitializationTypes())
      {
        Debug.Log("init - " + type);
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
          if(type.Namespace == "Application.Managers")
          {
            types.Add(type);
          }
        }
      }

      return types;
    }
  }
}
