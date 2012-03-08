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
Problem 11
(*) Modified run-length encoding.

Modify the result of problem 10 in such a way that if an element has no duplicates it is simply copied into the result list. Only elements with duplicates are transferred as (N E) lists.

Example:

* (encode-modified '(a a a a b c c a a d e e e e))
((4 A) B (2 C) (2 A) D (4 E))
Example in Haskell:

P11> encodeModified "aaaabccaadeeee"
[Multiple 4 'a',Single 'b',Multiple 2 'c',
 Multiple 2 'a',Single 'd',Multiple 4 'e']
-}
module Main (
    main
) where
import List

main = print (encodeModified  "aaaabccaadeeee")

data Encoded a = Single a | Multiple Int a
    deriving (Show)

encodeModified = map encodeItem . encode
    where
        encodeItem (1,x) = Single x
        encodeItem (i,x) = Multiple i x

encode = map getLength . group
getLength x = (length x, head x)
