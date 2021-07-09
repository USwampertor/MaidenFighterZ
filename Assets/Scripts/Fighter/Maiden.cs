#define TESTING

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

[System.Serializable]
public enum eButtons
{
  NONE = 0,
  UP,
  UPRIGHT,
  RIGHT,
  DOWNRIGHT,
  DOWN,
  DOWNLEFT,
  LEFT,
  UPLEFT,
  LPUNCH,
  MPUNCH,
  HPUNCH,
  LKICK,
  MKICK,
  HKICK
}

[System.Serializable]
public class MaidenAttack
{
  [SerializeField]
  public string name;

  [SerializeField]
  public float power;

  [SerializeField]
  public float coolDown;

  [SerializeField]
  public float time;

  public MaidenAttack(string newName, float newPower, float newCoolDown, float newTime)
  {
    name      = newName;
    power     = newPower;
    coolDown  = newCoolDown;
    time      = newTime;
  }
}

[System.Serializable]
public class MaidenCombo
{
  [SerializeField]
  public string name;

  [SerializeField]
  public float cost;

  [SerializeField]
  public float damage;
  
  [SerializeField]
  public List<KeyCode> buffer;

  public MaidenCombo(string newName, float newCost, float newDamage, List<KeyCode> keys)
  {
    name    = newName;
    cost    = newCost;
    damage  = newDamage;
    buffer  = keys;
  }

}

/// <summary>
/// This object contains the information that defines the maiden being used
/// This way, you have always two Maidens, and you only change the information
/// inside them with the MaidenInfo being a serializable Object
/// </summary>
[System.Serializable]
public class MaidenInfo
{
  [SerializeField]
  public string name;

  [SerializeField]
  public string spriteSheet;

  [SerializeField]
  public float movementSpeed;
  [SerializeField]
  public float sprintSpeed;
  [SerializeField]
  public float jumpForce;

  [SerializeField]
  public float health;

  [SerializeField]
  public MaidenAttack LP;
  [SerializeField]
  public MaidenAttack MP;
  [SerializeField]
  public MaidenAttack HP;

  [SerializeField]
  public MaidenAttack LK;
  [SerializeField]
  public MaidenAttack MK;
  [SerializeField]
  public MaidenAttack HK;

  [SerializeField]
  public List<MaidenCombo> combos;

  public MaidenInfo(string preset)
  {
    if ("test" == preset)
    {

      name          = "";
      spriteSheet   = "";
      movementSpeed = 10.0f;
      sprintSpeed   = 01.5f;
      jumpForce     = 200.0f;

      health        = 100.0f;

      LP = new MaidenAttack("testLP", 10, 1, 1);
      MP = new MaidenAttack("testMP", 10, 1, 1);
      HP = new MaidenAttack("testHP", 10, 1, 1);

      LK = new MaidenAttack("testLK", 10, 1, 1);
      MK = new MaidenAttack("testMK", 10, 1, 1);
      HK = new MaidenAttack("testHK", 10, 1, 1);

      combos = new List<MaidenCombo>();
      combos.Add(new MaidenCombo("testCombo", 10, 10, new List<KeyCode>()));
    }
  }
}

public class Maiden : MonoBehaviour
{
  #region PROPERTIES

  [SerializeField]
  public MaidenInfo info;

  public bool isGrounded;

  public int timesJumped;

  public (eButtons, int)[] taps;

  public float health;

  public float energy;

  public float defaultGroundValue = 1000.0f;

  #endregion

  #region INTERNAL_PROPERTIES

  public float movement;

  public Maiden otherPlayer = null;

  public SceneCamera cam;

  public Rigidbody rigidBody;

  public List<eButtons> buffer;

  public MaidenHUD hud;
  #endregion

  #region MONOBEHAVIOR_METHODS

  // Awake is called before anything

  // Start is called before the first frame update
  void Start()
  {
#if TESTING
    info = new MaidenInfo("test");
    health = info.health;
    cam = FindObjectOfType<SceneCamera>();
#endif

    rigidBody = GetComponent<Rigidbody>();

    taps = new (eButtons, int)[] 
    { 
      (eButtons.LEFT, 0),
      (eButtons.RIGHT, 0),
      (eButtons.UP, 0),
      (eButtons.DOWN, 0),
    };
  }

  // Update is called once per frame
  void Update()
  {
    var newDiff = Vector3.right * movement * info.movementSpeed * Time.deltaTime;
    if (otherPlayer != null)
    {
      if (((transform.position + newDiff) - otherPlayer.transform.position).magnitude <= cam.maxFighterDistance)
      {
        transform.position += newDiff;
      }
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if ("Floor" == collision.gameObject.tag)
    {
      isGrounded = true;
      timesJumped = 0;
    }
  }

  #endregion


  #region METHODS

  public void UpdateBuffer(eButtons newButton)
  {
    buffer.Add(newButton);

    if (buffer.Count > BattleConfiguration.Instance.maxBufferSize)
    {
      buffer.RemoveRange(0, buffer.Count - BattleConfiguration.Instance.maxBufferSize);
    }
    hud.UpdateBuffer(buffer);
  }

  #endregion
}
