using System.Data;

namespace OrderForm.Data
{
    internal interface IReadRepository
    {
        DataTable Read();
    }
}