# String Tutorial - Comprehensive C# String Guide

A complete guide to working with strings in C#, covering everything from basics to advanced topics.

## Project Structure

```
StringTutorial/
├── Basics/              # Fundamental string concepts
├── Methods/             # String methods and operations
├── Advanced/            # Advanced string techniques
├── Immutability/        # String immutability concepts
├── RegularExpressions/  # Pattern matching with regex
├── Performance/         # Performance optimization
├── Encoding/            # String encoding and decoding
└── Exercises/           # Practice problems and solutions
```

## Topics Covered

### 1. Basics
- **String Creation**: 8 different ways to create strings
  - String literals
  - Char array constructor
  - Repeated characters
  - Empty and null strings
  - Verbatim strings
  - Interpolated strings
  - Multi-line strings
  
- **String Properties**: Essential string properties
  - Length property
  - Character indexing
  - Null and empty checks
  - Iteration methods

### 2. Methods
- **String Comparison**: 7 comparison techniques
  - Equals method
  - Case-insensitive comparison
  - == operator
  - CompareTo method
  - String.Compare
  - StartsWith/EndsWith
  - Contains method

- **String Manipulation**: 7 manipulation operations
  - Case conversion (ToUpper/ToLower)
  - Trim methods (Trim/TrimStart/TrimEnd)
  - Substring extraction
  - Replace characters/strings
  - Insert text
  - Remove text
  - Padding (PadLeft/PadRight)

- **String Searching**: 6 search methods
  - IndexOf (first occurrence)
  - LastIndexOf (last occurrence)
  - IndexOfAny (multiple characters)
  - LastIndexOfAny
  - Contains
  - Finding all occurrences

### 3. Advanced
- **StringBuilder**: Mutable string operations
  - Why use StringBuilder
  - Append/AppendLine/AppendFormat
  - Insert/Remove/Replace
  - Clear method
  - Performance comparison (1000x faster for concatenations)

- **String Formatting**: 10 formatting techniques
  - String interpolation
  - String.Format
  - Composite formatting
  - Format specifiers (Currency, Fixed-point, Number, Percentage)
  - Alignment
  - Date formatting
  - Number formatting
  - Padding
  - Escape sequences
  - Verbatim strings

- **String Split and Join**: 9 split/join methods
  - Split by single character
  - Split by multiple characters
  - Split by string
  - StringSplitOptions (RemoveEmptyEntries, TrimEntries)
  - Split with count limit
  - String.Join
  - Join with numbers
  - String.Concat
  - Split lines

### 4. Immutability
- **String Immutability**: Understanding immutable strings
  - How string immutability works
  - String interning
  - String.Intern method
  - Performance impact
  - Memory allocation
  - When to use StringBuilder

### 5. Regular Expressions
- **Regex Basics**: Pattern matching fundamentals
  - IsMatch (pattern checking)
  - Match (find first)
  - Matches (find all)
  - Replace (pattern replacement)
  - Split (split by pattern)
  - Groups (capture groups)
  - Common regex patterns

- **Regex Validation**: Real-world validation
  - Email validation
  - Phone number validation
  - URL validation
  - Password strength checking
  - Credit card format validation
  - Username validation

### 6. Performance
- **Performance Comparison**: Optimization techniques
  - String concatenation vs StringBuilder
  - String.Concat vs + operator
  - String.Join vs StringBuilder
  - Comparison methods performance
  - Substring vs Span<char>
  - Best practices

### 7. Encoding
- **String Encoding**: Character encoding
  - UTF-8 encoding/decoding
  - UTF-16 encoding/decoding
  - ASCII encoding/decoding
  - Base64 encoding/decoding
  - Encoding size comparison
  - Character encoding info

### 8. Exercises
- **Common Problems**: 8 frequently encountered problems
  - Reverse a string
  - Check palindrome
  - Count vowels and consonants
  - Remove duplicate characters
  - Count word occurrences
  - Convert to title case
  - Remove all whitespace
  - Check anagram

- **Practice Problems**: 8 additional challenges
  - Find longest word
  - Count each character
  - Remove specific character
  - First non-repeating character
  - String compression
  - Check string rotation
  - Remove consecutive duplicates
  - Word frequency analysis

## Running the Tutorial

```bash
cd StringTutorial
dotnet run
```

The program presents an interactive menu where you can explore each topic.

## Key Concepts

### String Immutability
Strings in C# are immutable - once created, they cannot be changed. Any modification creates a new string object.

```csharp
string str = "Hello";
str += " World";  // Creates a NEW string object
```

### When to Use StringBuilder
Use StringBuilder when:
- Performing multiple concatenations (>5)
- Building strings in loops
- Performance is critical

```csharp
// Bad: Creates 1000 string objects
string result = "";
for (int i = 0; i < 1000; i++)
    result += "x";

// Good: Modifies internal buffer
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
    sb.Append("x");
```

### String Comparison Best Practices
```csharp
// Avoid: Creates temporary strings
if (str1.ToLower() == str2.ToLower())

// Prefer: Direct comparison
if (str1.Equals(str2, StringComparison.OrdinalIgnoreCase))
```

### Common String Operations

**Null/Empty Checks:**
```csharp
string.IsNullOrEmpty(str)        // Checks null or ""
string.IsNullOrWhiteSpace(str)   // Checks null, "", or whitespace
```

**Substring:**
```csharp
str.Substring(startIndex)           // From index to end
str.Substring(startIndex, length)   // Specific length
```

**Replace:**
```csharp
str.Replace(oldChar, newChar)       // Replace character
str.Replace(oldString, newString)   // Replace substring
```

**Split:**
```csharp
str.Split(',')                                    // Split by comma
str.Split(',', StringSplitOptions.RemoveEmptyEntries)  // Remove empty entries
```

## Performance Tips

1. Use StringBuilder for multiple concatenations
2. Use StringComparison for case-insensitive comparisons
3. Use Span<char> for substring operations when possible
4. Avoid ToLower()/ToUpper() in loops
5. Use String.Join for joining arrays
6. Cache string lengths in loops
7. Use string.Empty instead of ""
8. Consider string interning for repeated strings

## Regular Expression Patterns

```csharp
Email:      ^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$
Phone:      \d{3}-\d{3}-\d{4}
URL:        https?://[\w\.-]+
Digits:     ^\d+$
Letters:    ^[a-zA-Z]+$
Alphanumeric: ^[a-zA-Z0-9]+$
```

## Learning Path

1. Start with **Basics** to understand string creation and properties
2. Learn **Methods** for common string operations
3. Explore **Advanced** topics like StringBuilder and formatting
4. Understand **Immutability** and its performance implications
5. Master **Regular Expressions** for pattern matching
6. Study **Performance** optimization techniques
7. Learn **Encoding** for character set handling
8. Practice with **Exercises** to reinforce concepts

## Additional Resources

- Microsoft Docs: String Class
- C# Programming Guide: Strings
- Regular Expressions Quick Reference
- StringBuilder Class Documentation

## Notes

- All examples include detailed explanations
- Performance comparisons use real measurements
- Exercises include complete solutions
- Code follows C# best practices
- Examples are production-ready

## Target Framework

- .NET 10.0
- C# 13.0 features enabled
