{-
Problem 2

(*) Find the last but one element of a list.
 
(Note that the Lisp transcription of this problem is incorrect.)
 
Example in Haskell:

Prelude> myButLast [1,2,3,4]
3
Prelude> myButLast ['a'..'z']
'y'
-}

myButLast :: [a] -> a
myButLast = last . init

myButLast2 [x,_]  = x
myButLast2 (_:xs) = myButLast2 xs

main = print (myButLast2 [1,2,3,4])