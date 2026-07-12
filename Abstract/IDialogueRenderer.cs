using Systems.SimpleDialogue.Data;

namespace Systems.SimpleDialogue.Abstract
{
    /// <summary>
    ///     Presentation abstraction for rendering dialogue state.
    /// </summary>
    public interface IDialogueRenderer
    {
        void RenderDialogue(DialogueViewContext context);

        void ClearDialogue();
    }
}
