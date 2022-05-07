///
///
///
using UnityEngine;

namespace Application.Entities
{
  public static partial class EntityExtensions
  {
    public static Vector3 GetPosition(this Entity entity)
    {
      return entity.transform.position;
    }

    public static float GetPositionX(this Entity entity)
    {
      return entity.transform.position.x;
    }

    public static float GetPositionY(this Entity entity)
    {
      return entity.transform.position.y;
    }

    public static float GetPositionZ(this Entity entity)
    {
      return entity.transform.position.z;
    }

    public static void SetPosition(this Entity entity, Vector3 position)
    {
      entity.transform.position = position;
    }

    public static void SetPositionX(this Entity entity, float position)
    {
      entity.SetPosition(new Vector3(position, entity.GetPositionY(), entity.GetPositionZ()));
    }

    public static void SetPositionY(this Entity entity, float position)
    {
      entity.SetPosition(new Vector3(entity.GetPositionX(), position, entity.GetPositionZ()));
    }

    public static void SetPositionZ(this Entity entity, float position)
    {
      entity.SetPosition(new Vector3(entity.GetPositionX(), entity.GetPositionY(), position));
    }
  }
}
