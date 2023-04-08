using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Repository.DTOs.Articles;
using Repository.Models;
using Services.Services.Articles;
using System.IdentityModel.Tokens.Jwt;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController<ArticlesController>
    {
        private readonly IArticlesService _articlesService;
        private readonly swopContext _context;

        public ArticlesController(IArticlesService articlesService,
                                  swopContext context)
        {
            _articlesService = articlesService;
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<GenericReponse<List<Article>>>> GetArticles()
        {
            var errorMessages = new List<string>();

            try
            {
                var articlesResult = (await _articlesService.GetArticles()).ToList();

                if (articlesResult == null)
                {
                    errorMessages.Add("Articles not found");

                    return new GenericReponse<List<Article>>
                    {
                        Data = new List<Article>(),
                        StatusCode = 404,
                        ErrorMessages = errorMessages
                    };
                }

                return new GenericReponse<List<Article>> 
                {
                    Data = articlesResult,
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                errorMessages.Add(ex.Message);

                return new GenericReponse<List<Article>>
                {
                    Data = new List<Article>(),
                    StatusCode = 500,
                    ErrorMessages = errorMessages
                };
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
        [Authorize]
        public async Task<ActionResult<Article>> PostArticle([FromForm] ArticlesDTO article)
        {
            try
            {
                var userEmail = "test@test.test";
                var isAuthenticated = User.Identity.IsAuthenticated;
                var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(_bearer_token);
                var context = new swopContext();
                                                                                
                ApplicationUser user = _context.Users.Where(x => x.Email.Equals(userEmail)).FirstOrDefault();

                var articleResult = await _articlesService.PostArticle(article, user.Id);

                if (articleResult == null)
                {
                    return Problem("Entity set 'swopContext.Articles'  is null.");
                }

                foreach (var file in article.Images)
                {
                    //TODO - check if exist

                    bool fileExist = System.IO.File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", article.Id + "-" + file.FileName));

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);

                    context.Files.Add(new Repository.Models.File
                    {
                        Id = "7d335b75-0494-44fb-a767-78b5681c9d91",
                        Path = path,
                        ArticleId = articleResult.Id,
                    });                

                    //TODO - add to file table in database
                }
                
                await context.SaveChangesAsync();

                return CreatedAtAction("GetArticle", new { id = articleResult.Id }, article);
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
        [Authorize]
        public async Task<IActionResult> PutArticle(string id, ArticlesDTO article)
        {
            //if (id != article.Id)
            //{
            //    return BadRequest("Invalid 'id!'");
            //}

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
        [Authorize]
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
