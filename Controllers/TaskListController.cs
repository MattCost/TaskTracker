using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskApp2.Models;

namespace TaskApp2.Controllers
{
    public class TaskListController : Controller
    {
        private readonly TaskContext _context;
        protected void GenerateTaskList()
        {

            //if the TaskList is newer than the Template we can exit
            var TT_ts = _context.TaskTemplate.OrderByDescending( x=>x.DateModified).FirstOrDefault();
            var TL_ts = _context.TaskList.OrderByDescending( x=>x.DateModified).FirstOrDefault();
            if( (TT_ts != null) && (TL_ts != null) ){
                if( TL_ts.DateModified > TT_ts.DateModified)
                    return;
            }
            //Clear the task list
            //well maybe not completed tasks.
            //so this is stupid - can any template update will regen all tasks.
            //i should make it smart 
            //for any task in the list, if the parenttemplet id is gone - delete that task.
            //for every template, get all the tasks with matching ids, if template is newer - update the list
            DayOfWeek Today = DateTime.Now.DayOfWeek;
            foreach (var entity in _context.TaskList)
                _context.TaskList.Remove(entity);
            _context.SaveChanges();
    
            //process each tempate object
            foreach (var TaskObj in _context.TaskTemplate)
            {
                switch(TaskObj.RepeatFreq)
                {
                    case TaskApp2.RepeatFrequencyEnum.Daily:
                        _context.TaskList.Add(
                            new TaskInstance{
                                Name = TaskObj.Name,
                                Desc = TaskObj.Desc,
                                TemplateID = TaskObj.ID,
                                Complete = false,
                                TaskDate = DateTime.Today
                            }
                        );
                        _context.SaveChanges();
                    break;

                    case TaskApp2.RepeatFrequencyEnum.Weekends:
                        if ( (Today == DayOfWeek.Saturday) || (Today == DayOfWeek.Sunday)){
                            _context.TaskList.Add(
                            new TaskInstance{
                                Name = TaskObj.Name,
                                Desc = TaskObj.Desc,
                                TemplateID = TaskObj.ID,
                                Complete = false,
                                TaskDate = DateTime.Today
                            }
                        );
                        _context.SaveChanges();
                        }
                    break;
                    
                    case TaskApp2.RepeatFrequencyEnum.Weekdays:
                        if ( (Today != DayOfWeek.Saturday) && (Today != DayOfWeek.Sunday)){
                            _context.TaskList.Add(
                            new TaskInstance{
                                Name = TaskObj.Name,
                                Desc = TaskObj.Desc,
                                TemplateID = TaskObj.ID,
                                Complete = false,
                                TaskDate = DateTime.Today
                                }
                            );
                            _context.SaveChanges();
                        }
                    break;

                    case TaskApp2.RepeatFrequencyEnum.Weekly:
                        if ( Today == TaskObj.SelectedDay) {
                            _context.TaskList.Add(
                            new TaskInstance{
                                Name = TaskObj.Name,
                                Desc = TaskObj.Desc,
                                TemplateID = TaskObj.ID,
                                Complete = false,
                                TaskDate = DateTime.Today
                                }
                            );
                            _context.SaveChanges();
                        }
                    break;

                }
                
            }

        }
        public TaskListController(TaskContext context)
        {
                _context = context;
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
            GenerateTaskList();
            return View(await _context.TaskList.ToListAsync());
        }

        // GET: Task/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.TaskList
                .SingleOrDefaultAsync(m => m.ID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }
        // GET: Task/SetComplete/5
        public async Task<IActionResult> SetComplete(int? id)
        {
            if(id != null)
            {
                var task = await _context.TaskList
                    .SingleOrDefaultAsync(m=> m.ID == id);
                if(task != null)
                {
                    task.Complete = true;
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(task);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!TaskExists(task.ID))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));

        }


        private bool TaskExists(int id)
        {
            return _context.TaskList.Any(e => e.ID == id);
        }
    }
}
