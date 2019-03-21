using System;
using System.Windows.Forms;

namespace OrderForm.Data
{
    internal interface IWriteRepository
    {
        void Save(string firstName, string lastName, DateTime dateofBirth
            , DataGridViewRowCollection productsFromGrid);
    }
}