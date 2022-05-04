///
///
///
using UnityEngine.Events;

namespace Application
{
  public partial class Events
  {
    public static UnityAction OnPreReset;
    public static UnityAction OnReset;

    public static void RequestReset()
    {
      OnPreReset.TryInvoke();
      OnReset.TryInvoke();
    }
  }
}
