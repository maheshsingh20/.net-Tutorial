# Data Structures - Comprehensive Collection Guide

## Overview

This project provides comprehensive demonstrations of C# data structures, including both built-in collections and custom implementations. Each data structure includes practical examples, use cases, and performance characteristics.

## Project Structure

```
DataStructures/
├── Collections/
│   ├── ListDemo.cs                 # List<T> demonstrations
│   ├── DictionaryDemo.cs           # Dictionary<TKey, TValue>
│   ├── HashSetDemo.cs              # HashSet<T>
│   ├── QueueDemo.cs                # Queue<T>
│   ├── StackDemo.cs                # Stack<T>
│   ├── LinkedListDemo.cs           # LinkedList<T>
│   ├── SortedListDemo.cs           # SortedList<TKey, TValue>
│   ├── SortedSetDemo.cs            # SortedSet<T>
│   └── SortedDictionaryDemo.cs     # SortedDictionary<TKey, TValue>
├── CustomDS/
│   ├── BinarySearchTree.cs         # Custom BST implementation
│   ├── CustomLinkedList.cs         # Custom linked list
│   ├── CustomQueue.cs              # Custom queue
│   └── CustomStack.cs              # Custom stack
├── Program.cs                      # Main menu
└── README.md                       # This file
```

## Built-in Collections

### 1. List<T>

**Purpose**: Dynamic array with automatic resizing

**Key Features**:
- Random access by index
- Dynamic size
- Maintains insertion order
- Allows duplicates

**Time Complexity**:
- Access: O(1)
- Search: O(n)
- Insert at end: O(1) amortized
- Insert at position: O(n)
- Remove: O(n)

**Common Operations**:
```csharp
List<int> numbers = new List<int>();
numbers.Add(10);              // Add element
numbers.Insert(0, 5);         // Insert at index
numbers.Remove(10);           // Remove by value
numbers.RemoveAt(0);          // Remove by index
int value = numbers[0];       // Access by index
bool exists = numbers.Contains(5);  // Check existence
numbers.Sort();               // Sort in place
```

**Use Cases**:
- Storing ordered collections
- When you need index-based access
- Building dynamic arrays
- Implementing stacks/queues

### 2. Dictionary<TKey, TValue>

**Purpose**: Key-value pairs with fast lookup

**Key Features**:
- Unique keys
- Fast lookup by key
- Unordered
- No duplicate keys

**Time Complexity**:
- Access: O(1) average
- Insert: O(1) average
- Remove: O(1) average
- Search: O(1) average

**Common Operations**:
```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();
ages.Add("John", 25);         // Add key-value pair
ages["Jane"] = 30;            // Add or update
int age = ages["John"];       // Get value by key
bool exists = ages.ContainsKey("John");  // Check key
ages.Remove("John");          // Remove by key
ages.TryGetValue("Jane", out int value);  // Safe get
```

**Use Cases**:
- Caching data
- Counting occurrences
- Mapping relationships
- Configuration settings

### 3. HashSet<T>

**Purpose**: Unique elements with fast lookup

**Key Features**:
- No duplicates
- Unordered
- Fast membership testing
- Set operations (union, intersection)

**Time Complexity**:
- Add: O(1) average
- Remove: O(1) average
- Contains: O(1) average

**Common Operations**:
```csharp
HashSet<int> numbers = new HashSet<int>();
numbers.Add(10);              // Add element
numbers.Remove(10);           // Remove element
bool exists = numbers.Contains(10);  // Check existence
numbers.UnionWith(otherSet);  // Union operation
numbers.IntersectWith(otherSet);  // Intersection
```

**Use Cases**:
- Removing duplicates
- Membership testing
- Set operations
- Tracking unique items

### 4. Queue<T>

**Purpose**: First-In-First-Out (FIFO) collection

**Key Features**:
- FIFO ordering
- Add at rear, remove from front
- No random access

**Time Complexity**:
- Enqueue: O(1)
- Dequeue: O(1)
- Peek: O(1)

**Common Operations**:
```csharp
Queue<string> queue = new Queue<string>();
queue.Enqueue("First");       // Add to rear
queue.Enqueue("Second");
string first = queue.Dequeue();  // Remove from front
string peek = queue.Peek();   // View front without removing
int count = queue.Count;      // Get size
```

**Use Cases**:
- Task scheduling
- Breadth-first search
- Print queue
- Message processing

### 5. Stack<T>

**Purpose**: Last-In-First-Out (LIFO) collection

**Key Features**:
- LIFO ordering
- Add and remove from top
- No random access

**Time Complexity**:
- Push: O(1)
- Pop: O(1)
- Peek: O(1)

**Common Operations**:
```csharp
Stack<int> stack = new Stack<int>();
stack.Push(10);               // Add to top
stack.Push(20);
int top = stack.Pop();        // Remove from top
int peek = stack.Peek();      // View top without removing
int count = stack.Count;      // Get size
```

**Use Cases**:
- Undo/redo functionality
- Expression evaluation
- Depth-first search
- Function call stack

### 6. LinkedList<T>

