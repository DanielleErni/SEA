namespace SeamenResto.Api.Dto;

public record class UpdateOrderDto
(
    string CustomerName,
    int Quantity,
    string OrderName,
    double Price
);
