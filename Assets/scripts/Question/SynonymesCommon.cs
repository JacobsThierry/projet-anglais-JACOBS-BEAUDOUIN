
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SynonymesCommon{

        public Dictionary<string, Dictionary< string,List< List<string> > > > dico;


        public SynonymesCommon(){
                dico = new Dictionary<string, Dictionary< string,List< List<string> > > >();
        }
        public string getRandomWord(){
                System.Random rand = new System.Random();
                List<string> keyList = new List<string>(dico.Keys);
                string randomKey = keyList[rand.Next(this.dico.Count)];
                return randomKey;
        }
}