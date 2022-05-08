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
