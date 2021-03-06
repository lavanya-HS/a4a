﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Tekinroads.DAL
{
    class PersonRepository 
    {
        private TekinRoadsEntities personDB = new TekinRoadsEntities();

       public void Update(Person entity)
        {
            Person foundModel =
                personDB.Person
                .Where(a => a.PersonId.Equals(entity.PersonId))
                .FirstOrDefault();

            if (foundModel == null)
                throw new Exception("Model not found");

            foundModel.Name = entity.Name;
            personDB.Person.Add(foundModel);
            personDB.SaveChanges();
        }

        public void Delete(byte Id)
        {
            Person foundModel =
                personDB.Person
                .Where(a => a.PersonId.Equals(Id))
                .FirstOrDefault();

            if (foundModel == null)
                throw new Exception("Model not found");

            personDB.Person.Remove(foundModel);
            personDB.SaveChanges();
        }

        public Person SelectOne(byte Id)
        {
            return personDB.Person
                    .Where(a => a.PersonId.Equals(Id))
                    .FirstOrDefault();
        }

       
    }
}
