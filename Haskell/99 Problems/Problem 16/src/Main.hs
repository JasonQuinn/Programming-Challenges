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

main = print (dropEvery "abcdefghik" 3)

dropEvery list count = dropEveryHelper list count
    where
        dropEveryHelper [] _ = []
        dropEveryHelper (x:xs) i
            | i==1 = dropEveryHelper xs count
            |otherwise = x:dropEveryHelper (xs) (i-1)
