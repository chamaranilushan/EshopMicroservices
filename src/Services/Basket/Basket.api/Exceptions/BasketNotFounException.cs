
namespace Basket.api.Exceptions
{
    public class BasketNotFounException : NotFoundException
    {
        public BasketNotFounException(string message) : base("Basket",message)
        {
        }
    }
}
