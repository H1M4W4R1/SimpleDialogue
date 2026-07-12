using Systems.SimpleDialogue.Data;
using Systems.SimpleUI.Components.Abstract.Markers.Context;
using Systems.SimpleUI.Components.Lists;

namespace Systems.SimpleDialogue.UI
{
    /// <summary>
    ///     SimpleUI list renderer for current dialogue answer options.
    /// </summary>
    public sealed class SimpleDialogueAnswerContainer :
        UIListBase<DialogueOptionListContext, DialogueOption>,
        IWithLocalContext<DialogueOptionListContext>
    {
        private DialogueOptionListContext _context;

        public void SetOptions(DialogueOptionListContext context)
        {
            _context = context;
            RequestRefresh();
        }

        public bool TryGetContext(out DialogueOptionListContext context)
        {
            context = _context;
            return !ReferenceEquals(context, null);
        }
    }
}
