using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Top_Hat_App.Models;

namespace Top_Hat_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
   
    public class Admin_Cr : ControllerBase
    {
        private readonly TopHatContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Admin_Cr(TopHatContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Add_Category")]

        public async Task<ActionResult<Category>> PostCategory(Category s)
        {

           if (ModelState.IsValid)
            {
                int check = _dbContext.Categories.Where(x=>x.Name == s.Name).Count();
                if (check>0)
                {
                    return Ok("Category Already Created");
                }
                else
                {
                    _dbContext.Categories.Add(s);
                    await _dbContext.SaveChangesAsync();
                    return Ok("Category Added Successfully!");
                }
               
            }
            

            return NotFound("Internal Error");

        }


        [HttpPost("Add_Product")]

        public async Task<ActionResult<Category>> PostProduct(MenuItem s)
        {

            if (ModelState.IsValid)
            {
                int check = _dbContext.MenuItems.Where(x => x.Name == s.Name).Count();
                if (check > 0)
                {
                    return Ok("MenuItem Already Created");
                }
                else
                {
                    if (s.ImageFile1 != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(s.ImageFile1.FileName);
                        string extension = Path.GetExtension(s.ImageFile1.FileName);

                        string folder = "images_d";
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                        // Ensure the directory exists
                        string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        if (!Directory.Exists(serverFolderPath))
                        {
                            Directory.CreateDirectory(serverFolderPath);
                        }

                        string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                        using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                        {
                            await s.ImageFile1.CopyToAsync(fileStream);
                        }

                        s.Image1 = uniqueFileName;
                    }
                    else if (s.ImageFile2!=null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(s.ImageFile2.FileName);
                        string extension = Path.GetExtension(s.ImageFile2.FileName);

                        string folder = "images_d";
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                        // Ensure the directory exists
                        string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        if (!Directory.Exists(serverFolderPath))
                        {
                            Directory.CreateDirectory(serverFolderPath);
                        }

                        string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                        using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                        {
                            await s.ImageFile2.CopyToAsync(fileStream);
                        }

                        s.Image2 = uniqueFileName;

                    }
                    else if (s.ImageFile3 != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(s.ImageFile3.FileName);
                        string extension = Path.GetExtension(s.ImageFile3.FileName);

                        string folder = "images_d";
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                        // Ensure the directory exists
                        string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        if (!Directory.Exists(serverFolderPath))
                        {
                            Directory.CreateDirectory(serverFolderPath);
                        }

                        string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                        using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                        {
                            await s.ImageFile3.CopyToAsync(fileStream);
                        }

                        s.Image3 = uniqueFileName;
                    }
                    else if (s.ImageFile4 != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(s.ImageFile4.FileName);
                        string extension = Path.GetExtension(s.ImageFile4.FileName);

                        string folder = "images_d";
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                        // Ensure the directory exists
                        string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        if (!Directory.Exists(serverFolderPath))
                        {
                            Directory.CreateDirectory(serverFolderPath);
                        }

                        string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                        using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                        {
                            await s.ImageFile4.CopyToAsync(fileStream);
                        }

                        s.Image4 = uniqueFileName;
                    }
                    else if (s.ImageFile5 != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(s.ImageFile5.FileName);
                        string extension = Path.GetExtension(s.ImageFile5.FileName);

                        string folder = "images_d";
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                        // Ensure the directory exists
                        string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        if (!Directory.Exists(serverFolderPath))
                        {
                            Directory.CreateDirectory(serverFolderPath);
                        }

                        string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                        using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                        {
                            await s.ImageFile5.CopyToAsync(fileStream);
                        }

                        s.Image5 = uniqueFileName;
                    }
                    else if (s.ImageFile != null)
                    {
                        string filename = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
                        string extension = Path.GetExtension(s.ImageFile.FileName);

                        string folder = "images_d";
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                        // Ensure the directory exists
                        string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        if (!Directory.Exists(serverFolderPath))
                        {
                            Directory.CreateDirectory(serverFolderPath);
                        }

                        string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                        using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                        {
                            await s.ImageFile.CopyToAsync(fileStream);
                        }

                        s.Image = uniqueFileName;
                    }
                   
                        _dbContext.MenuItems.Add(s);
                        await _dbContext.SaveChangesAsync();
                        return Ok("MenuItem Added Successfully!");
                    
                   
                }

            }


            return NotFound("Filed to add");

        }


        [HttpPost("UpdateProductQty/{productId}/{qty}")]
        public async Task<ActionResult<MenuItem>> UpdateProductQty(int productId, int qty)
        {
            // Find the product by its ID
            var product = await _dbContext.MenuItems.FindAsync(productId);

            // Check if the product exists
            if (product == null)
            {
                return NotFound(); // Or BadRequest() depending on your requirements
            }

            // Update the product quantity
            product.Qty = qty; // Replace Quantity with your actual property

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return Ok($"Product quantity updated to {qty}");
        }


        [HttpGet("categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _dbContext.Categories.ToList();
            return Ok(categories);
        }

        // GET api/products
        [HttpGet("products")]
        public ActionResult<IEnumerable<MenuItem>> GetProducts()
        {
            var products = _dbContext.MenuItems.ToList();
            return Ok(products);
        }


        [HttpDelete("categories/{categoryId}")]
        public ActionResult DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.Find(categoryId);

            if (category == null)
            {
                return NotFound($"Category with ID {categoryId} not found");
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return NoContent(); // 204 No Content
        }

        // DELETE api/products/{productId}
        [HttpDelete("products/{productId}")]
        public ActionResult DeleteProduct(int productId)
        {
            var product = _dbContext.MenuItems.Find(productId);

            if (product == null)
            {
                return NotFound($"Product with ID {productId} not found");
            }

            _dbContext.MenuItems.Remove(product);
            _dbContext.SaveChanges();

            return NoContent(); // 204 No Content
        }


        [HttpPut("categories/{categoryId}")]
        public ActionResult UpdateCategory(int categoryId, [FromBody] Category updatedCategory)
        {
            var existingCategory = _dbContext.Categories.Find(categoryId);

            if (existingCategory == null)
            {
                return NotFound($"Category with ID {categoryId} not found");
            }

            // Update properties of the existing category
            existingCategory.Name = updatedCategory.Name;
            // Update other properties as needed

            _dbContext.SaveChanges();

            return Ok(existingCategory);
        }



        [HttpPut("UpdateProduct/{productId}")]
        public async Task<ActionResult<Category>> UpdateProduct(int productId, MenuItem updatedProduct)
        {
            // Retrieve the existing product from the database
            var existingProduct = await _dbContext.MenuItems.FindAsync(productId);

            if (existingProduct == null)
            {
                // Product with the given ID not found
                return NotFound($"Product with ID {productId} not found");
            }

            // Update properties of the existing product
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Categoryid = updatedProduct.Categoryid;
            existingProduct.Qty = updatedProduct.Qty;

            if (existingProduct.ImageFile1 != null)
            {
                string filename = Path.GetFileNameWithoutExtension(existingProduct.ImageFile1.FileName);
                string extension = Path.GetExtension(existingProduct.ImageFile1.FileName);

                string folder = "images_d";
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                // Ensure the directory exists
                string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                if (!Directory.Exists(serverFolderPath))
                {
                    Directory.CreateDirectory(serverFolderPath);
                }

                string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                {
                    await existingProduct.ImageFile1.CopyToAsync(fileStream);
                }

                existingProduct.Image1 = uniqueFileName;
            }
            else if (existingProduct.ImageFile2 != null)
            {
                string filename = Path.GetFileNameWithoutExtension(existingProduct.ImageFile2.FileName);
                string extension = Path.GetExtension(existingProduct.ImageFile2.FileName);

                string folder = "images_d";
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                // Ensure the directory exists
                string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                if (!Directory.Exists(serverFolderPath))
                {
                    Directory.CreateDirectory(serverFolderPath);
                }

                string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                {
                    await existingProduct.ImageFile2.CopyToAsync(fileStream);
                }

                existingProduct.Image2 = uniqueFileName;

            }
            else if (existingProduct.ImageFile3 != null)
            {
                string filename = Path.GetFileNameWithoutExtension(existingProduct.ImageFile3.FileName);
                string extension = Path.GetExtension(existingProduct.ImageFile3.FileName);

                string folder = "images_d";
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                // Ensure the directory exists
                string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                if (!Directory.Exists(serverFolderPath))
                {
                    Directory.CreateDirectory(serverFolderPath);
                }

                string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                {
                    await existingProduct.ImageFile3.CopyToAsync(fileStream);
                }

                existingProduct.Image3 = uniqueFileName;
            }
            else if (existingProduct.ImageFile4 != null)
            {
                string filename = Path.GetFileNameWithoutExtension(existingProduct.ImageFile4.FileName);
                string extension = Path.GetExtension(existingProduct.ImageFile4.FileName);

                string folder = "images_d";
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                // Ensure the directory exists
                string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                if (!Directory.Exists(serverFolderPath))
                {
                    Directory.CreateDirectory(serverFolderPath);
                }

                string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                {
                    await existingProduct.ImageFile4.CopyToAsync(fileStream);
                }

                existingProduct.Image4 = uniqueFileName;
            }
            else if (existingProduct.ImageFile5 != null)
            {
                string filename = Path.GetFileNameWithoutExtension(existingProduct.ImageFile5.FileName);
                string extension = Path.GetExtension(existingProduct.ImageFile5.FileName);

                string folder = "images_d";
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                // Ensure the directory exists
                string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                if (!Directory.Exists(serverFolderPath))
                {
                    Directory.CreateDirectory(serverFolderPath);
                }

                string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                {
                    await existingProduct.ImageFile5.CopyToAsync(fileStream);
                }

                existingProduct.Image5 = uniqueFileName;
            }
            else if (existingProduct.ImageFile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(existingProduct.ImageFile.FileName);
                string extension = Path.GetExtension(existingProduct.ImageFile.FileName);

                string folder = "images_d";
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename + extension;

                // Ensure the directory exists
                string serverFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                if (!Directory.Exists(serverFolderPath))
                {
                    Directory.CreateDirectory(serverFolderPath);
                }

                string serverFilePath = Path.Combine(serverFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(serverFilePath, FileMode.Create))
                {
                    await existingProduct.ImageFile.CopyToAsync(fileStream);
                }

                existingProduct.Image = uniqueFileName;
            }      // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return Ok($"Product with ID {productId} updated successfully");
        }



        [HttpGet("GetAdmin")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await _dbContext.Admins.ToListAsync();
        }

        // GET: api/Admins/5
        [HttpGet("(\"GetAdminbyid\"){id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _dbContext.Admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // POST: api/Admins
        [HttpPost("PostAdmin")]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            _dbContext.Admins.Add(admin);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id }, admin);
        }

        // PUT: api/Admins/5
        [HttpPut("(\"PutAdmin\"){id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(admin).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Admins/5
        [HttpDelete("(\"DeleteAdmin\"){id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _dbContext.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _dbContext.Admins.Remove(admin);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminExists(int id)
        {
            return _dbContext.Admins.Any(e => e.Id == id);
        }

    }
}
