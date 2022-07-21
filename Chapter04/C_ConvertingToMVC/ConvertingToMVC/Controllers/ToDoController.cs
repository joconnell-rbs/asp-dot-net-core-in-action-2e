using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace ConvertingToMVC
{
    public class ToDoController : Controller
    {
        private readonly ToDoService _service;

        public ToDoController(ToDoService service)
        {
            _service = service;
        }

        public ActionResult Category(string id)
        {
            var items = _service.GetItemsForCategory(id);
            var viewModel = new CategoryViewModel(items);

            return View(viewModel);
        }

        public ActionResult Add(string id, string name)
        {
            var newItem = _service.AddItem(new ToDoListModel { Category = id, Title = name });
            var items = _service.GetItemsForCategory(id);
            var vm = new CategoryViewModel(items);

            return View(vm);
        }
    }
}