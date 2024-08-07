using Jale_Xanm.Exceptions.Common;

namespace Jale_Xanm.Exceptions
{
    public class NotFoundException:Exception,IBaseException
    {
        public NotFoundException(string message):base(message)
        {
            
        }
    }
}
