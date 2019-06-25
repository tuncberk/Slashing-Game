import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt


dftext = pd.read_csv('credentials.txt', sep="*", names = ['player', 'date', 'hour', 'gid'])
filepath= "Players/" +str(dftext["player"].iloc[-1]) + "/" + str(dftext["date"].iloc[-1]) + "/" + str(dftext["hour"].iloc[-1]) + "-" + str(dftext["gid"].iloc[-1])+ ".csv"
folderpath= "Players/" +str(dftext["player"].iloc[-1]) + "/" + str(dftext["date"].iloc[-1]) + "/"
df = pd.read_csv(filepath, sep=",")

# game settings
new =df[:1]  # same as df.head(10)
 # same as df.head(10)
new_df = new.as_matrix()

leftdown =  new_df[0,1]
rightdown =  new_df[0,2]
leftup =  new_df[0,3]
rightup =  new_df[0,4]
df=df.drop(df.index[0])
# game settings end
#last row
i = df[(df.event_name == 'Collectibles')].index
myitem = df.loc[df['event_name'] == "Collectibles"]
lastrow = df.drop(i)
lastrowmatrix = myitem.as_matrix()

totalCoin = lastrowmatrix[0,3]
totalCrystal = lastrowmatrix[0,4]
totalTreasure = lastrowmatrix[0,5]
#last row end

#
for i in range(0,int(leftdown)):
    arow2 =  ["Burak", "LeftDown", "Success", 0 , 0, 1] 
    df.loc[len(df)+i] = arow2   

for i in range(0,int(leftup)):
    arow2 =  ["Burak", "LeftUp", "Success", 0 , 0, 1] 
    df.loc[len(df)+i] = arow2
for i in range(0,int(rightdown)):
    arow2 =  ["Burak", "RightDown", "Success", 0 , 0, 1] 
    df.loc[len(df)+i] = arow2 
for i in range(0,int(rightup)):
    arow2 =  ["Burak", "RightUp", "Success", 0 , 0, 1] 
    df.loc[len(df)+i] = arow2  
for i in range(0,int(totalCoin)):
    arow2 =  ["Burak", "Coin", "Fail", 0 , 0, 1] 
    df.loc[len(df)+i] = arow2
for i in range(0,int(totalTreasure)):
    arow2 =  ["Burak", "Treasure", "Fail", 0 , 0, 1] 
    df.loc[len(df)+i] = arow2  
for i in range(0,int(totalCrystal)):
    arow2 =  ["Burak", "Crystal", "Fail", 0 , 0, 1] 
    df.loc[len(df)+i] = arow2      

df.sort_values(by=['event_name'])
print("Before Save!")

group_by_carrier = df.groupby(['event_name','event_result'])
print("After Figure!")
count_delays_by_carrier  = group_by_carrier.size().unstack()
pp = count_delays_by_carrier.plot(kind='barh', stacked=True, figsize=[16,6], colormap='winter')
print("After Plot!")
pathtosave =  folderpath + str(dftext["hour"].iloc[-1]) + "-" + str(dftext["gid"].iloc[-1]) + "bar.png"
fig = pp.get_figure()
fig.savefig(pathtosave)
print("Saved!")
