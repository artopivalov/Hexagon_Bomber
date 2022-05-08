///
///
///
using UnityEngine;

using System.Collections.Generic;

namespace Application.Entities
{
  public class GroundGenerator : Entity
  {
    [Header("References")]
    public GroundBlock groundReference;

    [Header("Settings")]
    public int width;
    public int height;

    public float offsetX = 1f;
    public float offsetZ => offsetX * Mathf.Sin(60 * Mathf.Deg2Rad);
    public bool fillEmpty;

    protected List<GroundBlock> groundBlockInstances = new List<GroundBlock>();

#if UNITY_EDITOR
    protected virtual void CreateGround()
    {
      ClearData();

      for(int i = 0; i < height; i++)
      {
        for(int j = 0; j < width + i % 2; j++)
        {
          var newBlock = UnityEditor.PrefabUtility.InstantiatePrefab(groundReference) as GroundBlock;
          newBlock.transform.SetParent(transform);

          var posX = offsetX * j - offsetX * (int)(width * 0.5f) - (i % 2 * (offsetX * 0.5f));
          var posZ = offsetZ * i - offsetZ * (int)(height * 0.5f);
          var posY = 0;

          newBlock.transform.localPosition = new Vector3(posX, posY, posZ);

          if(i == 0 || i == height -1 || j == 0 || j == width - (1 - i % 2))
          {
            newBlock.SpawnWall();
          }
          else if(fillEmpty)
          {
            newBlock.SpawnBreakableWall();
          }

          groundBlockInstances.Add(newBlock);
        }
      }
    }

    protected void ClearData()
    {
      foreach(var instance in GetComponentsInChildren<GroundBlock>(true))
      {
        GameObject.DestroyImmediate(instance.gameObject);
      }

      groundBlockInstances.Clear();
    }

    [UnityEngine.ContextMenu("Create ground")]
    private void CreateFromEditor()
    {
      CreateGround();
      UnityEditor.EditorUtility.SetDirty(this);
    }
#endif
  }
}
