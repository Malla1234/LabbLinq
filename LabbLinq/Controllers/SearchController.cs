using LabbLinq.Data;
using LabbLinq.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LabbLinq.Controllers
{
   public class SearchController : Controller
    {

        //private readonly ApplicationDbContext context;

        //public SearchController(ApplicationDbContext _context)
        //{
        //    context = _context;
        //}

        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["CurrentFilter"] = SearchString;

        //    List<SearchViewModel> list = new List<SearchViewModel>();
        //    var items = await (from te in context.Teachers
        //                       join scc in context.SchoolConnections on te.TeacherId equals scc.FK_TeacherId
        //                       join co in context.Courses on scc.FK_CourseId equals co.CourseId
        //                       join st in context.Students on scc.FK_StudentId equals st.StudentId
        //                       select new 
        //                       {
        //                           TeacherFirstName = te.FirstName,
        //                           TeacherLastName = te.LastName,
        //                           StudentFirstName = st.FirstName,
        //                           StudentLastName = st.LastName,
        //                           Subjects = co.Subjects
        //                       }).ToListAsync();

        //    //konvertera från anonym
        //    foreach (var item in items)
        //    {
        //        SearchViewModel listItem = new SearchViewModel();
        //        listItem.TeacherFirstName = item.TeacherFirstName;
        //        listItem.TeacherLastName = item.TeacherLastName;
        //        listItem.StudentFirstName = item.StudentFirstName;
        //        listItem.StudentLastName = item.StudentLastName;
        //        listItem.Subjects = item.Subjects;
        //        list.Add(listItem);
        //    }

        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        list = list.Where(s => s.StudentFirstName.Contains(SearchString) ||
        //                                       s.StudentLastName.Contains(SearchString) ||
        //                                       s.Subjects.Contains(SearchString) ||
        //                                       s.TeacherFirstName.Contains(SearchString) ||
        //                                       s.TeacherLastName.Contains(SearchString)).ToList();
        //    }

        //    return View(list);
        //}
        //Edit
        // GET: Search/Edit/5

        private readonly ApplicationDbContext context;

        public SearchController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index(string SearchString)
        {
            ViewData["CurrentFilter"] = SearchString;

            var items = await (from te in context.Teachers
                               join scc in context.SchoolConnections on te.TeacherId equals scc.FK_TeacherId
                               join co in context.Courses on scc.FK_CourseId equals co.CourseId
                               join st in context.Students on scc.FK_StudentId equals st.StudentId
                               select new SearchViewModel
                               {
                                   TeacherFirstName = te.FirstName,
                                   TeacherLastName = te.LastName,
                                   StudentFirstName = st.FirstName,
                                   StudentLastName = st.LastName,
                                   Subjects = co.Subjects
                               }).ToListAsync();

            if (!String.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.StudentFirstName.Contains(SearchString) ||
                                               s.StudentLastName.Contains(SearchString) ||
                                               s.Subjects.Contains(SearchString) ||
                                               s.TeacherFirstName.Contains(SearchString) ||
                                               s.TeacherLastName.Contains(SearchString)).ToList();
            }

            return View(items);
        }
        //Edit
        // GET: Search/Edit/5

        private bool SearchViewModelExists(int id)
        {
            return false; // Eftersom SearchViewModel-tabellen inte är kopplad till databasen
        }

        public async Task<IActionResult> Edit(int id, string teacherFirstName, string teacherLastName, string studentFirstName, string studentLastName, string subjects)
        {
            if (teacherFirstName == null || teacherLastName == null || studentFirstName == null || studentLastName == null || subjects == null)
            {
                return NotFound();
            }

            var searchViewModel = new SearchViewModel
            {
                TeacherFirstName = teacherFirstName,
                TeacherLastName = teacherLastName,
                StudentFirstName = studentFirstName,
                StudentLastName = studentLastName,
                Subjects = subjects
            };

            return View(searchViewModel);
        }

        // POST: Search/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string teacherFirstName, string teacherLastName, string studentFirstName, string studentLastName, string subjects, [Bind("TeacherFirstName,StudentFirstName,Subjects")] SearchViewModel searchViewModel)
        {
            if (teacherFirstName == null || teacherLastName == null || studentFirstName == null || studentLastName == null || subjects == null || teacherFirstName != searchViewModel.TeacherFirstName || teacherLastName != searchViewModel.TeacherLastName || studentFirstName != searchViewModel.StudentFirstName || studentLastName != searchViewModel.StudentLastName || subjects != searchViewModel.Subjects)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Ingen Update-metod används eftersom SearchViewModel-tabellen inte är kopplad till databasen
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Ingen konflikthantering behövs eftersom ingen databasuppdatering sker
                }
                return RedirectToAction(nameof(Index));
            }
            return View(searchViewModel);
        }


    }
}

