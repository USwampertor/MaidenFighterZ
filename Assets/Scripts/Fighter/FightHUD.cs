using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ButtonPair
{
  [SerializeField]
  public eButtons key;
  [SerializeField]
  public Sprite value;
}

public class FightHUD : MonoBehaviour
{
  [SerializeField]
  public List<ButtonPair> buttons;

  [SerializeField]
  public List<Sprite> numbers;

  public Image ButtonTemplate;

  public Image unitImage;
  public Image decimalImage;

  public float timer;

  // Start is called before the first frame update
  void Start()
  {
    timer = 99;
  }

  // Update is called once per frame
  void Update()
  {
    timer -= Time.deltaTime;
    unitImage.sprite    = numbers[Mathf.Abs((int)(timer % 10))];
    decimalImage.sprite = numbers[Mathf.Abs((int)(timer / 10))];
  }
}
