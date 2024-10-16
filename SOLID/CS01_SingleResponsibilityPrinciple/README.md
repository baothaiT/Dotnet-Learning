
# Explain
The Single Responsibility Principle (SRP) is one of the five SOLID principles of object-oriented programming. It states that a class should have only one reason to change, meaning it should have only one responsibility or task to perform. In simpler terms, a class should only do one thing, and everything in the class should be related to that one thing.

Let's break it down with an example in C# and explain how it works.

Problem: A class violating the SRP
Here is an example of a class that violates the SRP because it handles multiple responsibilities:

Example: [Wrong Case] From Program

Issues
Employee data management (storing employees in the database) is handled by the AddEmployee() method.
Salary calculation is done by the CalculateSalary() method.
Email sending is done by the SendEmail() method.
This class is doing too many things! If we need to change the way emails are sent, it requires modifying the Employee class. Similarly, if the salary calculation changes, we will need to change the class again.

