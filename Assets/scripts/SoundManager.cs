using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{



   public float volume;


   private AudioSource asMusique;


   private bool _musiqueOn = true;

   public AudioClip musique;

   public static SoundManager instance;

   public bool musiqueOn
   {

      get
      {
         return _musiqueOn;
      }

      set
      {
         Debug.Log(value);
         asMusique.volume = value ? volume : 0;
         _musiqueOn = value;


      }
   }


   public void setupMusique()
   {
      if (transform.Find("Musique") == null)
      {
         GameObject go = new GameObject("Musique");
         go.transform.parent = transform;
         asMusique = go.AddComponent<AudioSource>();
         asMusique.clip = musique;
         asMusique.volume = volume;
         asMusique.loop = true;
         asMusique.Play();
      }
   }

   private void Start()
   {
      if (instance == null)
         instance = this;
      else
         Destroy(this.gameObject);


      setupMusique();
   }






   public void playSound(AudioClip ac)
   {
      GameObject go = new GameObject("sound");
      go.transform.parent = transform;
      AudioSource audioSource = go.AddComponent<AudioSource>();
      audioSource.clip = ac;
      audioSource.volume = volume;
      go.AddComponent<destroyAudio>();
      audioSource.Play();
   }



   // Update is called once per frame
   void Update()
   {


      foreach (Transform o in transform)
      {
         AudioSource audioSource = o.GetComponent<AudioSource>();
         audioSource.volume = volume;
      }

      if (asMusique != null)
      {
         Debug.Log(musiqueOn);
         asMusique.volume = musiqueOn ? volume : 0;
      }

   }



}
