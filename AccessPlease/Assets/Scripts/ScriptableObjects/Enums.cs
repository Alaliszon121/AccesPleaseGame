using UnityEngine;

public enum SecurityGroup
{
    Brak,
    SG_AllStaff,         // Podstawa - logowanie do komputera i maila
    SG_Printers,         // Drukowanie
    SG_Finance_Read,     // Podgl¹d faktur i bud¿etu
    SG_Finance_Write,    // Edycja bud¿etu i przelewy
    SG_HR_Read,          // Podgl¹d akt pracowniczych
    SG_HR_Write,         // Zatrudnianie/zwalnianie
    SG_Production_Read,  // Plany techniczne
    SG_Production_Write, // Zarz¹dzanie produkcj¹
    SG_IoT_Config,       // Sterowniki maszyn (i ekspresu do kawy)
    SG_Security_Cameras, // Dostêp do kamer CCTV
    SG_IT_Admin,         // Lokalne serwery i backupy
    Domain_Admin         // W³adza absolutna (Z£Y POMYS£ DLA ZWYK£YCH LUDZI)
}

public enum Department
{
    Finanse,
    HR,
    IT,
    Zarzad,
    Produkcja,
    Inne
}