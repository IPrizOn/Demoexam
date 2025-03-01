namespace DemoexamGUI.AppData
{
    public class StringCheck
    {
        public static bool IsIntNotNegative(string rating)
        {
            if (uint.TryParse(rating, out uint number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
