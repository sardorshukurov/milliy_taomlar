namespace Basket.API.Baskets.DeleteBasket.Handler;

using Data;

public class DeleteBasketHandler(IBasketRepository repository)
    : ICommandHandler<DeleteBasketCommand>
{
    public async Task<Response<Unit>> Handle(
        DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        await repository.DeleteBasketAsync(command.Username, cancellationToken);

        return new Response<Unit>(
            true,
            StatusCodes.Status204NoContent,
            Unit.Value);
    }
}
