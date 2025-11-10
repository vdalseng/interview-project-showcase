package com.example.Oblig1.service;

import com.example.Oblig1.model.Mail;
import com.example.Oblig1.model.MyDTO;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface MailService {
    Mail getMailById(Long id);
    void saveMail(Mail mail);

    Mail editMail(Mail newMail);
    void deleteMail(Long id);
    List<Mail> getAllMails();

    List<Mail> getAllFromEmail(String fromEmail);
    List<Mail> getAllToEmail(String toEmail);

    List<MyDTO> getAllDTOs();
    List<Mail> getMailsByDomain(String domain);
    List<Mail> findMailByContentContainingAndSubjectContains(@Param("content") String content, @Param("subject")String subject);
}
