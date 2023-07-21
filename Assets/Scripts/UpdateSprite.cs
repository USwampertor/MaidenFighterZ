using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprite : MonoBehaviour
{
  public Image image;

  // Start is called before the first frame update
  void Start()
  {
    Carousel.OnSelectionChange += UpdateImage;
  }

  // Update is called once per frame
  void Update()
  {
        
  }


  public void UpdateImage(GameObject ob)
  {
    Debug.Log(ob.name);
    image.sprite = ob.transform.GetChild(0).GetComponent<Image>().sprite;
  }

}
