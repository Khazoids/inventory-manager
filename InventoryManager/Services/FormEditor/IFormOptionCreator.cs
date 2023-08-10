using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Services.FormEditor
{
    public interface IFormOptionCreator
    {
        Task CreateItemType(FormOptionsModel formOptionsModel);
        Task CreateItemStatus(FormOptionsModel formOptionsModel);

    }
}
