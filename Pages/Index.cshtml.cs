using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroML.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string CodeInput { get; set; }

        public string AstHtml { get; set; }

        public void OnGet()
        {
            // Optional: Initialize anything here if needed
        }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(CodeInput))
            {
                // Parse the input and generate AST
                var ast = MicroMLParser.Parse(CodeInput); // Assuming this returns an AST object
                AstHtml = AstRenderer.RenderToHtml(ast); // Assuming this converts AST to HTML
            }
        }
    }
}
