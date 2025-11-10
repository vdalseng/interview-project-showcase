package com.example.Oblig1.service;

import com.example.Oblig1.model.User;
import java.util.List;

public interface UserService { // This interface defines a set of methods that other classes must adhere to.
    // The classes implementing this interface must apply the business logic.
    User getUserById(Long id);
    void saveUser(User user);
    User editUser(User newUser);
    void deleteUser(Long id);
    List<User> getAllUsers();

    List<User> getUsersByDomain(String domain);
}
