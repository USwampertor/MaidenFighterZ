using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleConfiguration : MonoBehaviour
{
  #region MODULE_PROPERTIES

  public static BattleConfiguration Instance { get => m_instance; }

  private static BattleConfiguration m_instance = null;

  #endregion


  #region PROPERTIES

  public float tapTimeOut = 0.5f;

  public int maxBufferSize = 10;

  #endregion


  #region INTERNAL_PROPERTIES


  #endregion


  #region MONOBEHAVIOR_METHODS

  private void Awake()
  {
   if (Instance == null)
    {
      m_instance = this;
      DontDestroyOnLoad(this.gameObject);
    }
   else
    {
      Debug.LogWarning("Trying to instantiate again BattleConfiguration");
      Destroy(this.gameObject);
    }
  }

  #endregion

  #region METHODS

  #endregion


}
