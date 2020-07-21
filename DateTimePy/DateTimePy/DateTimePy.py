import csv
import re
import os

if os.path.exists('decode.csv'):
    os.remove('decode.csv')
    pass

with open('datos.csv', newline='') as csvfile:
    data = list(csv.reader(csvfile))
for line in data:
    fullDate = line[0]
    min_temp = int(line[1]) << 14
    max_temp = int(line[2]) << 7
    precipitation = int(line[3])
    weatherInfo = min_temp | max_temp | precipitation
    dateTime = re.split('[-T:.+]', fullDate)
    year = int(dateTime[0]) << 48
    month = int(dateTime[1]) << 44
    day = int(dateTime[2]) << 39
    hour = int(dateTime[3]) << 34
    minute = int(dateTime[4]) << 28
    second = int(dateTime[5]) << 22
    millisecond = int(dateTime[6]) << 12
    zHour = int(dateTime[7]) << 6
    zMin = int(dateTime[8])
    temp = fullDate.split('T')
    if "+" in temp[1]:
        zSign = 2048
    else: 
        zSign = 0
        pass
    dateTimeInfo = year | month | day | hour | minute | second | millisecond | zSign | zHour | zMin
    with open('decode.csv', "a" , newline='') as output:
        writer = csv.writer(output)
        writer.writerow([str(dateTimeInfo),str(weatherInfo)])
    pass