using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Events;

#if UNITY_EDITOR
[CustomEditor(typeof(Carousel))]
public class CarouselEditor : Editor
{
  public float  sameSpeed;
  public float  moveSpeed;
  public float  scaleSpeed;

  public bool   diffuse;
  
  public bool   horizontalValue;
  
  public bool   shouldUseSameSpeeds;

  public GameObject navigatorFrom;

  public GameObject navigatorTo;
  
  // WIP
  public bool   explicitNavigation;

  public void Awake()
  {
    var t = target as Carousel;

    moveSpeed   = t.moveSpeed;
    sameSpeed   = t.speed;
    scaleSpeed  = t.scaleSpeed;

    diffuse             = t.diffuseButtons;
    horizontalValue     = t.isHorizontal;
    shouldUseSameSpeeds = t.shouldUseSameSpeeds;

    navigatorFrom = t.navigatorFrom;
    navigatorTo   = t.navigatorTo;

    explicitNavigation = t.explicitNavigation;
  }

  public override void OnInspectorGUI()
  {
    var t = target as Carousel;
    DrawDefaultInspector();

    EditorGUILayout.Space();

    EditorGUILayout.LabelField("Add Button");
    if (GUILayout.Button("Add Button"))
    {
      t.AddNewItem();
    }

    if(GUILayout.Button("Delete Button"))
    {
      t.RemoveFromList(t.selectables.Count - 1);  
    }

    EditorGUILayout.Space();

    shouldUseSameSpeeds = GUILayout.Toggle(shouldUseSameSpeeds, 
                                           "Use Same Speed");

    t.shouldUseSameSpeeds = shouldUseSameSpeeds;

    if (shouldUseSameSpeeds)
    {
      sameSpeed = EditorGUILayout.FloatField("Speed", 
                                             sameSpeed);
      t.speed = sameSpeed;
    }
    else
    {
      scaleSpeed = EditorGUILayout.FloatField("Scale Speed", 
                                              scaleSpeed);

      moveSpeed = EditorGUILayout.FloatField("Move Speed", 
                                             moveSpeed);
      
      t.scaleSpeed  = scaleSpeed;
      t.moveSpeed   = moveSpeed;
    }

    EditorGUILayout.Space();


    diffuse = GUILayout.Toggle(diffuse, "Diffuse Buttons");
    t.diffuseButtons = diffuse;
    t.DiffuseSiblings(diffuse);


    EditorGUILayout.Space();


    horizontalValue = GUILayout.Toggle(horizontalValue, 
                                       horizontalValue ? 
                                        "Navigate Horizontal" : 
                                        "Navigate Vertical");
    
    if (horizontalValue != t.isHorizontal)
    {
      t.isHorizontal = horizontalValue;
      for (int i = 0; i < t.selectables.Count; ++i)
      {
        t.SetSelectableProperties(i);
      }
    }

    // explicitNavigation = GUILayout.Toggle(explicitNavigation, "WIP Use explicit Navigation");
    // t.explicitNavigation = explicitNavigation;
    // TODO: MAKE CHOICE OF NAVIGATION BETWEEN AUTOMATIC AND EXPLICIT
    navigatorFrom = EditorGUILayout.ObjectField(horizontalValue ? 
                                                  "Down Connection" : 
                                                  "Left Connection", 
                                                navigatorFrom, 
                                                typeof(GameObject), true) as GameObject;
    navigatorTo   = EditorGUILayout.ObjectField(horizontalValue ? 
                                                  "Up Connection" : 
                                                  "Right Connection", 
                                                navigatorTo, 
                                                typeof(GameObject), true) as GameObject;

    t.navigatorFrom = navigatorFrom;
    t.navigatorTo   = navigatorTo;
    
    
    //WIP
    if (false/*explicitNavigation*/)
    {
    }

  }

}

#endif



public class Carousel : MonoBehaviour
{
  /// <summary>
  /// The prefab button that will be instantiated when adding items to the carousel
  /// You can always change this or edit the items inside the carousel
  /// </summary>
  [Tooltip("Set this with the selectable item you want to populate the carousel")]
  public GameObject buttonPrefab;

  /// <summary>
  /// This can be anything as long as they're selectables. 
  /// You can add images or slides or buttons
  /// </summary>
  [Tooltip("The items that the carrousel will move and manage")]
  public List<UnityEngine.UI.Selectable> selectables =  new List<Selectable>();

