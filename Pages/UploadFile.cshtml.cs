using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;
namespace RazorPagesMovie.Pages
{
    public class UploadFileModel : PageModel
    {
        private IHostingEnvironment _environment;
        public UploadFileModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\assets\\posters", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
            return RedirectToPage("UploadSuccess");
        }
    }
}