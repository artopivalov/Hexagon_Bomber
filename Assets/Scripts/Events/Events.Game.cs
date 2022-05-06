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

    public static void RequestReset()
    {
      PreReset.TryInvoke();
      Reset.TryInvoke();
    }
  }
}
