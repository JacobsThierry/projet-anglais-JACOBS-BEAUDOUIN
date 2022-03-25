using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    private List<GameObject> sounds = new List<GameObject>();


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
            _musiqueOn = value;
            asMusique.volume = value ? volume : 0;

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
        if (asMusique != null)
            asMusique.volume = musiqueOn ? volume : 0;

        foreach (GameObject o in sounds)
        {
            AudioSource audioSource = o.GetComponent<AudioSource>();
            audioSource.volume = volume;
        }
    }



}
