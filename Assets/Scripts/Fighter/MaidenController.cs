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

    var direction = (maiden.otherPlayer.transform.position - maiden.transform.position).normalized.x *
                    Vector3.right;

    var value = context.ReadValue<Vector2>();
    Debug.Log(context.phase);

    if (context.performed)
    {
      maiden.UpdateBuffer(value.AngleToDirection(direction));
    }

    // Movement in X
    maiden.movement = context.ReadValue<Vector2>().x;

    // Movement in Y
    if (value.y > 0.5f)
    {

      if (context.performed && maiden.isGrounded && maiden.timesJumped == 0)
      {
        maiden.rigidBody.AddForce(Vector3.up * value.y * maiden.info.jumpForce);
        maiden.isGrounded = false;
        ++maiden.timesJumped;
      }
      else if (context.performed && maiden.timesJumped < 2)
      {
        maiden.rigidBody.AddForce(Vector3.up * value.y * maiden.info.jumpForce * 1.5f);
        ++maiden.timesJumped;
      }

    }
    else if (value.y < -0.5f)
    {
      maiden.rigidBody.velocity = Vector3.zero;
      maiden.rigidBody.AddForce(Vector3.down * maiden.defaultGroundValue);
    }

  }


  public void OnLP(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      maiden.UpdateBuffer(eButtons.LPUNCH);
    }
  }

  public void OnMP(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      maiden.UpdateBuffer(eButtons.MPUNCH);
    }
  }

  public void OnHP(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      maiden.UpdateBuffer(eButtons.HPUNCH);
    }
  }

  public void OnLK(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      maiden.UpdateBuffer(eButtons.LKICK);
    }
  }


  public void OnMK(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      maiden.UpdateBuffer(eButtons.MKICK);
    }
  }

  public void OnHK(InputAction.CallbackContext context)
  {
    if (context.performed)
    {
      maiden.UpdateBuffer(eButtons.HKICK);
    }
  }

  #endregion
}
