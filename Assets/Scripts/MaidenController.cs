using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class MaidenController : MonoBehaviour, MaidenFighterZInputAction.IInGameActions
{
  #region PROPERTIES


  #endregion

  #region INTERNAL_PROPERTIES

  private Maiden maiden;

  private MaidenFighterZInputAction actions;

  #endregion

  #region MONOBEHAVIOR_METHODS

  private void OnEnable()
  {
    actions?.InGame.Enable();
  }

  private void OnDisable()
  {
    actions?.InGame.Disable();
  }

  // Awake is called before anything
  void Awake()
  {
    maiden = GetComponent<Maiden>();
    actions = new MaidenFighterZInputAction();
  }

  // Start is called before the first frame update
  void Start()
  {
    actions?.Enable();
    actions?.InGame.Enable();
    actions.InGame.SetCallbacks(this);


  }

  // Update is called once per frame
  void Update()
  {

  }

  #endregion

  #region METHODS


  #endregion

  #region INTERFACE_METHODS

  public void OnMove(InputAction.CallbackContext context)
  {
    maiden.buffer.Add(eButtons.DOWN);

    var value = context.ReadValue<Vector2>();
    Debug.Log(value.AngleRounded(Vector2.right, 45.0f));
    Debug.Log(value.AngleToDirection(Vector2.right));


    Debug.Log("Making double tap");
    maiden.movement = context.ReadValue<Vector2>().x;


  }


  public void OnLP(InputAction.CallbackContext context)
  {

  }

  public void OnMP(InputAction.CallbackContext context)
  {

  }

  public void OnLK(InputAction.CallbackContext context)
  {

  }

  public void OnHP(InputAction.CallbackContext context)
  {

  }

  public void OnMK(InputAction.CallbackContext context)
  {

  }

  public void OnHK(InputAction.CallbackContext context)
  {

  }

  #endregion
}
