-----------------------------------------------------------------------------
--
-- Module      :  Main
-- Copyright   :
-- License     :  AllRightsReserved
--
-- Maintainer  :
-- Stability   :
-- Portability :
--
-- |
--
-----------------------------------------------------------------------------

module Main (
    main
) where

main = print (removeAt 1 "abcd")

removeAt 0 (x:xs) = (x, xs)
removeAt i list@(x:xs)
    | i < 0 = error "i is less than 0"
    |otherwise = let (removed, remainder) = removeAt (i-1) xs in (removed, x:remainder)
