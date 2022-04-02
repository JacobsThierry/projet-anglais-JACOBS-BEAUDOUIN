using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameModeButtons : MonoBehaviour
{

   public List<GameMode> gameModes;
   public GameObject prefabButton;

   private GameObject spawner;

   // Start is called before the first frame update
   void Start()
   {
      Destroy(spawner);
   }

   private void OnEnable()
   {
      foreach (Transform child in this.transform)
      {
         Destroy(child.gameObject);
      }

      foreach (GameMode g in gameModes)
      {
         GameObject b = Instantiate(prefabButton, transform);
         b.name = "button_" + g.gameModeName;
         b.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = g.gameModeName;

         UnityEngine.UI.Button button = b.GetComponent<UnityEngine.UI.Button>();
         button.onClick.AddListener(() =>
         {
            spawner = Instantiate(g.spawner);

            DontDestroyOnLoad(spawner);

            SceneManager.LoadScene("game");


         });

      }

   }

   // Update is called once per frame
   void Update()
   {

   }
}
