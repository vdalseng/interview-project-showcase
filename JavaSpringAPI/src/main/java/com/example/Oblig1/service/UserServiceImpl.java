package com.example.Oblig1.service;

import com.example.Oblig1.model.User;
import com.example.Oblig1.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class UserServiceImpl implements UserService {

    private final UserRepository userRepository;

    @Autowired
    public UserServiceImpl(UserRepository userRepository) {
        this.userRepository = userRepository;
    }
    @Override // Retrieves a user by ID or null if not found
    public User getUserById(Long id) {
        Optional<User> optionalProduct = userRepository.findById(id);
        return optionalProduct.orElse(null);
    }

    @Override // Works as an insert for new users on the database.
    public void saveUser(User user) {
        userRepository.save(user);
    }

    @Override // Lets us edit existing users and returns the updated user.
    public User editUser(User newUser) {
        Optional<User> optionalUser = userRepository.findById(newUser.getId());
        if (optionalUser.isPresent()) {
            User existingUser = optionalUser.get();
            existingUser.setId(newUser.getId());
            existingUser.setUsername(newUser.getUsername());
            existingUser.setEmail(newUser.getEmail());
            existingUser.setPassword(newUser.getPassword());
            return userRepository.save(existingUser);
        } else {
            // If the user does not exist, this RuntimeException will run instead.
            throw new RuntimeException("User not found with ID " + newUser.getId());
        }
    }

    @Override // Lets us delete the user by ID.
    public void deleteUser(Long id) {
        userRepository.deleteById(id);
    }

    @Override // Retrieves all users found in the table “users”.
    public List<User> getAllUsers() {
        return userRepository.findAll();
    }

    @Override // Retrieves users by their domain in their email addresses.
    public List<User> getUsersByDomain(String domain) {
        return userRepository.getUsersByDomain(domain);
    }
}
