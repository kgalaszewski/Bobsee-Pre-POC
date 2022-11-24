using System.Text.Json.Serialization;

namespace Bobsee_Pre_POC.Data;

internal class User
{
    [JsonIgnore]
    public static User LoadedUser = null;

    public string Nickname { get; set; }

    public int Weight { get; set; }

    public int Height { get; set; }

    public int Age { get; set; }

    public Sex Sex { get; set; }

    public Diet Diet { get; set; }

    public Goal Goal { get; set; }

    public int DailyCaloriesLimit { get; set; }

    public string[] IntolerableProducts { get; set; }

    [JsonIgnore]
    public double BMI => Weight / Math.Pow(Height, 2);

    [JsonIgnore]
    public int CaloriesLeft => CalculateCaloriesLeft();

    public List<Meal> MealsEaten = new ();

    [JsonIgnore]
    public string Warning { get; set; }

    private int CalculateCaloriesLeft()
    {
        var caloriesEaten = MealsEaten.Sum(me => me.Calories);

        var caloriesLeft = DailyCaloriesLimit - caloriesEaten;

        if (caloriesLeft < 0)
        {
            Warning = "You have no calories left. You ate too much.";
        }

        return caloriesLeft;
    }
}
