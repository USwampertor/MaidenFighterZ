using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;


#if UNITY_EDITOR
[CustomEditor(typeof(VerticalCarousel))]
public class VerticalCarouselEditor : Editor
{
  public bool shouldUseSameSpeeds;
  public float scaleSpeed;
  public float sameSpeed;
  public float moveSpeed;
  public bool diffuse;

  public void Awake()
  {
    var t = target as VerticalCarousel;

    diffuse = t.diffuseButtons;
    shouldUseSameSpeeds = t.shouldUseSameSpeeds;
    sameSpeed = t.speed;
    scaleSpeed = t.scaleSpeed;
    moveSpeed = t.moveSpeed;
  }

  public override void OnInspectorGUI()
  {
    var t = target as VerticalCarousel;
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

public class VerticalCarousel : Carousel
{
    // Start is called before the first frame update
    void Start()
    {

    for (int i = 0; i < selectables.Count; i++)
    {

      EventTrigger trigger = selectables[i].gameObject.GetComponent<EventTrigger>();

      if (trigger != null)
      {
        // This means that there was already an event trigger set
        return;
      }

      else
      {
        trigger = selectables[i].gameObject.AddComponent<EventTrigger>();
      }


      EventTrigger.Entry deselected = new EventTrigger.Entry();
      deselected.eventID = EventTriggerType.Deselect;

      deselected.callback.AddListener((e) =>
      {
        previouslySelected = e.selectedObject;
        // Debug.Log("Previous: " + previouslySelected.name);
      });

      EventTrigger.Entry selected = new EventTrigger.Entry();
      selected.eventID = EventTriggerType.Select;

      selected.callback.AddListener((e) =>
      {

        if (selectables.Find(x => x.gameObject == e.selectedObject) != null)
        {

          currentlySelected = e.selectedObject;

          var previousIndex = selectables.FindIndex(x => x.gameObject.GetInstanceID() ==
                                                         previouslySelected.GetInstanceID());
          var currentIndex = selectables.FindIndex(x => x.gameObject.GetInstanceID() ==
                                                         currentlySelected.GetInstanceID());
          var difference = (currentIndex - previousIndex);

          Debug.Log("Difference:" + difference);

          selectables.Shift((difference == 1) ? (-1) : (difference == selectables.Count - 1 || difference == -1) ? 1 : 0);
          SetTransforms();
          ReorderSiblings();
          DiffuseSiblings(diffuseButtons);
        }


      });
      trigger.triggers.Add(selected);
      trigger.triggers.Add(deselected);


    }

    CalculatePoints();

    previouslySelected = selectables[0].gameObject;
    selectables[0].Select();
  }
}
