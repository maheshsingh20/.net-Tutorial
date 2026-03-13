#!/bin/bash

# Git Repository Cleanup Script
# This script removes files that should be ignored from Git tracking

echo "=========================================="
echo "Git Repository Cleanup Script"
echo "=========================================="
echo ""

# Check if we're in a git repository
if [ ! -d .git ]; then
    echo "❌ Error: Not a git repository!"
    echo "Please run this script from the root of your git repository."
    exit 1
fi

echo "📋 Current repository status:"
git status --short
echo ""

# Ask for confirmation
read -p "⚠️  This will remove cached files from Git. Continue? (y/n): " -n 1 -r
echo ""

if [[ ! $REPLY =~ ^[Yy]$ ]]; then
    echo "❌ Cleanup cancelled."
    exit 0
fi

echo ""
echo "🧹 Step 1: Removing all files from Git cache..."
git rm -r --cached .

echo ""
echo "✅ Step 2: Re-adding files (respecting .gitignore)..."
git add .

echo ""
echo "📊 Files that will be removed from repository:"
git status --short | grep "^D"

echo ""
echo "📊 New files that will be tracked:"
git status --short | grep "^A"

echo ""
read -p "👉 Ready to commit these changes? (y/n): " -n 1 -r
echo ""

if [[ $REPLY =~ ^[Yy]$ ]]; then
    echo ""
    echo "💾 Committing changes..."
    git commit -m "Apply .gitignore and remove ignored files from repository"
    
    echo ""
    echo "✅ Cleanup complete!"
    echo ""
    echo "📤 To push changes to remote, run:"
    echo "   git push origin main"
    echo ""
    echo "   (Replace 'main' with your branch name if different)"
else
    echo ""
    echo "❌ Commit cancelled. Changes are staged but not committed."
    echo "   Run 'git reset' to undo staging."
fi

echo ""
echo "=========================================="
echo "Cleanup script finished!"
echo "=========================================="
