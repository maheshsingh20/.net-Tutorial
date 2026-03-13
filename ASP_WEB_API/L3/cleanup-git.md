# Git Repository Cleanup Guide

You've already pushed files that should be ignored. Follow these steps to clean up your repository:

## Step 1: Remove Cached Files from Git

Run these commands to remove tracked files that should be ignored:

```bash
# Remove all files from Git's index (but keep them locally)
git rm -r --cached .

# Add all files back, respecting .gitignore
git add .

# Commit the changes
git commit -m "Apply .gitignore and remove ignored files from repository"

# Push to remote
git push origin main
```

**Note**: Replace `main` with your branch name if different (could be `master`).

## Step 2: Verify What Will Be Removed

Before running the above commands, you can check what will be removed:

```bash
# See what files are currently tracked
git ls-files

# After running 'git rm -r --cached .', check what will be committed
git status
```

## Step 3: Alternative - Remove Specific Directories

If you want to remove specific directories only:

```bash
# Remove .NET build outputs
git rm -r --cached Level3/bin
git rm -r --cached Level3/obj
git rm -r --cached Level3/.vs

# Remove Node modules
git rm -r --cached Level3F/node_modules

# Commit and push
git add .
git commit -m "Remove build artifacts and node_modules from repository"
git push origin main
```

## Step 4: Clean Up Sensitive Files (IMPORTANT!)

If you accidentally committed sensitive files like `appsettings.json` with secrets:

```bash
# Remove the file from Git history completely
git filter-branch --force --index-filter \
  "git rm --cached --ignore-unmatch Level3/appsettings.json" \
  --prune-empty --tag-name-filter cat -- --all

# Force push (WARNING: This rewrites history!)
git push origin --force --all
```

**⚠️ WARNING**: This rewrites Git history. Only do this if:
- You exposed sensitive data (passwords, API keys, connection strings)
- You're working alone or can coordinate with your team
- You understand the implications

## Step 5: Update Secrets

If you pushed `appsettings.json` with real credentials:

1. **Change all passwords and secrets immediately**
2. Update your database connection strings
3. Generate new JWT secret keys
4. Update any API keys or tokens

## Step 6: Verify Cleanup

After cleanup, verify the repository:

```bash
# Check repository size
git count-objects -vH

# List all tracked files
git ls-files

# Ensure ignored files are not tracked
git status --ignored
```

## Quick Command Reference

```bash
# One-liner to clean up and apply .gitignore
git rm -r --cached . && git add . && git commit -m "Apply .gitignore" && git push

# Check what's being tracked
git ls-files | grep -E "(bin|obj|node_modules|\.vs)"

# See ignored files
git status --ignored
```

## What Gets Removed

Based on the .gitignore file, these will be removed from Git:

### Backend (Level3/)
- `bin/` - Build outputs
- `obj/` - Intermediate build files
- `.vs/` - Visual Studio cache
- `*.user` - User-specific settings
- `*.suo` - Solution user options

### Frontend (Level3F/)
- `node_modules/` - NPM packages (can be huge!)
- `dist/` - Build output
- `.vite/` - Vite cache
- `*.log` - Log files

## Prevention for Future

To prevent this in the future:

1. **Always create .gitignore FIRST** before `git init`
2. Use `git status` before committing to review what will be added
3. Use `git add -p` for interactive staging
4. Review commits before pushing

## Need Help?

If you encounter issues:

```bash
# Undo last commit (keep changes)
git reset --soft HEAD~1

# Undo last commit (discard changes)
git reset --hard HEAD~1

# Restore a file from last commit
git checkout HEAD -- <file>
```

---

**Remember**: After cleanup, your repository will be much smaller and cleaner!
