using Microsoft.AspNetCore.Mvc;
using OldBarom.Core.Application.Interfaces.MyLinkList;

namespace OldBarom.Web.API.Controllers.MyLinkList
{
    [Route("api/[controller]")]
        [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

    }
}
