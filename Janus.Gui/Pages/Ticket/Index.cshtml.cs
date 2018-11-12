﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Janus.Persistence;
using Janus.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace Janus.Gui.Pages.Ticket
{
    public class IndexModel : PageModel
    {

        private JanusDbContext _context;

        //private readonly IJanusMongoDbContext _Repository;
        //private readonly IMongoCollection<Tickets> _CollectionTickets;
        //readonly IMongoCollection<Techs> _CollectionTechs;
        
        public IndexModel(JanusDbContext _context)
        {

        }

        public IList<Janus.Domain.Entities.Ticket> Items { get; set; }

        //public IList<LibModel.Data.Collections.TicketStatus> TicketStatus { get; set; }

        [BindProperty]
        public Janus.Domain.Entities.Ticket TicketInformation { get; set; }

        [BindProperty]
        public IList<Techs> Techs { get; set; }

        [BindProperty]
        public string filter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ViewMode { get; set; }

        /// <summary>
        /// Defines the location in the cookie to get filter info.
        /// </summary>
        readonly string CookieFilter = "Tickets.Index.Filter";

        public async Task OnGetAsync(string filter, string filterTicketOwner)
        {

            if (string.IsNullOrEmpty(ViewMode)) { ViewMode = "table"; }

            if (string.IsNullOrEmpty(filter))
            {
                try
                {
                    filter = Request.Cookies[CookieFilter].ToString();
                }
                catch
                {

                }
            }
            if (string.IsNullOrEmpty(filterTicketOwner))
            {
                try
                {
                    filter = Request.Cookies["Ticket.Index.FilterTicketOwner"].ToString();
                }
                catch
                {

                }
            }
            /*
            if(filter == null || filter == "*")
            {
                
                //Display All
                SetCookie("Tickets.Index.Filter", "*");

                Items = await _context.Tickets
                    .Where(x => x.ID == "Debug").ToList();

                Items = await _context.<Janus.Domain.Entities.Ticket>()
                    .Where(x => x.TenantID == "debug")
                    .ToListAsync();
            }
            else if(filter == "AllOpen")
            {
                SetCookie("Tickets.Index.Filter", "AllOpen");
                Items = await _CollectionTickets.AsQueryable<Model.Data.Collections.Tickets>()
                    .Where(x => x.TenantID == "debug")
                    .Where(x => x.StatusID != "Closed")
                    .ToListAsync();
                //Items = await _context.Tickets.Where(x => x.TicketFinished == null).ToListAsync();
            }
            */
            //TicketStatus = await _context.TicketStatus.ToListAsync();

            Techs = await _context.Techs.ToListAsync();
            //Techs = await _CollectionTechs.AsQueryable<Techs>()
                //.Where(x => x.TenantID == "debug")
                //.ToListAsync();
        }

        private async Task GetTicketItems()
        {
            //ApiTickets apiTickets = new ApiTickets()
            //{
                //ApiPath = "api/v1/Tickets",
                //BaseAddress = "http://localhost:55579"
            //};
             
            //Items = await apiTickets.GetAllItemsAsync();
            
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync()
        {

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            ////_context.Attach(TicketInformation).State = EntityState.Modified;
            //var z = await _context.Tickets
            //    .SingleOrDefaultAsync(x => x.Pk == TicketInformation.Pk);

            //if (z != null)
            //{
            //    if (TicketInformation.Status == "Resolved")
            //    {
            //        z.TicketFinished = DateTime.Now.ToString();
            //    }

            //    z.Status = TicketInformation.Status;
            //    _context.Update(z);
            //}

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TicketsInformationExists(TicketInformation.Pk))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            ////return Page();
            return Redirect($"./Tickets");
        }

        private bool TicketsInformationExists(Guid id)
        {
            //returns bool
            return _context.Tickets.Any(e => e.ID.Equals(id));

            //return _CollectionTickets.AsQueryable<Janus.Domain.Entities.Ticket>()
                //.Any(x => x.ID == id);
        }

        public void SetCookie(string key, string value)
        {
            CookieOptions cookie = new CookieOptions()
            {
                Secure = true
            };
            
            Response.Cookies.Append(key, value, cookie);
        }
    }
}