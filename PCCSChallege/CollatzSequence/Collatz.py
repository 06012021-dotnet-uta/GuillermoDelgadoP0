import sys
from typing import Counter

x =[]

def collatz(number) -> int:

    if number % 2 == 0:           # Even number
        result = number // 2
    elif number % 2 == 1:         # Odd number
        result = 3 * number + 1
    
    x.append(result)
    
    if result !=1:
        # print(result)
        number = result
        return collatz(number)

    elif result == 1:
        print(x)
        count = len(x)
        x.clear()
        return count

    # while result == 1:            # It would not print the number 1 without this loop
    #     print(result) 
    #     #sys.exit(x)                # So 1 is not printed forever.

    

    # while result != 1:            # Goes through this loop until the condition in the previous one is True.
    #     print(result)
    #     number = result
    #     collatz(number)          # This makes it so collatz() is called with the number it has previously evaluated down to.
              
        
                                    # Program starts here!
                                  
try:
   
    print('Enter number A: ')
    numberA = int(input())           # ERROR! if a text string or float is input.
    a = collatz(numberA)
    print(" ")
    print("A steps: "+ str(a))
    print(" ")

    print('Enter number B: ')
    numberB = int(input())
    b = collatz(numberB)
    print(" ")
    print("B steps: " + str(b))
    print(" ")
    

except ValueError:
    print('You must enter an integer type.')

if a < b:
    print("A, was "+ str(a) +" took fewer steps than B")

if b < a:
    print("B, was " + str(b) + " took fewer steps than A")