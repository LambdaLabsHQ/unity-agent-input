using LambdaLabs.UnityRepl.Editor;
using UnityEditor;

namespace LambdaLabs.UnityAgentInput
{
    [InitializeOnLoad]
    internal static class InputRegistrar
    {
        const string k_Description =
#if UNITY_AGENT_INPUT_HAS_INPUT_SYSTEM
            "Keyboard and mouse input simulation (PressKey, SetMousePosition, ClearAllInput). Requires Play Mode.";
#else
            "Input simulation — unavailable because com.unity.inputsystem is not installed.";
#endif

        const string k_Doc =
#if UNITY_AGENT_INPUT_HAS_INPUT_SYSTEM
@"## Input Simulation (com.lambda-labs.unity-agent-input)
Requires: com.unity.inputsystem >= 1.0.0. Must be in Play Mode.

| Method | Description |
|--------|-------------|
| `LambdaLabs.UnityAgentInput.InputAbility.PressKey(Key.W)` | Hold key across frames |
| `LambdaLabs.UnityAgentInput.InputAbility.ReleaseKey(Key.W)` | Release held key |
| `LambdaLabs.UnityAgentInput.InputAbility.PressMouseButton(""left"")` | Hold mouse button |
| `LambdaLabs.UnityAgentInput.InputAbility.SetMousePosition(x, y)` | Move cursor (screenshot-space, top-left origin) |
| `LambdaLabs.UnityAgentInput.InputAbility.ClearAllInput()` | Release all held inputs |";
#else
            "## Input Simulation (com.lambda-labs.unity-agent-input)\n⚠️ com.unity.inputsystem not installed — InputAbility unavailable.";
#endif

        static InputRegistrar() =>
            ReplAbilityRegistry.Register(new AbilityManifest
            {
                Name = "com.lambda-labs.unity-agent-input",
                Description = k_Description,
                Doc = k_Doc,
            });
    }
}
