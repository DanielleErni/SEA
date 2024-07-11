namespace SeamenResto.Api.Dto;

public record class CreateOrderDto
(
    string CustomerName,
    int Quantity,
    string OrderName,
    double Price
);
