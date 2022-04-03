using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantSpawnerController : MonoBehaviour
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

    public Synonymes synonymeEasy = null;
    public Synonymes synonymeHard = null ;
    public GameObject mechant;

    public GameObject mechantEasy;

    public GameObject mechantHard;

    public GameObject mechantSynonymeEasy;

    public GameObject mechantSynonymeHard;


    public GameObject mechantQuestion;

    public GameObject mechantAudio;

    public GameObject mechantAudioHard;

    public GameObject mechantAudioFindAccent;




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


            // if (Random.Range(0, 2) < 1)
            // {
            //     // mcht = Instantiate(mechantAudio);
            //     // mcht.GetComponent<MechantAudioController>().NewStart(accents[0]);
            //     mcht = audioEasy();
                
            // }
            // else
            // {
            //     // mcht = Instantiate(mechantSynonymeEasy);
            //     mcht = audioFindAccentMode();
            // }

            mcht = SynonymesHard();

            mcht.transform.position = transform.position + new Vector3(0, Random.Range(-spawnRange, spawnRange), 0);
        }

    }

    // public Gameobject question()
    // {
    //     return Instantiate(mechantQuestion);
    // }

    public GameObject MechantEasy()
    {
        return Instantiate(mechantEasy);
    }

    public GameObject MechantHard()
    {
        return Instantiate(mechantHard);
    }


    public GameObject SynonymesEasy()
    {
        if(synonymeEasy == null)
        {
            PauseGame();
            synonymeEasy = wordManager.getSynonymesEasy();
            Transform canvas = GameObject.Find("Canvas").transform;
            GameObject popUp = Instantiate(popup, canvas);
            popup.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = synonymeEasy.mot;

            string definition = "";
            for(int i= 0; i < synonymeEasy.json.definition.Count; i++)
            {
                definition +="Definition n°" + i.ToString() + "\n"+ synonymeEasy.json.definition[i] + "\n\n";
            }
            popup.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = definition;
            popup.SetActive(true);
            Debug.Log(synonymeEasy.mot);
        }

        GameObject mcht = Instantiate(mechantSynonymeEasy);
        mcht.GetComponent<MechantSynonymeEasyController>().NewStart(synonymeEasy);
        return mcht;
    }

    public GameObject SynonymesHard()
    {
        if(synonymeHard == null)
        {
            PauseGame();
            synonymeHard = wordManager.getSynonymesHard();
            Transform canvas = GameObject.Find("Canvas").transform;
            GameObject popUp = Instantiate(popup, canvas);
            popup.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = synonymeHard.mot;

            string definition = "";
            for(int i= 0; i < synonymeHard.json.definition.Count; i++)
            {
                definition +="Definition n°" + i.ToString() + "\n"+ synonymeHard.json.definition[i] + "\n\n";
            }
            popup.transform.GetChild(1).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = definition;
            popup.SetActive(true);
            Debug.Log(synonymeHard.mot);
        }
        GameObject mcht = Instantiate(mechantSynonymeEasy);
        mcht.GetComponent<MechantSynonymeEasyController>().NewStart(synonymeHard);
        return mcht;
    }


    public GameObject audioFindAccentMode(){
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


        GameObject mcht = Instantiate(mechantAudioFindAccent);
        // Get random number between 0 and 4
        int randomIndex = UnityEngine.Random.Range(0, words.Count);
        mcht.GetComponent<MechantAudioFindAccentController>().NewStart(words[randomIndex]);
        return mcht;
    }

    public GameObject audioEasy(){
        GameObject mcht = Instantiate(mechantAudio);
        mcht.GetComponent<MechantAudioController>().NewStart(accents[3]);
        return mcht;
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

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
