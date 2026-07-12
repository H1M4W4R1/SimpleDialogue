# SimpleDialogue

SimpleDialogue is a xNode-backed branching dialogue system. It keeps graph traversal separate from presentation so the same dialogue can be rendered as a visual novel panel, a list, a bark overlay, or a custom in-game UI.

## Setup

SimpleDialogue depends on:

- `com.github.siccity.xnode`
- `SimpleCore`
- `SimpleUI`
- `Unity.TextMeshPro`
- `Unity.ugui`

The project manifest already includes xNode through the Git URL:

```json
"com.github.siccity.xnode": "https://github.com/siccity/xNode.git"
```

If you move SimpleDialogue into another project, add xNode through Package Manager and make sure asmdefs reference `XNode`. Editor helpers additionally reference `XNodeEditor`.

## Graphs

Create a graph through `Assets > Create > Simple Dialogue > Dialogue Graph`.

The built-in nodes are:

- `DialogueEntryNode`: named graph entry point. The default entry id is `default`.
- `SimpleNPCDialogueNode`: an NPC line with answer outputs.
- `SimplePlayerDialogueNode`: a player answer with a single next output.
- `DialogueExitNode`: ends the active dialogue.
- `SubDialogueNode`: enters another graph and entry id.

Custom dialogue nodes inherit from `NPCDialogueNode`, `PlayerDialogueNode`, or `DialogueInteractionNode`. Provide text through methods, not base fields:

```csharp
protected internal override string GetSpeakerName(in DialogueContext context)
{
    return "Archivist";
}

protected internal override string GetText(in DialogueContext context)
{
    return "The gate remembers every name.";
}
```

Use `IsVisible`, `IsAvailable`, and `CanEnter` for conditions. Invisible answers are not rendered; unavailable answers are rendered disabled.

## Running Dialogue

Add `Dialogue` to a GameObject and assign a `DialogueGraph`.

```csharp
OperationResult result = DialogueAPI.Begin(dialogue);
```

To select an answer:

```csharp
DialogueOption option = dialogue.Options[0];
OperationResult result = DialogueAPI.Select(in option);
```

`Dialogue` automatically finds the first `IDialogueRenderer` on itself or inactive/active children. No renderer field is serialized on the runner.

## Renderers

Presentation is handled by `IDialogueRenderer`:

```csharp
public sealed class CustomDialogueRenderer : MonoBehaviour, IDialogueRenderer
{
    public void RenderDialogue(DialogueViewContext context)
    {
        // Render context.SpeakerName, context.Text, and context.Options.
    }

    public void ClearDialogue()
    {
        // Hide or reset the UI.
    }
}
```

The package includes `SimpleVisualNovelDialogueRenderer`, a bottom-of-screen SimpleUI panel using TextMeshPro. It uses:

- `SimpleDialogueText` for speaker/body text.
- `SimpleDialogueAnswerContainer` for answer lists.
- `SimpleDialogueAnswerOption` for answer buttons.

This renderer is intentionally just one implementation. You can replace it with a typewriter renderer, radial answers, subtitle-only renderer, or any other `IDialogueRenderer`.
