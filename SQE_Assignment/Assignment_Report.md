# SQE Assignment 1: Final Report Data

## 1. MC/DC Truth Table
**Logic**: `(IsProcessed && TotalAmount > 1000) || (!IsProcessed && TotalAmount < 0)`

| Case | IsProcessed (A) | TotalAmount > 1000 (B) | TotalAmount < 0 (C) | Outcome | Independence Proof |
|------|-----------------|-------------------------|----------------------|---------|---------------------|
| 1    | True            | True                    | X                    | **True**    | Proves A, B         |
| 2    | True            | False                   | X                    | **False**   | Proves B            |
| 3    | False           | X                       | True                 | **True**    | Proves A, C         |
| 4    | False           | X                       | False                | **False**   | Proves C            |

**Note**: X denotes "don't care" (short-circuiting).

## 2. Binary Search Control Flow Graph (CFG)
**Nodes:**
- **N1**: Start & Initialize `left = 0`, `right = length - 1`.
- **N2**: Loop Condition: `while (left <= right)`.
- **N3**: Compute `mid = left + (right - left) / 2`.
- **N4**: Decision: `if (arr[mid] == target)`.
- **N5**: Action: Return `mid` (Found).
- **N6**: Decision: `if (arr[mid] < target)`.
- **N7**: Action: `left = mid + 1`.
- **N8**: Action: `right = mid - 1`.
- **N9**: Action: Return `-1` (Not Found).
- **N10**: End.

**Edges:**
- **E1**: N1 → N2 (Initial entry)
- **E2**: N2 → N3 (Condition True)
- **E3**: N2 → N9 (Condition False)
- **E4**: N3 → N4 (Check mid)
- **E5**: N4 → N5 (Found: True)
- **E6**: N4 → N6 (Found: False)
- **E7**: N5 → N10 (Finish)
- **E8**: N6 → N7 (Go Right: True)
- **E9**: N6 → N8 (Go Left: False)
- **E10**: N7 → N2 (Repeat loop)
- **E11**: N8 → N2 (Repeat loop)
- **E12**: N9 → N10 (Finish)

## 4. Folder Fix (Action Required)
If your GitHub Actions tab is empty, it is likely because the folder is named incorrectly. Run this exact command in your terminal within the project directory to fix it:
`Rename-Item -Path "SQE.github" -NewName ".github"`

## 5. Green Tick Verification (Automation)
To verify that your automation is working correctly:
1. **Push Code**: After renaming the folder and committing your changes, push them to GitHub.
2. **Actions Tab**: Go to your repository on GitHub and click the **Actions** tab.
3. **Check Status**: You should see a workflow run in progress. Once it finishes, a **Green Checkmark (✅)** will appear next to the commit hash if all tests pass. This proves that your MSTest suite and CI/CD pipeline are functioning perfectly.
