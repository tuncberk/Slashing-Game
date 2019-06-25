# -*- coding: utf-8 -*-
"""Heatmap.ipynb

Automatically generated by Colaboratory.

Original file is located at
    https://colab.research.google.com/drive/1Axad-GOjhX8pI_Y2ZWJ5Ra9e3j24cbyL
"""

import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt

 
from pandas import DataFrame

import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt
import os

from pandas import DataFrame

# filepath= "00-46-07-1.csv"
# df = pd.read_csv(filepath)

# print(df)
dftext = pd.read_csv('credentials.txt', sep="*", names = ['player', 'date', 'hour', 'gid'])
filepath= "Players/" +str(dftext["player"].iloc[-1]) + "/" + str(dftext["date"].iloc[-1]) + "/" + str(dftext["hour"].iloc[-1]) + "-" + str(dftext["gid"].iloc[-1])+ ".csv"
folderpath= "Players/" +str(dftext["player"].iloc[-1]) + "/" + str(dftext["date"].iloc[-1]) + "/"
print(filepath)
print(folderpath)
df = pd.read_csv(filepath, sep=",")

# #Drop the first row ,
# #that contain total number of spatial regions
# new =df[:1] 
# new_df = new.as_matrix()

# leftdown =  new_df[0,1]
# rightdown =  new_df[0,2]
# leftup =  new_df[0,3]
# rightup =  new_df[0,4]
# df=df.drop(df.index[0])

# #Drop last row, that contain total number of collectibles that is instantiated
# i = df[(df.event_name == 'Collectibles')].index
# myitem = df.loc[df['event_name'] == "Collectibles"]
# lastrow = df.drop(i)
# lastrowmatrix = myitem.as_matrix()


# #buraya kadar dogru!!!

# ##totalCoin = lastrowmatrix[0,3]
# ##totalCrystal = lastrowmatrix[0,4]
# ##totalTreasure = lastrowmatrix[0,5]

# #Drop last row, that contain total number of collectibles that is instantiated
# i = df[(df.event_name == 'Collectibles')].index
# myitem = df.loc[df['event_name'] == "Collectibles"]
# lastrow = df.drop(i)
# lastrowmatrix = myitem.as_matrix()
# print(lastrowmatrix)
# totalCoin = lastrowmatrix[0,2]
# totalCrystal = lastrowmatrix[0,3]
# totalTreasure = lastrowmatrix[0,4]

#Iterate through each row and assign variable type.
#Note: astype is used to assign types
numOfRows = df.shape[0]
binNumber = int(numOfRows / 10)
print(binNumber)
counter = binNumber
position = 0
my_df = pd.DataFrame()

#CREATE NEW DATAFRAME my_df
# *group the rows of the df by binNumber 
# *assign new z_pos as position starting from 0 to ENDOFFILE
for i, row in df.iterrows():  #i: dataframe index; row: each row in series format
  if (counter == 0):
    counter = binNumber
    position = position +1
  else:
    counter = counter -1
    row["item_id"] = position
    my_df = my_df.append(row, ignore_index = True)
    
   
  
print(my_df)

col_names = ['upLeft', 'up', 'upRight', 'left', 'right', 'downLeft', 'down', 'downRight']
pdheat = pd.DataFrame(columns = col_names)
ul = 0
u = 0
ur = 0
l = 0
r = 0
dl = 0
d = 0
dr = 0

ulS = 0
uS = 0
urS = 0
lS = 0
rS = 0
dlS = 0
dS = 0
drS = 0

counter = 0

#TOTAL NUMBER OF OCCURENCES OF EVENTS
for i, row in my_df.iterrows():  #i: dataframe index; row: each row in series format 
  if row["item_id"] == counter + 1:
    if ul != 0:
      ulS = ulS/ul
    if u != 0:
      uS = uS/u
    if ur != 0:
      urS = urS/ur
    if l != 0:
      lS = lS/l
    if r != 0:
      rS = rS/r
    if dl != 0:
      dlS = dlS/dl
    if d != 0:
      dS = dS/d
    if dr != 0:
      drS = drS/dr
    my_dic = {'upLeft': ulS, 'up': uS, 'upRight': urS, 'left': lS, 'right': rS, 'downLeft': dlS, 'down': dS, 'downRight': drS}
    pdheat.loc[len(pdheat)] = my_dic
    #pdheat = pdheat.append(dataframe, ignore_index = True)
    counter = counter +1
    ul = 0
    u = 0
    ur = 0
    l = 0
    r = 0
    dl = 0
    d = 0
    dr = 0

    ulS = 0
    uS = 0
    urS = 0
    lS = 0
    rS = 0
    dlS = 0
    dS = 0
    drS = 0

  # if row["event_name"] == "RightDown" and row["event_result"] == "Success":
  #     rdS = rdS + 1
  # if row["event_name"] == "LeftDown" and row["event_result"] == "Success":
  #     ldS = ldS + 1
  # if row["event_name"] == "LeftUp" and row["event_result"] == "Success":
  #     luS = luS + 1
  # if row["event_name"] == "RightUp" and row["event_result"] == "Success":
  #     ruS = ruS + 1
  
  # if row["event_name"] == "LeftDown":
  #     ld = ld + 1
  # if row["event_name"] == "RightDown":
  #     rd = rd + 1 
  # if row["event_name"] == "LeftUp":
  #     lu = lu + 1 
  # if row["event_name"] == "RightUp":
  #     ru = ru + 1


  if row['x_coord'] == 6.3 and row['y_coord'] == 3:
    ul = ul + 1
    if row['hit'] == 1:
      ulS = ulS + 1
  elif row['x_coord'] == 7.4 and row['y_coord'] == 3:
    l = l + 1 
    if row['hit'] == 1:
      lS = lS + 1
  elif row['x_coord'] == 8.5 and row['y_coord'] == 3:
    ur = ur + 1 
    if row['hit'] == 1:
      urS = urS + 1
  elif row['x_coord'] == 6.3 and row['y_coord'] == 2:
    l = l + 1 
    if row['hit'] == 1:
      lS = lS + 1
  elif row['x_coord'] == 8.5 and row['y_coord'] == 2:
    r = r + 1 
    print(row['hit'])
    if row['hit'] == 1:
      rS = rS + 1
  elif row['x_coord'] == 6.3 and row['y_coord'] == 1:
    dl = dl + 1 
    if row['hit'] == 1:
      dlS = dlS + 1
  elif row['x_coord'] == 7.4 and row['y_coord'] == 1:
    d = d + 1 
    if row['hit'] == 1:
      dS = dS + 1
  elif row['x_coord'] == 8.5 and row['y_coord'] == 1:
    dr = dr + 1 
    if row['hit'] == 1:
      drS = drS + 1
    


print(pdheat)

df = DataFrame(pdheat, index=list(pdheat.index.astype(float)), columns=list(pdheat.columns.astype(str)))

df = df.astype(float)

sns_plot = sns.heatmap(df, annot=True)

fig = sns_plot.get_figure()
fig.savefig("output.png")