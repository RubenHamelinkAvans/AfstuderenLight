package com.avans.customerservice.repositories;

import com.avans.customerservice.domain.Customer;

public interface CustomerRepository {

    Customer getCustomer(String id);

    String createCustomer(Customer customer);
}
