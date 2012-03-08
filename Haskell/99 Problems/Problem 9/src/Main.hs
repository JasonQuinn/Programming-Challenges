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
Problem 9
(**) Pack consecutive duplicates of list elements into sublists. If a list contains repeated
elements they should be placed in separate sublists.

Example:

* (pack '(a a a a b c c a a d e e e e))
((A A A A) (B) (C C) (A A) (D) (E E E E))
Example in Haskell:

*Main> pack ['a', 'a', 'a', 'a', 'b', 'c', 'c', 'a',
             'a', 'd', 'e', 'e', 'e', 'e']
["aaaa","b","cc","aa","d","eeee"]
-}

module Main (
    main
) where
import List

main = print (pack ['a', 'a', 'a', 'a', 'b', 'c', 'c', 'a', 'a', 'd', 'e', 'e', 'e', 'e'])

pack :: Eq a => [a] -> [[a]]
pack a = group a
