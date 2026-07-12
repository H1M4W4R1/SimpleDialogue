using Systems.SimpleDialogue.Abstract;
using Systems.SimpleDialogue.Data;
using UnityEngine;

namespace Systems.SimpleDialogue.Implementations
{
    /// <summary>
    ///     Built-in player answer node with inspector-authored answer text.
    /// </summary>
    public sealed class SimplePlayerDialogueNode : PlayerDialogueNode
    {
        [SerializeField, TextArea(1, 4)] private string _text = string.Empty;

        protected internal override string GetSpeakerName(in DialogueContext context) => string.Empty;

        protected internal override string GetText(in DialogueContext context) => _text;
    }
}
