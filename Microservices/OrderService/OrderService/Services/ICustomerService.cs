﻿namespace OrderService.Services
{
    public interface ICustomerService
    {
        bool Exists(string id);
    }
}