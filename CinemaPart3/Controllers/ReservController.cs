
using Application.Action.ReservAction.Commands;
using Application.Action.ReservAction.Queries;
using Application.DTO.Request.ReservControllerRequest;
using Application.DTO.Response.ReservControllerResponse;
using Application.Interfaces.ValidatorServicesInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PostPart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IReservValidatorService _reservValidator;

        public ReservController(IMediator mediator, IReservValidatorService reservValidator)
        {
            _mediator = mediator;
            _reservValidator = reservValidator;
        }

        [HttpPost("AddReserv")]
        public async Task<ActionResult<Guid>> AddNewPostAsync([FromBody] NewReservReqModel reservInfo)
        {
            try
            {
                var resultValidation = await _reservValidator._validatorNewReserv.ValidateAsync(reservInfo);
                if(resultValidation.IsValid)
                {
                    var result = await _mediator.Send(new CreateReservCommand { newReserv = reservInfo });
                    return Ok(result);
                }
                var errorsValidation = await _reservValidator.GetErrorsValidationAsync(resultValidation);
                return StatusCode(StatusCodes.Status422UnprocessableEntity, Guid.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("DeleteResrv")]
        public async Task<ActionResult<string>> AddNewPostAsync(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteReservCommand { Id = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("GetReservForUser")]
        public async Task<ActionResult<IEnumerable<UserReservsResModel>>> GetPostForUserAsync(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetUserReservsQuerie { customer_id = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}
