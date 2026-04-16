using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public AudioSource notification;
    public SetAminationParameters ticket;
    public Button submitButton;

    [Header("Panele")]
    public GameObject ouTreePanel;
    public GameObject permissionsPanel;

    [Header("Elementy Ticketa")]
    public TextMeshProUGUI ticketNameText;
    public TextMeshProUGUI ticketJobText;
    public TextMeshProUGUI ticketMessageText;
    public TextMeshProUGUI ticketIdText;
    public Image ticketAvatar;

    [Header("Elementy Panelu Uprawnieñ")]
    public TextMeshProUGUI wrongFolderWarningText;
    public GameObject togglesContainer;

    [Header("Pop-up System")]
    public GameObject popupPanel;
    public TextMeshProUGUI popupTitle;
    public TextMeshProUGUI popupMessage;

    [Header("System Audytu")]
    public GameObject auditPanel;
    public Transform auditContentParent;
    public GameObject auditRowPrefab;
    public TextMeshProUGUI finalScoreText;
    public Color goodColor = new Color(0.2f, 0.8f, 0.2f, 1f);
    public Color wrongColor = new Color(0.8f, 0.2f, 0.2f, 1f);

    private TicketData activeTicket;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    public void UpdateTicketUI(TicketData newTicket)
    {
        notification.Play();
        ticket.changeBool();

        activeTicket = newTicket;
        ticketNameText.text = $"{newTicket.employee.firstName} {newTicket.employee.lastName}";
        ticketJobText.text = newTicket.employee.jobTitle;
        ticketMessageText.text = newTicket.requestMessage;
        ticketIdText.text = newTicket.employee.employeeID;
        ticketAvatar.sprite = newTicket.employee.avatar;
    }

    public void OnFolderClicked(Department clickedDept)
    {
        ouTreePanel.SetActive(false);
        permissionsPanel.SetActive(true);

        if (activeTicket.employee.department == clickedDept)
        {
            submitButton.interactable = true;
            wrongFolderWarningText.gameObject.SetActive(false);
            SetTogglesState(true);
            LoadTogglesForTicket(activeTicket);
        }
        else
        {
            submitButton.interactable = false;
            wrongFolderWarningText.gameObject.SetActive(true);
            wrongFolderWarningText.text = $"B£¥D: U¿ytkownik nale¿y do dzia³u {activeTicket.employee.department}, a nie {clickedDept}!";
            SetTogglesState(false);
            ClearAllToggles();
        }
    }

    private void SetTogglesState(bool isInteractable)
    {
        Toggle[] allToggles = togglesContainer.GetComponentsInChildren<Toggle>();
        foreach (Toggle t in allToggles)
        {
            t.interactable = isInteractable;
        }
    }

    private void ClearAllToggles()
    {
        Toggle[] allToggles = togglesContainer.GetComponentsInChildren<Toggle>();
        foreach (Toggle t in allToggles)
        {
            t.isOn = false;
        }
    }

    public void ReturnToTree()
    {
        permissionsPanel.SetActive(false);
        ouTreePanel.SetActive(true);
    }

    public void ConfirmPermissions()
    {
        List<SecurityGroup> selectedGroups = new List<SecurityGroup>();
        Toggle[] allToggles = togglesContainer.GetComponentsInChildren<Toggle>();

        foreach (Toggle t in allToggles)
        {
            if (t.isOn)
            {
                TextMeshProUGUI label = t.GetComponentInChildren<TextMeshProUGUI>();
                if (label != null)
                {
                    string groupName = label.text.Trim();
                    if (System.Enum.TryParse(groupName, out SecurityGroup parsedGroup))
                    {
                        selectedGroups.Add(parsedGroup);
                    }
                }
            }
        }

        GameManager.Instance.ProcessTicket(selectedGroups);
    }

    public void TriggerDelayedPopup(string senderName, string message)
    {
        StartCoroutine(ShowPopupRoutine(senderName, message));
    }

    private IEnumerator ShowPopupRoutine(string senderName, string message)
    {
        float randomDelay = Random.Range(1f, 3f);
        yield return new WaitForSeconds(randomDelay);

        popupPanel.SetActive(true);
        notification.Play();
        if (message[0] == 'A') {
            senderName = "AUDYT";
            message = message.Substring(1);
        }
        popupTitle.text = $"Wiadomoœæ od: {senderName}";
        popupMessage.text = message;
    }

    public void ShowAuditPanel(List<GameManager.ProcessedTicket> log, int finalScore)
    {
        auditPanel.SetActive(true);
        finalScoreText.text = $"{finalScore}";

        foreach (Transform child in auditContentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var entry in log)
        {
            GameObject row = Instantiate(auditRowPrefab, auditContentParent);
            TextMeshProUGUI text = row.GetComponent<TextMeshProUGUI>();

            string sign = entry.scoreDelta > 0 ? "+" : "";

            text.text = $"{entry.ticket.employee.firstName} {entry.ticket.employee.lastName}";
            text.text += ", " + entry.ticket.employee.jobTitle;
            text.text += ", " + entry.status;
            text.text += $" ({sign}{entry.scoreDelta} pkt)";

            if (entry.status == "Zgodne z polityk¹")
            {
                text.color = goodColor;
            }
            else
            {
                text.color = wrongColor;
            }
        }
    }

    private void LoadTogglesForTicket(TicketData ticket)
    {
        Toggle[] allToggles = togglesContainer.GetComponentsInChildren<Toggle>();

        foreach (Toggle t in allToggles)
        {
            TextMeshProUGUI label = t.GetComponentInChildren<TextMeshProUGUI>();

            if (label != null)
            {
                string groupName = label.text.Trim();

                if (System.Enum.TryParse(groupName, out SecurityGroup parsedGroup))
                {
                    t.isOn = ticket.startingGroups.Contains(parsedGroup);
                }
            }
        }
    }
}