  /// <summary>
  /// How small will items scale when being in the farther region of the carousel
  /// </summary>
  [Tooltip("How small will items scale when being in the farther region of the carousel")]
  public float minScale = 1;

  /// <summary>
  /// How small will items scale when being in the main region of the carousel
  /// </summary>
  [Tooltip("How small will items scale when being in the main region of the carousel")]
  public float maxScale = 1;

  /// <summary>
  /// Moves the center of the ellipse by x and y values
  /// </summary>
  [Tooltip("Moves the center of the ellipse by x and y values")]
  public Vector2 offset;

  /// <summary>
  /// How much you want items to separate in Y
  /// </summary>
  [Range(-1000, 1000), Tooltip("How much you want items to separate in Y")]
  public float maxHeight;

  /// <summary>
  /// How much you want items to separate in X
  /// </summary>
  [Range(-1000, 1000), Tooltip("How much you want items to separate in X")]
  public float maxWidth;

  /// <summary>
  /// Sets the position of items around the ellipse
  /// </summary>
  [Range(-360, 360), Tooltip("Sets the position of items around the ellipse")]
  public float offsetAngle = 0;

  // public UnityEvent OnSelectionChange;

  public delegate void Selected(GameObject item);
  public event Selected OnSelectionChange;

  public UnityEvent OnStart;

  protected List<Vector2> carrouselPoints = new List<Vector2>();

  protected GameObject currentlySelected;

  protected GameObject previouslySelected;

  [HideInInspector]
  public bool diffuseButtons = false;
  [HideInInspector]
  public float speed = 0.5f;
  [HideInInspector]
  public float moveSpeed = 0.5f;
  [HideInInspector]
  public float scaleSpeed = 0.5f;
  [HideInInspector]
  public bool shouldUseSameSpeeds = true;
  [HideInInspector]
  public bool isHorizontal = false;
  [HideInInspector]
  public bool explicitNavigation;
  [HideInInspector]
  public GameObject navigatorFrom = null;
  [HideInInspector]
  public GameObject navigatorTo = null;

#if UNITY_EDITOR
  [MenuItem("GameObject/UI/Carousel")]
  public static void CreateCarousel()
  {
    var newCarousel = new GameObject();
    newCarousel.transform.parent = FindObjectOfType<Canvas>().transform;
    var carouselTransform = newCarousel.AddComponent<RectTransform>();
    newCarousel.AddComponent<Carousel>();
    carouselTransform.localPosition = Vector3.zero;
    newCarousel.gameObject.name = "Carousel";
  }
#endif
  private void OnValidate()
  {
    CalculatePoints();
    SetTransforms();
    // ReorderSiblings();
    // DiffuseSiblings(diffuseButtons);
  }

  // Start is called before the first frame update
  void Start()
  {
    for (int i = 0; i < selectables.Count; ++i)
    {

      EventTrigger trigger = selectables[i].gameObject.GetComponent<EventTrigger>();

      if (trigger != null) { continue; }
      else 
      {
        trigger = selectables[i].gameObject.AddComponent<EventTrigger>();
      }

      EventTrigger.Entry deselected = new EventTrigger.Entry();
      deselected.eventID = EventTriggerType.Deselect;
     
      deselected.callback.AddListener((e) =>
      {
        previouslySelected = e.selectedObject;
      });

     
      EventTrigger.Entry selected = new EventTrigger.Entry();
      selected.eventID = EventTriggerType.Select;

      selected.callback.AddListener((e) =>
      {
        // That means that we are coming from somewhere else that is not the carousel
        GameObject newlySelected;
        newlySelected = e.selectedObject;
        if (selectables.Find(x => x.gameObject == newlySelected) != null)
        {

          currentlySelected = newlySelected;

          var previousIndex = selectables.FindIndex(x => x.gameObject.GetInstanceID() ==
                                                    previouslySelected.GetInstanceID());
          var currentIndex  = selectables.FindIndex(x => x.gameObject.GetInstanceID() ==
                                                    currentlySelected.GetInstanceID());
          
          var difference = (currentIndex - previousIndex);

          SetFrontNavigation(false);
          selectables.Shift((difference == 1) ? (-1) : 
                            (difference == selectables.Count - 1 || 
                             difference == -1) ? 
                            1 : 
                            0);
          SetInteractability();
          SetFrontNavigation(true);
          SetTransforms();
          ReorderSiblings();
          DiffuseSiblings(diffuseButtons);
          if (OnSelectionChange != null) { OnSelectionChange(newlySelected); }
        }
      });

      trigger.triggers.Add(selected);
      trigger.triggers.Add(deselected);
    }

    CalculatePoints();
    previouslySelected = selectables.Count > 0 ? selectables[0].gameObject : null;
    SetInteractability();
    SetFrontNavigation(true);
    OnStart.Invoke();
  }


