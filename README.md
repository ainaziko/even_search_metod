# Even Search method of optimization 

## Project Description
It is a software for searching solutions of optimization problems for a random allowed accuracy.


Given:
*	An analytic expression for random full mathematical function f(x);
*	An optimized specification for finding the optimized value of solving variable;
*	A structure of interface form that implements iterative method - Even Search Method.

To do:
*	Develop a softfare for searching solutions of optimization problems for a random allowed accuracy;
*	Write a code for searching a solution of problems for a random given allowed accuracccy
*	Prove that the optimized solution with accuracy not more than allowed accuracy is found 

## Problem 1: 
Find the minimum of f(x) = (x – 4)^2, where initial given point is X = -3 and Tol = 1E-2
### Solution:
<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/1.png" width=800>

## Problem 2
Find the maximum of function f(x) = (x – 4)^2, where initial point is X = -3 and Tol = 1e-2
If user clicks "ДА" Excel file with full solution will be created and opened.
### Solution:
<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/2.png" width=800>

## Problem 3
Check the case when input values are incorrect.
### Solution:
<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/3.png" width=800>


## Problem 4
f(x) = x^3 + x^2 - x + 1, where X = -2 and Tol = 1e-2. Find the maximum.
If the solution is not found in a given amount of iterations, message should appear.
### Solution:
<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/4.png" width=800>

If user clicks on "ДА" the current value of iteration(max) will be multiplied by2

<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/5.png" width=800>

## Problem 5
If user chooses x0 by the right side of optimal point then it is exceptional situation. In this case user will be notified that method has implemented 0 iterations and proposes to check the graph of function.
### Solution:
<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/6.png" width=800>

After clicking on "ДА" excel file with solution will be generated

<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/7.png" width=800>

After it user choses the value "a" so that it will be by the left side of optimal point. Then user must save the changes and close the excel file (MUST)

<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/8.png" width=800>

After closing the excel file user can click on «Получить значение x0 и Tol с excel файла» and paste the value in TextBox1(X0) and TextBox1(Tol)

<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/9.png" width=800>

After clicking on «Вычислить» twice the program with correct data finds the solution!

<img src="https://github.com/ainaziko/even_search_metod/blob/main/screenshots/10.png" width=800>

