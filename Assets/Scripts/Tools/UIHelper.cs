///
///
///
using Application.Managers;

using UnityEngine;
using UnityEngine.UI;

namespace Application
{
  public static class UIHelper
  {
    public static float GetCanvasScaleFactor()
    {
      var scaler = ScreensManager.GetCanvas().GetComponent<CanvasScaler>();
      return scaler.referenceResolution.y / Screen.height;
    }
  }
}
