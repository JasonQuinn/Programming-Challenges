import math
import os
import itertools

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
            
def nth(n, gen):
    i=1
    for v in gen_sieve():
         if i == n:
             return v
         i+=1

n=10001
print nth(n,gen_sieve())

os.system("pause")