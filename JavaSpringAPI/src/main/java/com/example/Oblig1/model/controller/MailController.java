package com.example.Oblig1.model.controller;

import com.example.Oblig1.model.Mail;
import com.example.Oblig1.model.MyDTO;
import com.example.Oblig1.service.MailService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@CrossOrigin(origins = "http://localhost:8080")
@RestController //Helps us retrieve objects in the form of JSON and sends it as an HTTP response.
@RequestMapping("/api/mail") //Defines this path as the base path for all endpoints with the controller.
public class MailController {
    private final MailService mailService;

    @Autowired //Automatically injects the required dependency to this component.
    public MailController(MailService mailService) {
        this.mailService = mailService;
    }

    @GetMapping("/{id}") //Simplifies the way we retrieve resources. In this instance we are trying to retrieve
    // Mail with a certain ID.
    public Mail getMailById(@PathVariable Long id) {
        return mailService.getMailById(id);
    }

    @GetMapping //Here we do not specify a set of data besides what type of resource we want to retrieve.
    // This lets us retrieve all mails, no matter what ID, subject or from/toEmail it contains.
    public List<Mail> getAllMails() {
        return mailService.getAllMails();
    }

    @GetMapping("/from/{from}") //Same as with the @GetMapping("/{id}"), this retrieves mail from a specific person.
    public List<Mail> getAllFromMail(@PathVariable String from) {
        return mailService.getAllFromEmail(from);
    }

    @GetMapping("/to/{to}")
    public List<Mail> getAllToMail(@PathVariable String to) {
        return mailService.getAllToEmail(to);
    }

    @PostMapping //Allows us to create new mail posts to insert into the database.
    public void addMail(@RequestBody Mail mail) {
        mailService.saveMail(mail);
    }

    @PutMapping// Allows us to change the mail information.
    public Mail editMail(@RequestBody Mail newMail) {
        return mailService.editMail(newMail);
    }

    @DeleteMapping("/{id}") //Opposite of the PostMapping, this one allows us to delete posts with a specific ID.
    public void deleteMail(@PathVariable Long id) {
        mailService.deleteMail(id);
    }

    @GetMapping("/dto") //Data Transfer Object turning multiple requests into one call to minimize traffic and
    // reduce network round-trip costs and time.
    public List<MyDTO> getAllDTOs() {
        return mailService.getAllDTOs();
    }

    @GetMapping("/domain/{domain}") //Takes a domain URL using the @PathVariable. It can be used as a way to filter
    // out those having the same domain name in their email address. For example, alice@example.com uses example.com
    // as their domain.
    public List<Mail> getAllFromDomain(@PathVariable String domain) {
        return mailService.getMailsByDomain(domain);
    }

    @GetMapping("/search") // Through this endpoint, we can search through a database for mails containing
    // a certain subject name or content.
    public List<Mail> searchMails(@RequestParam String content, @RequestParam String subject) {
        return mailService.findMailByContentContainingAndSubjectContains(content, subject);
    }
}