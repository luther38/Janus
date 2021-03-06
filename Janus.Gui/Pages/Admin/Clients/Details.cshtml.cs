﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janus.Domain.AppSettings;
using Janus.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Janus.Gui.Pages.Admin.NewFolder
{
    public class DetailsModel : PageModel
    {
        private JanusDbContext _context;
        private IOptions<AppSettings> _options;

        public DetailsModel(JanusDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }

        public Domain.Entities.Clients Clients { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Clients = await _context.Clients.SingleOrDefaultAsync(m => m.Pk == id);
            Clients = await _context.Clients
                .Where(x => x.TenantID == _options.Value.Debug.TenantID)
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();

            if (Clients == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
