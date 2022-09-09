package com.labs.lab2;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.context.annotation.ComponentScan;

@ComponentScan
@EnableAutoConfiguration
public class Lab2Application {

    public static void main(String[] args) {
        SpringApplication app = new SpringApplicationBuilder(Lab2Application.class).build();
        app.run(args);
    }

}
