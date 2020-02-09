using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BugTracker.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using BugTracker.Data;
using BugTracker.Interfaces;

namespace BugTracker.Controllers
{
	public class HomeController : Controller
	{
		public readonly IWorkItemService _WorkItemService;

		public HomeController(IWorkItemService workItemsService)
		{
			_WorkItemService = workItemsService;
		}

		public IActionResult Index()
		{
			var workItems = _WorkItemService.GetAllWorkItems();
			return View(workItems);
		}

		public ActionResult AddWorkItem()
		{
			return RedirectToAction("AddItem", "AddWorkItem");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}