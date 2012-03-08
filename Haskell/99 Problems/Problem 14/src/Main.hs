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

main = print (dupli [1, 2, 3])

dupli x = foldr duplicateItem [] x
    where
        duplicateItem x [] = [x,x]
        duplicateItem x y = x:x:y

dupli' [] = []
dupli' (x:xs) = x:x:dupli' xs