**Purpose**: Doubly-linked list

**Key Features**:
- Efficient insertion/deletion
- No random access
- Maintains order
- Allows duplicates

**Time Complexity**:
- Access: O(n)
- Insert at position: O(1) if node known
- Remove at position: O(1) if node known
- Search: O(n)

**Common Operations**:
```csharp
LinkedList<string> list = new LinkedList<string>();
list.AddFirst("First");       // Add at beginning
list.AddLast("Last");         // Add at end
LinkedListNode<string> node = list.First;
list.AddAfter(node, "After");  // Add after node
list.Remove("First");         // Remove by value
```

**Use Cases**:
- Frequent insertions/deletions
- Implementing queues/deques
- LRU cache
- Music playlists

### 7. SortedList<TKey, TValue>

**Purpose**: Sorted key-value pairs (array-based)

**Key Features**:
- Keys sorted automatically
- Index-based access
- Less memory than SortedDictionary
- Slower insertions

**Time Complexity**:
- Access by key: O(log n)
- Access by index: O(1)
- Insert: O(n)
- Remove: O(n)

**Common Operations**:
```csharp
SortedList<int, string> list = new SortedList<int, string>();
list.Add(3, "Three");         // Add key-value
list.Add(1, "One");           // Automatically sorted
string value = list[1];       // Access by key
string first = list.Values[0];  // Access by index
```

**Use Cases**:
- Small sorted collections
- When index access needed
- Memory-constrained scenarios
- Infrequent updates

### 8. SortedSet<T>

**Purpose**: Sorted unique elements (tree-based)

**Key Features**:
- No duplicates
- Automatically sorted
- Set operations
- Efficient range queries

**Time Complexity**:
- Add: O(log n)
- Remove: O(log n)
- Contains: O(log n)

**Common Operations**:
```csharp
SortedSet<int> set = new SortedSet<int>();
set.Add(5);                   // Add element
set.Add(3);                   // Automatically sorted
set.Remove(3);                // Remove element
int min = set.Min;            // Get minimum
int max = set.Max;            // Get maximum
var range = set.GetViewBetween(2, 6);  // Range query
```

**Use Cases**:
- Maintaining sorted unique items
- Range queries
- Priority queues
- Leaderboards

### 9. SortedDictionary<TKey, TValue>

**Purpose**: Sorted key-value pairs (tree-based)

**Key Features**:
- Keys sorted automatically
- Faster insertions than SortedList
- More memory than SortedList
- No index access

**Time Complexity**:
- Access: O(log n)
- Insert: O(log n)
- Remove: O(log n)

**Common Operations**:
```csharp
SortedDictionary<int, string> dict = new SortedDictionary<int, string>();
dict.Add(3, "Three");         // Add key-value
dict.Add(1, "One");           // Automatically sorted
string value = dict[1];       // Access by key
dict.Remove(3);               // Remove by key
```

**Use Cases**:
- Frequent insertions/deletions
- Sorted key-value pairs
- Range queries by key
- Priority-based processing

## Custom Implementations

### 1. Binary Search Tree (BST)

**Purpose**: Hierarchical sorted data structure

**Key Features**:
- Left child < parent < right child
- Efficient search, insert, delete
- In-order traversal gives sorted order

**Time Complexity** (balanced):
- Search: O(log n)
- Insert: O(log n)
- Delete: O(log n)
- Traversal: O(n)

**Operations**:
```csharp
BinarySearchTree bst = new BinarySearchTree();
bst.Insert(50);
bst.Insert(30);
bst.Insert(70);
bool found = bst.Search(30);
bst.InOrderTraversal();  // 30, 50, 70
bst.Delete(30);
```

**Use Cases**:
- Implementing sorted sets
- Expression trees
- File system hierarchies
- Decision trees

### 2. Custom LinkedList

**Purpose**: Understanding linked list internals

**Key Features**:
- Node-based structure
- Dynamic size
- Efficient insertions

**Operations**:
```csharp
CustomLinkedList list = new CustomLinkedList();
list.AddFirst(10);
list.AddLast(20);
list.InsertAfter(10, 15);
list.Remove(15);
list.Display();
```

**Learning Objectives**:
- Pointer manipulation
- Node creation/deletion
- Traversal algorithms

### 3. Custom Queue

**Purpose**: Understanding FIFO implementation

**Key Features**:
- Array or linked list based
- Front and rear pointers
- Circular buffer option

**Operations**:
```csharp
CustomQueue queue = new CustomQueue();
queue.Enqueue(10);
queue.Enqueue(20);
int value = queue.Dequeue();
int front = queue.Peek();
```

**Learning Objectives**:
- FIFO logic
- Circular buffer
- Overflow/underflow handling

### 4. Custom Stack

**Purpose**: Understanding LIFO implementation

**Key Features**:
- Array or linked list based
- Top pointer
- Dynamic resizing

**Operations**:
```csharp
CustomStack stack = new CustomStack();
stack.Push(10);
stack.Push(20);
int value = stack.Pop();
int top = stack.Peek();
```

**Learning Objectives**:
- LIFO logic
- Array resizing
- Stack overflow handling

