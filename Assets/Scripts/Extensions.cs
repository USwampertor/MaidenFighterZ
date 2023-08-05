using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
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
