///
///
///
using Application.Entities;

using UnityEngine;
using System;
using System.Collections.Generic;

namespace Application.Managers
{
  public static class PoolsManager
  {
    private static Dictionary<System.Type, Entity> references = new Dictionary<Type, Entity>();
    private static List<Entity> instances = new List<Entity>();

    static PoolsManager()
    {
      Subscribe();
      CollectReferences();
    }

    private static void Subscribe()
    {
      Events.PreReset += OnPreReset;
    }

    private static void OnPreReset()
    {
      ClearReferences();
    }

    private static void CollectReferences()
    {
      foreach(var reference in Resources.LoadAll<Entity>("Prefabs/Entities/"))
      {
        references.Add(reference.GetType(), reference);
      }
    }

    private static void ClearReferences()
    {
      foreach(var entity in instances)
      {
        if(entity != null)
        {
          GameObject.Destroy(entity.gameObject);
        }
      }

      instances.Clear();
    }

    public static T CreateElement<T>() where T : Entity
    {
      return CreateElement(typeof(T)) as T;
    }

    public static Entity CreateElement(Type type)
    {
      //TODO pool
      var entity = GameObject.Instantiate(references[type]);
      instances.Add(entity);
      return entity;
    }
  }
}
