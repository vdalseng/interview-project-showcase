package com.example.Oblig1.service;

import com.example.Oblig1.model.Mail;
import com.example.Oblig1.model.MyDTO;
import com.example.Oblig1.repository.MailRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class MailServiceImpl implements MailService {
    private final MailRepository mailRepository;

    @Autowired
    public MailServiceImpl(MailRepository mailRepository) {
        this.mailRepository = mailRepository;
    }

    @Override // Retrieves a mail by its ID.
    public Mail getMailById(Long id) {
        Optional<Mail> optionalProduct = mailRepository.findById(id);
        return optionalProduct.orElse(null);
    }

    @Override // Saves newly written mail to the database.
    public void saveMail(Mail mail) {
        mailRepository.save(mail);
    }

    @Override // Lets us change already existing mail and returns the newly changed mail.
    public Mail editMail(Mail newMail) {
        Optional<Mail> optionalMail = mailRepository.findById(newMail.getId());
        if (optionalMail.isPresent()) {
            Mail existingMail = optionalMail.get();
            existingMail.setFromEmail(newMail.getFromEmail());
            existingMail.setToEmail(newMail.getToEmail());
            existingMail.setSubject(newMail.getSubject());
            existingMail.setContent(newMail.getContent());
            return mailRepository.save(existingMail);
        } else {
            // This Exception is executed if the ID does not exist.
            throw new RuntimeException("Mail not found with ID " + newMail.getId());
        }
    }

    @Override // Lets us delete mail from the database by ID.
    public void deleteMail(Long id) {
        mailRepository.deleteById(id);
    }

    @Override // Retrieves all mail found in the table "mail".
    public List<Mail> getAllMails() {
        return mailRepository.findAll();
    }

    @Override // Retrieves all mail sent by a specific user.
    public List<Mail> getAllFromEmail(String fromEmail) {
        return mailRepository.findAllByFromEmail(fromEmail);
    }

    @Override // Retrieves all mail received by a specific user.
    public List<Mail> getAllToEmail(String toEmail) {
        return mailRepository.findAllByToEmail(toEmail);
    }

    @Override
    public List<MyDTO> getAllDTOs() {
        ArrayList<MyDTO> myDTOS = new ArrayList<>();
        myDTOS.add(new MyDTO("n1", "l1"));
        myDTOS.add(new MyDTO("n2", "l2"));
        return myDTOS;
    }

    @Override // Retrieves mails by their email address domain.
    public List<Mail> getMailsByDomain(String domain) {
        return mailRepository.getMailsByDomain(domain);
    }

    @Override // Searches for mail containing specific words, letters or symbols in the content and subject columns
    // typed by the user. If fields are left empty, it will return every mail stored in the base.
    public List<Mail> findMailByContentContainingAndSubjectContains(String content, String subject) {
        return mailRepository.findMailByContentContainingAndSubjectContains(content, subject);
    }
}