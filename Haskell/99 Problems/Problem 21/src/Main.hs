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

main = print (insertAt 'X' "abcd" 2)

insertAt item list 1 = item:list
insertAt item (x:xs) position
    | position < 1 = error "trying to insert before the start of the list"
    | otherwise = let result = insertAt item xs (position - 1) in x:result
