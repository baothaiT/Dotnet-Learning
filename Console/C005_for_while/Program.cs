 // // Vòng lặp for
// for (int i = 8;i <=10;i++)
// {
//     Console.WriteLine("Number i = " + i);
// }

// // Ví dụ lặp với for
// int j = 10;
// for (;j <=20;) 
// {
//     Console.WriteLine("Số j = " + j);
//     j += 2;
// }


// // Ví dụ vòng lặp while
// int i = 8;
// while (i <= 10)
// {
//     Console.WriteLine("Số i = " + i);
//     i++;
// }
// // Số i = 8
// // Số i = 9
// // Số i = 10


// // Ví dụ continue, in ra số chia hết cho 3
// for (int i = 10; i <= 20; i ++ )
// {
//     if (i % 3 != 0)
//         continue;
//     Console.WriteLine("Number i = " + i);

//     Console.WriteLine("Test");
// }
// // Số i = 12
// // Số i = 15
// // Số i = 18


// Ví dụ ngắt lặp với break;
// int i = 0; 
// while (true) 
// {
//     Console.Write(" " + ++i);
//     if (i == 10)
//         break; // Thoát lặp
// }
// // 1 2 3 4 5 6 7 8 9 10



// Ref: https://www.reddit.com/r/csharp/comments/wdisul/when_to_use_a_for_loop_and_when_to_use_a_while/
// User 1:

// After 14 years of C# coding, here are my personal preferences:

// Prefer a while loop when the condition has nothing to do with a collection/array and does not require a set number of iterations.

// Prefer a foreach or a for loop whenever the loop is related to a collection or array.

// Prefer a foreach instead of a for loop whenever you don't need the indexer.

// Prefer a for loop when you want to loop over a range of times and there is no 
//collection, or when you need the indexer of the collection within the loop body.

// Prefer LINQ if you are performing a common set-based operation on a collection 
//(like getting an average of a field, grouping, or finding the first matching value).

// User 2:

// First understand that there is no requirement here, so the type of loop you choose will be dependent on the scenario and code-readability. In reality, for loops and while loops are completely interchangeable in C# but just with different syntax. But in a very general sense:

// Use a foreach loop when iterating through an array or collection (including parsing chars in a string).

// Use a for loop to iterate a specific # of times. Obviously this isn't the only way a for loop can be used, but it's usually the best option here. If the # of iterations is based on a count or a simple mathematical expression, for loops are ok to use.

// Use a while loop for more complex/longer conditions and any boolean conditions that are not just counting or straight integer logic.

// In simplest terms, always use foreach if possible on the type, use for loops when you know the # of iterations, and while loops when you don't.

// I LOVE .NET collections and try to use collections for data sets wherever possible. In practice, I use foreach loops more than all other loop types combined, because it's so freaking easy to use and the readability is the best of all of them.

// Edit: Oh I should also mention that Linq introduced another type of loop, the ForEach() method which is very similar to the jquery forEach() if you've ever used that. The Linq ForEach() works similarly to the C# foreach loop, but uses Linq syntax/lambdas, which you may find handy in certain situations.