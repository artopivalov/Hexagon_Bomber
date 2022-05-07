///
///
///
using Application.Managers;

using UnityEngine;

namespace Application.Entities
{
  public class CameraMain : Entities.Camera
  {
    protected Entity trackingTarget;

    public override void Subscribe()
    {
      base.Subscribe();

      Events.PlayerSpawned += OnPlayerSpawned;
    }

    protected virtual void OnPlayerSpawned()
    {
      trackingTarget = CharactersManager.GetPlayer();
    }

    protected virtual void Update()
    {
      if(trackingTarget != null)
      {
        this.SetPosition(trackingTarget.GetPosition());
      }
    }
  }
}
