using FashionHeaven.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionHeaven.Core.Contracts
{
    public interface ICartService
    {
        public Task<IEnumerable<CartItem>> GetAllCartItemsAsync();

        public Task AddItemInCartAsync(int id,int colourId,int sizeId);

        public Task RemoveItemInCartAsync(int id);



    }
}
