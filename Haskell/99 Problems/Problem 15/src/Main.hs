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

main = print (repli "abc" 3)

repli x y = repliRec x y y
    where
        repliRec [] _ _ = []
        repliRec (x:xs) y 0 = repliRec (xs) y y
        repliRec (x:xs) y z = x:repliRec (x:xs) y (z-1)



--other solution
repli' xs n = concatMap (replicate n) xs
