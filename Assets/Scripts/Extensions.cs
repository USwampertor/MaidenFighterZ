using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
  public static float AngleRounded(this Vector2 to, Vector2 from, float roundingAngle)
  {
    var angle = Vector2.SignedAngle(from, to);
    if (0 == roundingAngle)
    {
      Debug.LogError("Cannot use 0 as a rounding angle");
      return 0;
    }
    return Mathf.Round(angle / roundingAngle) * roundingAngle > 0 ?
           Mathf.Round(angle / roundingAngle) * roundingAngle : 
           360 + Mathf.Round(angle / roundingAngle) * roundingAngle;
  }

  public static float AngleRoundedSigned(this Vector2 to, Vector2 from, float roundingAngle)
  {
    var angle = Vector2.SignedAngle(from, to);
    if (0 == roundingAngle)
    {
      Debug.LogError("Cannot use 0 as a rounding angle");
      return 0;
    }
    return Mathf.Round(angle / roundingAngle) * roundingAngle;
  }

  public static eButtons AngleToDirection(this Vector2 reference, Vector2 start)
  {
    var direction = reference.AngleRounded(start, 45.0f);
    return direction == 0   ? eButtons.RIGHT    :
           direction == 45  ? eButtons.UPRIGHT  :
           direction == 90  ? eButtons.UP       :
           direction == 135 ? eButtons.UPLEFT   :
           direction == 180 ? eButtons.LEFT     :
           direction == 225 ? eButtons.DOWNLEFT :
           direction == 270 ? eButtons.DOWN     :
           direction == 315 ? eButtons.DOWNRIGHT:
                              eButtons.RIGHT    ;
  }

  public static void Trim<T>(this List<T> list, int amount)
  {
    list.RemoveRange(list.Count - 1 - amount, amount);
  }

  public static void Shift<T>(this List<T> list, int amount)
  {
    // Moves the position of the objects in a list n times left or right

    // var listCopy = new List<T>(list);
    var abs = Mathf.Abs(amount);
    if (amount < 0)
    {
      for (int i = 0; i < abs; i++)
      {
        list.Add(list[0]);
        list.RemoveAt(0);
      }
    }
    else if (amount > 0)
    {

      for (int i = 0; i < abs; i++)
      {
        list.Insert(0, list[list.Count - 1]);
        list.RemoveAt(list.Count - 1);
      }
    }
    else
    {
      // Debug.Log("Shifting with value of 0 means you ain't changing anything");
    }
  }

}
