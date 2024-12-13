using BPKB_BackEnd.Data;
using BPKB_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Cryptography.X509Certificates;

namespace BPKB_BackEnd.Controllers
{
    public class BPKBController : Controller
    {
        private readonly BPKBContext _context;

        public BPKBController(BPKBContext context)
        {
            _context = context;
        }
        [Route("api/[controller]/Create")]

        [HttpPost]
        public async Task<IActionResult> CreateBPKB([FromQuery] string AgreementNumber, string BranchId, string BpkbNo, string BpkbDateIn, string BpkbDate, string FakturNo, string FakturDate,string PoliceNo, string LocationId, string CreatedBy, string LastUpdatedBy)
        {
            
            _context.Database.BeginTransaction();
            

            TrBpkb existingBPKB = await _context.TrBpkbs.FindAsync(AgreementNumber);
            if (existingBPKB == null)
            {
                TrBpkb trBpkb = new TrBpkb();
                trBpkb.AgreementNumber = AgreementNumber;
                trBpkb.BranchId = BranchId;
                trBpkb.BpkbNo = BpkbNo;
                trBpkb.BpkbDateIn = DateTime.Parse(BpkbDateIn);
                trBpkb.BpkbDate = DateTime.Parse(BpkbDate);
                trBpkb.FakturNo = FakturNo;
                trBpkb.FakturDate = DateTime.Parse(FakturDate);
                trBpkb.PoliceNo = PoliceNo;
                trBpkb.LocationId = LocationId;
                trBpkb.CreatedBy = CreatedBy;                
                trBpkb.CreatedOn = DateTime.Now;                
                await _context.TrBpkbs.AddAsync(trBpkb);
            }
            else
            {
                existingBPKB.AgreementNumber = AgreementNumber;
                existingBPKB.BranchId = BranchId;
                existingBPKB.BpkbNo = BpkbNo;
                existingBPKB.BpkbDateIn = DateTime.Parse(BpkbDateIn);
                existingBPKB.BpkbDate = DateTime.Parse(BpkbDate);
                existingBPKB.FakturNo = FakturNo;
                existingBPKB.FakturDate = DateTime.Parse(FakturDate);
                existingBPKB.PoliceNo = PoliceNo;
                existingBPKB.LocationId = LocationId;                
                existingBPKB.LastUpdatedBy = LastUpdatedBy;                
                existingBPKB.LastUpdatedOn = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            _context.Database.CommitTransaction();
            return Json(new { message = "Items saved successfully!" });
        }

        [Route("api/[controller]/GetLocation")]
        [HttpGet]
        public async Task<IActionResult> GetLocation()
        {
            try
            {                
                List<MsStorageLocation> storageLocationList = await _context.MsStorageLocations.ToListAsync();
                List<StorageLocationModel> storageLocationListModel = new List<StorageLocationModel>();
                foreach (var sl in storageLocationList)
                {
                    StorageLocationModel slModel = new StorageLocationModel();
                    slModel.LocationName = sl.LocationName;
                    storageLocationListModel.Add(slModel);
                }
                return Ok(storageLocationListModel);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [Route("api/[controller]/GetLocationByName")]
        [HttpGet]
        public async Task<IActionResult> GetLocationByName(string locationName)
        {
            try
            {
                MsStorageLocation storageLocation = await _context.MsStorageLocations.Where(x => x.LocationName == locationName).SingleOrDefaultAsync();
                
                return Ok(storageLocation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/[controller]/Login")]
        [HttpGet]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                MsUser user = await _context.MsUsers.Where(x => x.UserName == username && x.Password == password && x.IsActive == true).SingleOrDefaultAsync();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
