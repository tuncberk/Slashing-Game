import numpy as np
import numpy.random
import matplotlib.pyplot as plt
import itertools

import csv
with open('AssetsUser_Play.csv') as csvfile:
    readCSV = csv.reader(csvfile, delimiter=',')
    headers = next(readCSV, None)
    playerCount = 0
    hits = []
    x_coords = []
    y_coords = []
    colors = []
    areas = []
    area = 7000
    for row in readCSV:
        
        if(row[2] == "0"):
            playerCount += 1
        if(playerCount > 1):
            break
        hit = row[5]
        x_coord = row[3]
        y_coord = row[4]

        hits.append(hit)
        x_coords.append(x_coord)
        y_coords.append(y_coord)

        if(hit == "True"):
            color = 'g'
            #area += 15
        else:
            color = 'r'
            #area += 15
        colors.append(color)
        
print(len(hits))
#lists = sorted(itertools.izip(*[x_coords, y_coords]))
new_x, new_y = zip(*sorted(zip(x_coords, y_coords)))

#plt.scatter(new_x, new_y, s=area, c=colors, alpha=0.5)
plt.scatter(x_coords, y_coords, s=area, c=colors, alpha=0.5)
plt.show()
# Create data
#x = np.random.randn(4096)
#y = np.random.randn(4096)
 
# Create heatmap
# heatmap, xedges, yedges = np.histogram2d(x, y, bins=(64,64))
# extent = [xedges[0], xedges[-1], yedges[0], yedges[-1]]
 
# Plot heatmap
# plt.clf()
# plt.title('Pythonspot.com heatmap example')
# plt.ylabel('y')
# plt.xlabel('x')
# plt.imshow(heatmap, extent=extent)
# plt.show()