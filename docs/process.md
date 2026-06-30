# Project Process

## Branch Naming

- Use short, project-focused branch names.
- Format: `<phase>/<topic>`.
- Examples: `week-1/foundation`, `client/unity-skeleton`, `server/backend-skeleton`.
- Avoid mixing unrelated feature, documentation, and asset work in one branch.

## Commit Message Format

- Use clear imperative messages.
- Use a scope when it improves clarity.
- Examples:
  - `Day 1: Set up week 1 project foundation`
  - `Docs: Update testing plan`
  - `Server: Add health endpoint`
- Keep each commit focused on one reviewable change.

## Pull Request Rules

- Open pull requests from focused branches.
- Include a summary, changed files, checks run, and evidence when behavior or visuals change.
- Keep unrelated cleanup out of the pull request.
- Note follow-up work instead of hiding unfinished scope.
- Do not merge work that lacks the evidence needed for its milestone claim.

## Definition Of Done

A task is done when:

- The requested scope is complete.
- Existing project work is preserved unless a change was explicitly required.
- Relevant docs are updated.
- Local checks were run and reported.
- Visual or gameplay changes have screenshots or clips when useful.
- Follow-up work is written down.
- The branch has no unrelated changes.

## Weekly Review

At the end of each week:

- Summarize what shipped.
- List what was planned but not finished.
- Review screenshots, clips, logs, diagrams, and test output.
- Record risks and decisions.
- Set the next week of priorities from evidence, not assumptions.
