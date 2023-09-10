﻿using InventoryManager.DTOs;
using InventoryManager.Services;
using InventoryManager.Services.ItemProviders;
using InventoryManager.Services.ItemsCreator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models {
    public class ItemsModel : DomainObject {
        public string ItemName { get; }
        public string ItemType { get; }
       

        public ItemsModel(string itemName, string itemType) {
            ItemName = itemName;
            ItemType = itemType;
           
        }

        public override string ToString() {
            return $"{ItemName}{ItemType}";
        }

       
        
    }
}
