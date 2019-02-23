using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReMember.Models;

namespace ReMember.Controllers
{
    public class MembersController : Controller
    {
        private readonly ReMemberContext _context;

        public MembersController(ReMemberContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index(string firstNameSearchString, string sortOrder)
        {
            //sorting data
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "last_name" ? "last_name_desc" : "last_name";


            var members = from m in _context.Member
                          select m;

            switch(sortOrder)
            {
                case "first_name_desc":
                    members = members.OrderByDescending(s => s.MemberFirstName);
                    break;

                case "last_name_desc":
                    members = members.OrderByDescending(s => s.MemberLastName);
                    break;

                case "last_name":
                    members = members.OrderBy(s => s.MemberLastName);
                    break;

                default:
                    members = members.OrderBy(s => s.MemberFirstName);
                    break;
            }

            if (!String.IsNullOrEmpty(firstNameSearchString))
            {
                members = members.Where(s => s.MemberFirstName.Contains(firstNameSearchString));
            }

            return View(await members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MemberFirstName,MemberLastName,MemberAddress,MemberPhoneNumber")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MemberFirstName,MemberLastName,MemberAddress,MemberPhoneNumber")] Member member)
        {
            if (id != member.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.ID == id);
        }
    }
}
