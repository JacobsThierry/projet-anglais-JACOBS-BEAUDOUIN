using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantSpawnerAudioHardController : MonoBehaviour
{
    public Transform canvas;
    public GameObject popup;

    public GameObject popUp;
    private static List<string> accents = new List<string>{"Irish", "Jamaica", "scot", "general", "Yorkshire", "rp", "us", "south"};

    private enum accent
            {
                Irish,
                Jamaica,
                Scottish,
                UK,
                UK_Yorkshire,
                UK_Standard,
                US,
                US_South

            }

    

    public GameObject mechantAudioHard;





    public float timer;

    private float _timer;

    public float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        _timer = timer / 3; //On divise par 3 comme ça le premeir spawn est plus rapide
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _timer = timer;
            GameObject mcht;


            mcht = audioHard();

            mcht.transform.position = transform.position + new Vector3(0, Random.Range(-spawnRange, spawnRange), 0);
        }

    }
    public GameObject audioHard(){
        string word1 = wordManager.getWordForAudio(accents[3]); // accent de base
        string word2 = wordManager.getWordForAudio(accents[3]); // accent de base
        string word3 = wordManager.getWordForAudio(accents[3]); // accent de base
        string word4 = wordManager.getWordForAudio(accents[3]); // accent de base
        string word5 = wordManager.getWordForAudio(accents[3]); // accent de base

        List<string> words = new List<string>();
        words.Add(word1);
        words.Add(word2);
        words.Add(word3);
        words.Add(word4);
        words.Add(word5);


        GameObject mcht = Instantiate(mechantAudioHard);
        // Get random number between 0 and 4
        int randomIndex = UnityEngine.Random.Range(0, words.Count);
        mcht.GetComponent<MechantAudioHardController>().NewStart(words[randomIndex]);
        return mcht;
    }

}
