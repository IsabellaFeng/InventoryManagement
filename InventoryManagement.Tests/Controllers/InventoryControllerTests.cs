using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Api.Controllers;
using InventoryManagement.DataAccess.Data;
using MediatR;
using InventoryManagement.Application.Scenarios.CreateIngredient;
using InventoryManagement.Application.Scenarios.GetIngredient;
using System.Threading.Tasks;
using InventoryManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

public class InventoryControllerTests
{
    private readonly Mock<IDbContextFactory<InventoryDbContext>> _mockDbContextFactory;
    private readonly Mock<IMediator> _mockMediator;
    private readonly InventoryController _controller;

    public InventoryControllerTests()
    {
        _mockDbContextFactory = new Mock<IDbContextFactory<InventoryDbContext>>();
        _mockMediator = new Mock<IMediator>();
        _controller = new InventoryController(_mockDbContextFactory.Object, _mockMediator.Object);
    }

    [Fact]
    public async Task AddIngredient_ReturnsOkWithId()
    {
        var request = new CreateIngredientRequest();
        _mockMediator.Setup(m => m.Send(request, default)).ReturnsAsync(1); 

        var result = await _controller.AddIngredient(request);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(1, okResult.Value);
    }

    [Fact]
    public async Task GetIngredients_ReturnsOkWithIngredients()
    {
        var ingredients = new List<Ingredient>
    {
        new Ingredient { IngredientId = 1, LastUpdatedAt = DateTime.MinValue, Name = "Salt", Quantity = 0, Unit = "box" }
    };

        _mockMediator.Setup(m => m.Send(It.IsAny<GetIngredientsRequest>(), default)).ReturnsAsync(ingredients);

        var result = await _controller.GetIngredients();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(ingredients, okResult.Value);
    }
}