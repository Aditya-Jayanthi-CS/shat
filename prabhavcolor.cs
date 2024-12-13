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
              Console.WriteLine($"Random color for maze walls: #{randomColor.R:X2}{randomColor.G:X2}{randomColor.B:X2}");

              if (renderer != null) 
              {
                  renderer.material.color = randomColor;
          }

      public static void Main()
      {
          GeneratorColor(50, 200, 100, 255, 0, 150);
      }
}

  
