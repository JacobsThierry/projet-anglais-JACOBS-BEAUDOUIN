import requests
import json
import random
import os.path


if os.path.isfile('./synonymes/synonymesCommon.json'):
    with open('./synonymes/synonymesCommon.json',"rb") as syn:
        dico = json.load(syn)
else:
    dico = {}


with open("./commonWords.json","rb") as words:
    json_words = json.load(words)

long = len(json_words)

for i in range(100):
    mot = json_words[random.randint(0,long-1)]
    while(mot in dico):
        mot = json_words[random.randint(0,long-1)]

    
    url = f"https://dictionaryapi.com/api/v3/references/thesaurus/json/{mot}?key=735f8927-d471-46ef-985c-156e7d93280a" 
    r = requests.get(url, allow_redirects=True)
    json_string = json.loads(r.text)
    try:
        synonyms = json_string[0]["meta"]["syns"]
        definition = json_string[0]["shortdef"]
        dico[mot] = {"synonyms":synonyms,"definition":definition}
    except:
        try: 
            url = f"https://www.dictionaryapi.com/api/v3/references/collegiate/json/{mot}?key=8a111a24-4bb6-4f3d-a6a5-8ac310d5175c" 
            r = requests.get(url, allow_redirects=True)
            json_def = json.loads(r.text)
            synonyms = json_string[0]["meta"]["syns"]
            definition = json_def[0]["shortdef"]
            dico[mot] = {"synonyms":synonyms,"definition":definition}
        except:
            continue
    


open(f'./synonymes/synonymesCommon.json', 'w+').write(json.dumps(dico))




