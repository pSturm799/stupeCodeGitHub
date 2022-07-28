using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EntityFrameworkAccessLibrary.DataAccess;
using EntityFrameworkAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityFrameworkDemoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            AddSampleData();
            var p = _db.People.Include((a => a.Addresses)).Include(e => e.EmailAddresses).ToList();

            GetDataFromDatabase();

        }


        private void GetDataFromDatabase()
        {
            var p1 = _db.People.Where(x => x.Age == 10).ToList();
        }


        private void AddSampleData()
        {
            if (!_db.People.Any())
            {
                string file = System.IO.File.ReadAllText("generated.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                
                _db.AddRange(people);
                _db.SaveChanges();
            }
        }
    }
}
