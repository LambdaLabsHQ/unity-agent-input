# Unity Agent Input

Keyboard and mouse input simulation for AI agents in Unity Play Mode.

## Requirements

- Unity 2021.3+
- [com.lambda-labs.unity-repl](https://github.com/LambdaLabsHQ/unity-repl) 0.1.0+
- com.unity.inputsystem 1.0.0+ (for `InputAbility`)

## Installation

Add both packages to your project's `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.lambda-labs.unity-repl": "https://github.com/LambdaLabsHQ/unity-repl.git",
    "com.lambda-labs.unity-agent-input": "https://github.com/LambdaLabsHQ/unity-agent-input.git"
  }
}
```

## Usage from REPL

```csharp
// Must be in Play Mode
LambdaLabs.UnityAgentInput.InputAbility.PressKey(UnityEngine.InputSystem.Key.W);
// ... advance frames ...
LambdaLabs.UnityAgentInput.InputAbility.ReleaseKey(UnityEngine.InputSystem.Key.W);
LambdaLabs.UnityAgentInput.InputAbility.ClearAllInput();
```

## Why this exists

Unity's InputSystem processes the hardware event buffer each frame, which overwrites any
synthetic state injected mid-frame. `InputAbility` hooks `InputSystem.onAfterUpdate` to
re-inject held state *after* the buffer is fully processed, so synthetic inputs persist
correctly across frames.
