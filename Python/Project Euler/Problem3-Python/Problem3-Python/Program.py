import math
import os

def gen_sieve(ceiling=None):
    if ceiling is not None:
        if ceiling % 2 == 0:
            ceiling -= 1
        highest_prime = math.ceil(math.sqrt(ceiling))
    last_val = 1
    found_primes = []
    yield 2
    while ceiling is None or ceiling > last_val:
        current_val = None
        while current_val is None:
            current_val = last_val = last_val + 2
            for prime, square in found_primes:
                if current_val < square: 
                    break
                if current_val % prime == 0:
                    current_val = None
                    break
        yield current_val
        if ceiling is None or highest_prime > last_val:
            found_primes.append((current_val, current_val ** 2))

def isprime(n):
    for fac in gen_sieve(int(math.ceil(math.sqrt(n)))):
        if n % fac == 0 and n != fac:
            return fac
    return 0

def factorise(number):
    numberToTry=2
    while number!=1:
        if number%numberToTry==0:
            yield numberToTry
            number/=numberToTry
        else:
            numberToTry+=1
            
def findLargestPrimeFactor(number):
    maxFactor=0
    for f in factorise(number):
        if isprime(f)==0:
            maxFactor=f
    return maxFactor

print findLargestPrimeFactor(600851475143)
os.system("pause")