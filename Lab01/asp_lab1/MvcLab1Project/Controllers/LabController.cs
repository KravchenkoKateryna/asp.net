using Microsoft.AspNetCore.Mvc;
namespace MvcLab1Project.Controllers;

public class LabController : Controller
{
    public IActionResult Info()
    {
        // Дані, які передамо у View
        ViewData["LabNumber"] = "Лабораторна робота №1";
        ViewData["Topic"] = "Вступ до ASP.NET Core";
        ViewData["Goal"] = "Ознайомитися з основними принципами роботи .NET, навчитися налаштовувати середовище розробки та встановлювати необхідні компоненти, набути навичок створення рішень та проектів різних типів, набути навичок обробки запитів з використанням middleware.";
        ViewData["Student"] = "Катерина Кравченко";

        return View();
    }
}