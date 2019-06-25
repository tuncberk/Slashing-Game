import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt
import os

from pandas import DataFrame

dftext = pd.read_csv('credentials.txt', sep="*", names = ['player', 'date', 'hour', 'gid'])
filepath= "Players/" +str(dftext["player"].iloc[-1]) + "/" + str(dftext["date"].iloc[-1]) + "/" + str(dftext["hour"].iloc[-1]) + "-" + str(dftext["gid"].iloc[-1])+ ".csv"
folderpath= "Players/" +str(dftext["player"].iloc[-1]) + "/" + str(dftext["date"].iloc[-1]) + "/"
print(filepath)
print(folderpath)
df = pd.read_csv(filepath, sep="*")

#Drop the first row ,
#that contain total number of spatial regions
new =df[:1] 
new_df = new.as_matrix()

leftdown =  new_df[0,1]
rightdown =  new_df[0,2]
leftup =  new_df[0,3]
rightup =  new_df[0,4]
df=df.drop(df.index[0])

#Drop last row, that contain total number of collectibles that is instantiated
i = df[(df.event_name == 'Collectibles')].index
myitem = df.loc[df['event_name'] == "Collectibles"]
lastrow = df.drop(i)
lastrowmatrix = myitem.as_matrix()


#buraya kadar dogru!!!

##totalCoin = lastrowmatrix[0,3]
##totalCrystal = lastrowmatrix[0,4]
##totalTreasure = lastrowmatrix[0,5]

#Iterate through each row and assign variable type.
#Note: astype is used to assign types
counter = 30
position = 0
my_df = pd.DataFrame()
for i, row in df.iterrows():  #i: dataframe index; row: each row in series format
    if (counter == 0):
        counter = 30
        position = position +1
    else:
        counter = counter -1
        if(row["event_result"] == "Fail"): 
            row["z_pos"] = position
            my_df = my_df.append(row, ignore_index = True)
col_names = ['LeftDown' , 'RightDown', 'LeftUp', 'RightUp']
pdheat = pd.DataFrame(columns = col_names)
ld = 0
rd = 0
lu = 0
ru = 0
counter = 0
for i, row in my_df.iterrows():  #i: dataframe index; row: each row in series format 
    if row["z_pos"] == counter + 1:
        my_dic = {'LeftDown':ld, 'RightDown':rd, 'LeftUp':lu, 'RightUp':ru}
        pdheat.loc[len(pdheat)] = my_dic
        #pdheat = pdheat.append(dataframe, ignore_index = True)
        counter = counter +1
        ld = 0
        rd = 0
        lu = 0
        ru = 0
  
    
    if row["event_name"] == "LeftDown":
        ld = ld + 1
    if row["event_name"] == "RightDown":
        rd = rd + 1 
    if row["event_name"] == "LeftUp":
        lu = lu + 1 
    if row["event_name"] == "RightUp":
        ru = ru + 1 
    

df = DataFrame(pdheat, index=list(pdheat.index.astype(float)), columns=list(pdheat.columns.astype(str)))

df = df.astype(int)
print(df)
sns_plot = sns.heatmap(df, annot=True)
fig = sns_plot.get_figure()
pathtosave =  folderpath +  str(dftext["hour"].iloc[-1]) + "-" + str(dftext["gid"].iloc[-1]) + "heat.png"

fig.savefig(pathtosave) 
print("Saved!");

    
