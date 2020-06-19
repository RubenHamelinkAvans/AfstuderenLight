package com.avans.customerservice.controllers;

import com.avans.customerservice.domain.Customer;
import com.avans.customerservice.services.CustomerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/Customer")
public class CustomerController {

    private final CustomerService customerService;

    @Autowired
    public CustomerController(CustomerService customerService) {
        this.customerService = customerService;
    }

    @GetMapping
    public Customer get(String id){
        return customerService.getCustomer(id);
    }

    @PostMapping
    public String create(Customer customer){
        return customerService.createCustomer(customer);
    }

}
