using InventoryManager.Services.FormEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    public class FormModel
    {
        private readonly IEnumerable<String> _itemTypes;
        private readonly IEnumerable<String> _itemStatuses;
        private readonly IFormOptionCreator _formOptionCreator;

        public FormModel(IFormOptionCreator formOptionCreator)
        {  
            _formOptionCreator = formOptionCreator;
        }

        public async Task CreateItemType(FormOptionsModel formOptionsModel)
        {
            await _formOptionCreator.CreateItemType(formOptionsModel);
        }

        public async Task CreateItemStatus(FormOptionsModel formOptionsModel)
        {
            await _formOptionCreator.CreateItemStatus(formOptionsModel);
        }
    }
}
