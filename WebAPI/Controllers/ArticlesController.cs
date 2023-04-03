using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs.Articles;
using Repository.Models;
using Services.Services.Articles;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController<ArticlesController>
    {
        private readonly IArticlesService _articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        // GET: api/Articles
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ArticlesDTO>>> GetArticles()
        {
            try
            {
                var articlesResult = await _articlesService.GetArticles();

                if (articlesResult == null)
                {
                    return NotFound();
                }

                return articlesResult.ToList();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                return StatusCode(500, ex);
            }
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(string id)
        {
            //Create validation for guid and return BadRequest if is not!!!
            try
            {
                var articleResult = await _articlesService.GetArticle(id);

                if (articleResult == null)
                {
                    return NotFound();
                }

                return articleResult;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                return StatusCode(500, ex);
            }
        }

        // POST: api/Articles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            try
            {
                var articleResult = await _articlesService.PostArticle(article);

                if (articleResult == null)
                {
                    return Problem("Entity set 'swopContext.Articles'  is null.");
                }

                return CreatedAtAction("GetArticle", new { id = article.Id }, article);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                return StatusCode(500, ex);
            }
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticle(string id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest("Invalid 'id!'");
            }

            try
            {
                var articleResult = await _articlesService.PutArticle(id, article);

                if (articleResult == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                return StatusCode(500, ex);
            }
        }
        
        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(string id)
        {
            try
            {
                var articleResult = await _articlesService.DeleteArticle(id);

                if (articleResult == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                return StatusCode(500, ex);
            }
        }
    }
}
