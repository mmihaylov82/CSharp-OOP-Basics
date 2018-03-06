public abstract class Food
{
    public Food(int foodQuantity)
    {
        this.FoodQuantity = foodQuantity;
    }

    public int FoodQuantity { get; protected set; }
}