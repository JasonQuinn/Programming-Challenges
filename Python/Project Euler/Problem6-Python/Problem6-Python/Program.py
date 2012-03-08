import os
import math

def SumOfSquares(max):
    def square(a,b):
        return a+b*b
    return reduce(square,range(1,max+1))

def SquareOfSum(max):
    def sum(a,b):
        return a+b
    return int(math.pow(reduce(sum,range(1,max+1)),2))

max = 100
print "Sum of squares " + str(SumOfSquares(max))
print "Square of sum " + str(SquareOfSum(max))
print "Diff " + str(SquareOfSum(max)-SumOfSquares(max))
os.system("pause")