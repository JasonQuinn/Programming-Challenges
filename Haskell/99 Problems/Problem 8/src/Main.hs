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
Problem 8
(**) Eliminate consecutive duplicates of list elements.

If a list contains repeated elements they should be replaced with a single copy of the element. The order of the elements should not be changed.

Example:

* (compress '(a a a a b c c a a d e e e e))
(A B C A D E)
Example in Haskell:

> compress ["a","a","a","a","b","c","c","a","a","d","e","e","e","e"]
["a","b","c","a","d","e"]
-}
module Main (
    main
) where
import List

main = print (compress' ["a","a","a","a","b","c","c","a","a","d","e","e","e","e"])

compress x = (nub x)

compress' x = map head (group x)
