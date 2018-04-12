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
        protected void GenerateTaskList(TaskContext context)
        {
            //Clear the task list
            //well maybe not completed tasks.
            //sigh, the timestamps should really be on each db entry.
            //lets see if this can work first
            DayOfWeek Today = DateTime.Now.DayOfWeek;
            foreach (var entity in context.TaskList)
                context.TaskList.Remove(entity);
            context.SaveChanges();
    
            //process each tempate object
            foreach (var TaskObj in context.TaskTemplate)
            {
                switch(TaskObj.RepeatFreq){
                    case TaskApp2.RepeatFrequencyEnum.Daily:
                        context.TaskList.Add(
                            new TaskInstance{
                                Name = TaskObj.Name,
                                Desc = TaskObj.Desc,
                                Complete = false,
                                TaskDate = DateTime.Today
                            }
                        );
                        context.SaveChanges();
                    break;

                    case TaskApp2.RepeatFrequencyEnum.Weekends:
                        if ( (Today == DayOfWeek.Saturday) || (Today == DayOfWeek.Sunday)){
                            context.TaskList.Add(
                            new TaskInstance{
                                Name = TaskObj.Name,
                                Desc = TaskObj.Desc,
                                Complete = false,
                                TaskDate = DateTime.Today
                            }
                        );
                        context.SaveChanges();
                        }
                    break;
                    
                    case TaskApp2.RepeatFrequencyEnum.Weekdays:
                        if ( (Today != DayOfWeek.Saturday) && (Today != DayOfWeek.Sunday)){
                            context.TaskList.Add(
                            new TaskInstance{
                                Name = TaskObj.Name,
                                Desc = TaskObj.Desc,
                                Complete = false,
                                TaskDate = DateTime.Today
                            }
                        );
                        context.SaveChanges();
                        }
                    break;
                }
                
            }

        }
        public TaskListController(TaskContext context)
        {
            if(context.TaskTemplateUpdate == null ){
                GenerateTaskList(context);
                _context.TaskListUpdate = DateTime.Now;
            }

            else if(context.TaskTemplateUpdate > context.TaskListUpdate){
                GenerateTaskList(context);
                _context.TaskListUpdate = DateTime.Now;
            }
            else
                _context = context;
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
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


        private bool TaskExists(int id)
        {
            return _context.TaskList.Any(e => e.ID == id);
        }
    }
}
