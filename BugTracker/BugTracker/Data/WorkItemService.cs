using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Interfaces;
using BugTracker.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BugTracker.Data
{
	public class WorkItemService : IWorkItemService
	{
		private readonly MongoDBRepository repository;

		public WorkItemService(IOptions<Settings> settings)
		{
			repository = new MongoDBRepository(settings);
		}

		public IEnumerable<WorkItem> GetAllWorkItems()
		{
			return repository.WorkItems.Find(x => true).ToList();
		}

		public void InsertWorkItem(WorkItem workItem)
		{
			repository.WorkItems.InsertOne(workItem);
		}
	}
}