-----------------------------------------------------------------------------
--
-- Module      :  Main
-- Copyright   :
-- License     :  AllRightsReserved
--
-- Maintainer  :
-- Stability   :
-- Portability :
-----------------------------------------------------------------------------
{-
Problem 7
(**) Flatten a nested list structure.

Transform a list, possibly holding lists as elements into a `flat' list by replacing each list with
its elements (recursively).

Example:

* (my-flatten '(a (b (c d) e)))
(A B C D E)
Example in Haskell:

*Main> flatten (Elem 5)
[5]
*Main> flatten (List [Elem 1, List [Elem 2, List [Elem 3, Elem 4], Elem 5]])
[1,2,3,4,5]
*Main> flatten (List [])
[]
-}


module Main (
    main
) where

main = do
    print (flatten (List [Elem 1, List [Elem 2, List [Elem 3, Elem 4], Elem 5]]))
    print (flatten (Elem 5))
    print ((flatten (List [])) ++ "")

data NestedList a = Elem a | List [NestedList a]

flatten :: NestedList a -> [a]
flatten (Elem a) = [a]
flatten (List (x:xs)) = (flatten x) ++ (flatten (List xs))
flatten (List []) = []
