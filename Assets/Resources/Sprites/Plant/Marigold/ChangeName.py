from os import path
import os
import re

d = path.dirname(__file__)
fileList = os.listdir(d)

for file in fileList:
    if(str(file).split('.')[-1] == "png"):
        sum = re.findall("\d+",str(file))[0]
        value ='_'+"{:0>2}".format(int(sum)) 
        t = str(file).replace(sum,value)
        print(t)
        os.rename(file, t)
'''
for file in fileList:
    if(str(file).split('.')[-1] == "png"):
        t = str(file).replace("__","_")
        print(t)
        os.rename(file, t)
'''