  public Selectable GetSelectable()
  {
    return selectables.Count > 0 ? selectables[0] : null;
  }

  public void Select()
  {
    if (selectables.Count > 0)
    {
      selectables[0].Select();
    }
  }

  public void AddNewItem()
  {
    if (buttonPrefab == null)
    {
      Debug.LogWarning("There is no prefab object with" +
                       " Selectable component to add to the list");
      return;
    }

    AddToList(selectables.Count);
  }

  public void RemoveFromList(int index)
  {
    var toDelete = selectables[index].gameObject;
    GameObject.DestroyImmediate(toDelete);
    selectables.RemoveAt(index);

    for(int i = 0; i < selectables.Count; ++i)
    {
      SetSelectableProperties(i);
    }

    CalculatePoints();
    SetTransforms();
    ReorderSiblings();
    DiffuseSiblings(diffuseButtons);
  }

  private void AddToList(int i)
  {
    var newButton = Instantiate(buttonPrefab, this.transform);
    newButton.name = "New Button " + (i);
    
    if (GetComponentInChildren<TMPro.TextMeshProUGUI>() != null)
    {
      newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = newButton.name;
    }
    
    var btn = newButton.GetComponent<Button>();
    if (i >= selectables.Count)
    {
      selectables.Add(btn);
    }
    else
    { 
      selectables.Insert(i, btn);
    }

    for (int index = 0; index < selectables.Count; index++)
    {
      SetSelectableProperties(index);
    }

    CalculatePoints();
    SetTransforms();
    ReorderSiblings();
    DiffuseSiblings(diffuseButtons);
  }


  public void SetSelectableProperties(int i)
  {
    var navigation = selectables[i].navigation;
    navigation.mode = Navigation.Mode.Explicit;
    navigation.selectOnDown   = isHorizontal ? 
                                null : 
                                selectables[0 > i - 1 ? 
                                            selectables.Count - 1 : 
                                            i - 1];
    navigation.selectOnUp     = isHorizontal ? 
                                null : 
                                selectables[selectables.Count == i + 1 ? 
                                            0 : 
                                            i + 1];
    navigation.selectOnLeft   = isHorizontal ? 
                                selectables[0 > i - 1 ? 
                                            selectables.Count - 1 : 
                                            i - 1] : 
                                null;
    navigation.selectOnRight  = isHorizontal ? 
                                selectables[selectables.Count == i + 1 ? 
                                            0 : 
                                            i + 1] :
                                null;

    selectables[i].navigation = navigation;
    
  }

  public void SetFrontNavigation(bool isFront)
  {
    // TODO: MAKE IT POSSIBLE TO USE AUTOMATIC
    var navigation = selectables[0].navigation;
    // navigation.mode = isFront ? Navigation.Mode.Automatic : Navigation.Mode.Explicit;


    var interactables = GameObject.FindObjectsOfType<Selectable>();


    Selectable selectableFrom = null;
    Selectable selectableTo   = null;

    if (isFront)
    {
      if (navigatorFrom != null)
      {
        if (navigatorFrom.GetComponent<Carousel>())
        {
          selectableFrom = navigatorFrom.GetComponent<Carousel>().GetSelectable();
        }
        else if (navigatorFrom.GetComponent<Selectable>())
        {
          selectableFrom = navigatorFrom.GetComponent<Selectable>();
        }

      }

      if (navigatorTo != null)
      {
        if (navigatorTo.GetComponent<Carousel>())
        {
          selectableTo = navigatorTo.GetComponent<Carousel>().GetSelectable();
        }
        else if (navigatorTo.GetComponent<Selectable>())
        {
          selectableTo = navigatorTo.GetComponent<Selectable>();
        }
        
      }

    }

    // Check if object is left/down or right/up
    if (isHorizontal)
    {
      navigation.selectOnDown = isFront ? selectableFrom  : null;
      navigation.selectOnUp   = isFront ? selectableTo    : null;

    }
    else
    {
      navigation.selectOnLeft   = isFront ? selectableFrom  : null;
      navigation.selectOnRight  = isFront ? selectableTo    : null;

    }
   
    selectables[0].navigation = navigation;
  }


  

