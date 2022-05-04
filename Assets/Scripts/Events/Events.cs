///
///
///
using UnityEngine.Events;

namespace Application
{
  public partial class Events
  {

  }

  public static class EventExtension
  {
    public static void TryInvoke(this UnityAction unityAction)
    {
      unityAction?.Invoke();
    }
  }
}
