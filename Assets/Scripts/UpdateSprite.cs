using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprite : MonoBehaviour
{
  public Image image;
  public Carousel carousel;
  // Start is called before the first frame update
  void Start()
  {
    carousel.OnSelectionChange += UpdateImage;
  }

  // Update is called once per frame
  void Update()
  {
        
  }


  public void UpdateImage(GameObject ob)
  {
    image.sprite = ob.transform.GetChild(0).GetComponent<Image>().sprite;
  }

}
