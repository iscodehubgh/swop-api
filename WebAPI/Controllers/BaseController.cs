//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    public class BaseController<T> : ControllerBase where T : BaseController<T>
//    {
//        private ILogger<T>? _logger;
//        private IMapper? _mapper;
        
//        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>();
//        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();
//    }
//}
