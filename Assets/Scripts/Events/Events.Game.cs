///
///
///
using UnityEngine.Events;

namespace Application
{
  public partial class Events
  {
    public static UnityAction PreReset;
    public static UnityAction Reset;
    public static UnityAction Update;

    public static void RequestReset()
    {
      PreReset.TryInvoke();
      Reset.TryInvoke();
    }
  }
}
