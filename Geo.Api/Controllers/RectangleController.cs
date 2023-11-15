using Geo.Api.Application.Rectangle.CreateCommand;
using Geo.Api.Application.Rectangle.SearchQuery;
using Geo.Api.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Geo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RectangleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Searches for items based on the specified rectangle coordinates and dimensions.
        /// </summary>
        /// <remarks>
        /// The search is performed within the rectangle defined by the specified X, Y coordinates,
        /// and the given Width and Height dimensions.
        /// </remarks>
        /// <param name="request">The search criteria containing rectangle coordinates and dimensions.</param>
        /// <returns>
        /// <see cref="IActionResult"/> with the result of the search operation.
        /// If no items are found, returns a 404 NotFound response.
        /// </returns>

        [HttpGet("search")]
        public async Task<SearchResponse> SearchAsync([FromQuery] SearchRequest request)
        {
            var result = await _mediator.Send(new SearchQuery(request));

            if (!result.Items.Any())
            {
                throw new NotFoundException("Data not found");
            }

            return result;
        }
        /// <summary>
        /// Creates a rectangle on the provided rectangle coordinates and dimensions.
        /// </summary>
        /// <remarks>
        /// This endpoint initiates the creation of a rectangle using the specified X, Y coordinates,
        /// and the given Width and Height dimensions.
        /// </remarks>
        /// <param name="request">The request containing rectangle coordinates and dimensions.</param>
        /// <returns>
        /// An HTTP 200 OK response if the items are successfully created.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateTwoAsync([FromBody] CreateRequest request)
        {
            await _mediator.Send(new CreateCommand(request));

            return Ok();
        }
    }
}