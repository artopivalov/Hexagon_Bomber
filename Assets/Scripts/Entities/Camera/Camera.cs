///
///
///
using UnityEngine;

namespace Application.Entities
{
  public class Camera : Entity
  {
    protected new UnityEngine.Camera camera;

    protected override void Awake()
    {
      base.Awake();

      camera = GetComponentInChildren<UnityEngine.Camera>();
    }

    public UnityEngine.Camera GetCamera()
    {
      return camera;
    }
  }
}
