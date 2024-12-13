using BPKB.Data;
using BPKB.Models;
using BPKB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BPKB.Controllers
{
    public class InsertFormController : Controller
    {
        private readonly BpkbService _bpkbService;

        private readonly BPKBContext _context;

        //public InsertFormController(BPKBContext context)
        //{
        //    _context = context;
        //}
        public InsertFormController(BpkbService bpkbService, BPKBContext context)
        {
            _bpkbService = bpkbService;
            _context = context;
        }
        public async Task<IActionResult> InsertForm()
        {
            var locations = await _bpkbService.GetLocation();
            return View(locations);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitBPKB([FromBody] BpkbModel data)
        {
            StorageLocationModel storageLocation = await _bpkbService.GetLocationByName(data.LocationName);
            //MsStorageLocation storageLocation = await _context.MsStorageLocations.Where(x => x.LocationName == data.LocationName).SingleOrDefaultAsync();

            BpkbModel trBpkb = new BpkbModel();
            trBpkb.AgreementNumber = data.AgreementNumber;
            trBpkb.BranchId = data.BranchId;
            trBpkb.BpkbNo = data.BpkbNo;
            trBpkb.BpkbDateIn = data.BpkbDateIn;
            trBpkb.BpkbDate = data.BpkbDate;
            trBpkb.FakturNo = data.FakturNo;
            trBpkb.FakturDate = data.FakturDate;
            trBpkb.PoliceNo = data.PoliceNo;
            trBpkb.LocationId = storageLocation.LocationId;
            trBpkb.LocationName = storageLocation.LocationName;
            trBpkb.CreatedBy = HttpContext.Session.GetString("UserName");
            trBpkb.LastUpdatedBy = HttpContext.Session.GetString("UserName");
            await _bpkbService.SubmitBPKB(trBpkb);

            return Json(new { message = "Items saved successfully!" });

        }
    }
}
