package com.example.Oblig1.model;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@Entity
// Constructor for the mail object
@Table(name = "mail")
public class Mail {
    // Creates an automated ID. It takes the highest ID used in the database table and creates a higher value.
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO) // auto inc. key
    private Long id;
    // Maps the variable fromEmail to the table column "from_email" using the @Column annotations
    @Column(name = "from_email")
    private String fromEmail;

    //All of the other column mappings are the same as the column mapping above.
    @Column(name = "to_email")
    private String toEmail;

    @Column(name = "subject")
    private String subject;

    @Column(name = "body")
    private String content;

    @Column(name = "time_sent")
    private String timeSent;
}