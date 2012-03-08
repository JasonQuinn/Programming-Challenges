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

main=print(rotate ['a','b','c','d','e','f','g','h'] (-2))

rotate list@(x:xs) count
    | count == 0 = list
    | count > 0 = rotate (xs++[x]) (count - 1)
    | count < 0 = reverse (rotate (reverse list) (count * (-1)))

