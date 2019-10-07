using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_44_asp_entity_core.Pages
{
    public class ToDoListModel : PageModel
    {
        public static List<ToDoItem> todos = new List<ToDoItem>();
        public void OnGet()
        {
            //var ToDo = new ToDoItem()
            //{
            //    ToDoItemId = 1,
            //    ToDoItemName = "Bossman",
            //    DateCreated = DateTime.Now
            //};

            using( var db = new ToDoItemContext())
            {
               todos = db.ToDoItems.ToList();
            }


        }
    }
}