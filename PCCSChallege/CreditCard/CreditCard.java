// Java:
// Create a function that takes a number as an argument and returns true if the number is a valid credit card number, false otherwise.

// Credit card numbers must be between 14-19 digits in length, and pass the Luhn test, described below:

// Remove the last digit (this is the "check digit").
// Reverse the number.
// Double the value of each digit in odd-numbered positions. If the doubled value has more than 1 digit, add the digits together (e.g. 8 x 2 = 16 ➞ 1 + 6 = 7).
// Add all digits.
// Subtract the last digit of the sum (from step 4) from 10. The result should be equal to the check digit from step 1.
// Examples
// validateCard(1234567890123456) --> false

//  Step 1: check digit = 6, num = 123456789012345
//  Step 2: num reversed = 543210987654321
//  Step 3: digit array after selective doubling: [1, 4, 6, 2, 2, 0, 9, 8, 5, 6, 1, 4, 6, 2, 2]
//  Step 4: sum = 58
//  Step 5: 10 - 8 = 2 (not equal to 6) --> false

// validateCard(1234567890123452) --> true
import java.util.*;
import java.util.Scanner;

class CreditCard{

    public static boolean ValidateCard(String number){

        if(number.length() < 14 || number.length()  > 19){

            System.out.println("Invalid input, this is not a credit card number");

        }else{

            // Creating array of string length
            char[] ch = new char[number.length()];
            int[] num = new int[number.length()];

            // Copy cahracter by character into array
            for(int i = 0; i < number.length(); i++ ){
                ch[i] = number.charAt(i);
            }

            // Convert char to int and store it in array of interger
            for(int i = 0; i < number.length(); i++ ){

                num[i] = Integer.parseInt(String.valueOf(ch[i]));
            }

            // Remove the last element and save it
            int checkDigit = num[num.length - 1];
            num = Arrays.copyOf(num,num.length - 1);

            // Reverse the numbers
            int i, t;
            for (i = 0; i < num.length / 2; i++) {
                t = num[i];
                num[i] = num[num.length - i - 1];
                num[num.length - i - 1] = t;
            }

            /* Double the value of each digit in odd-numbered positions. 
                If the doubled value has more than 1 digit, 
                add the digits together (e.g. 8 x 2 = 16 ➞ 1 + 6 = 7)*/
            int k;
            int[] arr = new int[num.length];

            // Adding the new values in the array
            for(i = 0; i < num.length; i++){

                // Check for even numbers else they are odd numbers
                if(num[i] % 2 == 0){ 

                    arr[i] = num[i];

                }else{

                    k = num[i] * 2; 
                    
                    // Check if the doubled value has more than 1 digit,
                    if(k < 10){

                        arr[i] = k;

                    }else{

                        int sum = 0;

                        // add the digits together
                        while(k != 0){
                            sum = sum + k % 10; // take the last digit
                            k = k /10;
                        }

                        arr[i] = sum;

                    }
                }
            }

            // Adding all digits
            int total = 0;
            for (int c : arr) {
                total += c;
            }

            int lastDigit = 0;

            lastDigit = lastDigit + total % 10; // save the last digit of the total
            
            int validationNumber = 10 - lastDigit; // get the value for compare with the chech digit value

            if(validationNumber == checkDigit){

                System.out.println("Validation Correct");
                return true;
            }else{
                System.out.println("Validation Incorrect");
                return false;
            }

        }

        return false;
    }

    public static void main(String args[]){

        Scanner input = new Scanner(System.in);
        System.out.println("Enter Credit Card Number....");
        
        String number = input.nextLine();
        ValidateCard(number);

        input.close();
    }

}