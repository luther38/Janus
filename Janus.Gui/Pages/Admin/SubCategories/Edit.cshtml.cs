﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Domain.AppSettings;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Admin.SubCategories
{
    public class EditModel : PageModel
    {
        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public EditModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        [BindProperty]
        public Domain.Entities.SubCategories SubCategories { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Categories = await _context.Categories.SingleOrDefaultAsync(m => m.Pk == id);
            SubCategories = await _context.SubCategories
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .FirstOrDefaultAsync();

            if (SubCategories == null)
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

            _context.Attach(SubCategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!SubCategoriesExists(SubCategories.ID))
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

        private bool SubCategoriesExists(Guid id)
        {
            return _context.SubCategories.Any(e => e.ID == id);
            
        }
    }
}
