using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
