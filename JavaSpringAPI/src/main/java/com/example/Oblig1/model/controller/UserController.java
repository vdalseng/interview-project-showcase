package com.example.Oblig1.model.controller;
import com.example.Oblig1.model.User;
import com.example.Oblig1.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@CrossOrigin(origins = "http://localhost:8080")
@RestController //Helps us retrieve objects in the form of JSON and sends it as an HTTP response.
@RequestMapping("/api/user") //Defines this path as the base path for all endpoints with the controller.
public class UserController {

    private final UserService userService;

    @Autowired //Automatically injects the required dependency to this component.
    public UserController(UserService userService) {
        this.userService = userService;
    }

    @GetMapping("/{id}") //Simplifies the way we retrieve resources. In this instance we are trying to retrieve
    // Mail with a certain ID.
    public User getUserById(@PathVariable Long id) {
        return userService.getUserById(id);
    }

    @GetMapping //Here we do not specify a set of data besides what type of resource we want to retrieve.
    // This lets us retrieve all mails, no matter what ID, subject or from/toEmail it contains.
    public List<User> getAllUsers() {
        return userService.getAllUsers();
    }

    @PostMapping //Allows us to create new mail posts to insert into the database.
    public void addUser(@RequestBody User user) {
        userService.saveUser(user);
    }

    @PutMapping // Allows us to change the users information.
    public User editUser(@RequestBody User newUser) {
        return userService.editUser(newUser);
    }

    @DeleteMapping("/{id}") //Opposite of the PostMapping, this one allows us to delete posts with a specific ID.
    public void deleteUser(@PathVariable Long id) {
        userService.deleteUser(id);
    }

    @GetMapping("/domain/{domain}") //Takes a domain URL using the @PathVariable. It can be used as a way to filter
    // out those having the same domain name in their email address. For example, alice@example.com uses example.com
    // as their domain.
    public List<User> getAllFromDomain(@PathVariable String domain) {
        return userService.getUsersByDomain(domain);
    }
}
