import requests
import json
import random
import os.path

dirname = os.path.dirname(__file__)
path = "../Synonymes/synonymes/synonymesCommon.json"

file = os.path.join(dirname,path)

if os.path.isfile(file):
    with open(file,"rb") as syn:
        dico = json.load(syn)
else:
    print("erreur path")
    exit(0)


path = "./dico.json"

file2 = os.path.join(dirname,path)

if os.path.isfile(file2):
    with open(file2,"rb") as dict:
        dico_sortie = json.load(dict)
else:
    dico_sortie= {}




long = len(dico)

for mot in dico:
    
    url = f"https://www.dictionaryapi.com/api/v3/references/collegiate/json/{mot}?key=8a111a24-4bb6-4f3d-a6a5-8ac310d5175c" 

    r = requests.get(url, allow_redirects=True)
    json_string = json.loads(r.text)
    try:
        audio = json_string[0]["hwi"]["prs"][0]["sound"]["audio"]
        definition = json_string[0]["shortdef"]
        dico[mot] = {"definition":definition}

        print(audio)

        if audio[:3]=="bix" :
            subdirectory = "bix"

        elif audio[:3]== "gg" : 
            subdirectory = "gg"

        elif audio[0] in "123456789!_?.,;:":
            subdirectory = "number"

        else:
            subdirectory = audio[0]

        url_audio = f"https://media.merriam-webster.com/audio/prons/en/us/mp3/{subdirectory}/{audio}.mp3"
        print(url_audio)
        dico_sortie[mot] = url_audio

        # open(file2, 'w+').write(json.dumps(list))

    except:
        print("lol: ",mot)
        continue


open(file2, 'w+').write(json.dumps(dico_sortie))








