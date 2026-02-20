# TopBrains - Coding Challenges Collection

A comprehensive collection of coding challenges and algorithmic problems covering strings, arrays, collections, and advanced algorithms.

## 📋 Project Overview

TopBrains contains 28 coding challenges organized by difficulty and topic. Each question is implemented as a separate class with static methods for easy testing and reusability.

## 🎯 Question Categories

### String Manipulation (Questions 1-3, 11)
- Word comparison and cleanup
- String transformations
- Character analysis
- Inventory name cleanup

### Arrays & Collections (Questions 4-10)
- Array operations and sorting
- List manipulation
- Collection processing
- Merge sorted arrays
- Data structure implementations

### Algorithms (Questions 12-15)
- Sum calculations with conditions
- GCD (Greatest Common Divisor)
- Mathematical operations
- Pattern matching

### Advanced Problems (Questions 16-26, 56-57)
- Complex algorithmic challenges
- Advanced data structures
- Optimization problems

## 📁 Project Structure

```
TopBrains/
├── Questions/
│   ├── Question1.cs        # Word comparison
│   ├── Question2.cs        # String operations
│   ├── Question3.cs        # Character analysis
│   ├── Question4.cs        # Array operations
│   ├── Question5.cs        # List manipulation
│   ├── Question6.cs        # Array sorting
│   ├── Question7.cs        # Collection processing
│   ├── Question8.cs        # Array algorithms
│   ├── Question9.cs        # Data structures
│   ├── Question10.cs       # Merge sorted arrays
│   ├── Question11.cs       # Inventory cleanup
│   ├── Question12.cs       # Sum positive until zero
│   ├── Question13.cs       # GCD calculation
│   ├── Question14-26.cs    # Various challenges
│   ├── Question56.cs       # Advanced problem 1
│   └── Question57.cs       # Advanced problem 2
├── Program.cs              # Interactive menu system
├── TopBrains.csproj        # Project file
└── README.md              # This file
```

## 🚀 Running the Project

### Build
```bash
cd TopBrains
dotnet build
```

### Run
```bash
dotnet run
```

### Interactive Menu
The program provides an interactive menu to select and run any question:

```
╔════════════════════════════════════════════╗
║       TopBrains - Coding Challenges        ║
╚════════════════════════════════════════════╝

Select a question to run (1-26, 56-57) or 0 to exit:

String Manipulation:
  1.  Word Comparison & Cleanup
  2.  String Operations
  3.  Character Analysis

Arrays & Collections:
  4.  Array Operations
  5.  List Manipulation
  6.  Merge Sorted Arrays
  ...

Enter your choice:
```

## 📚 Featured Questions

### Question 1: Word Comparison & Cleanup
**Problem**: Process two words by removing common consonants and consecutive duplicates.

**Example**:
```csharp
string result = Question1.Solve("hello", "world");
// Processes words through multiple transformation steps
```

---

### Question 10: Merge Sorted Arrays
**Problem**: Merge two sorted arrays into one sorted array.

**Example**:
```csharp
int[] arr1 = { 1, 3, 5, 7 };
int[] arr2 = { 2, 4, 6, 8 };
int[] result = Question10.MergeSortedArrays(arr1, arr2);
// Result: [1, 2, 3, 4, 5, 6, 7, 8]
```

**Algorithm**: Two-pointer technique
- Time Complexity: O(n + m)
- Space Complexity: O(n + m)

---

### Question 11: Inventory Name Cleanup
**Problem**: Clean up product names by removing consecutive duplicates and special characters.

**Example**:
```csharp
string result = Question11.CleanupInventoryName("Heelllo  Worrld!!!");
// Result: "Hello World"
```

**Steps**:
1. Remove consecutive duplicate characters
2. Trim whitespace
3. Remove special characters
4. Normalize spacing

---

### Question 12: Sum Positive Until Zero
**Problem**: Sum all positive numbers in an array until encountering zero.

**Example**:
```csharp
int[] nums = { 5, 10, 15, 0, 20, 25 };
int sum = Question12.SumPositiveUntilZero(nums);
// Result: 30 (stops at 0)
```

---

### Question 13: GCD Calculation
**Problem**: Calculate Greatest Common Divisor using Euclidean algorithm.

**Example**:
```csharp
int gcd = Question13.GCD(48, 18);
// Result: 6
```

**Algorithm**: Recursive Euclidean method
```
GCD(48, 18) = GCD(18, 12) = GCD(12, 6) = GCD(6, 0) = 6
```

## 🎓 Concepts Covered

### Data Structures
- Arrays and Lists
- Strings and StringBuilder
- Generic collections
- Custom data structures

