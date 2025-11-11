package com.example.Oblig1.model;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@Entity
// Constructor for the user object
@Table(name = "users")
public class User {
    // Automatically generates the next ID based on the highest existing ID in the database.
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO) // auto inc. key
    private Long id;

    // Maps the variable username to the table column “username” using the @Column annotations. Same with the other
    // column mappings.
    @Column(name = "username")
    private String username;

    @Column(name = "email")
    private String email;

    @Column(name = "password")
    private String password;
}