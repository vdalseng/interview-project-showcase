package com.example.Oblig1.repository;

import com.example.Oblig1.model.Mail;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface MailRepository extends JpaRepository<Mail, Long> {
    List<Mail> findAllByToEmail(String toEmail);
    List<Mail> findAllByFromEmail(String fromEmail);

    // This query fetches all rows in the database as long as it contains the words typed by the user.
    // The subject and content columns can be long sentences, but as long as a word, letter or symbol can be found in
    // the content or subject column, the row will be returned and put into a list.
    @Query(value="SELECT * FROM mail WHERE body LIKE %:content% OR subject LIKE %:subject%", nativeQuery = true)
    List<Mail> findMailByContentContainingAndSubjectContains(@Param("content") String content, @Param("subject")String subject);

    // This query fetches all mail written by users based on their domain used in their email address.
    @Query(value="SELECT * FROM mail WHERE from_email LIKE %:domain", nativeQuery=true)
    List<Mail> getMailsByDomain(String domain);
}