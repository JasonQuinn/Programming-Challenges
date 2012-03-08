import os

def isPalidrome(stringToCheck):
    for i in range(0,len(stringToCheck)-1):
        if stringToCheck[i]!=stringToCheck[len(stringToCheck)-i-1]:
            return 0
    return 1

def checkNumbers(length):
    maxNumber=""
    for i in range(length):
        maxNumber += "9"
    maxNumber=int(maxNumber)
    maxPalidrome=0
    for i1 in range(maxNumber):
        for i2 in range(maxNumber):
            multipledNumber=i1*i2
            if (multipledNumber>maxPalidrome) & isPalidrome(str(multipledNumber)):
                    maxPalidrome=multipledNumber
    return maxPalidrome

print checkNumbers(3)
os.system("pause")