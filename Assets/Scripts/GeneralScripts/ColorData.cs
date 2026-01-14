using UnityEngine;

[System.Serializable]
public class ColorData 
{
    public string nameColor;               
    public int price;                  
    public bool status;                
    public bool mainColorStatus;
    public bool secondColorStatus;    
     
    
    public ColorData( string nameColor, int price, bool status, bool mainColorStatus, bool secondColorStatus)
    {
        this.nameColor = nameColor;
        this.price = price;
        this.status = status;
        this.mainColorStatus = mainColorStatus;
        this.secondColorStatus = secondColorStatus;
    }
}
