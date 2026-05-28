using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstractions
{

    public interface IEntity<T> : IEntity
    {
        public T Id { get; set; }
    }


    public interface IEntity
    {
    }
}
