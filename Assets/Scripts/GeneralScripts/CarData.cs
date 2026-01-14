using System;
using System.Reflection;
using JetBrains.Annotations;
using System.Collections.Generic;


[System.Serializable]
public class CarData
{
    public bool selected; public bool status;
    public int position;
    public string name;


    public int fuel;
    public int fuelUnlockedLevel;
    public int fuelCurrentLevel;
    public int fuelMaxLevel;
    public int fuelUpgradePerLevel;
    public int fuelPrice;
    public float fuelUpgradePriceMultiplier;


    public int fuelConsumption;
    public int fuelConsumptionUnlockedLevel;
    public int fuelConsumptionCurrentLevel;
    public int fuelConsumptionMaxLevel;
    public int fuelConsumptionUpgradePerLevel;
    public int fuelConsumptionPrice;
    public float fuelConsumptionUpgradePriceMultiplier;


    public int power;
    public int powerUnlockedLevel;
    public int powerCurrentLevel;
    public int powerMaxLevel;
    public int powerUpgradePerLevel;
    public int powerPrice;
    public float powerUpgradePriceMultiplier;


    public int maxSpeed;
    public int maxSpeedUnlockedLevel;
    public int maxSpeedCurrentLevel;
    public int maxSpeedMaxLevel;
    public int maxSpeedUpgradePerLevel;
    public int maxSpeedPrice;
    public float maxSpeedUpgradePriceMultiplier;


    public float turningAngle;
    public int turningAngleUnlockedLevel;
    public int turningAngleCurrentLevel;
    public int turningAngleMaxLevel;
    public float turningAngleUpgradePerLevel;
    public int turningAnglePrice;
    public float turningAngleUpgradePriceMultiplier;
    public int price;

    public List<ColorData> colorsCars;



    public CarData(bool selected,  bool status,
     int position,
     string name,
     int fuel,
     int fuelUnlockedLevel,
     int fuelCurrentLevel,
     int fuelMaxLevel,
     int fuelUpgradePerLevel,
     int fuelPrice,
     float fuelUpgradePriceMultiplier,
     int fuelConsumption,
     int fuelConsumptionUnlockedLevel,
     int fuelConsumptionCurrentLevel,
     int fuelConsumptionMaxLevel,
     int fuelConsumptionUpgradePerLevel,
     int fuelConsumptionPrice,
     float fuelConsumptionUpgradePriceMultiplier,
     int power,
     int powerUnlockedLevel,
     int powerCurrentLevel,
     int powerMaxLevel,
     int powerUpgradePerLevel,
     int powerPrice,
     float powerUpgradePriceMultiplier,
     int maxSpeed,
     int maxSpeedUnlockedLevel,
     int maxSpeedCurrentLevel,
     int maxSpeedMaxLevel,
     int maxSpeedUpgradePerLevel,
     int maxSpeedPrice,
     float maxSpeedUpgradePriceMultiplier,
     float turningAngle,
     int turningAngleUnlockedLevel,
     int turningAngleCurrentLevel,
     int turningAngleMaxLevel,
     float turningAngleUpgradePerLevel,
     int turningAnglePrice,
     float turningAngleUpgradePriceMultiplier,
     int price,
     List<ColorData> colorsCars
     )
    {
        this.selected = selected;
        this.status = status;
        this.position = position;
        this.name = name;

        this.fuel = fuel;
        this.fuelUnlockedLevel = fuelUnlockedLevel;
        this.fuelCurrentLevel = fuelCurrentLevel;
        this.fuelMaxLevel = fuelMaxLevel;
        this.fuelUpgradePerLevel = fuelUpgradePerLevel;
        this.fuelPrice = fuelPrice;
        this.fuelUpgradePriceMultiplier = fuelUpgradePriceMultiplier;





        this.fuelConsumption = fuelConsumption;
        this.fuelConsumptionUnlockedLevel = fuelConsumptionUnlockedLevel;
        this.fuelConsumptionCurrentLevel = fuelConsumptionCurrentLevel;
        this.fuelConsumptionMaxLevel = fuelConsumptionMaxLevel;
        this.fuelConsumptionUpgradePerLevel = fuelConsumptionUpgradePerLevel;
        this.fuelConsumptionPrice = fuelConsumptionPrice;
        this.fuelConsumptionUpgradePriceMultiplier = fuelConsumptionUpgradePriceMultiplier;

        this.power = power;
        this.powerUnlockedLevel = powerUnlockedLevel;
        this.powerCurrentLevel = powerCurrentLevel;
        this.powerMaxLevel = powerMaxLevel;
        this.powerUpgradePerLevel = powerUpgradePerLevel;
        this.powerPrice = powerPrice;
        this.powerUpgradePriceMultiplier = powerUpgradePriceMultiplier;


        this.maxSpeed = maxSpeed;
        this.maxSpeedUnlockedLevel = maxSpeedUnlockedLevel;
        this.maxSpeedCurrentLevel = maxSpeedCurrentLevel;
        this.maxSpeedMaxLevel = maxSpeedMaxLevel;
        this.maxSpeedUpgradePerLevel = maxSpeedUpgradePerLevel;
        this.maxSpeedPrice = maxSpeedPrice;
        this.maxSpeedUpgradePriceMultiplier = maxSpeedUpgradePriceMultiplier;

        this.turningAngle = turningAngle;
        this.turningAngleUnlockedLevel = turningAngleUnlockedLevel;
        this.turningAngleCurrentLevel = turningAngleCurrentLevel;
        this.turningAngleMaxLevel = turningAngleMaxLevel;
        this.turningAngleUpgradePerLevel = turningAngleUpgradePerLevel;
        this.turningAngleUpgradePriceMultiplier = turningAngleUpgradePriceMultiplier;
        this.turningAnglePrice = turningAnglePrice;
    

        this.price = price;
        this.colorsCars = colorsCars ?? new List<ColorData>();


    }

    
    
}