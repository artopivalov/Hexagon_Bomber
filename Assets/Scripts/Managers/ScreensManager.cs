///
///
///
using Application.Entities;

using UnityEngine;

namespace Application.Managers
{
  public static class ScreensManager
  {
    private const string pathToScreens = "Prefabs/UI/Screens";

    private static Entities.Canvas canvas;

    static ScreensManager()
    {
      InstantiateScreens();
    }

    private static void InstantiateScreens()
    {
      canvas = GameObject.FindObjectOfType<Entities.Canvas>();

      ProceedObject(GameObject.Instantiate(Resources.Load<Control>(pathToScreens + "/Control").gameObject));

      foreach(var screen in Resources.LoadAll<Entities.Presentation>(pathToScreens))
      {
        var newScreen = GameObject.Instantiate(screen);
        ProceedObject(newScreen.gameObject);
      }

      void ProceedObject(GameObject gameObject)
      {
        gameObject.transform.SetParent(canvas.transform);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
      }
    }

    public static Entities.Canvas GetCanvas()
    {
      return canvas;
    }
  }
}
