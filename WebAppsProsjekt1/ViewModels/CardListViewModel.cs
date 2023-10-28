using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Reflection;
using System.Xml.Linq;
using WebAppsProsjekt1.Models;
namespace WebAppsProsjekt1.ViewModels;


public class CardListViewModel
{
    public IEnumerable<Cardset> Cardsets;
    public string? CurrentViewName;

    public CardListViewModel(IEnumerable<Cardset> cardsets, string? currentViewName) // Constructor
    {
        Cardsets = cardsets;
        CurrentViewName = currentViewName;
    }

}

