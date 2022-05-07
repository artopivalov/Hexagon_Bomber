///
///
///
using Application.Entities;

using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Application.Managers
{
  public static class CameraManager
  {
    private const string pathToCameras = "Prefabs/Camera";

    public static CameraMain main;
    public static Entities.Camera ui;

    static CameraManager()
    {
      InstantiateCameras();
    }

    private static void InstantiateCameras()
    {
      main = GameObject.Instantiate<Entities.Camera>(
        Resources.Load<Entities.Camera>(pathToCameras + "/CameraMain")) as CameraMain;
      ui = GameObject.Instantiate<Entities.Camera>(
        Resources.Load<Entities.Camera>(pathToCameras + "/CameraUI"));

      main.GetCamera().GetUniversalAdditionalCameraData().cameraStack.Add(ui.GetCamera());
      ScreensManager.GetCanvas().GetComponent<UnityEngine.Canvas>().worldCamera = ui.GetCamera();
    }
  }
}
