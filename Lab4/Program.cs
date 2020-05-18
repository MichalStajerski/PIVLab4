using System;
using RestSharp;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Lab4
{
    class Program
    {
        static async Task Main(string[] args)
        {

            int rok = 2019;
            var db = new Context();
            await db.Database.EnsureCreatedAsync();

            var web = new RestClient("https://api.collegefootballdata.com");
            var request = new RestRequest($"/teams/fbs?year={rok}", Method.GET);
            var response = await web.ExecuteAsync(request);
            var json = response.Content;
            var teams = JsonSerializer.Deserialize<Team[]>(response.Content);
            var taskList = new List<Task<IRestResponse>>();
            

            foreach (var item in teams)
            {
                var result = new RestRequest($"/coaches?team={item.school}");
                taskList.Add(web.ExecuteAsync(result));
            }

            var taskResponses = await Task.WhenAll(taskList);

            var coaches = taskResponses.SelectMany(x => JsonSerializer.Deserialize<Coach[]>(x.Content));

            
            
             foreach (var item in coaches)
             {
               teams.Single(x => x.school == item.seasons.First().school).CoachNavigation.Add(item);
             }
           
            

           

            var nextTask = teams.Select(x => db.AddAsync(x).AsTask());
            await Task.WhenAll(nextTask);
            await db.SaveChangesAsync();
        }

    }   
}
