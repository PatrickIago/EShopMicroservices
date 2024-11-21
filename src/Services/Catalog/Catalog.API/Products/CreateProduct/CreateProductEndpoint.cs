namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price); // Minha requisição para criar um produto
public record CreateProductResponse(Guid Id); // A resposta que deve ser retornada.
public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>(); // Mapea as solicitações de entrada.

                var result = await sender.Send(command); // O mediator acionara a classe de tratamento.

                var response = result.Adapt<CreateProductResponse>(); //  Mapeia o resultado retornado pelo MediatR para a resposta final  que será enviada ao cliente.

                return Results.Created($"/products/{response.Id}", response); // Retornamos ao cliente.
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
    }
}
