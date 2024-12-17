  public class RandomColor : MonoBehaviour
  {   
      public static void GenerateColor(int minRed, int maxRed, int minGreen, int maxGreen, int minBlue, int maxBlue) 
      { 
          System.Random random = new System.Random();

          for (int i = 0; i < count; i + +)
          {
              int red = random.Next(minRed, maxRed + 1); 
              int green = random.Next(minGreen, maxGreen + 1); 
              int blue = random.Next(minBlue, maxBlue + 1); 
  
              Color randomColor = Color.FromArgb(red, green, blue); 
            
              if (renderer != null) 
              {
                  renderer.material.color = randomColor;
          }

      public static void Main()
      {
          GeneratorColor(50, 200, 100, 255, 0, 150);
      }
}

List<Color> randomColors = new List<Color>();
randomColors.Add(randomColor);

Console.WriteLine("Here is the list of colors that were generated so far: ");
foreach (Color color in randomColors)
{
    Console.WriteLine(color);
}

  
