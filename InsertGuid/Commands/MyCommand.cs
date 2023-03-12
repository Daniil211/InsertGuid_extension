using System.Linq;

namespace InsertGuid
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            var selection = docView.TextView.Selection.SelectedSpans.FirstOrDefault();
            if(selection != null)
            {
                docView.TextBuffer.Replace(selection, Guid.NewGuid().ToString());
            }
        }
    }
}
