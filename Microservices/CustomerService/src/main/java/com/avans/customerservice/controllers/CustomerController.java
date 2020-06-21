package com.avans.customerservice.controllers;

import com.avans.customerservice.domain.Customer;
import com.avans.customerservice.services.CustomerService;
import lombok.extern.slf4j.Slf4j;
import org.slf4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/Customer")
@Slf4j
public class CustomerController {

    private final CustomerService customerService;

    @Autowired
    public CustomerController(CustomerService customerService) {
        this.customerService = customerService;
    }

    @GetMapping
    public Customer get(String id){
        log.info("Getting customer information for " + id);
        return customerService.getCustomer(id);
    }

    @PostMapping
    public String create(Customer customer){
        log.info("Creating customer " + customer);
        return customerService.createCustomer(customer);
    }

}
