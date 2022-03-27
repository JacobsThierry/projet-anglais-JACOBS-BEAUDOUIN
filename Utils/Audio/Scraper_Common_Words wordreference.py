import requests
import json
import random
import os.path
import re 

dirname = os.path.dirname(__file__)
path = "../Synonymes/synonymes/synonymesCommon.json"

file = os.path.join(dirname,path)

if os.path.isfile(file):
    with open(file,"rb") as syn:
        dico = json.load(syn)
else:
    print("erreur path")
    exit(0)


path = "./dicoWR.json"

file2 = os.path.join(dirname,path)

if os.path.isfile(file2):
    with open(file2,"rb") as dict:
        dico_sortie = json.load(dict)
else:
    dico_sortie= {}




long = len(dico)

for mot in dico:
    if os.path.isfile(os.path.join(dirname,f"./audio/us/us/{mot}.mp3")) or os.path.isfile(os.path.join(dirname,f"./audio/us/south/{mot}.mp3")) or os.path.isfile(os.path.join(dirname,f"./audio/uk/general/{mot}.mp3")):
        continue
    
    url = f"https://www.wordreference.com/enfr/{mot}" 

    r = requests.get(url)

    try:
        match = re.findall("audio\/en\/.*?mp3",r.text)
    except:
        print(f"pas trouvé pour {mot}")

    for elem in match:

        # téléchargement 
        url_audio = f"https://www.wordreference.com/{elem}"
        print(url_audio)
        match2 = re.search("(?<=audio\/en\/)([a-zA-Z]*\/)+(?=.*.mp3)",url_audio)
        path2 = os.path.join(dirname,f"./audio/{match2[0]}")
        try:
            os.makedirs(path2)
        except FileExistsError:
            # directory already exists
            pass

        request_audio = requests.get(url_audio)
        with open(f"{path2}{mot}.mp3","w+b") as f:
            f.write(request_audio.content)

        









