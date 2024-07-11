using Microsoft.AspNetCore.Http.HttpResults;
using SeamenResto.Api.Dto;

namespace SeamenResto.Api.Endpoint;

public static class OrderEndpoint
{
    //this is a List of data acting as a database temporarily
    //data structure is based on the dto hence OrderDto
    private static readonly List<OrderDto> orders = [
        new (
            1,
            "Jojo",
            1,
            "Fries",
            69.99
        ),
        new (
            2,
            "Jaja",
            5,
            "Fries",
            6669.99
        ),
        new (
            3,
            "Jiji",
            2,
            "Fries",
            99.99
        )
    ];

    //used RouteGroupBuilder for routing of endpoints
    //used webappli in the params so can be used in this endpoint
    public static RouteGroupBuilder MapOrderEndpoint (this WebApplication app){

        //create a var to group the map endpoints name
        var OrderGroupName = app.MapGroup("order");

        //GET method purpose of this is to show the user all the data available 
        //in the database
        OrderGroupName.MapGet("/", ()=>{
            return orders;
        });

        //GET method purpose of this is to show the user all the data available 
        //in the database
        OrderGroupName.MapGet("/{id}", (int id)=>{

            OrderDto? existingOrder = orders.Find(order => order.Id == id);

            //to check if the data exist
            if(existingOrder == null){
                return Results.NotFound();
            }

            return Results.Ok(existingOrder);
        });

        //For Creating Data
        OrderGroupName.MapPost("/", (CreateOrderDto newOrder)=>{

            OrderDto order = new(
                orders.Count + 1,
                newOrder.CustomerName,
                newOrder.Quantity,
                newOrder.OrderName,
                newOrder.Price
            );
            orders.Add(order);

            return Results.Ok(order);
        });

        //For Updating Data
        OrderGroupName.MapPut("/{id}", ()=>{


            return Results.NoContent();
        });

        //For Updating Data
        OrderGroupName.MapDelete("/{id}", ()=>{
            return Results.NoContent();
        });

        return OrderGroupName;
    }
}
