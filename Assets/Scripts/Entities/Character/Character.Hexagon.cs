///
///
///
using Application.Attributes;
using Application.Managers;

using UnityEngine;
using System.Collections.Generic;

namespace Application.Entities
{
  public partial class Character
  {
    protected List<Vector3> availableDirections = new List<Vector3>();

    protected virtual Vector3 GetNearestDirection(Vector3 target, List<Vector3> samples)
    {
      var nearest = -target;
      for(int i = 0; i < samples.Count; i++)
      {
        Vector3 sample = samples[i];

        if(Vector3.Angle(target, sample) < Vector3.Angle(nearest, target))
        {
          nearest = sample;
        }
      }

      if(samples.Count > 0)
      {
        return nearest;
      }
      return target;
    }

    [SubscribeToMainMethod]
    protected virtual void UpdateHexagon()
    {
      availableDirections.Clear();

      foreach(var direction in HexagonManager.GetDirections())
      {
        var hit = Physics.Raycast(
          origin: currentGroundBlock.GetPosition() + Vector3.up * 0.5f,
          direction: direction,
          maxDistance: GenerationManager.GetGroundBlocksOffset() * 0.8f,
          layerMask: LayerMask.GetMask("Interactable")
        );
        if(!hit)
        {
          availableDirections.Add(direction);
        }
      }
    }
  }
}
