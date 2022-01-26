using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharpBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoedingswaardenController : ControllerBase
    {
        DatabaseContext databaseContext;

        public VoedingswaardenController(DatabaseContext dbContext)
        {
            databaseContext = dbContext;
        }

        [HttpGet("{voedingswaardenId}")]
        public Voedingswaarden GetVoedingswaarden(int voedingswaardenId)
        {
            var voedingswaarden = databaseContext.Find<Voedingswaarden>(voedingswaardenId);

            return voedingswaarden;
        }
    }
}