### Algorithms
- Sorting algorithms
- Searching techniques
- Two-pointer technique
- Recursion
- String manipulation
- Mathematical algorithms

### Programming Concepts
- Generic methods
- LINQ operations
- Lambda expressions
- Extension methods
- Static utility classes

## 💡 Key Learning Points

### 1. Generic Methods
```csharp
public static T[] MergeSortedArrays<T>(T[] a, T[] b) where T : IComparable<T>
```
- Type-safe operations
- Reusable across different types
- Constraint-based programming

### 2. String Manipulation
```csharp
StringBuilder sb = new StringBuilder();
// Efficient string building
```
- Use StringBuilder for multiple concatenations
- String is immutable
- Performance considerations

### 3. Algorithm Efficiency
- Time complexity analysis
- Space complexity considerations
- Optimization techniques

### 4. Two-Pointer Technique
```csharp
int i = 0, j = 0;
while (i < arr1.Length && j < arr2.Length)
{
    // Compare and merge
}
```
- Efficient for sorted arrays
- O(n) time complexity
- Common in merge operations

## 🧪 Testing

Each question can be tested individually through the menu system:

```bash
# Run the program
dotnet run

# Select question number
Enter your choice: 10

# View results
Array 1: [1, 3, 5, 7]
Array 2: [2, 4, 6, 8]
Merged:  [1, 2, 3, 4, 5, 6, 7, 8]
```

## 🔧 Extending the Project

### Adding New Questions

1. Create new question file:
```csharp
// Questions/Question28.cs
using System;

namespace TopBrains.Questions
{
    public class Question28
    {
        public static void Solve()
        {
            // Your implementation
        }
    }
}
```

2. Add demo method in Program.cs:
```csharp
static void Question28Demo()
{
    Console.WriteLine("Question 28 Demo");
    Question28.Solve();
}
```

3. Add menu option in switch statement

## 📊 Difficulty Levels

| Questions | Difficulty | Topics |
|-----------|-----------|--------|
| 1-5 | Easy | Basic string/array operations |
| 6-10 | Easy-Medium | Sorting, merging |
| 11-15 | Medium | String algorithms, recursion |
| 16-20 | Medium | Advanced algorithms |
| 21-26 | Medium-Hard | Complex problems |
| 56-57 | Hard | Advanced challenges |

## 🎯 Use Cases

### Educational
- Learning algorithms and data structures
- Practicing problem-solving
- Interview preparation
- Code kata practice

### Professional
- Algorithm reference
- Code examples
- Pattern library
- Quick prototyping

## 📈 Progress Tracking

Track your progress through the challenges:

- [ ] Questions 1-5 (Basics)
- [ ] Questions 6-10 (Arrays)
- [ ] Questions 11-15 (Algorithms)
- [ ] Questions 16-20 (Intermediate)
- [ ] Questions 21-26 (Advanced)
- [ ] Questions 56-57 (Expert)

## 🔍 Common Patterns

### Pattern 1: Two-Pointer
Used in: Question 10 (Merge Arrays)
```csharp
int i = 0, j = 0;
while (i < arr1.Length && j < arr2.Length)
{
    if (arr1[i] <= arr2[j])
        result[k++] = arr1[i++];
    else
        result[k++] = arr2[j++];
}
```

### Pattern 2: StringBuilder for Strings
Used in: Question 11 (Cleanup)
```csharp
StringBuilder sb = new StringBuilder();
foreach (char c in input)
{
    if (condition)
        sb.Append(c);
}
return sb.ToString();
```

### Pattern 3: Recursion
Used in: Question 13 (GCD)
```csharp
public static int GCD(int a, int b)
{
    if (b == 0) return a;
    return GCD(b, a % b);
}
```

## 🛠️ Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **IDE**: Visual Studio 2022
- **Platform**: Cross-platform

## 📝 Best Practices

1. **Code Organization**
   - One question per file
   - Static methods for utility functions
   - Clear naming conventions

2. **Performance**
   - Use appropriate data structures
   - Consider time/space complexity
   - Optimize when necessary

3. **Testing**
   - Test with edge cases
   - Validate inputs
   - Handle exceptions

4. **Documentation**
   - Comment complex algorithms
   - Explain time complexity
   - Provide examples

## 🤝 Contributing

This is a learning repository. Feel free to:
- Add new questions
- Optimize existing solutions
- Improve documentation
- Share alternative approaches

## 📄 License

Educational purposes only.

## 👤 Author

Created as part of coding practice and algorithm learning.

---

**Last Updated**: February 19, 2026  
**Total Questions**: 28  
**.NET Version**: 10.0  
**C# Version**: 10.0

## 🎉 Happy Coding!

Practice makes perfect. Work through these challenges to improve your algorithmic thinking and coding skills!
