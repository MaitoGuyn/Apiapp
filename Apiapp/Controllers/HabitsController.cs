﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apiapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : Controller
    {
        private readonly Listcs _habits;

        public HabitsController(Listcs habits)
        {
            _habits = habits;
        }


        [HttpPost]
        public JsonResult PostHabit(Habits habits)
        {
            //if (habits == null)
            //{
            //    return new JsonResult("Invalid habit data") { StatusCode = 400 };
            //}

            if (habits.Id == 0)
            {
                _habits.Habits.Add(habits);

            }
            else
            {
                var bookingInDB = _habits.Habits.FirstOrDefault(x => x.Id == habits.Id);

                if (bookingInDB == null)
                {
                    return new JsonResult(NotFound());
                }

                bookingInDB = habits;
            }
            
            return new JsonResult(habits);
        }

        [HttpGet]
        public JsonResult GetHabit(int id)
        {
            var habits = _habits.Habits.FirstOrDefault(x => x.Id == id);

            if (habits == null)
                return new JsonResult(NotFound());


            return new JsonResult(Ok(habits));
        }

        [HttpPut]
        public JsonResult PutHabits(int id, Habits habits)
        {
            if (habits == null)
            {
                return new JsonResult("Invalid habit data");
            }

            var bookInDb = _habits.Habits.FirstOrDefault(x => x.Id == id);

            if (bookInDb == null)
            {
                return new JsonResult(NoContent());
            }
            else
            {
                _habits.AddHabit(habits);
                return new JsonResult(Ok(habits));
                
            }

        }

        [HttpDelete]
        public JsonResult deleteBook(int id)
        {
            var habit = _habits.Habits.FirstOrDefault(x => x.Id == id);

            if (habit == null)
            {
                return new JsonResult(NotFound());
            }
            else
            {
                _habits.Habits.Remove(habit);
                return new JsonResult(Ok(habit));
            }

        }
    }
}