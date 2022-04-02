import requests
import json
import random
import os.path
import re 

dirname = os.path.dirname(__file__)

path = "./dicoWR.json"

file2 = os.path.join(dirname,path)
dico = {}


liste_directory = ["Irish","Jamaica","scot","uk","us"]
list_uk = ["general","rp","Yorkshire"]
list_us = ["south","us"]

for directory in liste_directory:
    path = os.path.join(dirname,f"./audio/{directory}")
    for filename in os.listdir(path):
        if filename.endswith(".mp3"):
            word = filename[:-4]
            if(word not in dico):
                dico[word] = {}
            dico[word][directory] = f"audio/{directory}" + "/" + word

        elif filename in list_uk:
            for filename2 in os.listdir(os.path.join(path,filename)):
                if filename2.endswith(".mp3"):
                    word = filename2[:-4]
                    if(word not in dico):
                        dico[word] = {}
                    dico[word][filename] = f"audio/{directory}" + "/" + filename + "/" + word
        
        elif filename in list_us:
            for filename2 in os.listdir(os.path.join(path,filename)):
                if filename2.endswith(".mp3"):
                    word = filename2[:-4]
                    if(word not in dico):
                        dico[word] = {}
                    dico[word][filename] = f"audio/{directory}" + "/" + filename + "/" + word


liste = ["Irish","Jamaica","scot"] + list_us + list_uk

for key in dico:
    for directory in liste:
        if directory not in dico[key]:
            dico[key][directory] = ""

with open(file2,"w") as dict:
    json.dump(dico,dict)

        









