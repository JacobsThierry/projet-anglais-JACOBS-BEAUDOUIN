using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSettingsController : MonoBehaviour
{

   public UnityEngine.UI.Slider slider;
   public UnityEngine.UI.Image image;

   public List<Sprite> sprites;
   private SoundManager soundManager;


   // Start is called before the first frame update
   void Start()
   {
      soundManager = SoundManager.instance;

      slider.value = soundManager.volume;

      image.sprite = sprites[Mathf.Max(0, Mathf.RoundToInt((slider.value * (sprites.Count - 1))))];


      slider.onValueChanged.AddListener((float v) =>
      {

         image.sprite = sprites[Mathf.Max(0, Mathf.RoundToInt((v * (sprites.Count - 1))))];
         soundManager.volume = v;
      });

   }


   private void OnEnable()
   {
      soundManager = SoundManager.instance;

      slider.value = soundManager.volume;

      image.sprite = sprites[Mathf.Max(0, Mathf.RoundToInt((slider.value * (sprites.Count - 1))))];
   }

   // Update is called once per frame
   void Update()
   {

   }
}
