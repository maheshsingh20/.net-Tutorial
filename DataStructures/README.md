# Data Structures Project

A comprehensive C# project demonstrating various data structures with both built-in .NET collections and custom implementations.

## Project Structure

```
DataStructures/
├── Collections/              # Built-in .NET Collections
│   ├── ListDemo.cs          # List<T> - Dynamic array
│   ├── DictionaryDemo.cs    # Dictionary<K,V> - Hash table
│   ├── HashSetDemo.cs       # HashSet<T> - Unique elements
│   ├── StackDemo.cs         # Stack<T> - LIFO
│   ├── QueueDemo.cs         # Queue<T> - FIFO
│   ├── LinkedListDemo.cs    # LinkedList<T> - Doubly linked
│   ├── SortedListDemo.cs    # SortedList<K,V> - Sorted by key
│   ├── SortedDictionaryDemo.cs  # SortedDictionary<K,V>
│   └── SortedSetDemo.cs     # SortedSet<T> - Unique & sorted
│
├── CustomDS/                 # Custom Implementations
│   ├── CustomStack.cs       # Custom stack with array
│   ├── CustomQueue.cs       # Custom queue with circular array
│   ├── CustomLinkedList.cs  # Custom singly linked list
│   └── BinarySearchTree.cs  # BST with traversals
│
└── Program.cs               # Main entry point
```

## Data Structures Covered

### Built-in Collections

1. **List<T>** - Dynamic array with indexing
2. **Dictionary<K,V>** - Key-value pairs (hash table)
3. **HashSet<T>** - Unique elements, no duplicates
4. **Stack<T>** - Last In First Out (LIFO)
5. **Queue<T>** - First In First Out (FIFO)
6. **LinkedList<T>** - Doubly linked list
7. **SortedList<K,V>** - Sorted by key, indexed access
8. **SortedDictionary<K,V>** - Sorted dictionary
9. **SortedSet<T>** - Unique and sorted elements

### Custom Implementations

1. **CustomStack** - Array-based stack with dynamic resizing
2. **CustomQueue** - Circular array-based queue
3. **CustomLinkedList** - Singly linked list
4. **BinarySearchTree** - BST with InOrder, PreOrder, PostOrder traversals

## How to Run

```bash
# Build the project
dotnet build

# Run the project
dotnet run
```

## Features Demonstrated

- Adding, removing, and searching elements
- Iterating through collections
- Set operations (union, intersection, difference)
- Sorting and ordering
- Custom implementations with dynamic resizing
- Tree traversals (InOrder, PreOrder, PostOrder)

## Learning Objectives

- Understand different data structure characteristics
- Learn when to use each data structure
- Compare built-in vs custom implementations
- Practice with generic types in C#
