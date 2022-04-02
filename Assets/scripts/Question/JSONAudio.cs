using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;

[System.Serializable]
public class JSONAudio
{
    // "lunch": {
    //     "Irish": "/audio/Irish/lunch.mp3",
    //     "Jamaica": "/audio/Jamaica/lunch.mp3",
    //     "scot": "/audio/scot/lunch.mp3",
    //     "general": "/audio/uk/general/lunch.mp3",
    //     "Yorkshire": "/audio/uk/Yorkshire/lunch.mp3",
    //     "rp": "/audio/uk/rp/lunch.mp3",
    //     "us": "/audio/us/us/lunch.mp3",
    //     "south": "/audio/us/south/lunch.mp3"
    // },
    public string Irish;
    public string Jamaica;
    public string scot;
    public string general;
    public string Yorkshire;
    public string rp;
    public string us;
    public string south;


    public string getAccent(string accent){
        return this.GetType().GetField(accent).GetValue(this).ToString();
    }

}