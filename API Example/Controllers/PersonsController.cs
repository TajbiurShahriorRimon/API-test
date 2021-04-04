using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Example.Controllers
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }

    public class PersonsController : ApiController
    {

        public static List<Person> people = new List<Person>()
        {
            new Person()
            {
                Id = 1001,
                Name = "Arif",
                Salary = 2000
            },
            new Person()
            {
                Id = 2002,
                Name = "Ahnaf",
                Salary = 4000
            }
        };

        public IHttpActionResult GetPerson()
        {
            return Ok(people);
        }

        public IHttpActionResult Get(int id)
        {
            Person singlePerson = people.Find(i => i.Id == id);

            if(singlePerson == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(singlePerson);
        }

        public IHttpActionResult Post(Person person)
        {
            people.Add(person);
            return Created("xzy", person);
            //return Ok(person);
        }

        public IHttpActionResult Put(Person person, int id)
        {
            var singlePerson = people.Find(i => i.Id == id);

            if (singlePerson == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            singlePerson.Name = person.Name;
            singlePerson.Salary = person.Salary;
            return Ok(singlePerson);
        }

        public IHttpActionResult Delete(Person person, int id)
        {
            Person singlePerson = people.Find(i => i.Id == id);

            if (singlePerson == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            people.Remove(singlePerson);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
