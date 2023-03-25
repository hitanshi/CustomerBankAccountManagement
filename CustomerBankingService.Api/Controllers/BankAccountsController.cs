using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CustomerBankingService.Api.Controllers.ResponseTypes;
using CustomerBankingService.Application.BankAccounts;
using CustomerBankingService.Application.BankAccounts.CreateBankAccount;
using CustomerBankingService.Application.BankAccounts.CreateBankAccountBankTransactionHistory;
using CustomerBankingService.Application.BankAccounts.DeleteBankAccount;
using CustomerBankingService.Application.BankAccounts.DeleteBankAccountBankTransactionHistory;
using CustomerBankingService.Application.BankAccounts.GetBankAccountBankTransactionHistories;
using CustomerBankingService.Application.BankAccounts.GetBankAccountBankTransactionHistoryById;
using CustomerBankingService.Application.BankAccounts.GetBankAccountById;
using CustomerBankingService.Application.BankAccounts.GetBankAccounts;
using CustomerBankingService.Application.BankAccounts.UpdateBankAccount;
using CustomerBankingService.Application.BankAccounts.UpdateBankAccountBankTransactionHistory;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.AspNetCore.Controllers.Controller", Version = "1.0")]

namespace CustomerBankingService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly ISender _mediator;

        public BankAccountsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> Post([FromBody] CreateBankAccountCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = result }, new { Id = result });
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified BankAccountDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an BankAccountDto with the parameters provided.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BankAccountDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankAccountDto>> Get([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBankAccountByIdQuery { Id = id }, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;BankAccountDto&gt;.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<BankAccountDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BankAccountDto>>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBankAccountsQuery(), cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] UpdateBankAccountCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Successfully deleted.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] int id, [FromQuery] DeleteBankAccountCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("{bankAccountId}/BankTransactionHistories")]
        [ProducesResponseType(typeof(JsonResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> PostBankTransactionHistory([FromRoute] int bankAccountId, [FromBody] CreateBankAccountBankTransactionHistoryCommand command, CancellationToken cancellationToken)
        {
            if (bankAccountId != command.BankAccountId)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = result }, new { Id = result });
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified BankAccountBankTransactionHistoryDto.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        /// <response code="404">Can't find an BankAccountBankTransactionHistoryDto with the parameters provided.</response>
        [HttpGet("{bankAccountId}/BankTransactionHistories/{id}")]
        [ProducesResponseType(typeof(BankAccountBankTransactionHistoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BankAccountBankTransactionHistoryDto>> GetBankTransactionHistory([FromRoute] int bankAccountId, [FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBankAccountBankTransactionHistoryByIdQuery { BankAccountId = bankAccountId, Id = id }, cancellationToken);
            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Returns the specified List&lt;BankAccountBankTransactionHistoryDto&gt;.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpGet("{bankAccountId}/BankTransactionHistories")]
        [ProducesResponseType(typeof(List<BankAccountBankTransactionHistoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BankAccountBankTransactionHistoryDto>>> GetAllBankTransactionHistories([FromRoute] int bankAccountId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBankAccountBankTransactionHistoriesQuery { BankAccountId = bankAccountId }, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// </summary>
        /// <response code="204">Successfully updated.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPut("{bankAccountId}/BankTransactionHistories/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PutBankTransactionHistory([FromRoute] int bankAccountId, [FromRoute] int id, [FromBody] UpdateBankAccountBankTransactionHistoryCommand command, CancellationToken cancellationToken)
        {
            if (bankAccountId != command.BankAccountId)
            {
                return BadRequest();
            }
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// </summary>
        /// <response code="200">Successfully deleted.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpDelete("{bankAccountId}/BankTransactionHistories/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBankTransactionHistory([FromRoute] int bankAccountId, [FromRoute] int id, [FromQuery] DeleteBankAccountBankTransactionHistoryCommand command, CancellationToken cancellationToken)
        {
            if (bankAccountId != command.BankAccountId)
            {
                return BadRequest();
            }
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}