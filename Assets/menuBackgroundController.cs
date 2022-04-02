using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuBackgroundController : MonoBehaviour
{


   public float colorSpeed;

   private float s, v;

   public UnityEngine.UI.Image img;

   // Start is called before the first frame update
   void Start()
   {
      float h;
      Color.RGBToHSV(img.color, out h, out s, out v);
   }

   // Update is called once per frame
   void Update()
   {
      float h, ss, vv;

      Color.RGBToHSV(img.color, out h, out ss, out vv);
      h += Time.deltaTime * colorSpeed % 360;
      img.color = Color.HSVToRGB(h, s, v);
   }
}
