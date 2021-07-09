using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MaidenHUD : MonoBehaviour
{
  #region PROPERTIES

  public FightHUD hud;

  #endregion


  #region INTERNAL_PROPERTIES

  // public GameObject bufferContainer;

  public List<Image> buffer;

  #endregion


  #region MONOBEHAVIOR_METHODS

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  #endregion

  #region METHODS

  public void UpdateBuffer(List<eButtons> buttons)
  {
    for(int i = 0; i < buttons.Count; ++i)
    {
      buffer[buttons.Count - i - 1].sprite = hud.buttons.Find(x => x.key == buttons[i]).value;
    }

  }

  #endregion
}
