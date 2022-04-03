using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallWManager : MonoBehaviour
{

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.name.StartsWith("Mechant"))
      {
         LifeManager.instance.hit();
         scoreManager.score -= 1;
         Destroy(other.gameObject);
      }
   }

}
