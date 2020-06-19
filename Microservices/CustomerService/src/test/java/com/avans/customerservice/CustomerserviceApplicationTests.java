package com.avans.customerservice;

import com.avans.customerservice.controllers.CustomerController;
import com.avans.customerservice.domain.Customer;
import org.assertj.core.util.Strings;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
class CustomerserviceApplicationTests {

    @Autowired
    private CustomerController customerController;

    @Test
    void createCustomer() {
        String customerId = customerController.create(new Customer("test"));
        assert !Strings.isNullOrEmpty(customerId);
    }
    @Test
    void createAndGetCustomer() {
        String customerId = customerController.create(new Customer("testName"));

        Customer customer = customerController.get(customerId);

        assert customer.getName().equals("testName");
    }

}
