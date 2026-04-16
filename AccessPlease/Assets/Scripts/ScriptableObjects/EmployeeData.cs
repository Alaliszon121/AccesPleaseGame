using UnityEngine;

[CreateAssetMenu(fileName = "NewEmployee", menuName = "ActiveDirectoryGame/Employee Data")]
public class EmployeeData : ScriptableObject
{
    [Header("Dane Personalne")]
    public string firstName;
    public string lastName;
    public string employeeID;
    public Sprite avatar;

    [Header("Pozycja w firmie")]
    public Department department;
    public string jobTitle;
}