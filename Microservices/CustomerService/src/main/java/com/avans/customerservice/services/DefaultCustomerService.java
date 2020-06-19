package com.avans.customerservice.services;

import com.avans.customerservice.domain.Customer;
import com.avans.customerservice.repositories.CustomerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class DefaultCustomerService implements CustomerService {

    private CustomerRepository customerRepository;

    @Autowired
    public DefaultCustomerService(CustomerRepository customerRepository) {
        this.customerRepository = customerRepository;
    }

    @Override
    public Customer getCustomer(String id) {
        return customerRepository.getCustomer(id);
    }

    @Override
    public String createCustomer(Customer customer) {
        return customerRepository.createCustomer(customer);
    }
}
