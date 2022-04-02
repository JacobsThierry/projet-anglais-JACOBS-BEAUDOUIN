using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopupButtonController : MonoBehaviour
{

   public GameObject popup;

   // Start is called before the first frame update
   void Start()
   {
      GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
      {
         popup.SetActive(false);
      });
   }

   // Update is called once per frame
   void Update()
   {

   }
}
