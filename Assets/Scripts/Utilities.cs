using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Utilities : MonoBehaviour
{
  public List<Vector3> lerpPositions = new List<Vector3>();
  private Vector3 startPos;
  public float time = 1.0f;

  // Start is called before the first frame update
  void Start()
  {
    startPos = GetComponent<RectTransform>().localPosition;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.matrix = GetComponent<RectTransform>().localToWorldMatrix;
    foreach (var position in lerpPositions)
    {
      Gizmos.DrawSphere(position, 50);
    }
  }

  public void LerpUIPos(int start, int end)
  {
    StartCoroutine(LerpUIPosCoroutine(lerpPositions[start], lerpPositions[end]));
  }

  public IEnumerator LerpUIPosCoroutine(Vector3 start, Vector3 end)
  {
    for (float i = 0; i < time; i += Time.deltaTime)
    {
      GetComponent<RectTransform>().localPosition = Vector3.Lerp(startPos + start,
                                                                 startPos + end,
                                                                 (i / time) );
      yield return null;
    }

    GetComponent<RectTransform>().localPosition = end;

    yield return null;
  }
}

