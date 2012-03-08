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
import List

main = print( concatMap decodeModified encodedList)

decodeModified :: Eq a => Encoded a -> [a]
decodeModified (Single a) = [a]
decodeModified (Multiple i a) = createArray (Multiple i a)
    where
        createArray (Multiple 0 a) = []
        createArray (Multiple i a) = a:createArray(Multiple (i-1) a)






data Encoded a = Single a | Multiple Int a
    deriving (Show)

encodeModified = map encodeItem . encode
    where
        encodeItem (1,x) = Single x
        encodeItem (i,x) = Multiple i x

encode = map getLength . group
getLength x = (length x, head x)

encodedList = encodeModified "aaaabccaadeeee"
