using System;

namespace HeadWorksDragonFight.Core.Exceptions
{
    public class EntityAlreadyExistsException : ApplicationException
    {
        public EntityAlreadyExistsException(string message):base(message)
        {
        }
    }
}
