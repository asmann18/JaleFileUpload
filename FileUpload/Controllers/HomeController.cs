using FileUpload.DAL;
using FileUpload.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers;

public class HomeController : Controller
{

    private readonly IWebHostEnvironment _env;
    private readonly AppDbContext _context;

    public HomeController(IWebHostEnvironment webHostEnvironment, AppDbContext context)
    {
        _env = webHostEnvironment;
        _context = context;
    }

    public IActionResult Create()
    {

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(Service service)
    {



        if (!ModelState.IsValid)
        {
            return View();
        }


        if (service.Image.Length >2*1024*1024)
        {
            ModelState.AddModelError("Image", "File-in olcusu 2 mb dan cox olmamalidir");
            return View();
        }

        if (!service.Image.ContentType.Contains("image"))
        {
            ModelState.AddModelError("Name","File sekil formatinda olmalidir");
            return View();
        }



        string fileName = Guid.NewGuid().ToString() + service.Image.FileName;
        
        string path = _env.WebRootPath + "\\img\\"+fileName;

        string path2 = Path.Combine(_env.WebRootPath, "img", fileName);

        FileStream stream=new FileStream(path2,FileMode.Create);

        await service.Image.CopyToAsync(stream);




        service.ImagePath = fileName;


        await _context.Services.AddAsync(service);

        await _context.SaveChangesAsync();



        return Content("Ok");
    }
}
