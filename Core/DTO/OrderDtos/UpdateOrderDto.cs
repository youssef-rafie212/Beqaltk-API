﻿using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO.OrderDtos
{
    public class UpdateOrderDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }
}
