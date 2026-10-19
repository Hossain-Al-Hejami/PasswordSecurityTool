# Password Security Tool

A console application built with C# and .NET for checking password strength and generating random passwords.

I created this project to practise C# and explore basic password security concepts.

## Features

### Password Checker
- Checks password length and character types
- Detects commonly used passwords from a predefined list
- Estimates password entropy
- Rates passwords as weak, medium or strong
- Hides password input in the console

### Password Generator
- Generates random passwords using `RandomNumberGenerator`
- Allows custom password lengths
- Supports uppercase and lowercase letters, numbers and special characters
- Lets users choose which character types to include

## Technologies

- C#
- .NET
- Regular Expressions (Regex)
- System.Security.Cryptography

## Getting Started

Make sure the .NET SDK is installed.

Clone the repository:

```bash
git clone https://github.com/Hossain-Al-Hejami/PasswordSecurityTool.git
```

Open the project directory:

```bash
cd PasswordSecurityTool
```

Run the application:

```bash
dotnet run
```

## Example

```text
=== Password Security Tool ===

1. Check password
2. Generate password
3. Exit

Choose option: 1

Enter password: ********

Length:             8
Uppercase:          Yes
Lowercase:          Yes
Numbers:            Yes
Special chars:      No
Common password:    No
Estimated entropy:  48 bits

Score: 3/5
Result: MEDIUM
```

## What I Learned

While working on this project, I gained experience with:

- Methods, loops and conditional statements
- Handling and validating user input
- Using regular expressions
- Working with cryptographically secure random number generation
- Building interactive console applications

## Future Improvements

- Improve password strength estimation
- Add better input validation
- Expand the common password list
- Ensure generated passwords contain every selected character type

## Note

The password checker uses a basic scoring system. Its entropy estimate is based on password length and character types and does not guarantee that a password is secure.

---

Developed as a personal C# project.
