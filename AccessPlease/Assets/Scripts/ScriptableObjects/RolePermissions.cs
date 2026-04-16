using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct RoleRule
{
    public string jobTitle;
    public Department department;

    public List<SecurityGroup> requiredGroups;
}

[CreateAssetMenu(fileName = "CompanyRuleBook", menuName = "ActiveDirectoryGame/Rule Book")]
public class RolePermissions : ScriptableObject
{
    [Header("Matryca Uprawnieñ (Ksiêga Zasad)")]
    public List<RoleRule> companyRules = new List<RoleRule>();
}