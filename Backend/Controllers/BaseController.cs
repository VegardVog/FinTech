using AutoMapper;
using FinTech.Repository.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTech.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]

    [ApiController]
    public class BaseController : ControllerBase
    {

        protected readonly IMapper _mapper;
        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
