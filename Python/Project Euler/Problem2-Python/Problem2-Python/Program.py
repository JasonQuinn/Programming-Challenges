import os
def fab(max):
    a,b=0,1
    while a<max:
        yield a
        a,b=b,a+b
        
        
def sumOfEvenFab(max):
    count=0
    for i in fab(max):
        if i%2==0:
            count+=i
    return count

print sumOfEvenFab(4000000)
os.system("pause")