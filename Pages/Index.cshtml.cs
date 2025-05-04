using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroML.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string CodeInput { get; set; }

        public string AstHtml { get; set; }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(CodeInput))
            {
                var ast = MicroMLParser.Parse(CodeInput); 
                AstHtml = AstRenderer.RenderToHtml(ast);
            }
        }
    }
}
