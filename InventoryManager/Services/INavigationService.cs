﻿using InventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This interface provides all the methods required to implement navigation
 */
namespace InventoryManager.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {

        void Navigate();
    }
}
