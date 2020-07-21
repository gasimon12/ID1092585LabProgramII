#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdint.h>

char* Extract(char* line, int num, char* delim)
{
    char* token;
    for (token = strtok(line, delim); token && *token; token = strtok(NULL, ("%s\n", delim)))
    {
        if (!--num)
            return token;
    }
    return NULL;
}

int Write(const char* input)
{
    FILE* file = fopen("decode.csv", "a");
    fprintf(file, input);
    fclose(file);
    return 0;
}

int main()
{
    FILE* stream = fopen("datos.csv", "r");
    remove("decode.csv");
    char line[1024];
    while (fgets(line, 1024, stream))
    {
        char* fulldate = Extract(strdup(line), 1, ",");
        int mintemp = atoi(Extract(strdup(line), 2, ","));
        int maxtemp = atoi(Extract(strdup(line), 3, ","));
        int precip = atoi(Extract(strdup(line), 4,","));
        int weatherCode = (mintemp << 14) | (maxtemp << 7) | precip;
        char* date = Extract(strdup(fulldate), 1, "T");
        char* time = Extract(strdup(fulldate), 2, "T");
        uint64_t year = atoi(Extract(strdup(date), 1, "-"));
        uint64_t month = atoi(Extract(strdup(date), 2, "-"));
        uint64_t day = atoi(Extract(strdup(date), 3, "-"));
        char* Positive = strchr(time, '+');
        int zSign;
        char* fullTime; 
        char* timeZone;
        if(Positive == NULL)
        {
            fullTime = Extract(strdup(time), 1, "-");
            timeZone = Extract(strdup(time), 2, "-");
            zSign = 0;
        }else
        {
            fullTime = Extract(strdup(time), 1, "+");
            timeZone = Extract(strdup(time), 2, "+");
            zSign = 2048;
        }
        uint64_t hour = atoi(Extract(strdup(fullTime), 1, ":"));
        uint64_t minute = atoi(Extract(strdup(fullTime), 2, ":"));
        char* fragment = Extract(strdup(fullTime), 3, ":");
        int second = atoi(Extract(strdup(fragment), 1, "."));
        int millisecond = atoi(Extract(strdup(fragment), 2, "."));
        int zHour, zMin;
        zHour = atoi(Extract(strdup(timeZone), 1, ":"));
        zMin = atoi(Extract(strdup(timeZone), 2, ":"));
        uint64_t dateTimeCode = (year << 48) | (month << 44) | (day << 39) | (hour << 34) | (minute << 28) | (second << 22) | (millisecond << 12) | zSign | (zHour << 6) | zMin;
        char output[32];
        sprintf(output, "%llu,%d\n", dateTimeCode, weatherCode);
        Write(output);
    }
}