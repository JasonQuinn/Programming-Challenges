{-
Problem 3
(*) Find the K'th element of a list. The first element in the list is number 1.

Example:
	* (element-at '(a b c d e) 3)
	c
	
Example in Haskell:
	Prelude> elementAt [1,2,3] 2
	2
	Prelude> elementAt "haskell" 5
	'e'
-}
removeFirstItem (_:x) = x

elementAtList x 1 = [(head x)]
elementAtList x i = elementAtList (removeFirstItem x) (i-1)

elementAt x i = head (elementAtList x i)


elementAt' x i = x !! (i-1)

main = 
	do	print (elementAt [1,2,3] 2)
		print (elementAt "haskell" 5)