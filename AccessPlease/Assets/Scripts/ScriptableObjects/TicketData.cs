using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTicket", menuName = "ActiveDirectoryGame/Ticket Data")]
public class TicketData : ScriptableObject
{
    [Header("Powi¹zany Pracownik")]
    public EmployeeData employee;

    [Header("Stan Pocz¹tkowy AD")]
    [Tooltip("Uprawnienia, które pracownik MA w momencie wziêcia ticketa. Te checkboxy bêd¹ domyœlnie zaznaczone.")]
    public List<SecurityGroup> startingGroups;

    [Header("Treœæ Wniosku")]
    [TextArea(3, 5)]
    public string requestMessage;
    public string authorizedBy;

    [Header("Punktacja")]
    public int correctScore = 100;
    public int underPrivilegedPenalty = -50;
    public int overPrivilegedPenalty = -200;

    [Header("Konsekwencje (Pop-upy)")]
    [TextArea(2, 3)]
    public string underPrivilegedPopUp = "Hej IT! Dalej nie mam dostêpu, praca stoi!";
    [TextArea(2, 3)]
    public string overPrivilegedPopUp = "Wow, mam teraz dostêp do listy p³ac zarz¹du. Fajnie!";
}