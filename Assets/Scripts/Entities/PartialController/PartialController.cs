///
/// legacy
///
using Application.Attributes;

using System;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

namespace Application.Attributes
{
  [AttributeUsage(AttributeTargets.Method)]
  public class SubscribeToMainMethodAttribute : Attribute
  {
  }
}

namespace Application.Entities
{
  public class PartialController
  {
    public enum SubscribeSettings
    {
      Init,
      Start,
      Reset,

      Subscribe,
      Unsubscribe,

      OnEnable,
      OnDisable,

      Update,
      LateUpdate,
      FixedUpdate,
    }

    protected Entity entity;

    protected Dictionary<SubscribeSettings, List<MethodInfo>> methods = new Dictionary<SubscribeSettings, List<MethodInfo>>();

    public PartialController(Entity entity)
    {
      this.entity = entity;
      this.CollectSubscribersData();
    }

    protected virtual void CollectSubscribersData()
    {
      foreach(SubscribeSettings setting in Enum.GetValues(typeof(SubscribeSettings)))
      {
        methods.Add(setting, new List<MethodInfo>());
      }

      foreach(var method in entity.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
      {
        if(method.GetCustomAttribute<SubscribeToMainMethodAttribute>() != null)
        {
          bool matchFounded = false;

          foreach(SubscribeSettings setting in Enum.GetValues(typeof(SubscribeSettings)))
          {
            if(method.Name.StartsWith(setting.ToString()))
            {
              methods[setting].Add(method);
              matchFounded = true;
              break;
            }
          }

          if(!matchFounded)
          {
            throw new Exception("Partial subscribe match didn't found in method - " + method.Name);
          }
        }
      }
    }

    public virtual void InvokeMethods(SubscribeSettings subscribeSettings)
    {
      foreach(var method in methods[subscribeSettings])
      {
        method.Invoke(entity, null);
      }
    }
  }
}
