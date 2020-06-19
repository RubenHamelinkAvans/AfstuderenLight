package com.avans.customerservice.unit;

import com.avans.customerservice.domain.Customer;
import com.avans.customerservice.repositories.CustomerRepository;
import com.avans.customerservice.repositories.DefaultCustomerRepository;
import org.assertj.core.util.Strings;
import org.junit.jupiter.api.Test;
import org.springframework.util.Assert;
import org.springframework.util.StringUtils;

public class DefaultCustomerRepositoryTests {

    private DefaultCustomerRepository customerRepository;
    private String existingId;

    public DefaultCustomerRepositoryTests() {
        customerRepository = new DefaultCustomerRepository();
        existingId = customerRepository.createCustomer(new Customer("test"));
    }

    @Test
    public void CreateCustomerSuccess() {
        String id = customerRepository.createCustomer(new Customer("testName"));
        assert !Strings.isNullOrEmpty(id);
    }


    @Test
    public void CreateCustomerExisting() {
        // given id doesn't matter as the order is assigned a new id
        String id = customerRepository.createCustomer(new Customer("existing", "testName"));
        assert !Strings.isNullOrEmpty(id);
    }

    @Test
    public void GetCustomerExisting() {
        Customer customer = customerRepository.getCustomer(existingId);
        assert "test".equals(customer.getName());
    }

    @Test
    public void GetCustomerNonExisting() {
        Customer customer = customerRepository.getCustomer("non-existent");
        assert customer == null;
    }

}
