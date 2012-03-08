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

main = print( split "abcdefghik" 3)

--my way
--split list count = helper [] list count
--    where
--        helper startList list 0 = [startList]++[list]
--        helper startList (x:xs) count = helper (startList++[x]) xs (count-1)


split list count = helper list count
    where
        helper [] _ = ([], [])
        helper list 0 = ([], list)
        helper (x:xs) count = let (f,l) = helper xs (count-1) in (x:f,l)
