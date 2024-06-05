using Microsoft.AspNetCore.Mvc;
using OldBarom.Core.Application.Interface.Base;
using OldBarom.Core.Domain.Model.Base;

namespace OldBarom.Web.API.Controllers.Base
{
    public class KeywordsController : ControllerBase
    {
        private readonly IKeywordsService _keywordService;
        public KeywordsController(IKeywordsService keywordService)
        {
            _keywordService = keywordService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _keywordService.GetAllKeywords();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _keywordService.GetByID(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Keywords keyword)
        {
            var result = await _keywordService.AddKeywords(keyword);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Keywords keyword)
        {
            var result = await _keywordService.UpdateKeywords(keyword.Id, keyword);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _keywordService.DeleteKeywords(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByKeyword(string keyword)
        {
            var result = await _keywordService.GetByKeyword(keyword);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByKeywordType(int keywordType)
        {
            var result = await _keywordService.GetByType(keywordType);
            return Ok(result);
        }
    }
}
