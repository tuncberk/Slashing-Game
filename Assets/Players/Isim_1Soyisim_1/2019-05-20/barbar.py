import matplotlib.pyplot as plt
import numpy as np
import pandas as pd

filepath= "00-46-07-1.csv"
df = pd.read_csv(filepath)

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

for i, row in df.iterrows():  #i: dataframe index; row: each row in series format 
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

ulF = ul - ulS
uF = u - uS
urF = ur - urS
lF = l -lS
rF = r - rS
dlF = dl - dlS
dF = d - dS
drF = dr - drS

city=['UpLeft','Up','UpRight','Left','Right','DownLeft','Down','DownRight']
Gender=['Success','Fail']
pos = np.arange(len(city))
Happiness_Index_Male=[ulS,uS,urS,lS,rS,dlS,dS,drS]
Happiness_Index_Female=[ulF,uF,urF,lF,rF,dlF,dF,drF]
 
plt.bar(pos,Happiness_Index_Male,color='blue',edgecolor='black')
plt.bar(pos,Happiness_Index_Female,color='pink',edgecolor='black',bottom=Happiness_Index_Male)
plt.xticks(pos, city)
plt.xlabel('City', fontsize=16)
plt.ylabel('Total Item', fontsize=16)
plt.title('Success - Failure Chart for Areas',fontsize=18)
plt.legend(Gender,loc=2)
plt.show()