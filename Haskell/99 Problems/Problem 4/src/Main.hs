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
-- |Problem 4
--(*) Find the number of elements of a list.
--
--Example in Haskell:
--
--Prelude> myLength [123, 456, 789]
--3
--Prelude> myLength "Hello, world!"
--13
--
-----------------------------------------------------------------------------

module Main (
    main
) where




main = do
        print (myLength [123, 456, 789])
        print (myLength "Hello, world!")


myLengthRec  [] i = i
myLengthRec  x i = myLengthRec (tail x) (i+1)

myLength x = (myLengthRec x 0)
