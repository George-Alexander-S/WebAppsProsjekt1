using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Reflection;
using System.Xml.Linq;
using WebAppsProsjekt1.Models;
namespace WebAppsProsjekt1.ViewModels;

//An IEnumerable<Cardset>, which is a collection of Cardset objects, typically representing multiple instances of Cardset from your models.
//A nullable string, currentViewName, representing the name of the current view.

public class CardListViwModel
{
    public IEnumerable<Cardset> Cardsets;
    public string? CurrentViewName;

    public CardListViwModel(IEnumerable<Cardset> cardsets, string? currentViewName) // Constructor
    {
        Cardsets = cardsets; // Correct: Assigning the parameter to the property of the class.
        CurrentViewName = currentViewName; // Assigning the parameter to the property of the class.
    }

}

