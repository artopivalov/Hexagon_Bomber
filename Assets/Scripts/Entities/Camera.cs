///
///
///
using UnityEngine;

namespace Application.Entities
{
  public class Camera : Entity
  {
    protected new UnityEngine.Camera camera;

    private void Awake()
    {
      camera = GetComponent<UnityEngine.Camera>();
    }

    public UnityEngine.Camera GetCamera()
    {
      return camera;
    }
  }
}
