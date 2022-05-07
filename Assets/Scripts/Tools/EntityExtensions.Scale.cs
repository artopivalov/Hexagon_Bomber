///
///
///
using UnityEngine;

namespace Application.Entities
{
  public static partial class EntityExtensions
  {
    public static Vector3 GetScale(this Entity entity)
    {
      return entity.transform.localScale;
    }

    public static float GetScaleX(this Entity entity)
    {
      return entity.transform.localScale.x;
    }

    public static float GetScaleY(this Entity entity)
    {
      return entity.transform.localScale.y;
    }

    public static float GetScaleZ(this Entity entity)
    {
      return entity.transform.localScale.z;
    }

    public static void SetScale(this Entity entity, Vector3 scale)
    {
      entity.transform.localScale = scale;
    }

    public static void SetScale(this Entity entity, float scale)
    {
      entity.transform.localScale = new Vector3(scale, scale, scale);
    }

    public static void SetScaleX(this Entity entity, float scale)
    {
      entity.SetScale(new Vector3(scale, entity.GetScaleY(), entity.GetScaleZ()));
    }

    public static void SetScaleY(this Entity entity, float scale)
    {
      entity.SetScale(new Vector3(entity.GetScaleX(), scale, entity.GetScaleZ()));
    }

    public static void SetScaleZ(this Entity entity, float scale)
    {
      entity.SetScale(new Vector3(entity.GetScaleX(), entity.GetScaleY(), scale));
    }
  }
}
