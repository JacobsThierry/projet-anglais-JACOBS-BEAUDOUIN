using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

   public int max_Life;
   public int life;

   public GameObject coeur;

   public static LifeManager instance;

   public GameObject gameOver;

   public GameObject player;

   // Start is called before the first frame update
   void Start()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(this.gameObject);
      }

      life = max_Life;

      for (int i = 0; i < max_Life; i++)
      {
         Instantiate(coeur, transform);
      }

   }

   // Update is called once per frame
   void Update()
   {

   }

   public void hit()
   {
      life--;
      Destroy(transform.GetChild(0).gameObject);


      if (life <= 0)
      {
         gameOver.SetActive(true);
         Destroy(player);
      }


   }
}
