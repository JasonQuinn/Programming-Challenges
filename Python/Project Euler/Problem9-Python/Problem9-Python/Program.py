#A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
#
#a^2 + b^2 = c^2
#For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
#
#There exists exactly one Pythagorean triplet for which a + b + c = 1000.
#Find the product abc.
import os
import math
def isPythagoreanTriplet(a, b, c):
    return math.pow(a, 2) + math.pow(b, 2) == math.pow(c, 2)

def findTriplet():
    for a in range(1, 1000):
        for b in range(a + 1, 1000):
            if a + b < 1000:
                for c in range(b + 1, 1000):
                    if a + b + c == 1000:
                        if isPythagoreanTriplet(a, b, c):
                            return a * b * c

print findTriplet()
os.system("pause")