## Choosing the Right Data Structure

### Decision Tree

```
Need key-value pairs?
├─ Yes
│  ├─ Need sorted keys?
│  │  ├─ Yes
│  │  │  ├─ Frequent insertions? → SortedDictionary
│  │  │  └─ Infrequent insertions? → SortedList
│  │  └─ No → Dictionary
│  └─ No
│     ├─ Need unique values?
│     │  ├─ Yes
│     │  │  ├─ Need sorted? → SortedSet
│     │  │  └─ No → HashSet
│     │  └─ No
│     │     ├─ Need FIFO? → Queue
│     │     ├─ Need LIFO? → Stack
│     │     ├─ Need frequent insert/delete? → LinkedList
│     │     └─ Need index access? → List
```

### Performance Comparison

| Operation | List | Dictionary | HashSet | Queue | Stack | LinkedList |
|-----------|------|------------|---------|-------|-------|------------|
| Add | O(1)* | O(1) | O(1) | O(1) | O(1) | O(1) |
| Remove | O(n) | O(1) | O(1) | O(1) | O(1) | O(1)** |
| Search | O(n) | O(1) | O(1) | O(n) | O(n) | O(n) |
| Access | O(1) | O(1) | N/A | N/A | N/A | O(n) |

*Amortized  
**If node is known

## How to Run

```bash
cd DataStructures
dotnet build
dotnet run
```

### Menu Options

```
Select a data structure to demo:
1. List<T>
2. Dictionary<TKey, TValue>
3. HashSet<T>
4. Queue<T>
5. Stack<T>
6. LinkedList<T>
7. SortedList<TKey, TValue>
8. SortedSet<T>
9. SortedDictionary<TKey, TValue>
10. Binary Search Tree (Custom)
11. Custom LinkedList
12. Custom Queue
13. Custom Stack
0. Exit
```

## Practical Examples

### Example 1: Removing Duplicates

```csharp
// Using HashSet
List<int> numbers = new List<int> { 1, 2, 2, 3, 3, 4 };
HashSet<int> unique = new HashSet<int>(numbers);
// Result: { 1, 2, 3, 4 }
```

### Example 2: Counting Occurrences

```csharp
// Using Dictionary
string text = "hello world";
Dictionary<char, int> counts = new Dictionary<char, int>();
foreach (char c in text)
{
    if (counts.ContainsKey(c))
        counts[c]++;
    else
        counts[c] = 1;
}
```

### Example 3: Top K Elements

```csharp
// Using SortedDictionary
SortedDictionary<int, List<string>> scores = 
    new SortedDictionary<int, List<string>>(
        Comparer<int>.Create((a, b) => b.CompareTo(a))
    );
// Automatically sorted in descending order
```

### Example 4: LRU Cache

```csharp
// Using LinkedList + Dictionary
LinkedList<int> list = new LinkedList<int>();
Dictionary<int, LinkedListNode<int>> map = 
    new Dictionary<int, LinkedListNode<int>>();
// Fast access and reordering
```

## Common Patterns

### Pattern 1: Frequency Counter
```csharp
Dictionary<T, int> frequency = new Dictionary<T, int>();
foreach (var item in collection)
{
    frequency[item] = frequency.GetValueOrDefault(item, 0) + 1;
}
```

### Pattern 2: Two Pointers (List)
```csharp
int left = 0, right = list.Count - 1;
while (left < right)
{
    // Process
    left++;
    right--;
}
```

### Pattern 3: Sliding Window (Queue)
```csharp
Queue<int> window = new Queue<int>();
foreach (var item in collection)
{
    window.Enqueue(item);
    if (window.Count > windowSize)
        window.Dequeue();
    // Process window
}
```

## Learning Objectives

After completing this project, you should understand:

1. ✅ When to use each data structure
2. ✅ Time and space complexity
3. ✅ Trade-offs between structures
4. ✅ Implementation details
5. ✅ Common algorithms and patterns
6. ✅ Performance characteristics
7. ✅ Memory management

## Best Practices

1. **Choose the right structure** for your use case
2. **Consider performance** requirements
3. **Use generics** for type safety
4. **Initialize with capacity** when size is known
5. **Use LINQ** for complex queries
6. **Avoid premature optimization**
7. **Profile before optimizing**

## Common Mistakes

1. Using List when HashSet is better for uniqueness
2. Using Dictionary when SortedDictionary is needed
3. Not considering memory overhead
4. Ignoring time complexity
5. Using wrong collection for frequent operations

## Extension Ideas

1. Implement Trie data structure
2. Create a Graph implementation
3. Build a Heap/Priority Queue
4. Implement LRU Cache
5. Create a Bloom Filter
6. Build a Skip List
7. Implement B-Tree

## Technologies Used

- **Language**: C# 10.0
- **Framework**: .NET 10.0
- **Concepts**: Data Structures, Algorithms, Generics

---

**Project Type**: Console Application  
**Difficulty**: Beginner to Intermediate  
**Focus**: Data Structures & Algorithms  
**Estimated Time**: 5-6 hours
