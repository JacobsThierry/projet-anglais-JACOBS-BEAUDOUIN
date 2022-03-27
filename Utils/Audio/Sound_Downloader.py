import requests
import json
import random
import os.path



dirname = os.path.dirname(__file__)
path = "./dico.json"

file = os.path.join(dirname,path)
with open(file,"rb") as dict:
        dico = json.load(dict)


for mot in dico:
    request_audio = requests.get(dico[mot])
    with open(os.path.join(dirname,f"./audio/{mot}.mp3"),"w+b") as f:
        f.write(request_audio.content)

        