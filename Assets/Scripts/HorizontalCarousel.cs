using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
[CustomEditor(typeof(HorizontalCarousel))]
public class HorizontalCarouselEditor : Editor
{
  public bool shouldUseSameSpeeds;
  public float scaleSpeed;
  public float sameSpeed;
  public float moveSpeed;
  public bool diffuse;

  public void Awake()
  {
    var t = target as HorizontalCarousel;

    diffuse = t.diffuseButtons;
    shouldUseSameSpeeds = t.shouldUseSameSpeeds;
    sameSpeed = t.speed;
    scaleSpeed = t.scaleSpeed;
    moveSpeed = t.moveSpeed;
  }

  public override void OnInspectorGUI()
  {
    var t = target as HorizontalCarousel;
    DrawDefaultInspector();


    EditorGUILayout.LabelField("Add Button");
    if (GUILayout.Button("Add Button"))
    {
      t.AddNewItem();
    }
    if (GUILayout.Button("Delete Button"))
    {
      t.RemoveFromList(t.selectables.Count - 1);
    }

    shouldUseSameSpeeds = GUILayout.Toggle(shouldUseSameSpeeds, "Use Same Speed");
    t.shouldUseSameSpeeds = shouldUseSameSpeeds;

    if (shouldUseSameSpeeds)
    {
      sameSpeed = EditorGUILayout.FloatField("Speed", sameSpeed);
      t.speed = sameSpeed;
    }
    else
    {
      scaleSpeed = EditorGUILayout.FloatField("Scale Speed", scaleSpeed);
      moveSpeed = EditorGUILayout.FloatField("Move Speed", moveSpeed);

      t.scaleSpeed = scaleSpeed;
      t.moveSpeed = moveSpeed;
    }


    diffuse = GUILayout.Toggle(diffuse, "Diffuse Buttons");
    t.diffuseButtons = diffuse;
    t.DiffuseSiblings(diffuse);


  }

}

#endif


public class HorizontalCarousel : Carousel
{
    // Start is called before the first frame update
    void Start()
    {

    }

}
