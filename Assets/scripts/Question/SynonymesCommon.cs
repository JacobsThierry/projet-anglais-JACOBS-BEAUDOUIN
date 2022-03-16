
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SynonymesCommon{

        public Dictionary<string, Dictionary< string,List< List<string> > > > dico;
        
        private int commonLen;

        public List<string> keyList;

        public SynonymesCommon(){
                dico = new Dictionary<string, Dictionary< string,List< List<string> > > >();
                commonLen = this.dico.Count;
                keyList = new List<string>(dico.Keys);
        }
        public string getRandomWord(){
                System.Random rand = new System.Random();
                string randomKey = keyList[rand.Next(commonLen)];
                return randomKey;
        }
}