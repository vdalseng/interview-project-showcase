package com.example.Oblig1.repository;

import com.example.Oblig1.model.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;
public interface UserRepository extends JpaRepository<User, Long> {

    // This query fetches all users based on their domain used in their email address.
    @Query(value="SELECT * FROM users WHERE email LIKE %:domain", nativeQuery=true)
    List<User> getUsersByDomain(String domain);
}