  protected void SetInteractability()
  {
    if (selectables.Count > 1)
    {
      for(int i = 1; i < selectables.Count; ++i)
      {
        selectables[i].interactable = false; 
      }

      selectables[0].interactable = true;
      if (selectables.Count > 1)
      {
        selectables[selectables.Count - 1].interactable = false;
      }
      if (selectables.Count > 2) {
        selectables[1].interactable = false;
      }
    }

  }

  protected void CalculatePoints()
  {
    // CIRCLE

    // for (int i = 0; i < selectables.Count; ++i)
    // {
    //   // We want to create a 1D circle that starts from the center of the carrousel and goes 
    //   // either up or down or left or right and around all the way to the point again 
    //   // TODO: make it customizable
    // 
    //   var angle = i * (360 / selectables.Count);
    //   Vector2 newPoint = new Vector2(offset.x + maxDistance * 
    //                                  Mathf.Cos(Mathf.Deg2Rad * angle),
    //                                  offset.y + maxDistance * 
    //                                  Mathf.Sin(Mathf.Deg2Rad * angle));
    //   selectables[i].gameObject.GetComponent<RectTransform>().localPosition =
    //    new Vector3(newPoint.x,
    //                newPoint.y,
    //                newPoint.x);
    //   carrouselPoints.Add(newPoint);
    // }

    // ELLIPSE

    carrouselPoints.Clear();

    for (int i = 0; i < selectables.Count; ++i)
    {

      var angle = i * (360 / selectables.Count) + offsetAngle;
      Vector2 newPoint = new Vector2(offset.x + maxWidth  * Mathf.Cos(Mathf.Deg2Rad * angle),
                                     offset.y + maxHeight * Mathf.Sin(Mathf.Deg2Rad * angle));
      selectables[i].gameObject.GetComponent<RectTransform>().localPosition = 
        new Vector3(newPoint.x, 
                    newPoint.y, 
                    newPoint.x);
      carrouselPoints.Add(newPoint);
    }
    this.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Abs(2f*maxWidth), Mathf.Abs(2f*maxHeight));
  }

  // Update is called once per frame
  void Update()
  {
    // This means that the new selected object is NOT part of the carousel
    if (currentlySelected != null && 
        selectables.Find(x => x.gameObject == 
                         EventSystem.current.currentSelectedGameObject ) == null)
    {
      currentlySelected = null;
    }
  }


  Vector3 CalcParabolaVertex(Vector2 v1, Vector2 v2, Vector2 v3)
  {
    double denom = (v1.x - v2.x) * 
                   (v1.x - v3.x) * 
                   (v2.x - v3.x);

    double A = (v3.x * (v2.y - v1.y) + v2.x * 
                       (v1.y - v3.y) + v1.x * 
                       (v3.y - v2.y)) / denom;

    double B = (v3.x * v3.x * (v1.y - v2.y) + v2.x * v2.x * 
                              (v3.y - v1.y) + v1.x * v1.x * 
                              (v2.y - v3.y)) / denom;

    double C = (v2.x * v3.x * (v2.x - v3.x) * v1.y + v3.x * v1.x * 
                              (v3.x - v1.x) * v2.y + v1.x * v2.x * 
                              (v1.x - v2.x) * v3.y) / denom;

    return new Vector3((float)A, (float)B, (float)C);
  }

  protected void SetTransforms()
  {
    var parabolaextremeX = (selectables.Count / 2);

    Vector3 ABC = CalcParabolaVertex(new Vector2(0, maxScale),
                                     new Vector2(parabolaextremeX, minScale),
                                     new Vector2(selectables.Count, maxScale));

    for (int i = 0; i < selectables.Count; ++i)
    {
      var newPoint = carrouselPoints[i];
      var obj = selectables[i].gameObject;

      //  y     = Ax^2            + Bx          + C
      var scale = (ABC.x * i * i) + (ABC.y * i) + ABC.z;


      if(float.IsNaN(scale))
      {
        scale = maxScale;
      }

      var rect = obj.GetComponent<RectTransform>();
      if (Application.isPlaying && gameObject.activeInHierarchy)
      {
        StartCoroutine(MoveButton(rect.localPosition, 
                                  newPoint, 
                                  selectables[i]));
        StartCoroutine(ScaleButton(rect.localScale, 
                                   new Vector3(scale, scale, 1), 
                                   selectables[i]));
      }
      else // This way we can edit in Editor mode and see the changes
      {
        rect.localPosition = newPoint;
        rect.localScale = new Vector3(scale, scale, 1);
      }
      
    }

  }

  public void ReorderSiblings()
  {
    if (selectables.Count < 1) { return; }

    var side0 = selectables[selectables.Count / 2];
    side0.gameObject.GetComponent<RectTransform>().SetAsLastSibling();
    for (int i = 0; i < selectables.Count / 2 + 1; ++i)
    {
      if (selectables.Count / 2 + i < selectables.Count)
      {
        var side1 = selectables[selectables.Count / 2 + i];
        side1.gameObject.GetComponent<RectTransform>().SetAsLastSibling();
      }

      if(selectables.Count / 2 - i > -1)
      {
        var side2 = selectables[selectables.Count / 2 - i];
        side2.gameObject.GetComponent<RectTransform>().SetAsLastSibling();
      }
    }
    selectables[0].gameObject.GetComponent<RectTransform>().SetAsLastSibling();
  }


  public void DiffuseSiblings(bool shouldDiffuse)
  {
    if (selectables.Count < 3) { return; }

    if (!shouldDiffuse) // Set alpha to 1 in all Canva groups
    {
      for (int i = 0; i < selectables.Count; ++i)
      {
        var canvaGroup = selectables[i].GetComponent<CanvasGroup>();
        if (canvaGroup != null)
        {
          // DestroyImmediate(canvaGroup);
          canvaGroup.alpha = 1.0f;
        }
      }
    }
    else // We should set canvagroup values
    {
      var canvaGroup = selectables[selectables.Count / 2].GetComponent<CanvasGroup>();
      if (canvaGroup == null)
      {
        canvaGroup = selectables[selectables.Count / 2].gameObject.AddComponent<CanvasGroup>();
      }
      canvaGroup.alpha = 0.01f;

      for (int i = 0; i < selectables.Count / 2 + 1; ++i)
      {
        var topValue = selectables.Count / 2 + i;
        var botValue = selectables.Count / 2 - i;
        if (topValue < selectables.Count)
        {
          canvaGroup = selectables[topValue].GetComponent<CanvasGroup>();
          if (canvaGroup == null)
          {
            canvaGroup = selectables[topValue].gameObject.AddComponent<CanvasGroup>();
          }
          canvaGroup.alpha = 2 * i / (float)(selectables.Count + 1);
        }
        if (botValue > -1)
        {
          canvaGroup = selectables[botValue].GetComponent<CanvasGroup>();
          if (canvaGroup == null)
          {
            canvaGroup = selectables[botValue].gameObject.AddComponent<CanvasGroup>();
          }
          canvaGroup.alpha = 2 * i / (float)(selectables.Count + 1);
        }
      }

      canvaGroup = selectables[0].GetComponent<CanvasGroup>();
      if (canvaGroup == null)
      {
        canvaGroup = selectables[0].gameObject.AddComponent<CanvasGroup>();
      }
      canvaGroup.alpha = 1.0f;
    }
  }

  public IEnumerator ScaleButton(Vector3 previousScale, Vector3 newScale, Selectable obj)
  {
    float speedToUse = shouldUseSameSpeeds ? speed : scaleSpeed;
    for (float i = 0; i < speedToUse; i += Time.deltaTime)
    {
      obj.GetComponent<RectTransform>().localScale = Vector3.Lerp(previousScale, 
                                                                  newScale, 
                                                                  i / speedToUse);
      yield return null;
    }

    obj.GetComponent<RectTransform>().localScale = newScale;

    yield return null;
  }

  public IEnumerator MoveButton(Vector3 previousPos, Vector3 newPos, Selectable obj)
  {
    float speedToUse = shouldUseSameSpeeds ? speed : moveSpeed;

    for (float i = 0; i < speedToUse; i += Time.deltaTime)
    {
      obj.GetComponent<RectTransform>().localPosition = Vector3.Lerp(previousPos, 
                                                                     newPos, 
                                                                     i / speedToUse);
      yield return null;
    }

    obj.GetComponent<RectTransform>().localPosition = newPos;

    yield return null;
  }

}
