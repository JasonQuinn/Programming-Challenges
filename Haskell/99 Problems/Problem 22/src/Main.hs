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
--Problem 22
--Create a list containing all integers within a given range.
--
--Example:
--
-- (range 4 9)
--(4 5 6 7 8 9)
--Example in Haskell:
--
--Prelude> range 4 9
--[4,5,6,7,8,9]


module Main (
    main
) where

main = print (range 4 9)

range x y = [x..y]
