﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Janus.Gui.Pages.Admin.SubCategories
{
    public class EditModel : PageModel
    {
        private DatabaseContext _context;

        public EditModel()
        {
            _context = new DatabaseContext();
        }

        [BindProperty]
        public Model.Data.Collections.Categories Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Categories = await _context.Categories.SingleOrDefaultAsync(m => m.Pk == id);
            Categories = await _context.CategoriesCollection.AsQueryable<Model.Data.Collections.Categories>()
                .Where(x => x.TenantID == "debug")
                .Where(x => x.SubCategory == true)
                .FirstOrDefaultAsync();

            if (Categories == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(SubCategories).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!SubCategoriesExists(Categories.GUID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubCategoriesExists(string id)
        {
            //return _context.SubCategories.Any(e => e.Pk == id);
            return _context.CategoriesCollection.AsQueryable<Model.Data.Collections.Categories>()
                .Any(x => x.GUID == id);
        }
    }
}
