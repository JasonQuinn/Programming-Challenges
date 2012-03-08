#The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
#
#Find the sum of all the primes below two million.
import os

from math import sqrt
def getPrimes (limit):
    results = [2,3,5]
    sieve = [False]*(limit+1)
    factor = int(sqrt(limit))+1
    for i in range(1,factor):
        for j in range(1, factor):
            n = 4*i**2+j**2
            if (n <= limit) and (n % 12 == 1 or n % 12 == 5):
                sieve[n] = not sieve[n]
            n = 3*i**2+j**2
            if (n <= limit) and (n % 12 == 7):
                sieve[n] = not sieve[n]
            if i>j:
                n = 3*i**2-j**2
                if (n <= limit) and (n % 12 == 11):
                    sieve[n] = not sieve[n]
    for index in range(5,factor):
        if sieve[index]:
            for jndex in range(index**2, limit, index**2):
                sieve[jndex] = False
    for index in range(7,limit):
        if sieve[index]:
            results.append(index)
    return results

def sumOfPrimes(upTo):
    return sum(getPrimes(upTo))

print sumOfPrimes(2000000)
os.system("pause")


