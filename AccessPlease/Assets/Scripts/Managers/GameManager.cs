using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int currentScore = 1000;
    public RolePermissions ruleBook;
    public List<TicketData> todaysTickets;
    private int currentTicketIndex = 0;

    public struct ProcessedTicket
    {
        public TicketData ticket;
        public List<SecurityGroup> grantedGroups;
        public string status;
        public int scoreDelta;
    }

    public List<ProcessedTicket> endOfDayLog = new List<ProcessedTicket>();

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        currentTicketIndex = 0;
        LoadNextTicket();
    }

    public void LoadNextTicket()
    {
        if (currentTicketIndex < todaysTickets.Count)
        {
            TicketData nextTicket = todaysTickets[currentTicketIndex];
            UIManager.Instance.UpdateTicketUI(nextTicket);
        }
        else
        {
            StartCoroutine(EndWorkday());
        }
    }

    public void CloseTheGame() { Application.Quit(); }
    public void ProcessTicket(List<SecurityGroup> selectedGroups)
    {
        StartCoroutine(ProcessTicketWithDelay(selectedGroups));
    }

    private IEnumerator ProcessTicketWithDelay(List<SecurityGroup> selectedGroups)
    {
        TicketData ticket = todaysTickets[currentTicketIndex];

        RoleRule expectedRule = ruleBook.companyRules.FirstOrDefault(
            r => r.jobTitle == ticket.employee.jobTitle && r.department == ticket.employee.department);

        List<SecurityGroup> requiredGroups = expectedRule.requiredGroups ?? new List<SecurityGroup>();

        bool hasOverPrivilege = selectedGroups.Except(requiredGroups).Any();
        bool hasUnderPrivilege = requiredGroups.Except(selectedGroups).Any();

        string finalStatus = "Zgodne z polityk¹";
        string popupMessage = "";
        int scoreDelta = 0;

        if (hasOverPrivilege)
        {
            finalStatus = "Over-privileging";
            scoreDelta = ticket.overPrivilegedPenalty;
            popupMessage = ticket.overPrivilegedPopUp;
        }
        else if (hasUnderPrivilege)
        {
            finalStatus = "Under-privileging";
            scoreDelta = ticket.underPrivilegedPenalty;
            popupMessage = ticket.underPrivilegedPopUp;
        }
        else
        {
            scoreDelta = ticket.correctScore;
        }

        currentScore += scoreDelta;

        endOfDayLog.Add(new ProcessedTicket
        {
            ticket = ticket,
            grantedGroups = new List<SecurityGroup>(selectedGroups),
            status = finalStatus,
            scoreDelta = scoreDelta
        });

        if (finalStatus != "Zgodne z polityk¹" && !string.IsNullOrEmpty(popupMessage))
        {
            UIManager.Instance.TriggerDelayedPopup(ticket.employee.firstName + " " + ticket.employee.lastName, popupMessage);
        }

        yield return new WaitForSeconds(1.5f);

        currentTicketIndex++;
        UIManager.Instance.ReturnToTree();
        LoadNextTicket();
    }

    private IEnumerator EndWorkday()
    {
        yield return new WaitForSeconds(3f);
        UIManager.Instance.ShowAuditPanel(endOfDayLog, currentScore);
    }
}