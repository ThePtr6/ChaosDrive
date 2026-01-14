using System.Collections.Generic;

[System.Serializable]
public class CarListWrapper
{
    public List<CarData> cars;

    public CarListWrapper(List<CarData> cars)
    {
        this.cars = cars;
    }
}