/*
[HttpPost]
[ValidateAntiForgeryToken]
//public async Task<IActionResult> Register([Bind("CarRegNumber,CarBrand,CarBrandModel,CarFuelConsumption")] CarModel carModel)

public async Task<IActionResult> Register(UserViewModel model)
{

    if (ModelState.IsValid)
    {



        _context.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    return View(nameof(Index));
}
public IActionResult Register()
{
    return View();
}
*/