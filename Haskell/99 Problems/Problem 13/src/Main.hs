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
--Run-length encoding of a list (direct solution).
--
--Implement the so-called run-length encoding data compression method directly. I.e. don't explicitly
--create the sublists containing the duplicates, as in problem 9, but only count them. As in problem
--P11, simplify the result list by replacing the singleton lists (1 X) by X.
--
--Example:
--
--(encode-direct '(a a a a b c c a a d e e e e))
--((4 A) B (2 C) (2 A) D (4 E))
--Example in Haskell:
--
--P13> encodeDirect "aaaabccaadeeee"
--[Multiple 4 'a',Single 'b',Multiple 2 'c',
-- Multiple 2 'a',Single 'd',Multiple 4 'e']


module Main (
    main
) where
import List

main = print (encodeModified "aaaabccaadeeee")

encode' x = foldr encode [] x
    where
        encode x [] = [(1, x)]
        encode x (i@((a,b):xs))
            | x==b      =   (1+a,b):xs
            | otherwise =   (1,x):i

data Encoded a = Single a | Multiple Int a
    deriving (Show)

encodeModified = map encodeItem . encode'
    where
        encodeItem (1,x) = Single x
        encodeItem (i,x) = Multiple i x

{-
how this works
foldr encode [] [1,2,3]

1 encode (foldr encode [1,2,3] [])
1 encode (1 encode (foldr encode [2,3] []))
1 encode (1 encode (2 encode (foldr encode [3] [])))

1 encode (1 encode (2 encode [(1,3)]))
1 encode (1 encode [(1,2),(1,3)])
1 encode [(1,1),(1,2),(1,3)]
[(2,1),(1,2),(1,3)]
-}
