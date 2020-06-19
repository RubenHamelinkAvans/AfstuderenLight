package com.avans.customerservice.repositories;

import com.avans.customerservice.domain.Customer;
import org.springframework.stereotype.Repository;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.UUID;

@Repository
public class DefaultCustomerRepository implements CustomerRepository {

    private ArrayList<Customer> customers;

    public DefaultCustomerRepository(){
        customers = new ArrayList<>();
        customers.add(new Customer("0", "Piet"));
        customers.add(new Customer("1", "Henk"));
        customers.add(new Customer("2", "Kees"));
    }

    @Override
    public Customer getCustomer(String id) {
        return customers.stream()
                .filter(c -> c.getId().equals(id))
                .findFirst()
                .orElse(null);
    }

    @Override
    public String createCustomer(Customer customer) {
        customer.setId(UUID.randomUUID().toString());
        customers.add(customer);
        return customer.getId();
    }
}
