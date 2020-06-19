package com.avans.customerservice.services;

import com.avans.customerservice.domain.Customer;

public interface CustomerService {

    Customer getCustomer(String id);

    String createCustomer(Customer customer);
}
