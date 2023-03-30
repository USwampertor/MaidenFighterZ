using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class SceneCamera : MonoBehaviour
{
  public Vector3 initialPos;

  public Vector3 zoomOutPos;
  public float zoomOutFov;

  public Vector3 zoomInPos;
  public float zoomInFov;

  public List<Maiden> fighters;

  public float maxFighterDistance = 10.0f;
  public float minFighterDistance = 05.0f;

  // Start is called before the first frame update
  IEnumerator Start()
  {
    yield return new WaitForSeconds(0.5f);

    // Gets the two players that are active in scene
    fighters = new List<Maiden>();
    fighters.AddRange(FindObjectsOfType<Maiden>());

    // Checks if it fetched correctly both players
    if (fighters.Count != 2)
    {
      Debug.LogError("Couldn't get both players: Players found were " + fighters.Count);
    }
    else
    {
      fighters[0].otherPlayer = fighters[1];
      fighters[1].otherPlayer = fighters[0];
    }
    yield return null;
  }

  // Update is called once per frame
  void Update()
  {
    if (fighters.Count > 0)
    {
      // Get the middle point and set the x position
      var middlePoint = (fighters[0].transform.position + fighters[1].transform.position) * 0.5f;
      var position = transform.position;
      position.x = middlePoint.x;

      var distanceProportion = Mathf.InverseLerp(minFighterDistance,
                                                 maxFighterDistance,
                                                 (fighters[0].transform.position -
                                                 fighters[1].transform.position).magnitude);

      distanceProportion = Mathf.Clamp(distanceProportion, 0, 1);

      position.y = Vector3.Lerp(zoomInPos, zoomOutPos, distanceProportion).y +
        (fighters[0].transform.position.y - fighters[1].transform.position.y);
      position.z = Vector3.Lerp(zoomInPos, zoomOutPos, distanceProportion).z -
        (fighters[0].transform.position.y - fighters[1].transform.position.y) * 0.75f;

      transform.position = position;
    }
  }



}
