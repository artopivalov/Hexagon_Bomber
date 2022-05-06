///
///
///
using UnityEngine.Events;

using UnityEngine;

namespace Application
{
  public partial class Events
  {
    public static UnityAction PointerDown;
    public static UnityAction PointerUp;
    public static UnityAction<Vector2> PointerMove;
  }
}
