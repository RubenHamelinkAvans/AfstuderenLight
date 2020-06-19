package com.avans.customerservice.domain;

import lombok.Getter;
import lombok.Setter;

public class Customer {
    @Getter @Setter private String id;
    @Getter @Setter private String name;

    public Customer() {
    }

    public Customer(String name) {
        this.name = name;
    }

    public Customer(String id, String name) {
        this.id = id;
        this.name = name;
    }
}
