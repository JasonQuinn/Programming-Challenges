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

{-
Problem 6
(*) Find out whether a list is a palindrome. A palindrome can be read forward or backward; e.g. (x a m a x).

Example in Haskell:

*Main> isPalindrome [1,2,3]
False
*Main> isPalindrome "madamimadam"
True
*Main> isPalindrome [1,2,4,8,16,8,4,2,1]
-}

module Main (
    main
) where

main = do
    print (isPalindrome [1,2,3])
    print (isPalindrome "madamimadam")
    print (isPalindrome [1,2,4,8,16,8,4,2,1])


isPalindrome x = (x == reverse x)
