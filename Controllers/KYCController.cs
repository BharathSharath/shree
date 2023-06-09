public class KYCController : Controller
{
    private readonly AppDbContext _context;

    public KYCController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var kycList = _context.KYC.ToList();
        return View(kycList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(KYC kyc)
    {
        _context.KYC.Add(kyc);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var kyc = _context.KYC.Find(id);
        if (kyc == null)
        {
            return NotFound();
        }
        return View(kyc);
    }

    [HttpPost]
    public IActionResult Edit(KYC kyc)
    {
        _context.KYC.Update(kyc);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var kyc = _context.KYC.Find(id);
        if (kyc == null)
        {
            return NotFound();
        }
        return View(kyc);
    }

    public IActionResult Delete(int id)
    {
        var kyc = _context.KYC.Find(id);
