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

main = print( slice ['a','b','c','d','e','f','g','h','i','k'] 3 7)

slice list start end = helper list start end
    where
        helper _ i j
            | i > j = []
        helper _ 1 0 = []
        helper (x:xs) 1 i = x:helper(xs) 1 (i-1)
        helper (x:xs) i j = helper(xs) (i-1) (j-1)
